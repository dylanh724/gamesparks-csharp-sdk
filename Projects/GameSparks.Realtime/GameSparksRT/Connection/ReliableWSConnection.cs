#if !__WINDOWS__
using System;
using System.IO;
using System.Text.RegularExpressions;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.RT.Commands;
using GameSparks.RT.Pools;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Connection
{
	internal class ReliableWSConnection : Connection
	{
		private IGameSparksWebSocket socket;

		public ReliableWSConnection(string remotehost, int remoteport, IRTSessionInternal session) : base(remotehost, remoteport, session)
		{
			//GameSparks.Core.GameSparksUtil.LogMessageHandler = Console.WriteLine;

			session.Log ("ReliableWSConnection", GameSparksRT.LogLevel.DEBUG, "wss://" + remotehost + ":" + remoteport);

            if (session.GetGSInstance() != null)
            {
                socket = session.GetGSInstance().GSPlatform.GetBinarySocket("wss://" + remotehost + ":" + remoteport, OnBinaryMessageReceived, OnClosed, OnOpened, OnError);
            } else {
                socket = new GameSparksWebSocket();
                socket.Initialize("wss://" + remotehost + ":" + remoteport, OnBinaryMessageReceived, OnClosed, OnOpened, OnError);
            }
            socket.Open();
        }

        // No-Op override to prevent DNS resolution
        protected override void ResolveRemoteEndpoint(String remoteHost, int port)
        {
        }

        public override int Send(RTRequest request)
		{
			if (socket != null && socket.State == GameSparksWebSocketState.Open)			
            {
                Packet p = request.ToPacket(session, false);
				MemoryStream ms = PooledObjects.MemoryStreamPool.Pop ();

				ms.Position = 0;

                try
				{
                    Packet.SerializeLengthDelimited(ms, p);

					int ret = (int)ms.Position;

					socket.SendBinary(ms.GetBuffer(), 0, ret);

					return ret;
                }
                catch (Exception e)
				{
                    if (session != null && !stopped)
                    {
                        session.ConnectState = GameSparksRT.ConnectState.Disconnected;
                        session.Log("ReliableWSConnection", GameSparksRT.LogLevel.DEBUG, e.Message);
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
					PooledObjects.MemoryStreamPool.Push(ms);
                }
            }

			return -1;
		}

		internal override void StopInternal()
		{
			if (socket != null && socket.State == GameSparksWebSocketState.Open) {
				socket.Terminate();
				socket = null;
			}

			session = null;
		}

		internal void OnBinaryMessageReceived(byte[] message)
		{
			if (stopped) {
				if (socket != null) {
					socket.Terminate();
					socket = null;
				}

				return;
			}

			BinaryWriteMemoryStream ms = new BinaryWriteMemoryStream ();
			int length = message.Length;

			ms.Write (message, 0, length);
			ms.Position = 0;

			while (ms.Position < length) {
				int bytesRead;
				Packet p = PooledObjects.PacketPool.Pop();

				if (stopped) {
					return;
				}

				p.Session = session;
				p.Reliable = true;

				bytesRead = Packet.DeserializeLengthDelimited (ms, ms.BinaryReader, p);

				p.Reliable = p.Reliable.GetValueOrDefault(true);

				OnPacketReceived(p, bytesRead);

				PooledObjects.PacketPool.Push(p);
			}
		}

		internal void OnClosed()
		{
			if (session != null) {
				session.Log("ReliableWSConnection", GameSparksRT.LogLevel.DEBUG, " TCP Connection Closed");
			}
		}

		internal void OnOpened()
		{
			if (stopped || session == null) {
				if (socket != null) {
					socket.Terminate ();
					socket = null;
				}

				return;
			}

			session.Log("ReliableWSConnection", GameSparksRT.LogLevel.DEBUG, " TCP Connection Established");

			LoginCommand loginCmd = new LoginCommand(session.ConnectToken);

			Send(loginCmd);
		}
			
		internal void OnError(String errorMessage)
		{
			if (session != null) {
				session.Log ("ReliableWSConnection", GameSparksRT.LogLevel.ERROR, errorMessage);
			}
		}

		private String PrintBuffer(byte[] buffer, int length)
		{
			int end;
			String output = "";

			for (int i = 1; i <= (int)Math.Ceiling((float)length / 16.0f) * 16; i ++) {
				if ((i - 1) % 16 == 0) {
					output += String.Format("{0:X8}  ", i - 1);
				}
				if (i > length) {
					output += "   ";
				} else {
					output += String.Format("{0:X2} ", (int)(buffer[i - 1] & 0xff));
				}
				if (i % 8 == 0) { 
					output += " "; 
				}
				if (i % 16 == 0) {
					if (i > length) {
						end = length;
					} else {
						end = i;
					}

					String newString = "";
					Regex rgx = new Regex("[^\u0020-\u007E]");

					for (int a = i - 16; a < end; a++) {
						newString += (char)buffer [a];
					}

					output += rgx.Replace(newString, ".") + '\n';
				}
			}

			return output;
		}
	}
}
#endif
