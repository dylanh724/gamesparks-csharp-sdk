using System;
using System.Collections.Generic;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.Core;

namespace GameSparks.RT
{
	/// <summary>
	/// The realtime session interface. An instance if this interface can be obtainedfrom RTSessionFactory
	/// Each realtime session will have a single instance of this interface.
	/// </summary>
	public interface IRTSession {
		
		/// <summary>
		/// The user supplied session listener.
		/// </summary>
		IRTSessionListener SessionListener { set; get; }

		/// <summary>
		/// Starts the session and connects to the real time services.
		/// </summary>
		void Start ();

		/// <summary>
		/// Starts the session and disconnects from the real time services.
		/// </summary>
		void Stop ();

		/// <summary>
		/// The peerId of the current player.
		/// </summary>
		int? PeerId { get; }

		/// <summary>
		/// Indicates if the SDK is Ready and connected
		/// </summary>
		bool Ready { get; }

		/// <summary>
		/// The list of peers who are currently connected.
		/// </summary>
		List<int> ActivePeers { get; }

		/// <summary>
		/// The connection state of the session.
		/// </summary>
		GameSparksRT.ConnectState ConnectState { get; }

		/// <summary>
		/// Sends a message to other players
		/// </summary>
		/// <param name="opCode">The opCode to send</param>
		/// <param name="deliveryIntent">How this message should be sent.</param>
		/// <param name="payload">the byte array to send</param>
		/// <param name="data">The RTData object to send</param>
		/// <param name="targetPlayers">The list of players to send to (empty to send to all)</param>
		int SendData (int opCode, GameSparksRT.DeliveryIntent deliveryIntent, byte[] payload, RTData data, params int[] targetPlayers);

		/// <summary>
		/// Sends a strucured message to other players
		/// </summary>
		/// <param name="opCode">The opCode to send</param>
		/// <param name="deliveryIntent">How this message should be sent.</param>
		/// <param name="data">The RTData object to send</param>
		/// <param name="targetPlayers">The list of players to send to (empty to send to all)</param>
		int SendRTData (int opCode, GameSparksRT.DeliveryIntent deliveryIntent, RTData data, params int[] targetPlayers);

		/// <summary>
		/// Sends a byte[] to other players
		/// </summary>
		/// <param name="opCode">The opCode to send</param>
		/// <param name="deliveryIntent">How this message should be sent.</param>
		/// <param name="payload">bytes to send, as an ArraySegment<c> struct</c></param>
		/// <param name="targetPlayers">The list of players to send to (empty to send to all)</param>
		int SendBytes (int opCode, GameSparksRT.DeliveryIntent deliveryIntent, ArraySegment<byte> payload, params int[] targetPlayers);

		/// <summary>
		/// Sends both RTData and bytes to other players
		/// </summary>
		/// <param name="opCode">The opCode to send</param>
		/// <param name="intent">How this message should be sent.</param>
		/// <param name="payload">bytes to send, as an ArraySegment<c> struct</c></param>
		/// <param name="targetPlayers">The list of players to send to (empty to send to all)</param>
		int SendRTDataAndBytes(int opCode, GameSparksRT.DeliveryIntent intent, ArraySegment<byte>? payload, RTData data, params int[] targetPlayers);

		/// <summary>
		/// This method should be called as frequently as possible by the thread you want
		/// Your callbacks to execute on. In unity, you should call this from an Update 
		/// method in a MonoBehaviour
		/// </summary>
		void Update();

        GSInstance GetGSInstance();
	}

}

