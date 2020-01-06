using System;
using System.Threading;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using GameSparks.Api;

namespace GameSparks.Core
{
    /// <summary>
    /// This is a static class, which automatically instantiates the default <see cref="GSInstance"/> and handles it. 
    /// </summary>
	public class GS
    {
        private static GSInstance _instance;
        
        /// <summary>
        /// Returns the currently used platform specific implementation. 
        /// </summary>
        public static IGSPlatform GSPlatform
        {
            get
            {
                return Instance.GSPlatform;
            }
            set
            {
                Instance.GSPlatform = value;
            }
        }
		
        /// <summary>
        /// Describes the current version of the sdk. 
        /// </summary>
        public static string Version
        {
            get
            {
                return GameSparks.Core.Version.VersionString;
            }
        }

        /// <summary>
        /// Initialise GameSparks with a given platform implementation. 
        /// </summary>
		public static void Initialise (IGSPlatform gSPlatform)
		{
            Instance.Initialise(gSPlatform);
		} 

        /// <summary>
        /// This will end the remote session and stop all connections. 
        /// </summary>
        public static void ShutDown()
        {
            Instance.ShutDown(null);
            _instance = null;
        }

        /// <summary>
        /// Stops all connections. 
        /// </summary>
		public static void Disconnect ()
		{
            Instance.Disconnect();
		}

        /// <summary>
        /// Reconnect to the GameSparks service. 
        /// </summary>
		public static void Reconnect ()
		{
            Instance.Reconnect();
		}
        
        /// <summary>
        /// Stops all connections, resets the authentication token and establishes a new connection to the service. 
        /// </summary>
		public static void Reset ()
		{
            Instance.Reset();
		}

        /// <summary>
        /// Currently active GameSparks service instance. 
        /// </summary>
		public static GSInstance Instance {
			get {
                if (_instance == null)
                {
					_instance = new GSInstance("default");   
                }

                return _instance;
            }
		}

		private GS ()
		{   
		}

        /// <summary>
        /// True if a connection to the service is available for use. 
        /// </summary>
		public static bool Available 
        {
			get
            {
                return Instance.Available;
            }
		}

        /// <summary>
        /// True if a connection is available and the user is authenticated. 
        /// </summary>
		public static bool Authenticated
        {
			get
            {
                return Instance.Authenticated;
            }
		}

        /// <summary>
        /// Send the given request durable. 
        /// Durable requests are persisted automatically. 
        /// If it cannot be send right now the sdk will try to send it later. 
        /// </summary>
		public static void SendDurable(GSRequest request)
        {
			request.Durable = true;

            Instance.Send(request);
		}


        /// <summary>
        /// Send the given request. 
        /// </summary>
		public static void Send (GSRequest request)
		{
            Instance.Send(request);
		}

		internal static int RetryBase {
			get { return 2000; }
		}

		internal static int RetryMax {
			get { return 60000; }
		}

		internal static int RequestTimeout {
			get { return 15000; }
		}

		internal static int DurableConcurrentRequests {
			get { return 1; }
		}

		internal static int DurableDrainInterval {
			get { return 100; }
		}

		internal static int HandshakeOffset {
			get { return 2000; }
		}	
			
		public static Func<String, String> OnGameSparksNonce { 
			private get { return Instance.OnGameSparksNonce; }
			set { Instance.OnGameSparksNonce = value; }
		}

		/// <summary>
        /// Callback which is triggered whenever the service becomes available or the connection to the service is lost. 
        /// </summary>
		public static Action<bool> GameSparksAvailable {
            get { return Instance.GameSparksAvailable; }
            set { Instance.GameSparksAvailable = value; }
		}

		/// <summary>
		/// Callback which is triggered whenever the service becomes available or the connection to the service is lost. 
		/// </summary>
		public static Action<string> GameSparksAuthenticated {
			get { return Instance.GameSparksAuthenticated; }
			set { Instance.GameSparksAuthenticated = value; }
		}

        /// <summary>
        /// If set true the SDK will provide debug information via <see cref="IGSPlatform.DebugMsg"/>
        /// </summary>
		public static bool TraceMessages {
			get { return Instance.TraceMessages; }
            set { Instance.TraceMessages = value; }
		}

        /// <summary>
        /// Whenever a durable request is sent it is added to the durable queue. 
        /// This can be used to determine how many requests are pending to be sent. 
        /// </summary>
		public static int DurableQueueCount {
			get {
                if (_instance == null)
                {
					return 0;
				}

				return Instance.DurableQueueEntries.Count;
			}
		}

        /// <summary>
        /// Whenever a request is sent it is added to a request queue. 
        /// Each request has its own time out. 
        /// This can used to determine how many requests are not yet sent or have not yet timed out. 
        /// </summary>
		public static int RequestQueueCount {
			get { 
				if (_instance == null) {
					return 0;
				}

                return Instance.RequestQueueCount;
			}
		}

	}
}
