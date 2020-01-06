using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;


namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class UDPConnectMessage : AbstractResult
	{
		internal static ObjectPool<UDPConnectMessage> pool = new ObjectPool<UDPConnectMessage> (() => {
			return new UDPConnectMessage();
		});

		public override  void Execute(){
			session.Log ("UDPConnectMessage", GameSparksRT.LogLevel.DEBUG, "(UDP) reliable={0}, ActivePeers {1}", packet.Reliable.GetValueOrDefault(false), session.ActivePeers.Count);
			if (!packet.Reliable.GetValueOrDefault (false)) {
				session.ConnectState = GameSparksRT.ConnectState.ReliableAndFast;
				session.SendData (-5, GameSparksRT.DeliveryIntent.RELIABLE, null, null);
			} else {
				session.Log ("UDPConnectMessage", GameSparksRT.LogLevel.DEBUG, "TCP (Unexpected) UDPConnectMessage");
			}
			pool.Push (this);
		}

		internal override bool ExecuteAsync()
		{
			return false;
		}
	}
}

