using System;
using System.Collections.Generic;
using GameSparks.Api.Messages;
using GameSparks.Core;

namespace GameSparks.Api
{
    /// <summary>
    /// Static message handler. 
    /// Receives all GameSparks Messages. 
    /// Used for debugging. 
    /// </summary>
	public static class GSMessageHandler
	{
        /// <summary>
        /// Register a custom handler to receive all GameSparks Messages here. 
        /// </summary>
		public static Action<GSMessage> _AllMessages;

		static internal void HandleMessage(GSInstance gsInstance, GSObject messageData){

            var message = GSMessage.CreateMessageFromObject(gsInstance, messageData);
            
			if (_AllMessages != null){
                _AllMessages(message);
			}
            
            message.NotifyListeners();
		}
	}
}