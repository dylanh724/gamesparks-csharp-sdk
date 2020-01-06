using System;
#if __WINDOWS__
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.Networking.Sockets;
using Windows.System.Threading;
using System.Threading.Tasks;
#else
using System.Net.Sockets;
using System.Net;
using System.Threading;
#endif
using Com.Gamesparks.Realtime.Proto;
using System.IO;
using GameSparks.RT.Commands;
using GameSparks.RT.Proto;
using System.Collections.Generic;
using GameSparks.RT.Pools;


namespace GameSparks.RT.Connection
{
	internal class FastConnection : Connection
	{
#if __WINDOWS__
        DatagramSocket client;
#else
        UdpClient client;
        AsyncCallback callback;
#endif
		public byte[] buffer = new byte[GameSparksRT.MAX_UNRELIABLE_MESSAGE_SIZE_BYTES];

		private BinaryWriteMemoryStream ms = new BinaryWriteMemoryStream ();

		private int connectionAttempts = 1;

		public FastConnection (string remotehost, int remoteport, IRTSessionInternal session) : base(remotehost, remoteport, session)
		{
#if __WINDOWS__
            client = new DatagramSocket();
            client.MessageReceived += OnSocketMessageReceived;

            Task t = Task.Run(() => {
                ConnectAsync().Wait();

                DoLogin();
            });

            session.Log("FastConnection", GameSparksRT.LogLevel.DEBUG, " local=" + endPoint.LocalHostName + " remote=" + remotehost + ":" + remoteport);
#else
            bool ipv6 = false;

            callback = new AsyncCallback(Recv);

            if (remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6) {
                try {
                    if (Socket.OSSupportsIPv6) {
                        ipv6 = true;
                    }
                } catch (Exception e) {
                    Console.WriteLine("Socket.OSSupportsIPv6: " + e.ToString());
                }

                try {
                    if (Socket.SupportsIPv6) {
                        ipv6 = true;
                    }
                } catch (Exception e) {
                    Console.WriteLine("Socket.SupportsIPv6: " + e.ToString());
                }
            }

			if (ipv6) {
                client = new UdpClient(AddressFamily.InterNetworkV6);

                Console.WriteLine("IPv6 on!");
            } else {
                client = new UdpClient(AddressFamily.InterNetwork);
            }

            client.Connect (remoteEndPoint);
            
			session.Log("FastConnection", GameSparksRT.LogLevel.DEBUG, " local=" + client.Client.LocalEndPoint + " remote=" + remotehost + ":" + remoteport);

			client.Client.BeginReceive (buffer, 0, GameSparksRT.MAX_UNRELIABLE_MESSAGE_SIZE_BYTES, 0, callback, null);  
            
			DoLogin();      
#endif
        }

#if __WINDOWS__
        private async Task ConnectAsync()
        {
            try {
                await client.ConnectAsync(endPoint);
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
#endif

        private void DoLogin()
        {
#if __WINDOWS__      
            try {
                while (session != null && session.ConnectState < GameSparksRT.ConnectState.ReliableAndFastSend && connectionAttempts < GameSparksRT.UDP_HANDSHAKE_ATTEMPTS) {
                    LoginCommand loginCmd = new LoginCommand(session.ConnectToken);
                    Send(loginCmd);
                    Task.Delay(GameSparksRT.UDP_HANDSHAKE_SLEEP).Wait();
					connectionAttempts ++;
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
            try {
                session.OnReady(true);
            } catch {}

#else
            new Thread (
				new ThreadStart (() => {
					try {
						while (session != null && session.ConnectState < GameSparksRT.ConnectState.ReliableAndFastSend && connectionAttempts < GameSparksRT.UDP_HANDSHAKE_ATTEMPTS) {
							LoginCommand loginCmd = new LoginCommand (session.ConnectToken);
							Send (loginCmd);
                            Thread.Sleep(GameSparksRT.UDP_HANDSHAKE_SLEEP);
							connectionAttempts ++;
						}
                    } catch {
					}
                    try
                    {
                        session.OnReady(true);
                    }
                    catch { }
                })
			).Start ();
#endif
        }

#if __WINDOWS__
        private void OnSocketMessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
#else
        private void Recv(IAsyncResult res)
#endif
        {
			try {
#if __WINDOWS__
                var reader = args.GetDataReader();
                int read = (int)reader.UnconsumedBufferLength;

                Array.Resize<byte>(ref buffer, read);
       
                reader.ReadBytes(buffer);
#else
                int read = client.Client.EndReceive(res);             
#endif
                ReadBuffer(read);
#if !__WINDOWS__            
                SyncReceive();
#endif
            } catch (Exception e) {
				try{
					session.Log("FastConnection EndReceive", GameSparksRT.LogLevel.DEBUG, e.Message);
				}
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }  finally {
				if (!stopped && session != null) {
					try {
#if !__WINDOWS__
                        client.Client.BeginReceive (buffer, 0, GameSparksRT.MAX_UNRELIABLE_MESSAGE_SIZE_BYTES, 0, callback, null);
#endif
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
			}
		}

        private void ReadBuffer(int read)
        {
			try {
				ms.Position = 0;
				ms.Write (buffer, 0, read);
				ms.Position = 0;

				while (ms.Position < read) {
					Packet p = PooledObjects.PacketPool.Pop ();
					//Set the session
					p.Session = session;
					//This is an unreliable packet (unless the server says something different)
					p.Reliable = false;
					try {
						int packetSize = Packet.DeserializeLengthDelimited (ms, ms.BinaryReader, p);
						p.Reliable = p.Reliable.GetValueOrDefault (false);
						OnPacketReceived (p, packetSize);
					} finally {
						PooledObjects.PacketPool.Push(p);
					}
				}
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

#if !__WINDOWS__
        public void SyncReceive()
		{
			while (!stopped && session != null) {
				int read = client.Client.Receive(buffer);

				if (read > 0) {
					ReadBuffer (read);
				}
			}
		}
#endif

        public override int Send(RTRequest request)
        {
            MemoryStream ms = PooledObjects.MemoryStreamPool.Pop ();

			try {
				ms.Position = 0;

				Packet p = request.ToPacket(session, true);

				try {
					Packet.SerializeLengthDelimited(ms, p);
				} finally {
					PooledObjects.PacketPool.Push (p);
				}

				try {
#if __WINDOWS__
                    Task t = Task.Run(async () => {
                        byte[] newArray = ms.ToArray();

                        Array.Resize<byte>(ref newArray, (int)ms.Position);

                        DataWriter writer = new DataWriter(client.OutputStream);

                        writer.WriteBytes(newArray);

                        await writer.StoreAsync();
                        await writer.FlushAsync();

                        writer.DetachStream();
                        writer.Dispose();
                    });
                    t.Wait();
                    //client.OutputStream.AsStreamForWrite().WriteAsync(newArray, 0, (int)ms.Position);
#else
					client.Send (ms.GetBuffer(), (int)ms.Position);
#endif
                } catch(Exception e) {
                    System.Diagnostics.Debug.WriteLine(e);

                    session.Log("fastConnection", GameSparksRT.LogLevel.INFO, "Exception sending UDP {0}" , e.Message); 
				}

				return (int)ms.Position;
			} finally {
				PooledObjects.MemoryStreamPool.Push (ms);
			}
		}

		internal override void StopInternal(){
			if (client != null) {
#if __WINDOWS__
                client.Dispose();
                client = null;
#else
				client.Close ();
#endif
			}

			session = null;
		}
	}
}

