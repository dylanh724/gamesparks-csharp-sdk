using System;
using System.IO;
using GameSparks.RT.Pools;
using Com.Gamesparks.Realtime.Proto;

namespace GameSparks.RT.Proto
{
	internal class RTValSerializer {

		internal static RTVal ReadRTVal(Stream stream, BinaryReader br)
		{
			RTVal instance = new RTVal();

			long limit = global::GameSparks.RT.Proto.ProtocolParser.ReadUInt32(stream);
			limit += stream.Position;
			while (true)
			{
				if (stream.Position >= limit)
				{
					if (stream.Position == limit)
						break;
					else
						throw new global::GameSparks.RT.Proto.ProtocolBufferException("Read past max limit");
				}
				int keyByte = stream.ReadByte();
				if (keyByte == -1)
					throw new System.IO.EndOfStreamException();
				// Optimized reading of known fields with field ID < 16
				switch (keyByte)
				{
				// Field 1 LengthDelimited
				case 10:
					instance.string_val = global::GameSparks.RT.Proto.ProtocolParser.ReadString(stream);
					continue;
					// Field 2 LengthDelimited
				case 18:
					// repeated packed
					long end2 = global::GameSparks.RT.Proto.ProtocolParser.ReadUInt32 (stream);
					end2 += stream.Position;
					RTVector v = new RTVector ();
					int i = 0;
					while (stream.Position < end2) {
						float read = br.ReadSingle ();
						switch (i) {
						case 0:
							v.x = read;
							break;
						case 1:
							v.y = read;
							break;
						case 2:
							v.z = read;
							break;
						case 3:
							v.w = read;
							break;
						default:
							break;
						}
						i++;
					}
					instance.vec_val = v;

					if (stream.Position != end2)
						throw new global::GameSparks.RT.Proto.ProtocolBufferException("Read too many bytes in packed data");
					continue;
					// Field 14 LengthDelimited
				case 114:
					if (instance.data_val == null) {
						instance.data_val = RTDataSerializer.cache.Pop ();
					}
					RTData.ReadRTData(stream, br, instance.data_val);
					continue;
				}

				var key = global::GameSparks.RT.Proto.ProtocolParser.ReadKey((byte)keyByte, stream);

				// Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field)
				{
				case 0:
					throw new global::GameSparks.RT.Proto.ProtocolBufferException("Invalid field id: 0, something went wrong in the stream");
				default:
					global::GameSparks.RT.Proto.ProtocolParser.SkipKey(stream, key);
					break;
				}
			}

			return instance;
		}

		/// <summary>Helper: Serialize with a varint length prefix</summary>
		internal static void WriteRTVal(Stream stream, RTVal val)
		{
			BinaryWriteMemoryStream ms = (BinaryWriteMemoryStream)PooledObjects.MemoryStreamPool.Pop ();
			try
			{
				if (val.string_val != null)
				{
					// Key for field: 1, LengthDelimited
					ms.WriteByte(10);
					global::GameSparks.RT.Proto.ProtocolParser.WriteBytes(ms, System.Text.Encoding.UTF8.GetBytes(val.string_val));
				} else if(val.data_val != null) { 
					ms.WriteByte(114); 
					RTData.WriteRTData(ms, val.data_val); 
				} else if (val.vec_val != null) {

					RTVector vec_value = val.vec_val.Value;
					// Key for field: 2, LengthDelimited
					ms.WriteByte(18);
					int numberOfFloatsSet = vec_value.w != null ? 4 : (vec_value.z != null ? 3 : (vec_value.y != null ? 2 : (vec_value.x != null ? 1 : 0)));
					global::GameSparks.RT.Proto.ProtocolParser.WriteUInt32(ms, 4u * (uint)numberOfFloatsSet);

					for(int i=0 ; i<numberOfFloatsSet ; i++){
						switch (i) {
						case 0:
							ms.BinaryWriter.Write(vec_value.x.Value);
							break;
						case 1:
							ms.BinaryWriter.Write(vec_value.y.Value);
							break;
						case 2:
							ms.BinaryWriter.Write(vec_value.z.Value);
							break;
						case 3:
							ms.BinaryWriter.Write(vec_value.w.Value);
							break;
						default:
							break;
						}
					}

				}

#if __WINDOWS__
                var data = ms.ToArray();
#else
				var data = ms.GetBuffer();
#endif
				global::GameSparks.RT.Proto.ProtocolParser.WriteUInt32(stream, (uint)ms.Position);
				stream.Write(data, 0, (int)ms.Position);
			}
			finally
			{
				PooledObjects.MemoryStreamPool.Push (ms);
			}
		}

	}
	
