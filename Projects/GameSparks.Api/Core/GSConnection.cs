using System;
using System.Collections.Generic;
using System.Reflection;

namespace GameSparks.Core
{
	internal class GSConnection
	{
		private IDictionary<String, GSRequest> _pendingRequests = new Dictionary<String,GSRequest> ();
		internal bool _stopped;
		private String url;

		private IGameSparksWebSocket _WebSocketClient;
		private GSInstance _gs;

		IGSPlatform _gSPlatform;

		private long mustConnectBy;

		internal GSConnection (GSInstance gs, IGSPlatform gsPlatform, String currentUrl)
		{
			this._gs = gs;
			this._gSPlatform = gsPlatform;
			url = currentUrl;

			mustConnectBy = DateTime.Now.AddMilliseconds(gs.HandshakeOffset).Ticks;

#if DEBUG
			if (GSInstance.customUrlBase.Length <= 0) 
#endif
			{
				if (url.IndexOf ('?') == -1) {
					url += "?deviceOS=" + gsPlatform.DeviceOS;
					url += "&deviceID=" + gsPlatform.DeviceId;
					url += "&SDK=" + gsPlatform.SDK;
				}
			}

			_gSPlatform.DebugMsg ("Connecting to:" + url);

			EnsureConnected();
		}

		internal void Terminate(){
			Stop ();
			Close ();
		}

		internal void Stop(){
			_stopped = true;
		}

		internal void PrintDetails(){
			if(GS.TraceMessages)
				_gSPlatform.DebugMsg ("_stopped:" + _stopped + " state:" + _WebSocketClient.State + " _pendingCount:" + _pendingRequests.Count);
		}

		internal void Close(){
            if (_WebSocketClient != null)
            {
                lock (_WebSocketClient)
                {
                    if (_WebSocketClient != null)
                    {
                        //GameSparksWebSocketState state = _WebSocketClient.State;
                        //if (state == GameSparksWebSocketState.Open || state == GameSparksWebSocketState.Connecting)
                        {
							_WebSocketClient.Terminate();
                        }
                    }
                }
            }
		}

		internal void OnOpened ()
		{
			_gSPlatform.DebugMsg ("OPENED");
		}

		internal void OnClosed ()
		{
            _stopped = true;
            _WebSocketClient = null;
		}

		internal void OnError (String errorMessage)
		{
			try{
				_gs.AddRequestedAction(()=>{
					_gs.WebSocketClient_OnError (errorMessage, this);
				});
			}catch{
				//on WP8 if the app goes out of score for some reason the gs is null, so ignore this
			}
		}

		private void GSConnection_OnMessageReceived (String message)
		{
			try{

	            if (_gSPlatform.ApiSecret.Contains(":"))
	            {
					message = Decrypt (message);
					if (SessionId != null) {
						IDictionary<string,object> parsed = (IDictionary<string,object>)GSJson.From (message);
						GSData secureResponse = new GSData (parsed);
						string json = secureResponse.GetString ("json");
	                    if (secureResponse.GetString("hmac").Equals(_gs.GSPlatform.MakeHmac(json, GS.GSPlatform.ApiSecret + "-" + SessionId)))
	                    {
							_gs.AddRequestedAction(()=>{
								_gs.OnMessageReceived (json, this);	
							});
						} 
						else 
						{
							if (_gs.TraceMessages) {
								_gSPlatform.DebugMsg ("SOCKET-TAMPERED:" + secureResponse.JSON);
							}
						}
						return;
					}
				}
				_gs.AddRequestedAction(()=>{
					_gs.OnMessageReceived (message, this);	
				});
			}catch{
				//on WP8 if the app goes out of score for some reason the gs is null, so ignore this
			}

		}

		internal void EnsureConnected ()
		{
			
			if (_stopped) {
				return;
			}

			if (!GameSparksUtil.ShouldConnect) {
				return;
			}

			lock (this) {

				if (_WebSocketClient == null) {
					_WebSocketClient = _gSPlatform.GetSocket(url, GSConnection_OnMessageReceived, OnClosed, OnOpened, OnError);
				}

                lock (_WebSocketClient)
                {
                    GameSparksWebSocketState state = _WebSocketClient.State;

					if (mustConnectBy < DateTime.Now.Ticks && state == GameSparksWebSocketState.Connecting) {
						Terminate ();
					} else if (state != GameSparksWebSocketState.Open && state != GameSparksWebSocketState.Connecting) {
						_WebSocketClient.Open ();			
					}
                }
			}
		}

