using System;
using System.IO;
using System.Collections.Generic;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.RT;
using GameSparks.Core;

namespace GameSparks.RT
{
	/// <summary>
	/// Main entry point for the GameSparksRT SDK
	/// </summary>
	public class GameSparksRT
	{

		static GameSparksRT()
		{
			Logger = (msg) => {
#if __WINDOWS__
                System.Diagnostics.Debug.WriteLine(msg);
#else
                Console.WriteLine(msg);
#endif
            };

            /*SetLogLevel("IRTSession", GameSparksRT.LogLevel.DEBUG);
            SetLogLevel("FastConnection", GameSparksRT.LogLevel.DEBUG);
            SetLogLevel("ReliableConnection", GameSparksRT.LogLevel.DEBUG);*/
        }

		public const int MAX_RTDATA_SLOTS = 128;
        public const int UDP_HANDSHAKE_SLEEP = 200;
        public const int UDP_HANDSHAKE_ATTEMPTS = 10;

        internal const int MAX_UNRELIABLE_MESSAGE_SIZE_BYTES = 1400;

		private static LogLevel logLevel  = LogLevel.DEBUG;
		private static IDictionary<string, LogLevel> tagLevels = new Dictionary<string, LogLevel>();
		private static Random random = new Random((int)(DateTime.Now.Ticks & 0xFFFFFFFF));

		/// <summary>
		/// Get a session instance
		/// </summary>
		/// <returns>The session.</returns>
		/// <param name="connectToken">A Connect token as recieved from the GameSparks SDK</param>
		/// <param name="hostName">Host name.</param>
		/// <param name="tcpPort">TCP port.</param>
		/// <param name="udpPort">UDP port.</param>
		public static IRTSession GetSession(string connectToken, string hostName, int tcpPort, int udpPort, bool useOnlyWebSockets = false)
		{
			return new RTSessionImpl (connectToken, hostName, tcpPort, udpPort, useOnlyWebSockets);
		}

		public static GameSparksRTSessionBuilder SessionBuilder(){
			return new GameSparksRTSessionBuilder();
		}

		internal static int RetryBase {
			get { return 2000; }
		}

		internal static int RetryMax {
			get { return 60000; }
		}

		internal static int HandshakeOffset {
			get { return 2000; }
		}	

		internal static int ComputeSleepPeriod(int attempt) {
			if (attempt > 16) {
				return random.Next (0, RetryMax);
			} else {
				return random.Next (0, Math.Min (RetryMax, RetryBase * (int)Math.Pow (2, attempt)));
			}
		}

		#region Logging

		/// <summary>
		/// Log level.
		/// </summary>
		public enum LogLevel {
			/// <summary>
			/// Log at DEBUG
			/// </summary>
			DEBUG=0,
			/// <summary>
			/// Log at INFO
			/// </summary>
			INFO=1,
			/// <summary>
			/// Log at WARN
			/// </summary>
			WARN=2,
			/// <summary>
			/// Log at ERROR
			/// </summary>
			ERROR=3
		}

		/// <summary>
		/// The state of the current SDK
		/// </summary>
		public enum ConnectState
		{
			/// <summary>
			/// Disconnected.
			/// </summary>
			Disconnected = 0,

			/// <summary>
			/// Connecting.
			/// </summary>
			Connecting = 1,

			/// <summary>
			/// Only a TCP connection is established.
			/// </summary>
			ReliableOnly = 2,

			/// <summary>
			/// We've successfully send some UDP and the server has recieved it, but have not recieved any
			/// </summary>
			ReliableAndFastSend = 3,

			/// <summary>
			/// All systems go. We can send and recieve UCP.
			/// </summary>
			ReliableAndFast = 4
		}

		/// <summary>
		/// How the message should be attempted to be sent.
		/// If ConnectState==ReliableOnly the message will be sent as RELIABLE
		/// </summary>
		public enum DeliveryIntent
		{
			/// <summary>
			/// Send over TCP
			/// </summary>
			RELIABLE = 0,
			/// <summary>
			/// Send over UDP, don't discard out of sequence packets
			/// </summary>
			UNRELIABLE = 1,
			/// <summary>
			/// Send over UDP, discard out of sequence packets
			/// </summary>
			UNRELIABLE_SEQUENCED = 2
		}

		/// <summary>
		/// Set the default log level for logging in the SDK
		/// </summary>
		/// <param name="level">The LogLevel to set</param>
		public static void SetRootLogLevel(LogLevel level)
		{
			logLevel = level;
		}

		/// <summary>
		/// Set the log level for a given tag.
		/// </summary>
		/// <param name="tag">The tag to set the LogLevel of</param>
		/// <param name="level">The LogLevel to set</param>
		public static void SetLogLevel(string tag, LogLevel level)
		{
			tagLevels.Add (tag, level);
		}

		/// <summary>
		/// Gets or sets the logger.
		/// </summary>
		/// <value>An Action&lt;string&gt;</value>
		public static Action<String> Logger { internal get; set; }

		internal static bool ShouldLog(String tag, LogLevel level)
		{
			if (tagLevels.ContainsKey (tag)) {
				return tagLevels[tag] >= level;
			}
			return logLevel <= level;
		}

		#endregion
	}

	public class GameSparksRTSessionBuilder {

		string connectToken;
		string host;
		int port;
		IRTSessionListener listener;
		bool useOnlyWebSockets = false;
        GSInstance instance = null;

		public GameSparksRTSessionBuilder SetConnectToken(string connectToken){
			this.connectToken = connectToken;
			return this;
		}

		public GameSparksRTSessionBuilder SetHost(string host){
			this.host = host;
			return this;
		}

		public GameSparksRTSessionBuilder SetPort(int port){
			this.port = port;
			return this;
		}

		public GameSparksRTSessionBuilder SetListener(IRTSessionListener listener){
			this.listener = listener;
			return this;
		}

		public GameSparksRTSessionBuilder UseOnlyWebSockets(bool use){
			this.useOnlyWebSockets = use;
			return this;
		}

        public GameSparksRTSessionBuilder SetGSInstance(GSInstance instance = null)
        {
            this.instance = instance;
            return this;
        }

        public IRTSession Build(){
			IRTSession session = new RTSessionImpl (connectToken, host, port, port, useOnlyWebSockets, instance);
			session.SessionListener = listener;
			return session;
		}

	}

}