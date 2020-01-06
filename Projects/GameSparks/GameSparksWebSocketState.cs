using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks
{
    /// <summary>
    /// Describes the current state of a WebSocket. 
    /// </summary>
    public enum GameSparksWebSocketState
    {
        /// <summary>
        /// WebSocket is not initialized. 
        /// </summary>
        None = -1,
        /// <summary>
        /// WebSocket is currently connecting.
        /// </summary>
        Connecting,
        /// <summary>
        /// WebSocket connection is established and waiting for io.
        /// </summary>
        Open,
        /// <summary>
        /// WebSocket was requested to be closed. 
        /// </summary>
        Closing,
        /// <summary>
        /// WebSocket connection was successfully closed. 
        /// </summary>
        Closed
    }
}
