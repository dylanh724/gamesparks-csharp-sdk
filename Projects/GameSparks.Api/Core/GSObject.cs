using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    /// <summary>
    /// Data container with type.
    /// </summary>
    public class GSObject : GSRequestData
    {
        /// <summary>
        /// Create an instance with the basedata of the given dictionary. 
        /// </summary>
        public GSObject(IDictionary<string, object> data) : base(data) { }

        /// <summary>
        /// Create an instance with the basedata of the given wrapper. 
        /// </summary>
        public GSObject(GSData wrapper) : base(wrapper.BaseData) { }

        /// <summary>
        /// Create an empty instance without any basedata. 
        /// </summary>
        protected GSObject() { }

        /// <summary>
        /// Create a new instance of the given type ("@class")
        /// </summary>
        public GSObject(String type)
        {
            AddString("@class", type);
        }

        /// <summary>
        /// Type of this object ("@class")
        /// </summary>
        public string Type
        {
            get { return GetString("@class"); }
        }

        /// <summary>
        /// Parse the given json string into a new GSObject. 
        /// </summary>
        public static GSObject FromJson(String json)
        {
            object parsed = GSJson.From(json);
            if (parsed is IDictionary<string, object>)
            {
                return new GSObject((IDictionary<string, object>)parsed);
            }
            return null;
        }

    }
}
