using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;

namespace SuperSocket.ClientEngine
{
    public static partial class ConnectAsyncExtension
    {
        public static void ConnectAsync(this EndPoint remoteEndPoint, ConnectedCallback callback, object state)
        {
            ConnectAsyncInternal(remoteEndPoint, callback, state);
        }

        static partial void CreateAttempSocket(DnsConnectState connectState)
        {
            bool ipv6 = false;

            try
            {
                if (Socket.OSSupportsIPv6)
                {
                    ipv6 = true;
                }
            }
            catch (Exception e)
            {
                GameSparks.Core.GameSparksUtil.LogError("Socket.OSSupportsIPv6: " + e.ToString());
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
                GameSparks.Core.GameSparksUtil.LogError("Socket.SupportsIPv6: " + e.ToString());
            }

            if (ipv6)
            {
                try 
                {
                    connectState.Socket6 = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);

                    GameSparks.Core.GameSparksUtil.Log("IPv6 on!");
                }
                catch (Exception e)
                {
                    GameSparks.Core.GameSparksUtil.LogError(e.ToString());
                }                
            }

			connectState.Socket4 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}