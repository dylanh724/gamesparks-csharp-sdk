using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks
{
    /// <summary>
    /// Interface for all WebSocket implementations used with the sdk. 
    /// </summary>
    public interface IGameSparksWebSocket
    {
        /// <summary>
        /// 
        /// </summary>
        void Initialize(String url,
            Action<String> onMessage,
            Action onClose,
            Action onOpen,
            Action<String> onError);
        /// <summary>
        /// 
        /// </summary>
        void Initialize(String url,
            Action<byte[]> onMessage,
            Action onClose,
            Action onOpen,
            Action<String> onError);
        /// <summary>
        /// 
        /// </summary>
        void Open();
        /// <summary>
        /// 
        /// </summary>
        void Close();

		/// <summary>
		/// 
		/// </summary>
		void Terminate();

        /// <summary>
        ///
        /// </summary>
        void Send(String request);

        /// <summary>
        ///
        /// </summary>
        void SendBinary(byte[] request, int offset, int length);

        /// <summary>
        ///
        /// </summary>
        GameSparksWebSocketState State { get; }

    }
}
