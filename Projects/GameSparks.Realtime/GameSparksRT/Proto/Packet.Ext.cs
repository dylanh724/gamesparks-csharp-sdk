using System;
using GameSparks.RT.Commands;
using GameSparks.RT;
using System.IO;
using GameSparks.RT.Pools;
using System.Collections.Generic;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Proto
{

	internal partial class Packet
	{
		public RTRequest Request { get; set; }

		internal bool hasPayload;
		internal IRTCommand Command { get; set; }
		internal IRTSessionInternal Session { get; set; }

		internal void Reset(){
			OpCode = 0;
			SequenceNumber = null;
			RequestId = null;
			TargetPlayers = null;
			Sender = null;
			Reliable = null;
			Payload = null;
			Command = null;
			Request = null;
			hasPayload = false;
			Data = null;
		}

		public String toString(){
			return "{OpCode:" + OpCode + ",TargetPlayers:" + TargetToString() + "}";
		}

		private String TargetToString(){
			String s = "[";

			if (TargetPlayers != null) {
				foreach (int val in TargetPlayers) {
					s += val + " ";
				}
			}

			return s += "]";
		}

		private byte[] ReadPayload (Stream stream, int packetSize)
		{
			hasPayload = true;
			Command = CommandFactory.GetCommand (OpCode, Sender.GetValueOrDefault(0), SequenceNumber, stream, Session, Data, packetSize);
			return null;
		}

		private void WritePayload (Stream stream)
		{
			if (Request != null) {
				// Key for field: 15, LengthDelimited
				MemoryStream ms = PooledObjects.MemoryStreamPool.Pop();
				try{
					Request.Serialize (ms);
#if __WINDOWS__
                    byte[] written = ms.ToArray();
#else
					byte[] written = ms.GetBuffer();
#endif
					if (ms.Position > 0) {
						stream.WriteByte (122);
						global::GameSparks.RT.Proto.ProtocolParser.WriteBytes (stream, written, (int)ms.Position);
					}
				}finally { 
					PooledObjects.MemoryStreamPool.Push (ms);
				}
			} else {
				if (Payload != null)
				{
					// Key for field: 15, LengthDelimited
					stream.WriteByte(122);
					global::GameSparks.RT.Proto.ProtocolParser.WriteBytes(stream, Payload);
				}
			}
		}

	}

	internal struct RTVal
	{
		internal long? long_val;
		internal float? float_val;
		internal double? double_val;
		internal RTData data_val;
		internal string string_val;
		internal RTVector? vec_val;

		internal void Reset(){
			if (data_val != null) {
				data_val.Dispose ();
			}
			long_val = null;
			float_val = null;
			double_val = null;
			data_val = null;
			string_val = null;
			vec_val = null;
		}

		internal RTVal(long value){
			long_val = value;
			float_val = null;
			double_val = null;
			data_val = null;
			string_val = null;
			vec_val = null;
		}

		internal RTVal(float value){
			long_val = null;
			float_val = value;
			double_val = null;
			data_val = null;
			string_val = null;
			vec_val = null;
		}

		internal RTVal(double value){
			long_val = null;
			float_val = null;
			double_val = value;
			data_val = null;
			string_val = null;
			vec_val = null;
		}

		internal RTVal(string value){
			long_val = null;
			float_val = null;
			double_val = null;
			data_val = null;
			string_val = value;
			vec_val = null;
		}
		internal RTVal(RTData value){
			long_val = null;
			float_val = null;
			double_val = null;
			data_val = value;
			string_val = null;
			vec_val = null;
		}

		internal RTVal(RTVector value){
			long_val = null;
			float_val = null;
			double_val = null;
			data_val = null;
			string_val = null;
			vec_val = value;
		}

		internal static RTVal DeserializeLengthDelimited(Stream stream, BinaryReader br)
		{
			return RTValSerializer.ReadRTVal (stream, br);
		}

		/// <summary>Helper: Serialize with a varint length prefix</summary>
		internal void SerializeLengthDelimited(Stream stream)
		{
			RTValSerializer.WriteRTVal (stream, this);
		}

		internal bool Dirty()
		{
			if (float_val != null)
			{
				return true;
			}
			else if (long_val != null)
			{
				return true;
			}
			else if (double_val != null)
			{
				return true;
			}
			else if (data_val != null)
			{
				return true;
			}
			else if (string_val != null)
			{
				return true;
			}
			else if (vec_val != null)
			{
				return true;
			}
			return false;
		}

		internal string AsString(){

			if (float_val != null) {
				return float_val.ToString();
			} else if (long_val != null) {
				return long_val.ToString();
			} else if (double_val != null) {
				return double_val.ToString();
			} else if (data_val != null) {
				return data_val.ToString();
			} else if (string_val != null) {
				return "\"" + string_val + "\"";
			} else if (vec_val != null) {
				return "|"+vec_val.Value.x+"|"+vec_val.Value.y+"|"+vec_val.Value.z+"|"+vec_val.Value.w+"|";
			}
			return null;
		}

	}

}
