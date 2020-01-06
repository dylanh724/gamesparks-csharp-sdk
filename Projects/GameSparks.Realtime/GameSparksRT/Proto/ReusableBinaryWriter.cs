using System;
using System.IO;
using System.Text;

namespace GameSparks.RT
{
	internal class BinaryWriteMemoryStream : MemoryStream
	{
		public BinaryReader BinaryReader;
		public BinaryWriter BinaryWriter;

		internal BinaryWriteMemoryStream(){
			BinaryReader = new BinaryReader(this, Encoding.UTF8);
			BinaryWriter = new BinaryWriter(this, Encoding.UTF8);
		}
	}
}
