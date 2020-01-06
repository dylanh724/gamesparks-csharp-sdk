using System;
using GameSparks.RT.Pools;
#if __WINDOWS__
using Windows.System.Threading;
#else
using System.Threading;
#endif

namespace GameSparks.RT
{
	internal class LogCommand : IRTCommand
	{
		public static ObjectPool<LogCommand> pool = new ObjectPool<LogCommand>(() => {return new LogCommand();});
			
		String tag, msg;
		GameSparks.RT.GameSparksRT.LogLevel level;
		object[] formatParams;
		IRTSession session;

		public LogCommand Configure(IRTSession session, String tag, GameSparks.RT.GameSparksRT.LogLevel level, String msg, params object[] formatParams)
		{
			this.tag = tag;
			this.level = level;
			this.formatParams = formatParams;
			this.msg = msg;
			this.session = session;
			return this;
		}

		public void Execute()
		{
			try{
				if(GameSparksRT.ShouldLog(tag, level))
				{
					GameSparksRT.Logger (session.PeerId + " " + tag + ":" + String.Format (msg, formatParams));
				}
			}finally {
				pool.Push (this);
			}
		}

	}
}

