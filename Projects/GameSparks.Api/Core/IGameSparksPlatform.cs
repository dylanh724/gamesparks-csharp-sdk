using System;
using System.Collections;
using System.Collections.Generic;
using GameSparks.Core;

namespace GameSparks.Core {
	/// <summary>
	/// Platform specific interface to help GameSparks SDK to run on a multitude of platforms and frameworks. 
	/// </summary>
	public interface IGSPlatform 
	{

		/// <summary>
        /// Gets a unique identifier for the device
		/// </summary>
		String DeviceId {get;}
		
        /// <summary>
        /// IOS or AND or WP8 - Required for in app purchases
        /// </summary>
		String DeviceOS {get;}

		/// <summary>
        /// Will be used in analytics reports
		/// </summary>
		String Platform {get;}

		/// <summary>
        /// Will be used in analytics reports
		/// </summary>
		String SDK {get;}

		/// <summary>
        /// Will be used in analytics reports
		/// </summary>
		String DeviceType {get;}

        GSData DeviceStats { get; }

		/// <summary>
        /// Set to true to get extended debugging information
		/// </summary>
		bool ExtraDebug { get;}

		string ApiKey { get; }
		string ApiSecret { get; }
		string ApiCredential { get; }
		string ApiStage { get; }
		string ApiDomain { get; }

        /// <summary>
        /// Reusable AuthToken. Should be stored persistently when set. 
        /// </summary>
		String AuthToken {get; set;}

        /// <summary>
        /// The UserId of the player currently authenticated. 
        /// </summary>
        String UserId {get; set;}

		/// <summary>
        /// Recieves debugging information from the API
		/// </summary>
		void DebugMsg(String message);

        /// <summary>
        /// Execute the given Action on the main thread. 
        /// </summary>
		void ExecuteOnMainThread(Action action);

        /// <summary>
        /// A path to a location where persistent storage can take place. 
        /// </summary>
		String PersistentDataPath{ get; }

        /// <summary>
        /// Returns a new Instance of a <see cref="IGameSparksTimer"/>. 
        /// </summary>
        IGameSparksTimer GetTimer();

        /// <summary>
        /// Returns a hmac created with SHA-256 based on the given parameters. 
        /// </summary>
        string MakeHmac(string stringToHmac, string secret);

        /// <summary>
        /// Returns a platform specific instance of <see cref="IGameSparksWebSocket"/>. 
        /// Also sets the target Url for the socket and the relevant callback actions. 
        /// </summary>
        IGameSparksWebSocket GetSocket(string url, Action<string> messageReceived, Action closed, Action opened, Action<string> error);

        /// <summary>
        /// Returns a platform specific instance of <see cref="IGameSparksWebSocket"/>. 
        /// Also sets the target Url for the socket and the relevant callback actions. 
        /// </summary>
        IGameSparksWebSocket GetBinarySocket(string url, Action<byte[]> messageReceived, Action closed, Action opened, Action<string> error);

    }
}
	 


