using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Org.BouncyCastle.Crypto.Tls;

namespace SuperSocket.ClientEngine
{
    public class SslStreamTcpSession : TcpClientSession
    {
        class SslAsyncState
        {
            public Stream SslStream { get; set; }

            public Socket Client { get; set; }

            public PosList<ArraySegment<byte>> SendingItems { get; set; }
        }

        private Stream m_SslStream;

        public bool AllowUnstrustedCertificate { get; set; }

        public SslStreamTcpSession(EndPoint remoteEndPoint)
            : base(remoteEndPoint)
        {

        }

        public SslStreamTcpSession(EndPoint remoteEndPoint, int receiveBufferSize)
            : base(remoteEndPoint, receiveBufferSize)
        {

        }

        protected override void SocketEventArgsCompleted(object sender, SocketAsyncEventArgs e)
        {
            ProcessConnect(sender as Socket, null, e);
        }

        protected override void OnGetSocket(SocketAsyncEventArgs e)
        {
            try
            {
				m_SslStream = GameSparks.RT.GSTlsClient.WrapStream(new NetworkStream(Client), HostName);

				OnConnected();

				if (Buffer.Array == null)
					Buffer = new ArraySegment<byte>(new byte[ReceiveBufferSize], 0, ReceiveBufferSize);

				BeginRead();
                
            }
            catch (Exception exc)
            {
				if (!IsIgnorableException(exc) || exc is TlsFatalAlert)
                    OnError(exc);
            }
        }

        private void OnDataRead(IAsyncResult result)
        {
            var state = result.AsyncState as SslAsyncState;

            if (state == null || state.SslStream == null)
            {
                OnError(new NullReferenceException("Null state or stream."));
                return;
            }

            var sslStream = state.SslStream;

            int length = 0;

            try
            {
                length = sslStream.EndRead(result);
            }
            catch (Exception e)
            {
				if (!IsIgnorableException(e) && m_SslStream != null)
                    OnError(e);

                if (EnsureSocketClosed(state.Client))
                    OnClosed();

                return;
            }

            if (length == 0)
            {
                if (EnsureSocketClosed(state.Client))
                    OnClosed();

                return;
            }

            OnDataReceived(Buffer.Array, Buffer.Offset, length);
            BeginRead();
        }

        void BeginRead()
        {
            var client = Client;

            if (client == null || m_SslStream == null)
                return;

            try
            {
                m_SslStream.BeginRead(Buffer.Array, Buffer.Offset, Buffer.Count, OnDataRead, new SslAsyncState { SslStream = m_SslStream, Client = client });
            }
            catch (Exception e)
            {
                if (!IsIgnorableException(e))
                    OnError(e);

                if (EnsureSocketClosed(client))
                    OnClosed();
            }
        }

        protected override bool IsIgnorableException(Exception e)
        {
            if (base.IsIgnorableException(e))
                return true;

            if (e is System.IO.IOException)
            {
                if (e.InnerException is ObjectDisposedException)
                    return true;

                //In mono, some exception is wrapped like IOException -> IOException -> ObjectDisposedException
                if (e.InnerException is System.IO.IOException)
                {
                    if (e.InnerException.InnerException is ObjectDisposedException)
                        return true;
                }
            }

            return false;
        }

        protected override void SendInternal(PosList<ArraySegment<byte>> items)
        {

			var client = this.Client;

            try
            {
                var item = items[items.Position];
				GameSparks.Core.GameSparksUtil.Log("SendInternal items.length=" + items.Count);

				GameSparks.Core.GameSparksUtil.Log(m_SslStream.ToString());

				//m_SslStream.Write(item.Array, item.Offset, item.Count);

				//OnWriteComplete(new SslAsyncState { SslStream = m_SslStream, Client = client, SendingItems = items });

				m_SslStream.BeginWrite(item.Array, item.Offset, item.Count,
				    OnWriteComplete, new SslAsyncState { SslStream = m_SslStream, Client = client, SendingItems = items });

				GameSparks.Core.GameSparksUtil.Log("SendInternal, done");
            }
            catch (Exception e)
            {
                if (!IsIgnorableException(e))
                    OnError(e);

                if (EnsureSocketClosed(client))
                    OnClosed();
            }
        }

		private void OnWriteComplete(IAsyncResult result)
        {
			GameSparks.Core.GameSparksUtil.Log("OnWriteComplete");

            var state = result.AsyncState as SslAsyncState;

            if (state == null || state.SslStream == null)
            {
                OnError(new NullReferenceException("State of Ssl stream is null."));
                return;
            }

            var sslStream = state.SslStream;

            try
            {
                sslStream.EndWrite(result);
            }
            catch (Exception e)
            {
                if (!IsIgnorableException(e))
                    OnError(e);

                if (EnsureSocketClosed(state.Client))
                    OnClosed();

                return;
            }

            var items = state.SendingItems;
            var nextPos = items.Position + 1;

            //Has more data to send
            if (nextPos < items.Count)
            {
                items.Position = nextPos;
                SendInternal(items);
                return;
            }

            try
            {
                //m_SslStream.Flush();
            }
            catch (Exception e)
            {
                if (!IsIgnorableException(e))
                    OnError(e);

                if (EnsureSocketClosed(state.Client))
                    OnClosed();

                return;
            }

            OnSendingCompleted();
        }

        public override void Close()
        {
            var sslStream = m_SslStream;

            if (sslStream != null)
            {
                sslStream.Close();
                sslStream.Dispose();
                m_SslStream = null;
            }

            base.Close();
        }
    }
}
