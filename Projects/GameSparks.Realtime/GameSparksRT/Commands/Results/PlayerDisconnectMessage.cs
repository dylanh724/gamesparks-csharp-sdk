using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;


namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class PlayerDisconnectMessage : AbstractResult
	{
		private PlayerDisconnectMessage(){}

		internal static ObjectPool<PlayerDisconnectMessage> pool = new ObjectPool<PlayerDisconnectMessage> (() => {
			return new PlayerDisconnectMessage();
		}, (instance) => {
			instance.ActivePeers.Clear();
		});

		public override void Execute(){
			session.ActivePeers.Clear ();
			session.ActivePeers.AddRange(ActivePeers);
			session.Log ("PlayerDisconnectMessage", GameSparksRT.LogLevel.DEBUG ,"PeerId={0}, ActivePeers {1}", PeerId, session.ActivePeers.Count);
			session.OnPlayerDisconnect (PeerId);
			pool.Push (this);
		}
	}
}

