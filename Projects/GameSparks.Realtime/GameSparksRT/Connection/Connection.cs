using System;
using System.IO;
#if __WINDOWS__
using System.Collections.Generic;
using System.Reflection;
using Windows.Networking;
using Windows.Networking.Connectivity;
using Windows.Networking.Sockets;
using System.Threading.Tasks;
#else

#endif
using System.Net;
using Com.Gamesparks.Realtime.Proto;
using GameSparks.Core;
using GameSparks.RT.Commands;
using GameSparks.RT.Proto;

namespace GameSparks.RT.Connection
{
	internal abstract class Connection
	{
#if __WINDOWS__
        protected EndpointPair endPoint;
#else
		protected IPEndPoint remoteEndPoint;
#endif
        protected IRTSessionInternal session;
		protected bool stopped = false;

		//Passed to callbacks when nothing to parse
		private static LimitedPositionStream emptyStream = new LimitedPositionStream ();

#if __WINDOWS__
        private static async Task<EndpointPair> ResolveDNS(string remoteHostName, int port)
        {
            if (string.IsNullOrEmpty(remoteHostName))
            {
                return null;
            }

            string ipAddress = string.Empty;

            try
            {
                IReadOnlyList<EndpointPair> data = await DatagramSocket.GetEndpointPairsAsync(new HostName(remoteHostName), port.ToString());

                if (data != null && data.Count > 0)
                {
                    foreach (EndpointPair item in data)
                    {
                        if (item != null && item.RemoteHostName != null && (item.RemoteHostName.Type == HostNameType.Ipv4 || item.RemoteHostName.Type == HostNameType.Ipv6))
                        {
                            return item;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

            return null;
        }
#endif

        public Connection (string remoteHost, int port, IRTSessionInternal session)
		{
			emptyStream.Wrap (new BinaryWriteMemoryStream ());
			this.session = session;

#if __WINDOWS__
            try
            {
                Task<EndpointPair> t = Task.Run<EndpointPair>(() => ResolveDNS(remoteHost, port));

                t.Wait();

                endPoint = t.Result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
#else
            GSInstance instance = session.GetGSInstance();
            ResolveRemoteEndpoint(remoteHost, port);
        }

        protected virtual void ResolveRemoteEndpoint(String remoteHost, int port)
        {
            IPAddress ipAddress;
            IPAddress.TryParse(remoteHost, out ipAddress);

            if (ipAddress == null)
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(remoteHost);
                ipAddress = ipHostInfo.AddressList[0];
            }

            remoteEndPoint = new IPEndPoint(ipAddress, port);
#endif
        }



        public void Stop(){
			this.stopped = true;
			StopInternal ();
		}
		internal abstract void StopInternal ();

        public abstract int Send (RTRequest request);

        protected void OnPacketReceived(Packet p, int packetSize)
		{
			if (p.Command != null) {
#if __WINDOWS__
                if (typeof(AbstractResult).GetTypeInfo().IsAssignableFrom(p.Command.GetType().GetTypeInfo())) {
#else
                if (typeof(AbstractResult).IsAssignableFrom (p.Command.GetType ())) {
#endif
                    AbstractResult result = ((AbstractResult)p.Command);
					result.Configure (p, session);
					if (result.ExecuteAsync ()) {
						session.SubmitAction (p.Command);
					} else {
						p.Command.Execute ();
					}
				} else {
					session.SubmitAction (p.Command);
				}

			} else {
				//If it has a payload, we've already got the IRTCommand from the user
				if (!p.hasPayload) {
					IRTCommand cmd = CustomCommand.pool.Pop ().Configure (p.OpCode, p.Sender.GetValueOrDefault(0), null, p.Data, 0, session, packetSize);
					if (cmd != null) {
						session.SubmitAction ( cmd );
					}
				}
			}
		}

	}
}

