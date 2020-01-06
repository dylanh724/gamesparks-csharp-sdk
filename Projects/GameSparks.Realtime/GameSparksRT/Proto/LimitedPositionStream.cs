using System;
using System.IO;
using GameSparks.RT.Pools;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Proto
{
	internal class LimitedPositionStream : PositionStream
	{
		long limit;

		public void Wrap (Stream baseStream, long limit)
		{
			base.Wrap (baseStream);
			this.limit = limit;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int toRead = (count > limit - BytesRead) ? (int)(limit - BytesRead) : count;
			return base.Read(buffer, offset, toRead);
		}

		public override int ReadByte()
		{
			return (BytesRead >= limit) ? -1 : base.ReadByte ();
		}

		public void SkipToEnd(){
			if (BytesRead < limit) {
				byte[] discardBytes = PooledObjects.ByteBufferPool.Pop ();
				try{
					while (256 == Read (discardBytes, BytesRead, 256)) {}
				}finally{
					PooledObjects.ByteBufferPool.Push (discardBytes);
				}
			}
		}
	}
}

