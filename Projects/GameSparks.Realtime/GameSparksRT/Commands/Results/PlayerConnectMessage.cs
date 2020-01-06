using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;


namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class PlayerConnectMessage : AbstractResult
	{
		internal static ObjectPool<PlayerConnectMessage> pool = new ObjectPool<PlayerConnectMessage> (() => {
			return new PlayerConnectMessage();
		}, (instance) => {
			instance.ActivePeers.Clear();
		});

		public override void Execute(){
			session.ActivePeers.Clear ();
			session.ActivePeers.AddRange (ActivePeers);
			session.Log ("PlayerConnectMessage", GameSparksRT.LogLevel.DEBUG, "PeerId={0}, ActivePeers {1}", PeerId, session.ActivePeers.Count);
			session.OnPlayerConnect (PeerId);

			pool.Push (this);
		}
	}
}

