using System;
using Com.Gamesparks.Realtime.Proto;
using System.IO;
using GameSparks.RT.Connection;
using GameSparks.RT.Commands;
using GameSparks.RT.Pools;
using System.Threading;
using GameSparks.Core;
#if __WINDOWS__
using Windows.System.Threading;
using System.Threading.Tasks;
#else

#endif
using System.Collections.Generic;

namespace GameSparks.RT
{
	internal class RTSessionImpl : IRTSessionInternal
	{
		//Private instance fields
		private ReliableConnection reliableConnection;
#if !__WINDOWS__
		private ReliableWSConnection reliableWSConnection;
#endif
		private FastConnection fastConnection;
		internal string hostName;
		internal int TcpPort;
		public int FastPort { get; set; }
		private bool running = false;
		//private Thread controlThread;
		private bool useOnlyWebSockets = false;

		public String ConnectToken { get; set; }

		public bool Ready { get; set; }

		private int connectionAttempts = 1;

		internal DateTime mustConnectBy = DateTime.Now;

        private GSInstance instance;

		public RTSessionImpl (){
			ActivePeers = new List<int> ();
		}

		public RTSessionImpl (string connectToken, string hostName, int tcpPort, int udpPort, bool useOnlyWebSockets, GSInstance instance = null)
		{
			ConnectToken = connectToken;
			this.TcpPort = tcpPort;
			this.FastPort = udpPort;
			this.hostName = hostName;
			this.useOnlyWebSockets = useOnlyWebSockets;
            this.instance = instance;
			ActivePeers = new List<int>();
		}

		public void Log(String tag, GameSparks.RT.GameSparksRT.LogLevel level, String msg, params object[] formatParams){
			if(GameSparksRT.ShouldLog(tag, level))
			{
				SubmitAction(LogCommand.pool.Pop().Configure(this, tag, level, msg, formatParams));
			}
		}

#region IRTSession members

		public int? PeerId { get; set; }

		private volatile GameSparksRT.ConnectState internalState = GameSparksRT.ConnectState.Disconnected;

		public GameSparksRT.ConnectState ConnectState { 
			get 
			{
				return internalState;
			} 
			set 
			{
				if (useOnlyWebSockets && (value == GameSparksRT.ConnectState.ReliableAndFastSend || value == GameSparksRT.ConnectState.ReliableAndFast)) {
					value = GameSparksRT.ConnectState.ReliableOnly;
				}

				if (value != internalState) {
					if (internalState < value || value == GameSparksRT.ConnectState.Disconnected) {
						Log ("IRTSession", GameSparksRT.LogLevel.DEBUG, "State Change : from {0} to {1}, ActivePeers {2}", internalState, value, ActivePeers.Count);

						internalState = value;

						if (internalState >= GameSparksRT.ConnectState.ReliableOnly) {
							mustConnectBy = DateTime.Now;
							connectionAttempts = 0;
						}

						if (useOnlyWebSockets && value == GameSparksRT.ConnectState.ReliableOnly) {
							OnReady (true);
						}
					}
				}
			} 
		}

		public List<int> ActivePeers { get; set; }

		public int SendData(int opCode, GameSparksRT.DeliveryIntent intent, byte[] payload, RTData data, params int[] targetPlayers){
			if (payload == null) {
				return SendRTDataAndBytes (opCode, intent, null, data, targetPlayers);
			} else {
				return SendRTDataAndBytes (opCode, intent, new ArraySegment<byte>(payload), data, targetPlayers);
			}
		}

		public int SendRTData(int opCode, GameSparksRT.DeliveryIntent intent, RTData data, params int[] targetPlayers){
			return SendRTDataAndBytes (opCode, intent, null, data, targetPlayers);
		}

		public int SendBytes (int opCode, GameSparksRT.DeliveryIntent intent, ArraySegment<byte> payload, params int[] targetPlayers){
			return SendRTDataAndBytes (opCode, intent, payload, null, targetPlayers);
		}


