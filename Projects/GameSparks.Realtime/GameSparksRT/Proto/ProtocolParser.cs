
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

// 
//  Read/Write string and byte arrays 
// 
using GameSparks.RT.Pools;


namespace GameSparks.RT.Proto
{

	internal enum Wire
	{

		Varint = 0,          //int32, int64, UInt32, UInt64, SInt32, SInt64, bool, enum
		Fixed64 = 1,         //fixed64, sfixed64, double
		LengthDelimited = 2, //string, bytes, embedded messages, packed repeated fields
		Fixed32 = 5,         //32-bit    fixed32, SFixed32, float
	}

	internal struct Key
	{
		internal uint Field { get; set; }

		internal Wire WireType { get; set; }

		internal Key(uint field, Wire wireType) : this()
		{
			this.Field = field;
			this.WireType = wireType;
		}

		public override string ToString()
		{
			return string.Format("[Key: {0}, {1}]", Field, WireType);
		}
	}

	internal struct KeyValue
	{
		public Key Key { get; set; }

		public byte[] Value { get; set; }

		public KeyValue(Key key, byte[] value) : this()
		{
			this.Key = key;
			this.Value = value;
		}

		public override string ToString()
		{
			return string.Format("[KeyValue: {0}, {1}, {2} bytes]", Key.Field, Key.WireType, Value.Length);
		}
	}

	internal static class ProtocolParser
    {
		internal static ObjectPool<MemoryStream> Stack = PooledObjects.MemoryStreamPool;

		internal static Key ReadKey(byte firstByte, Stream stream)
		{
			if (firstByte < 128)
				return new Key((uint)(firstByte >> 3), (Wire)(firstByte & 0x07));
			uint fieldID = ((uint)ReadUInt32(stream) << 4) | ((uint)(firstByte >> 3) & 0x0F);
			return new Key(fieldID, (Wire)(firstByte & 0x07));
		}

		/// <summary>
		/// Seek past the value for the previously read key.
		/// </summary>
		internal static void SkipKey(Stream stream, Key key)
		{
			switch (key.WireType)
			{
			case Wire.Fixed32:
				stream.Seek(4, SeekOrigin.Current);
				return;
			case Wire.Fixed64:
				stream.Seek(8, SeekOrigin.Current);
				return;
			case Wire.LengthDelimited:
				stream.Seek(ProtocolParser.ReadUInt32(stream), SeekOrigin.Current);
				return;
			case Wire.Varint:
				ProtocolParser.ReadSkipVarInt(stream);
				return;
			default:
				throw new NotImplementedException("Unknown wire type: " + key.WireType);
			}
		}

        internal static string ReadString(Stream stream)
        {
			//VarInt length
			int length = (int)ReadUInt32(stream);

			MemoryStream ms = PooledObjects.MemoryStreamPool.Pop ();

			byte[] buffer = PooledObjects.ByteBufferPool.Pop ();

			int read = 0;

			while (read < length) {
				int r = stream.Read(buffer, 0, Math.Min(length - read, buffer.Length));
				if (r == 0)
					throw new ProtocolBufferException("Expected " + (length - read) + " got " + read);
				ms.Write (buffer, 0, r);
				read += r;
			}

#if __WINDOWS__
            string ret = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Position); 
#else
			string ret = Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Position);
#endif