		private Boolean _initialised;

		internal bool Ready{
            get
            {
                if (_WebSocketClient != null)
                {
                    lock (_WebSocketClient)
                    {
                        if (_WebSocketClient != null)
                        {
                            return _WebSocketClient.State == GameSparksWebSocketState.Open && _initialised;
                        }
                    }
                }
                return false;
            }
			set{_initialised = value; }
		}

		internal string SessionId{get; set;}

		internal void SendImmediate (GSRequest request)
		{
            if(_WebSocketClient != null)
            {
                lock(_WebSocketClient)
                {
                    if(_WebSocketClient != null)
                    {
		                if (!request.Type.Equals(".AuthenticatedConnectRequest")) {

			                if (request.GetString ("requestId") == null) {
				                request.AddString ("requestId", DateTime.Now.Ticks + "_" + (_gs._requestCounter++));
			                }

							//if (request.MaxResponseTimeInMillis != _gs.RequestTimeout) {
							//	request.AddNumber ("timeout", request.MaxResponseTimeInMillis);
							//}

			                lock (_pendingRequests) {
				                _pendingRequests.Add (request.GetString ("requestId"), request);
			                }
		                }

		                String requestJson = request.JSON;

		                _gSPlatform.DebugMsg ("SEND:" + requestJson);

		                //Wrap it in a secure request
		                if (_gs.GSPlatform.ApiSecret.Contains (":") && SessionId != null) {
			                GSRequestData secureRequest = new GSRequestData();

			                secureRequest.AddString("json", requestJson);
			                secureRequest.AddString("hmac", _gs.GSPlatform.MakeHmac(requestJson, _gs.GSPlatform.ApiSecret + "-" + SessionId));
			                
							requestJson = secureRequest.JSON;
		                }

		                if (_gs.GSPlatform.ApiSecret.Contains (":")) {
			                requestJson = Encrypt (requestJson);
		                }

		                if (_gs.TraceMessages) {
			                _gSPlatform.DebugMsg ("SOCKET-SEND:" + requestJson);
		                }

		                _WebSocketClient.Send (requestJson);
                    }
                }
            }
		}

		static string Encrypt(string inputStr)
		{	
			int len = inputStr.Length;

			int sum = 10;

			char[] encryptedChars = new char[len];
			for (int i=0; i<len; i++) 
			{
				encryptedChars[i] = (char)((int)inputStr[i] + sum);
			}

			char[] newNameStr = new char[len];
			for (int i=0; i<len; i++) 
			{ // reverse the name
				newNameStr[i] = encryptedChars[len-1-i];
			}

			for (int i=0; i<len; i++) 
			{ // reverse the name
				encryptedChars[i] = newNameStr[i];
			}

			return new String(encryptedChars);
		}

		static string Decrypt(string inputStr)
		{	
			int len = inputStr.Length;
			char[] decryptedChars = new char[len];
			for (int i=0; i<len; i++) 
			{
				decryptedChars[i] = (char)((int)inputStr[i] - 10);
			}	

			char[] newNameStr = new char[len];
			for (int i=0; i<len; i++) 
			{ // reverse the name
				newNameStr[i] = decryptedChars[len-1-i];
			}

			for (int i=0; i<len; i++) 
			{ // reverse the name
				decryptedChars[i] = newNameStr[i];
			}

			return new String(decryptedChars);
		}

		public IDictionary<String, GSRequest> PendingRequestCopy {
			get { return new Dictionary<String, GSRequest> (_pendingRequests); }
			private set{ }
		}

		public void RemovePending(GSRequest toRemove){

		}

		public int PendingRequestCount {
			get {
				lock (_pendingRequests) {
					return _pendingRequests.Count;
				}
			}
			private set { }
		}

		public GSRequest GetPending(String requestId) {
			GSRequest toReturn = null;

			_pendingRequests.TryGetValue (requestId, out toReturn);

			return toReturn;
		}

		public GSRequest GetAndRemovePending(String requestId) {
			GSRequest toReturn = null;

			_pendingRequests.TryGetValue (requestId, out toReturn);

			if (toReturn != null) {
				_pendingRequests.Remove (requestId);
			}

			return toReturn;
		}
	}
}

