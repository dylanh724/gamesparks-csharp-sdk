using System;
using System.IO;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Commands
{
	internal class CommandFactory {

		internal static IRTCommand GetCommand(int opCode, int sender, int? sequence, Stream stream, IRTSessionInternal session, RTData data, int packetSize){

			long limit = global::GameSparks.RT.Proto.ProtocolParser.ReadUInt32(stream);
			LimitedPositionStream lps = PooledObjects.LimitedPositionStreamPool.Pop ();

			try{
				lps.Wrap (stream, limit);
				switch (opCode) {
				case OpCodes.LoginResult:
					return LoginResult.Deserialize(lps, LoginResult.pool.Pop());
				case OpCodes.PingResult:
					return PingResult.Deserialize(lps, PingResult.pool.Pop());
				case OpCodes.UDPConnectMessage:
					return UDPConnectMessage.Deserialize(lps, UDPConnectMessage.pool.Pop());
				case OpCodes.PlayerConnectMessage:
					return PlayerConnectMessage.Deserialize(lps, PlayerConnectMessage.pool.Pop());
				case OpCodes.PlayerDisconnectMessage:
					return PlayerDisconnectMessage.Deserialize(lps, PlayerDisconnectMessage.pool.Pop());
				default:
					if(session.ShouldExecute(sender, sequence)){
						return CustomCommand.pool.Pop().Configure(opCode, sender, lps, data, (int)limit, session, packetSize);
					}

					return null;
				}
			} finally {
				lps.SkipToEnd ();
				PooledObjects.LimitedPositionStreamPool.Push (lps);
			}
		}
	}

	internal class OpCodes {
		
		public const int LoginResult = -1;
		public const int PingResult = -3;
		public const int UDPConnectMessage = -5;
		public const int PlayerReadyMessage = -7;
		public const int PlayerConnectMessage = -101;
		public const int PlayerDisconnectMessage = -103;

	}

}

