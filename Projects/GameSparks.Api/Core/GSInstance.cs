using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
	/// <summary>
	/// Represents a connection to the GameSparks backend. 
	/// This class connects the <see cref="IGSPlatform"/> implementation with the GameSparks backend. 
	/// </summary>
	public class GSInstance
	{

		private bool _paused = false;

		private String _sessionId = null;

		private LinkedList<GSRequest> _sendQueue = new LinkedList<GSRequest>();

		private LinkedList<GSRequest> _persistantQueue = new LinkedList<GSRequest>();

		private LinkedList<Action> _requestedActions = new LinkedList<Action>();

		private String _persistantQueueUserId;

		private List<GSConnection> _connections = new List<GSConnection>();

		private IGameSparksTimer _mainLoopTimer = null;

		private IGameSparksTimer _durableWriteTimer = null;
		private bool _durableQueueDirty = false;

		internal long _requestCounter = 0;

		/// <summary>
		/// Gets or sets the GS platform instance related to this GSInstance.
		/// </summary>
		/// <value>The GS platform.</value>
		public IGSPlatform GSPlatform { get; set; }

		private String _currentSocketUrl;

		private bool _ready = false;

		//Allow pausing of durable queues when switching players
		private bool _durableQueuePaused = false;
		private long _durableDrainTimer = 0;

		private int _currAttemptConnection = 0;
		private long _nextReconnect = 0;
		private static Random _random = new Random((int)(DateTime.Now.Ticks & 0xFFFFFFFF));

		private int _retryBase;
		private int _retryMax;
		private int _requestTimeout;
		private int _durableConcurrentRequests;
		private int _durableDrainInterval;
		private int _handshakeOffset;

		public GSInstance(string name)
		{
			DurableQueueRunning = false;

			Name = name;

			GSAllMessageTypes.RegisterAllMessageTypes();

			Instances.Add (Name, this);
		}

		#region named instances

		private static Dictionary<String, GSInstance> Instances = new Dictionary<string, GSInstance> ();

		public static IEnumerable<GSInstance> AllInstances { get { return Instances.Values; } }

		/// <summary>
		/// The name of this instance
		/// </summary>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Constructor. Creates a new connection to the GameSparks backend.
		/// </summary>
		/// <param name="name">Name of the instance. If an instance already exists with this name it will be returned </param>
		public static GSInstance GetInstance(string name)
		{

			if(Instances.ContainsKey(name)){
				return Instances[name];
			}

			GSInstance instance = new GSInstance (name);

			return instance;


		}

		#endregion

		#region public Properties
		/// <summary>
		/// True if a connection to the service is available for use. 
		/// </summary>
		public bool Available { get{ return _ready; } }


		/// <summary>
		/// True if a connection is available and the user is authenticated. 
		/// </summary>
		public bool Authenticated
		{
			get { return _ready && GSPlatform.AuthToken != null && !"0".Equals(GSPlatform.AuthToken); }
		}

		/// <summary>
		/// If set true the SDK will provide debug information via <see cref="IGSPlatform.DebugMsg"/>
		/// </summary>
		public bool TraceMessages
		{
			get;
			set;
		}

		#endregion

		#region DurableQueue

		public Action DurableQueueLoaded
		{
			get;
			set;
		}

		public Func<String, String> OnGameSparksNonce { 
			get;
			set;
		}

		/// <summary>
		/// Indicates if requests marked as durable will be sent when network is available. 
		/// </summary>
		public bool DurableQueueRunning
		{
			get;
			set;
		}

		/// <summary>
		/// A list with all requests marked as durable, which are not yet sent. 
		/// </summary>
		public List<GSRequest> DurableQueueEntries
		{
			get
			{
				var tempQueue = new List<GSRequest>();

				lock (_persistantQueue)
				{
					tempQueue = new List<GSRequest>(_persistantQueue);
				}
				return tempQueue;
			}
		}

		/// <summary>
		/// Removes a request from the durable queue. This will prevent the SDK from further trying to send this request. 
		/// </summary>
		/// <param name="requestToRemove"></param>
		/// <returns></returns>
		public bool RemoveDurableQueueEntry(GSRequest requestToRemove)
		{
			lock (_persistantQueue)
			{
				_durableQueueDirty = _persistantQueue.Remove(requestToRemove);

				return _durableQueueDirty;
			}
		}

		/// <summary>
		/// Whenever a request is sent it is added to a request queue. 
		/// Each request has its own time out. 
		/// This can used to determine how many requests are not yet sent or have not yet timed out. 
		/// </summary>
		public int RequestQueueCount
		{
			get
			{
				return _sendQueue == null ? 0 : _sendQueue.Count;
			}
		}

		public int RetryBase {
			get {
				return _retryBase;
			}
			set {
				if (value <= 0) {
					_retryBase = GS.RetryBase;
				} else {
					_retryBase = value;
				}
			}
		}

		public int RetryMax {
			get {
				return _retryMax;
			}
			set {
				if (value <= RetryBase) {
					_retryMax = GS.RetryMax;
				} else {
					_retryMax = value;
				}
			} 
		}

		public int RequestTimeout {
			get {
				return _requestTimeout;
			}
			set {
				if (value <= 0) {
					_requestTimeout = GS.RequestTimeout;
				} else {
					_requestTimeout = value;
				}
			}
		}

		public int DurableConcurrentRequests {
			get {
				return _durableConcurrentRequests;
			}
			set {
				if (value <= 0) {
					_durableConcurrentRequests = GS.DurableConcurrentRequests;
				} else {
					_durableConcurrentRequests = value;
				}
			}
		}

		public int DurableDrainInterval {
			get {
				return _durableDrainInterval;
			}
			set {
				if (value <= 0) {
					_durableDrainInterval = GS.DurableDrainInterval;
				} else {
					_durableDrainInterval = value;
				}
			} 
		}

		public int HandshakeOffset {
			get {
				return _handshakeOffset;
			}
			set {
				if (value <= 0) {
					_handshakeOffset = GS.HandshakeOffset;
				} else {
					_handshakeOffset = value;
				}
			}  
		}

		/// <summary>
		/// Callback which is triggered whenever the service becomes available or the connection to the service is lost. 
		/// </summary>
		public Action<bool> GameSparksAvailable
		{
			get;
			set;
		}

		/// <summary>
		/// Callback which is triggered whenever authenticated player changes. 
		/// </summary>
		public Action<string> GameSparksAuthenticated
		{
			get;
			set;
		}

		#endregion


		#region public lifecycle Methods

		/// <summary>
		/// Initialise GameSparks with a given platform implementation. 
		/// </summary>
		public void Initialise(IGSPlatform platform)
		{
			GSPlatform = platform;

			_paused = false;

			RetryBase = GS.RetryBase;
			RetryMax = GS.RetryMax;
			RequestTimeout = GS.RequestTimeout;
			DurableConcurrentRequests = GS.DurableConcurrentRequests;
			DurableDrainInterval = GS.DurableDrainInterval;
			HandshakeOffset = GS.HandshakeOffset;

			InitialisePersistentQueue ();

			DurableQueueRunning = true;

			_currentSocketUrl = BuildServiceUrl(GSPlatform);

			lock (_connections)
			{
				_connections.Add(new GSConnection(this, GSPlatform, _currentSocketUrl));
			}

			CalcNewReconnectionTimeout (1);

            InitAllTimers();
		}

        private void InitAllTimers()
        {
            if (_mainLoopTimer != null)
            {
                _mainLoopTimer.Stop();
                _mainLoopTimer = null;
            }

            _mainLoopTimer = GSPlatform.GetTimer();
            _mainLoopTimer.Initialize(1000 / 60, ProcessQueues);

            if (_durableWriteTimer != null)
            {
                _durableWriteTimer.Stop();
                _durableWriteTimer = null;
            }

            _durableWriteTimer = GSPlatform.GetTimer();
			_durableWriteTimer.Initialize(1000 / 60, WriteDurableQueueIfDirty);
        }

		/// <summary>
		/// Shutdown and call the onDone callback when the shutdown is complete. 
		/// </summary>
		public void ShutDown(System.Action onDone)
		{    
            if (Instances.Values.Contains(this))
			{
				Instances.Remove(Name);
			}

			if (GSPlatform == null)
			{
				// If no platform is set, then we were never initialised. We can just return here. 
				return;
			}
			// we don't care about the response but to clean up properly we wait for it. 
			EndSessionRequest r = new EndSessionRequest(this);

			r.Send((response) =>
			{
				if (_mainLoopTimer != null)
				{
					_mainLoopTimer.Stop();
					_mainLoopTimer = null;
				}

				if (_durableWriteTimer != null)
				{
					_durableWriteTimer.Stop();
					_durableWriteTimer = null;
				}
						
				_paused = true;

				Stop(true);

				if (onDone != null)
				{
					onDone();
				}
			});
			
			if (Instances.ContainsKey(Name))
			{
				Instances.Remove(Name);
			}
		}

		/// <summary>
		/// Reconnect to the GameSparks service. 
		/// </summary>
		public void Reconnect()
		{
            InitAllTimers();      

            //Wierd situation where system clock has changed
            if (Math.Abs(_nextReconnect - DateTime.Now.Ticks) > TimeSpan.TicksPerSecond)
			{
				_nextReconnect = 0;
			}

			_paused = false;

			AddRequestedAction (() => {
				ConnectIfRequired ();
			});
		}

		/// <summary>
		/// Stops all connections. 
		/// </summary>
		public void Disconnect()
		{
			_paused = true;

			AddRequestedAction (() => {
				Stop (false);
			});
		}

		/// <summary>
		/// Stops all connections, resets the authentication token and establishes a new connection to the service. 
		/// </summary>
		public void Reset()
		{
			AddRequestedAction (() => {
				Stop (false);

				_sessionId = null;

				GSPlatform.ExecuteOnMainThread(()=>{
					GSPlatform.AuthToken = "0";
					GSPlatform.UserId = "";
				});

				ConnectIfRequired ();
			});
		}

		#region WebSocket Callbacks

		internal void WebSocketClient_OnError(String errorMessage, GSConnection connection)
		{
			if (errorMessage.Contains("INVALID LOCATION")) {
				Disconnect ();
			} else if (errorMessage.Contains("UNKNOWN SERVICE")) {
				GSPlatform.DebugMsg ("ERROR: UNKNOWN SERVICE");

				Disconnect ();
			}

			_currentSocketUrl = BuildServiceUrl(GSPlatform);

			if (TraceMessages) {
				GSPlatform.DebugMsg ("ERROR:" + errorMessage);
			}
		}

		internal void OnMessageReceived(String message, GSConnection connection)
		{
			GSPlatform.DebugMsg("RECV:" + message);

			GSObject response = GSObject.FromJson(message);

			if (response.ContainsKey("connectUrl"))
			{
				_currentSocketUrl = response.GetString("connectUrl");

				connection.Stop();

				CalcNewReconnectionTimeout (0);

				NewConnection();
			}

			if (response.ContainsKey("authToken"))
			{
				GSPlatform.ExecuteOnMainThread(() =>
					{
						GSPlatform.AuthToken = response.GetString("authToken");
					});
			}

			if (response.Type != null)
			{
				if (".AuthenticatedConnectResponse".Equals(response.Type))
				{
					Handshake(response, connection);
				}
				else
				{
					ProcessReceivedItem(response, connection);
				}
			}
		}

		private void Handshake(GSObject response, GSConnection connection)
		{
			if (response.ContainsKey("error"))
			{
				GSPlatform.DebugMsg(response.GetString("error"));

				ShutDown(null);
			}
			else if (response.ContainsKey("nonce"))
			{
				SendHandshake(response, connection);
			}
			else
			{
				if (response.ContainsKey("sessionId"))
				{
					_sessionId = response.GetString("sessionId");

					connection.SessionId = _sessionId;

					if (response.ContainsKey("authToken"))
					{
						GSPlatform.ExecuteOnMainThread(() =>
							{
								GSPlatform.AuthToken = response.GetString("authToken");
							});
					}
					else
					{
						GSPlatform.ExecuteOnMainThread(() =>
							{
								GSPlatform.AuthToken = "0";
								GSPlatform.UserId = "";
							});
					}

					if (response.ContainsKey ("clientConfig")) {
						GSData clientConfig = response.GetGSData ("clientConfig");

						RetryBase = clientConfig.GetInt ("retryBase").GetValueOrDefault (GS.RetryBase);
						RetryMax = clientConfig.GetInt ("retryMax").GetValueOrDefault (GS.RetryMax);
						RequestTimeout = clientConfig.GetInt ("requestTimeout").GetValueOrDefault (GS.RequestTimeout);
						DurableConcurrentRequests = clientConfig.GetInt ("durableConcurrentRequests").GetValueOrDefault (GS.DurableConcurrentRequests);
						DurableDrainInterval = clientConfig.GetInt ("durableDrainInterval").GetValueOrDefault (GS.DurableDrainInterval);
						HandshakeOffset = clientConfig.GetInt ("handshakeOffset").GetValueOrDefault (GS.HandshakeOffset);
					} else {
						RetryBase = GS.RetryBase;
						RetryMax = GS.RetryMax;
						RequestTimeout = GS.RequestTimeout;
						DurableConcurrentRequests = GS.DurableConcurrentRequests;
						DurableDrainInterval = GS.DurableDrainInterval;
						HandshakeOffset = GS.HandshakeOffset;
					}

					//We want availability to be triggered before authenticated
					GSPlatform.DebugMsg("Available");

					connection.Ready = true;

					setAvailability(true);

					if(response.ContainsKey("userId"))
					{
						SetUserId(response.GetString("userId"));
					}

					CalcNewReconnectionTimeout (0);
				}
			}
		}

		private void SendHandshake(GSObject response, GSConnection connection)
		{
			GSRequest handshakeRequest = new GSRequest(this, "AuthenticatedConnectRequest");

			if (OnGameSparksNonce != null) {
				handshakeRequest.AddString ("hmac", OnGameSparksNonce (response.GetString ("nonce")));
			} else {
				handshakeRequest.AddString ("hmac", GSPlatform.MakeHmac (response.GetString ("nonce"), GSPlatform.ApiSecret));
			}

			handshakeRequest.AddString("os", GSPlatform.DeviceOS);
			handshakeRequest.AddString("platform", GSPlatform.Platform);
			handshakeRequest.AddString("deviceId", GSPlatform.DeviceId);

			if (GSPlatform.AuthToken != null && !GSPlatform.AuthToken.Equals("0"))
			{
				handshakeRequest.AddString("authToken", GSPlatform.AuthToken);
			}

			if (_sessionId != null)
			{
				handshakeRequest.AddString("sessionId", _sessionId);
			}

			connection.SendImmediate(handshakeRequest);
		}

		#endregion



		/// <summary>
		/// Send the given request. 
		/// </summary>
		public void Send(GSRequest request)
		{
			AddRequestedAction (() => {
				if (request.Durable) {
					SendDurable (request);

					return;
				}

				lock (_connections) {
					if (_connections.Count == 0) {
						NewConnection ();
					}
				}
					
				request.WaitForResponseTicks = DateTime.Now.AddMilliseconds(request.GetResponseTimeout()).Ticks;

				lock (_sendQueue) {
					_sendQueue.AddLast (request);
				}
			});
		}

		#endregion

		#region private methods

		internal void AddRequestedAction(Action action){
			lock (_requestedActions) {
				_requestedActions.AddLast (action);
			}
		}

		private void ExecuteRequestedActions(){
			lock (_requestedActions) {
				var node = _requestedActions.First;

				while (node != null) {
					var nextNode = node.Next;

					node.Value ();

					_requestedActions.Remove(node);

					node = nextNode;
				}
			}
		}

		private void setAvailability(bool avail)
		{
			if (_ready != avail)
			{
				_ready = avail;

				if (GameSparksAvailable != null)
				{
					GSPlatform.ExecuteOnMainThread(() =>
						{
							GameSparksAvailable(avail);
						});
				}
			}
		}

		private void ProcessQueues()
		{
			try
			{
				ExecuteRequestedActions();
				ConnectIfRequired();
				TrimOldConnections();
				ProcessPersistantQueue();
				ProcessSendQueue();
				ProcessPendingQueue();
			}
			catch (Exception e)
			{
				GSPlatform.ExecuteOnMainThread(() =>
					{
						if (TraceMessages) {
							GSPlatform.DebugMsg(e.ToString());
						}
					});
			}
		}

		private void TrimOldConnections()
		{
			List<GSConnection> connectionsToCheck = null;

			lock (_connections) {
				connectionsToCheck = new List<GSConnection> (_connections);
			}

			foreach (GSConnection connection in connectionsToCheck)
			{
				if (connection.PendingRequestCount == 0 && connection._stopped)
				{
					lock (_connections) {
						_connections.Remove (connection);
					}

					connection.Close();

					if (TraceMessages)
						GSPlatform.DebugMsg("REMOVING CONNECTION");
				}
			}
		}

		private void ProcessPendingQueue()
		{
			List<GSConnection> connectionsToCheck = null;

			lock (_connections) {
				connectionsToCheck = new List<GSConnection> (_connections);
			}

			foreach (GSConnection connection in connectionsToCheck)
			{
				foreach (KeyValuePair<string, GSRequest> entry in connection.PendingRequestCopy)
				{
					if (entry.Value.WaitForResponseTicks < DateTime.Now.Ticks)
					{
						CancelRequest(connection, entry.Value);
					}
				}
			}
		}

		private void CancelRequest(GSRequest request)
		{
			if (request.Durable)
			{
				return;
			}

			GSObject error = new GSObject("ClientError");

			error.AddObject("error", new GSRequestData().AddString("error", "timeout"));
			error.AddString("requestId", request.GetString("requestId"));

			GSPlatform.ExecuteOnMainThread(() =>
				{
					try
					{
						request.Complete(this, error);
					}
					catch (Exception e)
					{
						GSPlatform.DebugMsg(e.ToString());
					}
				});
		}

		private void CancelRequest(GSConnection connection, GSRequest request)
		{
			/*if (request.Durable)
			{
				return;
			}*/

			GSObject error = new GSObject("ClientError");

			error.AddObject("error", new GSRequestData().AddString("error", "timeout"));
			error.AddString("requestId", request.GetString("requestId"));

			ProcessReceivedResponse(error, connection);
		}

		private void ProcessReceivedItem(GSObject response, GSConnection connection)
		{
			string theType = response.Type;

			if (theType.EndsWith("Response"))
			{
				if (theType.Equals(".AuthenticationResponse"))
				{
					SetUserId(response.GetString("userId"));
				}

				ProcessReceivedResponse(response, connection);
			}
			else if (theType.EndsWith("Message"))
			{
				GSPlatform.ExecuteOnMainThread(() =>
					{
						try
						{
							GSMessageHandler.HandleMessage(this, response);
						}
						catch (Exception e)
						{
							GSPlatform.DebugMsg(e.ToString());
						}
					});
			}
		}

		private void InitialisePersistentQueue()
		{
			if (_persistantQueueUserId == GSPlatform.UserId) {
				return;
			}

			_durableQueuePaused = true;

			LinkedList<GSRequest> queue = new LinkedList<GSRequest>();

			if (GSPlatform.PersistentDataPath != null)
			{
				queue = QueuePersistor.Read(this);
			}

			if (_persistantQueue != null)
			{
				lock (_persistantQueue)
				{
					_persistantQueue = queue;
				}
			}
			else
			{
				_persistantQueue = queue;
			}

			_persistantQueueUserId = GSPlatform.UserId;

			if (DurableQueueLoaded != null) {
				DurableQueueLoaded ();
			}

			_durableQueuePaused = false;

			Log("_persistantQueue COUNT : " + _persistantQueue.Count);
		}

		private void SetUserId(string userId)
		{
			// clear the pending durable requests for recent user. 
			Log("New UserId init persistent queue " + userId);

			bool previous_durableQueuePaused = _durableQueuePaused;

			//Temporarily stop durable queue processing
			_durableQueuePaused = true;

			//Execute the callback
			GSPlatform.ExecuteOnMainThread (() => {
				GSPlatform.UserId = userId;

				InitialisePersistentQueue();

				//We want this to be callback to the user code to allow them to make decisions 
				//about the queue before we start processing it, but after it's been initialised
				if(GameSparksAuthenticated != null) {
					GameSparksAuthenticated (userId);
				}

				//Resume queue processing.
				_durableQueuePaused = previous_durableQueuePaused;
			});
		}

		private void ProcessReceivedResponse(GSObject response, GSConnection connection)
		{
			String requestId = response.GetString("requestId");
			GSRequest request = connection.GetAndRemovePending(requestId);

			if (request == null) {
				return;
			}
				
			if (request.RequestExpiresAt > 0)
			{
				//It's durable request, if it's a ClientError do nothing as it will be retried
				if (response.ContainsKey("@class") && !response.GetString("@class").Equals("ClientError"))
				{
					_durableQueueDirty = _persistantQueue.Remove(request);

					request.Complete(this, response);
				}
			}
			else
			{
				request.Complete(this, response);
			}
		}

		private void ProcessPersistantQueue()
		{
			int numDurableRequestsProcessed = 0;

			if (!DurableQueueRunning || _durableQueuePaused || _persistantQueue.Count == 0 || _connections.Count == 0 || 
				!Available || _durableDrainTimer >= DateTime.Now.Ticks)
			{
				return;
			}
				
			_durableDrainTimer = DateTime.Now.AddMilliseconds(DurableDrainInterval).Ticks;

			for (LinkedListNode<GSRequest> node = _persistantQueue.First; node != _persistantQueue.Last.Next; node = node.Next) {
				GSRequest request = node.Value;

				if (request.RequestExpiresAt >= DateTime.Now.Ticks) {
					numDurableRequestsProcessed++;
				}
			}
				
			for (LinkedListNode<GSRequest> node = _persistantQueue.First; node != _persistantQueue.Last.Next; node = node.Next)
			{
				GSRequest request = node.Value;

				if (numDurableRequestsProcessed >= DurableConcurrentRequests || _durableDrainTimer < DateTime.Now.Ticks) {
					return;
				}

				if (request.RequestExpiresAt == 0 || request.RequestExpiresAt < DateTime.Now.Ticks) {
					request.WaitForResponseTicks = DateTime.Now.AddMilliseconds (request.GetResponseTimeout ()).Ticks;

					request.DurableAttempts++;

					request.RequestExpiresAt = DateTime.Now.AddMilliseconds (request.GetResponseTimeout () + ComputeSleepPeriod(request.DurableAttempts)).Ticks;

					_connections [0].SendImmediate (request);

					numDurableRequestsProcessed++;
				} 
			}
		}

		private void ProcessSendQueue()
		{
			while (_sendQueue.Count > 0)
			{
				GSRequest request = _sendQueue.First.Value;

				if (request.WaitForResponseTicks < DateTime.Now.Ticks)
				{
					_sendQueue.Remove(request);

					CancelRequest(request);

					continue;
				}

				if (_connections.Count > 0 && _connections[0].Ready && Available)
				{
					try
					{
						_connections[0].SendImmediate(request);

						if (_sendQueue.Contains(request))
						{
							_sendQueue.Remove(request);
						}
					}
					catch { 
						return;
					}
				}
				else
				{
					return;
				}
			}
		}

		private void Stop(Boolean terminate)
		{
			foreach (GSConnection connection in _connections)
			{
				if (terminate)
				{
					connection.Terminate();
				}
				else
				{
					connection.Stop();
				}
			}

			setAvailability(false);
		}

		private void ConnectIfRequired()
		{
			long nowTicks = DateTime.Now.Ticks;
         
            if (_nextReconnect < nowTicks)
			{
				if (_connections.Count == 0 || _connections [0]._stopped) {                
					if (Available) {
						setAvailability (false);
					}

					NewConnection ();
				} else if (!_connections [0].Ready) {
					_connections [0].Terminate ();
				} else {   
                    _connections [0].EnsureConnected();
				}
			}
				
		}

		private void NewConnection()
		{
			if (!_paused)
			{            
				lock (_connections)
				{
					_connections.Reverse();
					_connections.Add(new GSConnection(this, GSPlatform, _currentSocketUrl));
					_connections.Reverse();
				}

				CalcNewReconnectionTimeout ();
			}
		}

		private void Log(string message)
		{
			if (TraceMessages)
			{
				GSPlatform.DebugMsg(message);
			}
		}
		/// <summary>
		/// Send the given request durable. 
		/// Durable requests are persisted automatically. 
		/// If it cannot be send right now the sdk will try to send it later. 
		/// </summary>
		private void SendDurable(GSRequest request)
		{
			request.AddString("requestId", "d_" + DateTime.Now.Ticks + "_" + (_requestCounter++));

			_persistantQueue.AddLast(request);

			_durableQueueDirty = true;
		}

		private void WriteDurableQueueIfDirty(){
			if (_durableQueueDirty) {
				_durableQueueDirty = false;

				if (GSPlatform.PersistentDataPath != null) {
					List<GSRequest> requestsToWrite;

					lock (_persistantQueue) {
						requestsToWrite = DurableQueueEntries;
					}

					QueuePersistor.Write (this, requestsToWrite);
				}
			}
		}

		private static readonly string serviceUrlBase = "wss://{0}-{1}.{3}/ws/{2}/{1}";

#if DEBUG
		internal static string customUrlBase = "";
#endif

		private static String BuildServiceUrl(IGSPlatform platform)
		{
#if DEBUG
			if (customUrlBase.Length <= 0) 
#endif
			{
				String credential = platform.ApiCredential == null ? "device" : platform.ApiCredential;
				String apiDomain = platform.ApiDomain == null ? "ws.gamesparks.net" : platform.ApiDomain;

				if (platform.ApiSecret.Contains (":")) {
					credential = "secure";
				}

				return String.Format (serviceUrlBase, platform.ApiStage, platform.ApiKey, credential, apiDomain);
			} 
#if DEBUG
			else {
				return String.Format (customUrlBase, platform.ApiKey);
			}
#endif
		}

#if DEBUG
		public static void SetCustomServiceUrl(string  url)
		{
			customUrlBase = url;
		}
#endif

		private void CalcNewReconnectionTimeout(int? numAttempt = null) {
			if (numAttempt.HasValue) {
				_currAttemptConnection = numAttempt.Value;
			}

			if (_currAttemptConnection == 0) {
				_nextReconnect = DateTime.Now.Ticks;
			} else {
				int timeout = ComputeSleepPeriod(_currAttemptConnection) + HandshakeOffset;

				_nextReconnect = DateTime.Now.AddMilliseconds(timeout).Ticks;
			}

			_currAttemptConnection ++;
		}

		private int ComputeSleepPeriod(int attempt) {
			if (attempt > 16) {
				return _random.Next (0, RetryMax);
			} else {
				return _random.Next (0, Math.Min (RetryMax, RetryBase * (int)Math.Pow (2, attempt)));
			}
		}

		#endregion
	}
}
