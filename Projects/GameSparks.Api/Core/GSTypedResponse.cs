using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#pragma warning disable 612,618

namespace GameSparks.Core
{
    /// <summary>
    /// Abstract base class for responses received from the service. 
    /// </summary>
	public abstract class GSTypedResponse{
        // TODO: Do we need the response to be protected if we already have a public BaseData getter? We might need to clean this up a bit. 

        /// <summary>
        /// 
        /// </summary>
		protected GSData response;

        /// <summary>
        /// 
        /// </summary>
		public GSTypedResponse(GSData response){
			this.response = response;
		}

        /// <summary>
        /// Content of this response as a json string. 
        /// </summary>
		public String JSONString{
			get{ return response.JSON; }
		}

        /// <summary>
        /// Content of this response as a json data object. 
        /// </summary>
		public IDictionary<string,object> JSONData{
			get{ return response.BaseData; }
		}

        /// <summary>
        /// Script data content of this response. 
        /// </summary>
		public GSData ScriptData{
			get{return response.GetObject ("scriptData");}
		}

        /// <summary>
        /// True if there are any errors within this response. 
        /// </summary>
		public bool HasErrors {
			get{ return response.ContainsKey ("error"); }
		}

        /// <summary>
        /// Contains the errors in this response. 
        /// </summary>
		public GSData Errors{
			get{return response.GetObject ("error"); }
		}

        /// <summary>
        /// 
        /// </summary>
		public String RequestId{
			get{ return response.GetString ("requestId"); }
		}

        /// <summary>
        /// Response data. 
        /// </summary>
		public GSData BaseData{
			get{ return response; }
		}	

	}
}

#pragma warning restore 612, 618