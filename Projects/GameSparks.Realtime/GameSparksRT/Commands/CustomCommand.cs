using System;
using System.IO;
#if __WINDOWS__
using Windows.System.Threading;
#else
using System.Threading;
#endif
using GameSparks.RT.Pools;
using GameSparks.RT.Proto;

namespace GameSparks.RT
{
	internal class CustomCommand : IRTCommand
	{
		internal static ObjectPool<CustomCommand> pool = new ObjectPool<CustomCommand>(() => {return new CustomCommand();});

		IRTSessionInternal session;
		int opCode, sender, limit, packetSize;
		MemoryStream ms;
		LimitedPositionStream limitedStream;
		RTData data;

		internal CustomCommand Configure(int opCode, int sender, Stream lps, RTData data, int limit, IRTSessionInternal session, int packetSize)
		{
			ms = PooledObjects.MemoryStreamPool.Pop();
			this.packetSize = packetSize;
			this.opCode = opCode;
			this.sender = sender;
			this.data = data;
			this.session = session;
			this.limit = limit;
			this.limitedStream = null;

			if (lps != null) {

				limitedStream = PooledObjects.LimitedPositionStreamPool.Pop ();

				for (int i = 0; i < limit; i++) {
					byte read = (byte)lps.ReadByte ();
					ms.WriteByte (read);
				}
				ms.Position = 0;
				limitedStream.Wrap (ms, limit);

			}

			return this;
		}

		public void Execute()
		{
			try{
				session.SessionListener.OnPacket(new RTPacket(opCode, sender, limitedStream, limit, data, packetSize));
			}finally {
				PooledObjects.MemoryStreamPool.Push (ms);
				PooledObjects.LimitedPositionStreamPool.Push (limitedStream);
				pool.Push (this);
			}
		}

	}
}