	internal class RTDataSerializer {
	
		internal static ObjectPool<RTData> cache = new ObjectPool<RTData>(() => {return new RTData();}, (rtData) => {
#if __WINDOWS__
            foreach (RTVal entry in rtData.data)
            {
                if (entry.data_val != null)
                {
                    entry.data_val.Dispose();
                }
                entry.Reset();
            }
#else
            Array.ForEach (rtData.data, (entry) => {
				if (entry.data_val != null) {
					entry.data_val.Dispose();
				}
				entry.Reset();
			});
#endif
        });

		public static RTData Get(){
			return RTDataSerializer.cache.Pop ();
		}

		internal static RTData ReadRTData (Stream stream, BinaryReader br, RTData instance){


			if (instance == null) {
				instance = cache.Pop();
			}

			long limit = global::GameSparks.RT.Proto.ProtocolParser.ReadUInt32(stream);
			limit += stream.Position;

			while (true)
			{
				if (stream.Position >= limit)
				{
					if (stream.Position == limit)
						break;
					else
						throw new global::GameSparks.RT.Proto.ProtocolBufferException("Read past max limit");
				}

				int keyByte = stream.ReadByte();

				if (keyByte == -1)
					break;

				var key = global::GameSparks.RT.Proto.ProtocolParser.ReadKey((byte)keyByte, stream);

//				if (key.Field == 0) {
//					throw new global::GameSparks.RT.Proto.ProtocolBufferException("Invalid field id: 0, something went wrong in the stream");
//				}

				switch (key.WireType) {
				case Wire.Varint:
					instance.data [key.Field] = new RTVal(ProtocolParser.ReadZInt64 (stream));
					break;
				case Wire.Fixed32:
					instance.data [key.Field] = new RTVal(br.ReadSingle ());
					break;
				case Wire.Fixed64:
					instance.data [key.Field] = new RTVal(br.ReadDouble ());
					break;
				case Wire.LengthDelimited:
					instance.data [key.Field] = RTVal.DeserializeLengthDelimited (stream, br);
					break;
				default:
					break;
				}

				// Reading field ID > 16 and unknown field ID/wire type combinations
				switch (key.Field)
				{
				case 0:
					throw new global::GameSparks.RT.Proto.ProtocolBufferException("Invalid field id: 0, something went wrong in the stream");
				default:
					break;
				}
			}

			return instance;
		}

		internal static void WriteRTData (Stream stream, RTData instance) {

			BinaryWriteMemoryStream ms = (BinaryWriteMemoryStream)PooledObjects.MemoryStreamPool.Pop ();

			for (uint index = 1; index < instance.data.Length; index++) {

				RTVal entry = instance.data [index];

				if (entry.long_val.HasValue) {
					ProtocolParser.WriteUInt32 (ms, index << 3);
					//ms.WriteByte ((byte)(index << 3));
					ProtocolParser.WriteZInt64 (ms, (long)entry.long_val.Value);

				} else if (entry.double_val.HasValue) {
					ProtocolParser.WriteUInt32 (ms, (index << 3) | ((uint)1));
					//ms.WriteByte ((byte)((index << 3) + 1));
					ms.BinaryWriter.Write ((double)entry.double_val.Value);

				} else if (entry.float_val.HasValue) {
					ProtocolParser.WriteUInt32 (ms, (index << 3) | ((uint)5));
					//ms.WriteByte ((byte)((index << 3) + 5));
					ms.BinaryWriter.Write ((float)entry.float_val.Value);

				} else if (entry.data_val  != null || entry.string_val != null || entry.vec_val != null) {
					ProtocolParser.WriteUInt32 (ms, (index << 3) | ((uint)2));
					//ms.WriteByte ((byte)((index << 3) + 2));
					entry.SerializeLengthDelimited (ms);
				}
			}

#if __WINDOWS__
            var buffer = ms.ToArray();
#else
			var buffer = ms.GetBuffer();
#endif

			global::GameSparks.RT.Proto.ProtocolParser.WriteUInt32(stream, (uint)ms.Position);
			stream.Write(buffer, 0, (int)ms.Position);

			PooledObjects.MemoryStreamPool.Push (ms);


		}
	}
}

