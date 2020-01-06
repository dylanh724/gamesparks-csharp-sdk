using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using GameSparks.RT.Pools;


namespace Com.Gamesparks.Realtime.Proto
{
	internal partial class PingResult : AbstractResult
	{
		internal static ObjectPool<PingResult> pool = new ObjectPool<PingResult> (() => {
			return new PingResult();
		});

		public override void Execute(){
			session.Log ("PingResult", GameSparksRT.LogLevel.DEBUG, "");
			pool.Push (this);
		}

		internal override bool ExecuteAsync()
		{
			return false;
		}
	}
}

