using System;
using System.Collections.Generic;
using System.Threading;
using GameSparks.Core;
using GameSparks.Api.Responses;






namespace GameSparks.Core{


    /// <summary>
    /// Base class for all GameSparks requests. 
    /// </summary>
	public class GSRequest : GSObject
	{
		private GSObject _response = null;

		internal Action<GSObject> _callback;
		internal Action<GSObject> _errorCallback;
		internal Action<GSObject> _completer;

		internal long WaitForResponseTicks {get;set;}
		internal long RequestExpiresAt {get;set;}
		internal int DurableAttempts {get;set;}

		internal int MaxResponseTimeInMillis {get;set;}

		internal Boolean Durable = false;
        private GSInstance gsInstance;

        /// <summary>
        /// Create a new request with the given data. 
        /// This is the base class for all requests. 
        /// You should never need to use it directly. 
        /// </summary>
		public GSRequest(IDictionary<string,object> data) : base(data) {
		}

        /// <summary>
        /// Create a new request based on its type. 
        /// This needs to be a valid requestType as exposed by the GameSparks Service. 
        /// This is the base class for all requests. 
        /// You should never need to use it directly. 
        /// </summary>
		public GSRequest(String requestType){
			AddString("@class", "." + requestType);
		}

        /// <summary>
        /// Create a new request based on its type. 
        /// This needs to be a valid requestType as exposed by the GameSparks Service. 
        /// This is the base class for all requests. 
        /// You should never need to use it directly. 
        /// </summary>
        public GSRequest(GSInstance instance, string requestType)
        {
            this.gsInstance = instance;
            AddString("@class", "." + requestType);
        }

		internal void Complete(GSInstance gsInstance, GSObject response){
			_response = response;
			if (_completer != null) {
				_completer (response);
			}
            if (_errorCallback != null && response.ContainsKey ("error")) {
                gsInstance.GSPlatform.ExecuteOnMainThread(() =>
                {
                        _errorCallback(response);
                });
            }else if (_callback != null) {
                gsInstance.GSPlatform.ExecuteOnMainThread(() =>
                {
                        _callback(response);
				});
			}
		}

		internal int GetResponseTimeout(){
			if (MaxResponseTimeInMillis == 0) {
				MaxResponseTimeInMillis = gsInstance != null ? gsInstance.RequestTimeout : GS.RequestTimeout;
			}
			return MaxResponseTimeInMillis;
		}

		internal void Send (Action<GSObject> callback){
			_callback = callback;
            GSRequest requestToSend = this.DeepCopy();

            if (gsInstance != null)
            {
                gsInstance.Send(requestToSend);
            }
            else
            {
                GS.Instance.Send(requestToSend);
            }
		}

		/// <summary>
		/// Determines whether this instance has callbacks set.
		/// </summary>
		/// <returns><c>true</c> if this instance has callbacks; otherwise, <c>false</c>.</returns>
		public bool HasCallbacks()
		{
			return _callback != null;
		}

		/// <summary>
		/// Sets the success and error callbacks. Useful when managing the Durable queue after a app restart
		/// </summary>
		/// <param name="successCallback">Success callback.</param>
		/// <param name="errorCallback">Error callback.</param>
		public void SetCallbacks(Action<GSObject> successCallback, Action<GSObject> errorCallback)
		{
			_callback = successCallback;
			_errorCallback = errorCallback;
		}

		/// <summary>
		/// Sets the main callback.
		/// </summary>
		/// <param name="callback">Callback.</param>
		public void SetCallback(Action<GSObject> callback)
		{
			_callback = callback;
			_errorCallback = null;
		}

        private GSRequest DeepCopy()
        {
            var request = new GSRequest(this._data);

            request.Durable = this.Durable;
            request._callback = _callback;
            request._completer = _completer;
            request._errorCallback = _errorCallback;
            request._response = _response;
			request.MaxResponseTimeInMillis = this.MaxResponseTimeInMillis;
			request.WaitForResponseTicks = this.WaitForResponseTicks;
			request.RequestExpiresAt = this.RequestExpiresAt;
			request.DurableAttempts = this.DurableAttempts;

			return request;
        }

		internal void Send (Action<GSObject> successCallback, Action<GSObject> errorCallback){
			_callback = successCallback;
            _errorCallback = errorCallback;

            GSRequest requestToSend = this.DeepCopy();

            if (gsInstance != null)
            {
                gsInstance.Send(requestToSend);
            }
            else
            {
                GS.Instance.Send(requestToSend);
            }
		}

        /// <summary>
        /// Add a string value to the request
        /// </summary>
		public new GSRequest AddString(string paramName, string value){
			base.AddString (paramName, value);

			return this;
		}

        /// <summary>
        /// Add a DateTime value to the request
        /// </summary>
		public new GSRequest AddDate(string paramName, DateTime date){
			base.AddDate (paramName, date);

			return this;
		}

        /// <summary>
        /// Add a number value to the request
        /// </summary>
		public new GSRequest AddNumber(string paramName, long value){
			base.AddNumber (paramName, value);

			return this;
		}

        /// <summary>
        /// Add a data value to the request. 
        /// </summary>
        public new GSRequest AddObject(String paramName, GSData child){
			base.AddObject (paramName, child);

			return this;
		}

        /// <summary>
        /// Add a list of data objects to the request
        /// </summary>
		public new GSRequest AddObjectList(String paramName, List<GSData> child){
			base.AddObjectList (paramName, child);

			return this;
		}

        /// <summary>
        /// Add a list of strings to the request. 
        /// </summary>
		public new GSRequest AddStringList(String paramName, List<string> child){
			base.AddStringList (paramName, child);

			return this;
		}

        /// <summary>
        /// Add a boolean value to the request.
        /// </summary>
		public new GSRequest AddBoolean(String paramName, Boolean value){
			base.AddBoolean (paramName, value);

			return this;
		}
    }

}

