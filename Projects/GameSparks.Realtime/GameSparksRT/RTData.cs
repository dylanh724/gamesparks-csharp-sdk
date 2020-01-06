using System;
using System.IO;
using GameSparks.RT.Proto;
using Com.Gamesparks.Realtime.Proto;

namespace GameSparks.RT
{
	public struct RTPacket {

		public RTPacket(int opCode, int sender, Stream limitedStream, int limit, RTData data, int packetSize){
			this.OpCode = opCode;
			this.Sender = sender;
			this.Stream = limitedStream;
			this.StreamLength = limit;
			this.Data = data;
			this.PacketSize = packetSize;
		}

		public int OpCode;
		public int Sender;
		public Stream Stream;
		public int StreamLength;
		public RTData Data;
		public int PacketSize;

		public override string ToString(){
			return "OpCode=" + OpCode + ",Sender=" + Sender + ",streamExists=" + (Stream != null) + (Stream==null ? "" : ",StreamLength=" + StreamLength) + ",Data=" + (Data != null ? Data.ToString() : ".PacketSize=" + PacketSize);
		}
	}

	public struct RTVector {
		public float? x;
		public float? y;
		public float? z;
		public float? w;

		public RTVector(float x, float y){
			this.x = x;
			this.y = y;
			this.z = null;
			this.w = null;
		}

		public RTVector(float x, float y, float z){
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = null;
		}

		public RTVector(float x, float y, float z, float w){
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}
	}

	public class RTData : IDisposable {

		public static RTData Get(){
			return RTDataSerializer.cache.Pop ();
		}

		internal RTVal[] data = new RTVal[GameSparksRT.MAX_RTDATA_SLOTS];

		public void Dispose(){

			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].Dirty())
				{
					data[i] = new RTVal();
				}
			}

			RTDataSerializer.cache.Push (this);
		}

		internal static RTData ReadRTData (Stream stream, BinaryReader br, RTData instance){
			return RTDataSerializer.ReadRTData (stream, br, instance);
		}

		internal static void WriteRTData (Stream stream, RTData instance) {
			RTDataSerializer.WriteRTData (stream, instance);
		}

		public int? GetInt(uint index){
			if(data[index].long_val.HasValue)
				return (int)(data[index].long_val);

			return null;
		}

		public RTVector? GetRTVector(uint index){
			return data[index].vec_val;
		}

		public long? GetLong(uint index){
			return data[index].long_val;
		}

		public float? GetFloat(uint index){
			return data[index].float_val;
		}

		public double? GetDouble(uint index){
			return data[index].double_val;
		}

		public string GetString(uint index){
			return data[index].string_val;
		}

		public RTData GetData(uint index){
			return data[index].data_val;
		}

		public RTData SetInt(uint index, int value){
			data[index] = new RTVal((long)value);
			return this;
		}

		public RTData SetLong(uint index, long value){
			data[index] = new RTVal(value);
			return this;
		}

		public RTData SetRTVector(uint index, RTVector value){
			data[index] = new RTVal(value);
			return this;
		}

		public RTData SetFloat(uint index, float value){
			data[index] = new RTVal(value);
			return this;
		}

		public RTData SetDouble(uint index, double value){
			data[index] = new RTVal(value);
			return this;
		}

		public RTData SetString(uint index, string value){
			data[index] = new RTVal(value);
			return this;
		}

		public RTData SetData(uint index, RTData value){
			data[index] = new RTVal(value);
			return this;
		}

		public override string ToString ()
		{
			return AsString ();
		}

		internal string AsString ()
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder (" {");
			for (int i = 0; i < 128; i++) {
				String val = data [i].AsString();
				if (val != null) {
					builder.Append (" [" + i + " " + val + "] ");
				}
			}
			builder.Append ("} ");
			return builder.ToString ();
		}

	}
}

