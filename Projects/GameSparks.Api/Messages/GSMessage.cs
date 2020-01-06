using System;

using GameSparks.Core;
using System.Collections.Generic;

namespace GameSparks.Api.Messages
{

    public class GSMessage : GSTypedResponse
    {

        public static IDictionary<string, Func<GSData, GSMessage>> handlers = new Dictionary<string, Func<GSData, GSMessage>>();

        public GSMessage(GSData message) : base(message) { }

        /// <summary>
        /// Factory method which creates a strongly typed message from the object data provided. 
        /// </summary>
        internal static GSMessage CreateMessageFromObject(GSInstance gsInstance, GSObject messageData)
        {
            if (messageData.ContainsKey("extCode"))
            {
                if (handlers.ContainsKey(messageData.Type + "_" + messageData.GetString("extCode")))
                {
                    var message = handlers[messageData.Type + "_" + messageData.GetString("extCode")](messageData);
                    message.gsInstance = gsInstance;
                    return message;
                }
            }

            if (handlers.ContainsKey(messageData.Type))
            {
                var message = handlers[messageData.Type](messageData);
                message.gsInstance = gsInstance;
                return message;
            }

            return null;
        }

        public string MessageId
        {
            get { return response.GetString("messageId"); }
        }

        public virtual void NotifyListeners()
        {
            throw new NotImplementedException("This has to be overwritten by implementations of GSMessage. ");
        }

		protected virtual void RegisterMessageType()
        {
            throw new NotImplementedException();
        }

        public GSInstance gsInstance
        {
            get;
            private set;
        }
    }
}
