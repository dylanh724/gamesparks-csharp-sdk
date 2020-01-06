using System;

//
// Exception used in the generated code
//
namespace GameSparks.RT.Proto
{
	///<summary>>
	/// This exception is thrown when badly formatted protocol buffer data is read.
	///</summary>
	internal class ProtocolBufferException : Exception
	{
		public ProtocolBufferException(string message) : base(message)
		{
		}
	}
}
