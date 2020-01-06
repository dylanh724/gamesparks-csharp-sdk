using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;


namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class LoginResult : AbstractResult, IRTCommand
	{
		internal static ObjectPool<LoginResult> pool = new ObjectPool<LoginResult> (() => {
			return new LoginResult();
		}, (instance) => {
			instance.ActivePeers.Clear();
			instance.FastPort = null;
			instance.ReconnectToken = null;
			instance.PeerId = null;

		});

		public override void Execute(){

			session.ConnectToken = this.ReconnectToken;
			session.PeerId = this.PeerId;

			if (packet.Reliable.GetValueOrDefault (true)) {

				if (this.FastPort.HasValue && this.FastPort.Value != 0) {
					session.FastPort = this.FastPort.Value;
				}

				session.ActivePeers.Clear ();
				session.ActivePeers.AddRange(ActivePeers);
				session.ConnectState = GameSparksRT.ConnectState.ReliableOnly;
				session.ConnectFast ();
				session.Log ("LoginResult", GameSparksRT.LogLevel.DEBUG, "{0} TCP LoginResult.ActivePeers {1} FastPort {2}", session.PeerId, session.ActivePeers.Count, session.FastPort);
			} else {
				session.ConnectState = GameSparksRT.ConnectState.ReliableAndFastSend;
				session.Log ("LoginResult", GameSparksRT.LogLevel.DEBUG, "{0} UDP LoginResult, ActivePeers {1}", session.PeerId, session.ActivePeers.Count);
			}
			pool.Push (this);
		}

		internal override bool ExecuteAsync()
		{
			return false;
		}
	}
}

