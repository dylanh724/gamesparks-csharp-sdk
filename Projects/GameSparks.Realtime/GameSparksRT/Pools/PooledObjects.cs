using System;
using System.IO;
using System.Collections.Generic;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.RT.Commands;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Pools
{
	internal class PooledObjects
	{
		
		public static ObjectPool<MemoryStream> MemoryStreamPool { get; private set;}
		public static ObjectPool<CustomRequest> CustomRequestPool { get; private set;}
		public static ObjectPool<PositionStream> PositionStreamPool { get; private set;}
		public static ObjectPool<LimitedPositionStream> LimitedPositionStreamPool { get; private set;}
		public static ObjectPool<byte[]> ByteBufferPool { get; private set;}
		public static ObjectPool<Packet> PacketPool { get; private set;}

		static PooledObjects ()
		{
			PacketPool = new ObjectPool<Packet> (() => {
				return new Packet ();
			}, (packet) => {
				packet.Reset();
			});

			MemoryStreamPool = new ObjectPool<MemoryStream> (() => {
				return new BinaryWriteMemoryStream ();
			}, (stream) => {
				stream.Position = 0;
			});

			CustomRequestPool = new ObjectPool<CustomRequest>(() => {
				return new CustomRequest(); 
			}, (cr) => {cr.Reset();});

			PositionStreamPool = new ObjectPool<PositionStream>(()=>{
				return new PositionStream();
			});

			LimitedPositionStreamPool = new ObjectPool<LimitedPositionStream>(()=>{
				return new LimitedPositionStream();
			});

			ByteBufferPool = new ObjectPool<byte[]>(()=>{
				return new byte[256];
			});


		}
	}

}