		public int SendRTDataAndBytes(int opCode, GameSparksRT.DeliveryIntent intent, ArraySegment<byte>? payload, RTData data, params int[] targetPlayers){
			CustomRequest csr = PooledObjects.CustomRequestPool.Pop ();

			try{
				csr.Configure(opCode, intent, payload, data, targetPlayers);
				if(!useOnlyWebSockets && intent != GameSparksRT.DeliveryIntent.RELIABLE && ConnectState >= GameSparksRT.ConnectState.ReliableAndFastSend ){
                    return fastConnection.Send(csr);
                } else {
					if(ConnectState >= GameSparksRT.ConnectState.ReliableOnly){
#if !__WINDOWS__
						if (useOnlyWebSockets)
                        {
							return reliableWSConnection.Send(csr);
						}
                        else
#endif
                        {
                        	return reliableConnection.Send(csr);
						}
                    }
				}
			}finally{
				PooledObjects.CustomRequestPool.Push (csr);
			}

			return 0;
		}

		public void Stop()
		{
			Log("IRTSession", GameSparksRT.LogLevel.DEBUG, "Stopped");

			running = false;
			Ready = false;
			//controlThread = null;

#if !__WINDOWS__
			if (useOnlyWebSockets)
            {    
				if (reliableWSConnection != null) {
					reliableWSConnection.Stop ();
				}
			}
            else
#endif
            {
				if (fastConnection != null) {
					fastConnection.Stop ();
				}

				if (reliableConnection != null) {
					reliableConnection.Stop ();
				}
			}

			ConnectState = GameSparksRT.ConnectState.Disconnected;
		}

		private void CheckConnection()
		{
			try {
				if (DateTime.Now > mustConnectBy) {
					if (ConnectState == GameSparksRT.ConnectState.Disconnected) {
						Log("IRTSession", GameSparksRT.LogLevel.INFO, "Disconnected, trying to connect");

						ConnectState = GameSparksRT.ConnectState.Connecting;

#if !__WINDOWS__
						if (useOnlyWebSockets)
                        {
							ConnectWSReliable ();
						}
                        else
#endif
                        {
							ConnectReliable ();
						}

						connectionAttempts ++;
					} else if (ConnectState == GameSparksRT.ConnectState.Connecting) {
						ConnectState = GameSparksRT.ConnectState.Disconnected;

						Log("IRTSession", GameSparksRT.LogLevel.INFO, "Not connected in time, retrying");

#if !__WINDOWS__
						if (useOnlyWebSockets)
                        {
							if (reliableWSConnection != null) {
								reliableWSConnection.StopInternal();
								reliableWSConnection = null;
							}
						}
                        else
#endif
                        {
							if(reliableConnection != null) {
								reliableConnection.StopInternal();
								reliableConnection = null;
							}

							if(fastConnection != null) {
								fastConnection.StopInternal();
								fastConnection = null;
							}
						}
	                }
				}
#if __WINDOWS__

#else
            } catch (ThreadAbortException e) {
				Log("IRTSession", GameSparksRT.LogLevel.INFO, e.StackTrace);

				return;
#endif
            } catch (Exception e) {
                //General exception, ignore it
                System.Diagnostics.Debug.WriteLine(e);

                Log("IRTSession", GameSparksRT.LogLevel.ERROR, e.StackTrace);
			}
		}

		public void Start(){
			running = true;
		}

#endregion

#region Internals

		public void ConnectReliable(){
			mustConnectBy = DateTime.Now.AddMilliseconds(GameSparksRT.ComputeSleepPeriod(connectionAttempts) + GameSparksRT.HandshakeOffset);

			reliableConnection = new ReliableConnection (hostName, TcpPort, this);
        }

#if !__WINDOWS__
		public void ConnectWSReliable() {
			mustConnectBy = DateTime.Now.AddMilliseconds(GameSparksRT.ComputeSleepPeriod(connectionAttempts) + GameSparksRT.HandshakeOffset * 10);
		
			reliableWSConnection = new ReliableWSConnection (hostName, TcpPort, this);
		}
#endif

