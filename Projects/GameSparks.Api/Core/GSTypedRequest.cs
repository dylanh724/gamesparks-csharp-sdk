
using System;
using System.Collections.Generic;
namespace GameSparks.Core
{

    /// <summary>
    /// Abstract base class for all requests against the GameSparks backend
    /// </summary>
    /// <typeparam name="IN">Request type</typeparam>
    /// <typeparam name="OUT">Response type</typeparam>
    public abstract class GSTypedRequest<IN, OUT>
        where IN : GSTypedRequest<IN, OUT>
        where OUT : GSTypedResponse
    {

        protected GSRequest request;
       
        protected GSTypedRequest(String type)
        {
            request = new GSRequest(type);
        }

        internal GSTypedRequest(IDictionary<string, object> data)
        {
            request = new GSRequest(data);
        }

        /// <summary>
        /// Create a new Request of the given type. 
        /// </summary>
        /// <param name="instance">The GSInstance this request will be send with</param>
        /// <param name="type">Request type name</param>
        public GSTypedRequest(GSInstance instance, string type)
        {
            request = new GSRequest(instance, type);
        }

        internal void AddCompleter(Action<GSObject> completer)
        {
            request._completer = completer;
        }

        protected abstract GSTypedResponse BuildResponse(GSObject response);

        /// <summary>
        /// The request as a json string. 
        /// </summary>
        public String JSONString
        {
            get { return request.JSON; }
        }

        // TODO: Check if we should rather deep copy the wrapper than just use the data reference. 
        /// <summary>
        /// Returns the underlying json data of this request. 
        /// </summary>
        public IDictionary<string, object> JSONData
        {
            get { return request.BaseData; }
        }

        /// <summary>
        /// Sets the maximum amount of time this request will stay in the send-queue until it will timeout. 
        /// </summary>
        /*public IN SetMaxQueueTimeInMillis(int maxQueueTime)
        {
            request.MaxQueueTimeInMillis = maxQueueTime;

            return (IN)this;
        }*/

        /// <summary>
        /// Sets the maximum amount of time GSInstance will wait for a response to this request.
        /// </summary>
        /// <param name="maxResponseTime"></param>
        /// <returns></returns>
        public IN SetMaxResponseTimeInMillis(int maxResponseTime)
        {
            request.MaxResponseTimeInMillis = maxResponseTime;

            return (IN)this;
        }


        /// <summary>
        /// If set true this request will be handled as a durable request. The SDK will make sure this gets send even after a shutdown/disconnect/reconnect. 
        /// </summary>
        public IN SetDurable(bool durable)
        {
            request.Durable = durable;

            return (IN)this;
        }

        /// <summary>
        /// Set the script-data which will be sent to the backend in addition to the data-fields defined by the request itself. 
        /// </summary>
        public IN SetScriptData(GSRequestData data)
        {
            request.AddObject("scriptData", data);

            return (IN)this;
        }


        /// <summary>
        /// Asyncronous send method, provide an Action to handle the callback.
        /// It's the callers responsibility to validate whether the response has errors using response.HasErrors
        /// If the SDK is not connected, the default timeout will be used as defined in GSPlatform.RequestTimeoutSeconds
        /// </summary>
        public void Send(Action<OUT> callback)
        {
            request.Send((response) =>
            {
                if (callback != null)
                {
                    callback((OUT)BuildResponse(response));
                }
            });
        }

        /// <summary>
        /// Asyncronous send method, provide an Action to handle the callback.
        /// The timeoutMillis parameter indicates how long the request will be queued for in case the SDK is not connected to the GameSparks service.
        /// It's the callers responsibility to validate whether the response has errors using response.HasErrors
        /// </summary>
        public void Send(Action<OUT> callback, int timeoutMillis)
        {
            if (request.MaxResponseTimeInMillis == 0)
            {
                request.MaxResponseTimeInMillis = timeoutMillis;
            }
            request.Send((response) =>
            {
                if (callback != null)
                {
                    callback((OUT)BuildResponse(response));
                }
            });
        }

        /// <summary>
        /// Asyncronous send method, provide an Action to handle a successful response and an Action to handle an error response.
        /// If the SDK is not connected, the default timeout will be used as defined in GSPlatform.RequestTimeoutSeconds
        /// </summary>
        public void Send(Action<OUT> successCallback, Action<OUT> errorCallback)
        {
            request.Send(
                (response) =>
                {
                    if (successCallback != null)
                    {
                        successCallback((OUT)BuildResponse(response));
                    }
                },
                (response) =>
                {
                    if (errorCallback != null)
                    {
                        errorCallback((OUT)BuildResponse(response));
                    }
                });
        }

        /// <summary>
        /// Asyncronous send method, provide an Action to handle a successful response and an action to handle an error response.
        /// The timeoutMillis parameter indicates how long the request will be queued for in case the SDK is not connected to the GameSparks service.
        /// </summary>
        public void Send(Action<OUT> successCallback, Action<OUT> errorCallback, int timeoutMillis)
        {
            if (request.MaxResponseTimeInMillis == 0)
            {
                request.MaxResponseTimeInMillis = timeoutMillis;
            }
            request.Send(
                (response) =>
                {
                    if (successCallback != null)
                    {
                        successCallback((OUT)BuildResponse(response));
                    }
                },
                (response) =>
                {
                    if (errorCallback != null)
                    {
                        errorCallback((OUT)BuildResponse(response));
                    }
                }
            );
        }
    }
}