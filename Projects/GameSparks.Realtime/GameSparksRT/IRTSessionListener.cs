using System;
using System.IO;

namespace GameSparks.RT
{
	public interface IRTSessionListener {

		/// <summary>
		/// Executed when another player joins the room.
		/// </summary>
		/// <param name="peerId">The player who has just joined</param>
		void OnPlayerConnect (int peerId);

		/// <summary>
		/// Executed when another player leaves the room.
		/// </summary>
		/// <param name="peerId">The player who has just left</param>
		void OnPlayerDisconnect (int peerId);

		/// <summary>
		/// Executed when the SDK moves between a ready and non ready state
		/// </summary>
		/// <param name="ready">Whether the SDK is in a ready state (or not)</param>
		void OnReady (bool ready);

		/// <summary>
		/// Executed when the SDK recieves a message from another player via SendPacket
		/// </summary>
		/// <param name="opCode">The opCode sent by the other player</param>
		/// <param name="sender">The peerId of the other player</param>
		/// <param name="stream">The stream of bytes sent by the other player</param>
		/// <param name="length">The number of bytes in the stream that can be read</param>
		void OnPacket (RTPacket packet);
	}
}