		public void ConnectFast(){
			if (!useOnlyWebSockets) {
				Log("IRTSession", GameSparksRT.LogLevel.DEBUG, PeerId + ": Creating new fastConnection to " + FastPort);
				//if (fastConnection != null) {
					fastConnection = new FastConnection (hostName, FastPort, this);
				//}
			}
		}

#endregion

#region Threading

		Queue<IRTCommand> actionQueue = new Queue<IRTCommand>();

		public void Update()
		{     
			if (running) {
				CheckConnection ();
			}

			IRTCommand toExecute = null;           

            while ((toExecute = GetNextAction()) != null) {          
                toExecute.Execute ();
			}
		}

		private IRTCommand GetNextAction()
		{
			if (actionQueue.Count > 0) {              
				lock (actionQueue) {
					return actionQueue.Dequeue ();
				}
			}

			return null;
		}

		public void SubmitAction(IRTCommand action)
		{       
            lock (actionQueue) {
				actionQueue.Enqueue (action);
			}
		}

#endregion

#region Listener proxy

		public IRTSessionListener SessionListener { get; set; }

		public void OnPlayerConnect (int peerId)
		{
			ResetSequenceForPeer (peerId);
			if (SessionListener != null) {
				if (this.Ready) {
					SessionListener.OnPlayerConnect (peerId);
				}
			}
		}

		public void OnPlayerDisconnect (int peerId){
			if (SessionListener != null) {
				if (this.Ready) {
					SessionListener.OnPlayerDisconnect (peerId);
				}
			}
		}

		//This can be called by numerous threads, make sure we wrap the code into an action
		public void OnReady (bool ready){
			
            if (!this.Ready && ready){             
                SendData (OpCodes.PlayerReadyMessage, GameSparksRT.DeliveryIntent.RELIABLE, null, null);            
                if (PeerId.HasValue && !ActivePeers.Contains(PeerId.Value)){
					ActivePeers.Add (PeerId.Value);               
                }
			}

			this.Ready = ready;

			if (!this.Ready) {
				ConnectState = GameSparksRT.ConnectState.Disconnected;
			}


			if (SessionListener != null) {             
                SubmitAction ( ActionCommand.pool.Pop().Configure(
					() => {                     
                        SessionListener.OnReady (ready);
					}));
			}
		}

		public void OnPacket(RTPacket packet)
		{
#if __WINDOWS__
            throw new Exception();
#else
            throw new AccessViolationException();	
#endif
		}

#endregion

#region Sequences

		IDictionary<int, int> peerMaxSequenceNumbers = new Dictionary<int, int>();

		public bool ShouldExecute(int peerId, int? sequence){
			
			if (!sequence.HasValue) {
				return true;
			} else if (!peerMaxSequenceNumbers.ContainsKey (peerId)) {
				peerMaxSequenceNumbers.Add (peerId, 0);
			}

			if (peerMaxSequenceNumbers [peerId] > sequence) {
				Log ("IRTSession", GameSparksRT.LogLevel.DEBUG, "Discarding sequence id {0} from peer {1}", sequence, peerId);
				return false;
			} else {
				peerMaxSequenceNumbers [peerId] = sequence.Value;
				return true;
			}
		}

		private void ResetSequenceForPeer (int peerId)
		{
			if (peerMaxSequenceNumbers.ContainsKey (peerId)) {
				peerMaxSequenceNumbers.Add (peerId, 0);
			}
		}

		int sequenceNumber = 0;

		public int NextSequenceNumber()
		{
			return sequenceNumber++;
		}

        public GSInstance GetGSInstance()
        {
            return instance;
        }


        #endregion
    }
}