using System;
using System.IO;
using System.Text;

namespace GameSparks.RT
{
	/// <summary>
	/// Wrapper for streams that does not support the Position property.
	/// Adds support for the Position property.
	/// </summary>
	internal class PositionStream : Stream
	{
		Stream stream;

		//Pre-allocate
		byte[] readByte = new byte[1];

		internal BinaryReader BinaryReader;

		internal PositionStream(){
			BinaryReader = new BinaryReader(this, Encoding.UTF8);
		}

		/// <summary>
		/// Bytes left to read
		/// </summary>
		public int BytesRead { get; private set; }

		/// <summary>
		/// Define how many bytes are allowed to read
		/// </summary>
		/// <param name='baseStream'>
		/// Base stream.
		/// </param>
		/// <param name='maxLength'>
		/// Max length allowed to read from the stream.
		/// </param>
		public PositionStream Wrap(Stream baseStream)
		{
			this.BytesRead = 0;
			this.stream = baseStream;
			return this;
		}

		public override void Flush()
		{
			throw new NotImplementedException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int read = stream.Read(buffer, offset, count);
			BytesRead += read;
			return read;
		}

		public override int ReadByte()
		{
			if (Read (readByte, 0, 1) == 1) {
				return readByte [0];
			}
			return -1;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			for (int i = 0; i < offset; i++) {
				ReadByte ();
			}
			return BytesRead;
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override bool CanRead
		{
			get
			{
				return true;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		public override long Length
		{
			get
			{
				return stream.Length;
			}
		}

		public override long Position
		{
			get
			{
				return this.BytesRead;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

#if __WINDOWS__
        public void Close()
        {
            base.Dispose();
        }
#else
        public override void Close()
		{
			base.Close();
		}
#endif

        protected override void Dispose(bool disposing)
		{
			stream.Dispose();
			base.Dispose(disposing);
		}

	}
}