            PooledObjects.ByteBufferPool.Push (buffer);
			PooledObjects.MemoryStreamPool.Push (ms);
			return ret;
        }

        internal static void WriteString(Stream stream, string val)
        {
            WriteBytes(stream, Encoding.UTF8.GetBytes(val));
        }

        /// <summary>
        /// Writes length delimited byte array
        /// </summary>
        internal static void WriteBytes(Stream stream, byte[] val)
        {
            WriteUInt32(stream, (uint)val.Length);
            stream.Write(val, 0, val.Length);
        }

		/// <summary>
		/// Writes length delimited byte array
		/// </summary>
		internal static void WriteBytes(Stream stream, byte[] val, int len)
		{
			WriteUInt32(stream, (uint)len);
			stream.Write(val, 0, len);
		}


		/// <summary>
        /// Reads past a varint for an unknown field.
        /// </summary>
        internal static void ReadSkipVarInt(Stream stream)
        {
            while (true)
            {
                int b = stream.ReadByte();
                if (b < 0)
                    throw new IOException("Stream ended too early");

                if ((b & 0x80) == 0)
                    return; //end of varint
            }
        }

        /// <summary>
        /// Zig-zag signed VarInt format
        /// </summary>
        internal static int ReadZInt32(Stream stream)
        {
            uint val = ReadUInt32(stream);
            return (int)(val >> 1) ^ ((int)(val << 31) >> 31);
        }

        /// <summary>
        /// Zig-zag signed VarInt format
        /// </summary>
        internal static void WriteZInt32(Stream stream, int val)
        {
            WriteUInt32(stream, (uint)((val << 1) ^ (val >> 31)));
        }

        /// <summary>
        /// Unsigned VarInt format
        /// Do not use to read int32, use ReadUint64 for that.
        /// </summary>
        internal static uint ReadUInt32(Stream stream)
        {
            int b;
            uint val = 0;

            for (int n = 0; n < 5; n++)
            {
                b = stream.ReadByte();
                if (b < 0)
                    throw new IOException("Stream ended too early");

                //Check that it fits in 32 bits
                if ((n == 4) && (b & 0xF0) != 0)
                    throw new ProtocolBufferException("Got larger VarInt than 32bit unsigned");
                //End of check

                if ((b & 0x80) == 0)
                    return val | (uint)b << (7 * n);

                val |= (uint)(b & 0x7F) << (7 * n);
            }

            throw new ProtocolBufferException("Got larger VarInt than 32bit unsigned");
        }

        /// <summary>
        /// Unsigned VarInt format
        /// </summary>
        internal static void WriteUInt32(Stream stream, uint val)
        {
            byte b;
            while (true)
            {
                b = (byte)(val & 0x7F);
                val = val >> 7;
                if (val == 0)
                {
                    stream.WriteByte(b);
                    break;
                }
                else
                {
                    b |= 0x80;
                    stream.WriteByte(b);
                }
            }
        }

        /// <summary>
        /// Zig-zag signed VarInt format
        /// </summary>
        internal static long ReadZInt64(Stream stream)
        {
            ulong val = ReadUInt64(stream);
            return (long)(val >> 1) ^ ((long)(val << 63) >> 63);
        }

        /// <summary>
        /// Zig-zag signed VarInt format
        /// </summary>
        internal static void WriteZInt64(Stream stream, long val)
        {
            WriteUInt64(stream, (ulong)((val << 1) ^ (val >> 63)));
        }

        /// <summary>
        /// Unsigned VarInt format
        /// </summary>
        internal static ulong ReadUInt64(Stream stream)
        {
            int b;
            ulong val = 0;

            for (int n = 0; n < 10; n++)
            {
                b = stream.ReadByte();
                if (b < 0)
                    throw new IOException("Stream ended too early");

                //Check that it fits in 64 bits
                if ((n == 9) && (b & 0xFE) != 0)
                    throw new ProtocolBufferException("Got larger VarInt than 64 bit unsigned");
                //End of check

                if ((b & 0x80) == 0)
                    return val | (ulong)b << (7 * n);

                val |= (ulong)(b & 0x7F) << (7 * n);
            }

            throw new ProtocolBufferException("Got larger VarInt than 64 bit unsigned");
        }

        /// <summary>
        /// Unsigned VarInt format
        /// </summary>
        internal static void WriteUInt64(Stream stream, ulong val)
        {
            byte b;
            while (true)
            {
                b = (byte)(val & 0x7F);
                val = val >> 7;
                if (val == 0)
                {
                    stream.WriteByte(b);
                    break;
                }
                else
                {
                    b |= 0x80;
                    stream.WriteByte(b);
                }
            }
        }

        internal static bool ReadBool(Stream stream)
        {
            int b = stream.ReadByte();
            if (b < 0)
                throw new IOException("Stream ended too early");
            if (b == 1)
                return true;
            if (b == 0)
                return false;
            throw new ProtocolBufferException("Invalid boolean value");
        }

        internal static void WriteBool(Stream stream, bool val)
        {
            stream.WriteByte(val ? (byte)1 : (byte)0);
        }

    }
}
