using System;
#if __WINDOWS__
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.Networking.Sockets;
using Windows.System.Threading;
using Windows.Security.Cryptography.Certificates;
using System.Threading.Tasks;
using System.Collections.Generic;
using Windows.Networking;
#else
using System.Net.Sockets;
using Org.BouncyCastle.Crypto.Tls;
using Org.BouncyCastle.Security;
#endif
using System.Text;
using Com.Gamesparks.Realtime.Proto;
using System.IO;
using GameSparks.RT.Commands;
using GameSparks.RT.Pools;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Connection
{
	internal class ReliableConnection : Connection
	{
#if __WINDOWS__
        private StreamSocket client;
        private bool connected = false;
#else
        private TcpClient client;
		private Stream clientStream;
		private string remotehost;
#endif

        public ReliableConnection(string remotehost, int remoteport, IRTSessionInternal session) : base(remotehost, remoteport, session)
		{

#if __WINDOWS__
            client = new StreamSocket();

            client.Control.NoDelay = true;
            client.Control.KeepAlive = true;
            //client.Control.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted | ChainValidationResult.InvalidName);

            System.Diagnostics.Debug.WriteLine("*** Connecting to server...");

            connected = false;

            Task t = Task.Run(() =>
            {
                connected = ConnectAsync(remotehost, remoteport).Result;

                ConnectCallback();
            });  
#else
            bool ipv6 = false;

            this.remotehost = remotehost;

            if (remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6)
            {
                try
                {
                    if (Socket.OSSupportsIPv6)
                    {
                        ipv6 = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Socket.OSSupportsIPv6: " + e.ToString());
                }

                try
                {
                    if (Socket.SupportsIPv6)
                    {
                        ipv6 = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Socket.SupportsIPv6: " + e.ToString());
                }
            }

            if (ipv6)
            {
                client = new TcpClient(AddressFamily.InterNetworkV6);

                Console.WriteLine("IPv6 on!");
            }
            else
            {
                client = new TcpClient(AddressFamily.InterNetwork);
            }

            client.NoDelay = true;
			client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
			client.BeginConnect (remoteEndPoint.Address, remoteEndPoint.Port, new AsyncCallback (ConnectCallback), null);
#endif
        }

#if __WINDOWS__
        private async Task<bool> ConnectAsync(string remotehost, int remoteport)
        {
            try
            {
                //string certInformation;

                //try
                //{
                //await client.ConnectAsync(endPoint, SocketProtectionLevel.Tls12);
                await client.ConnectAsync(new HostName(remotehost), remoteport.ToString(), SocketProtectionLevel.Tls12);

                return true;
                /*} 
                catch (Exception e)
                {
                    if (client.Information.ServerCertificateErrorSeverity == SocketSslErrorSeverity.Ignorable && client.Information.ServerCertificateErrors.Count > 0)
                    {
                        client.Control.IgnorableServerCertificateErrors.Clear();
                        foreach (ChainValidationResult ignorableError in client.Information.ServerCertificateErrors)
                        {
                            client.Control.IgnorableServerCertificateErrors.Add(ignorableError);
                        }

                        await client.ConnectAsync(endPoint, SocketProtectionLevel.Tls12);
                        //System.Diagnostics.Debug.WriteLine("CONNECTED");

                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(e);

                        //System.Diagnostics.Debug.WriteLine("NOT IGNORABLE");
                    }
                }*/

                //certInformation = GetCertificateInformation(client.Information.ServerCertificate,
                //    client.Information.ServerIntermediateCertificates);

                //System.Diagnostics.Debug.WriteLine("Connected to server. Certificate information: " + Environment.NewLine + certInformation);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);

                return false;
            }
        }

        /*private string GetCertificateInformation(
            Certificate serverCert,
            IReadOnlyList<Certificate> intermediateCertificates)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\tFriendly Name: " + serverCert.FriendlyName);
            sb.AppendLine("\tSubject: " + serverCert.Subject);
            sb.AppendLine("\tIssuer: " + serverCert.Issuer);
            sb.AppendLine("\tValidity: " + serverCert.ValidFrom + " - " + serverCert.ValidTo);

            // Enumerate the entire certificate chain.
            if (intermediateCertificates.Count > 0)
            {
                sb.AppendLine("\tCertificate chain: ");
                foreach (var cert in intermediateCertificates)
                {
                    sb.AppendLine("\t\tIntermediate Certificate Subject: " + cert.Subject);
                }
            }
            else
            {
                sb.AppendLine("\tNo certificates within the intermediate chain.");
            }

            return sb.ToString();
        }*/
#endif

        public override int Send(RTRequest request)
        {
#if __WINDOWS__
            if (client != null && connected)
#else
            if (client.Connected)			
#endif
            {
                Packet p = request.ToPacket(session, false);
                try
                {
#if __WINDOWS__
                    MemoryStream stream = new MemoryStream();

                    int result = Packet.SerializeLengthDelimited(stream, p);

                    Task t = Task.Run(async () =>
                    {
                        DataWriter writer = new DataWriter(client.OutputStream);

                        writer.WriteBytes(stream.ToArray());

                        await writer.StoreAsync();
                        await writer.FlushAsync();

                        writer.DetachStream();
                        writer.Dispose();
                    });
                    t.Wait();

                    return result;
#else
                    int ret = Packet.SerializeLengthDelimited(clientStream, p);
					clientStream.Flush();
					return ret;

#endif
                }
                catch (Exception e)
                {

                    if (session != null && !stopped)
                    {
                        session.ConnectState = GameSparksRT.ConnectState.Disconnected;
                        session.Log("ReliableConnection", GameSparksRT.LogLevel.DEBUG, e.Message);
                        try
                        {
                            session.OnReady(false);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex);
                        }
                    }
                    return 0;
                }
                finally
                {
                    PooledObjects.PacketPool.Push(p);
                }
            }
			return -1;
		}

#if __WINDOWS__
        private void ConnectCallback()
#else
        private void ConnectCallback(IAsyncResult result)
#endif
        {

            //We can get here is the connection fails and the monotor thread
            // calls close. We should just do nothing at this point
#if __WINDOWS__
            if (client == null || !connected)
            {
                return;
            }

            if (stopped)
            {
                if (connected)
                {
                    client.Dispose();
                }
                return;
            }
#else
            if ((client != null && !client.Connected)) {
				return;
			}

			if (stopped) {
				if (client.Connected) {
					client.Close ();
				}
				return;
			}

			clientStream = GSTlsClient.WrapStream(client.GetStream(), remotehost);

#endif

            //Each time a tcp connection is established we re-authenticate
            try {
                LoginCommand loginCmd = new LoginCommand(session.ConnectToken);

                Send(loginCmd);

                Packet p = PooledObjects.PacketPool.Pop();

                PositionStream rss = PooledObjects.PositionStreamPool.Pop();
#if __WINDOWS__
                rss.Wrap(client.InputStream.AsStreamForRead());
#else
                rss.Wrap (clientStream);
#endif

                int bytesRead = 0;
           
                while ((bytesRead = read(rss, p)) != 0) {
                    OnPacketReceived(p, bytesRead);
                    PooledObjects.PacketPool.Push(p);
                    p = PooledObjects.PacketPool.Pop();                           
                }
           
                PooledObjects.PacketPool.Push(p);
                PooledObjects.PositionStreamPool.Push(rss);

            }
#if __WINDOWS__
            /*catch (AggregateException exception)
            {
                foreach (Exception ex in exception.InnerExceptions)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }*/
#endif
            catch (Exception e)
            {
				if (session != null && !stopped) {
					session.ConnectState = GameSparksRT.ConnectState.Disconnected;
					session.Log ("ReliableConnection", GameSparksRT.LogLevel.DEBUG, e.Message);
					try{
						session.OnReady (false);
					}
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
			}
		}

		private int read(PositionStream stream, Packet p){

			if (stopped) {
				return 0;
			}
			p.Session = session;
			p.Reliable = true;

			int ret = Packet.DeserializeLengthDelimited (stream, stream.BinaryReader, p);
			p.Reliable = p.Reliable.GetValueOrDefault(true);
			return ret;
			
		}

		internal override void StopInternal(){
			try{
#if __WINDOWS__
                if (client != null && connected)
                {
                    connected = false;

                    client.Dispose();
                    client = null;
                }
#else
                if(client != null && client.Connected)
					client.Close ();
#endif
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            // Null the session, as we no longer want this connection to be able to mutate it
            session = null;
		}
	}
}