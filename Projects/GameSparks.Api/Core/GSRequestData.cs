using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    /// <summary>
    /// Data container for request data.
    /// </summary>
    public class GSRequestData : GSData
    {
        /// <summary>
        /// Create a new request data container which is empty. 
        /// </summary>
        public GSRequestData() { }

        /// <summary>
        /// Create a new request data container based on a json string. 
        /// </summary>
        /// <param name="jsonString"></param>
        public GSRequestData(string jsonString)
        {
            object o = GSJson.From(jsonString);
            if (o is IDictionary<string, object>)
            {
                this._data = ((IDictionary<string, object>)o);
            }
        }

        /// <summary>
        /// Create a new request data container with the given data. 
        /// </summary>
        public GSRequestData(GSData wrapper) : base(wrapper) { }


        /// <summary>
        /// Create a new request with the given data. 
        /// </summary>
        public GSRequestData(IDictionary<string, object> data) : base(data) { }

        /// <summary>
        /// Adds the given paramName-value to this container. Existing paramNames will be overwritten. 
        /// </summary>
        public void Add(string paramName, object value)
        {
            if (_data.ContainsKey(paramName))
            {
                _data.Remove(paramName);
            }
            _data.Add(paramName, value);
        }

        /// <summary>
        /// Add a string value. 
        /// </summary>
        public GSRequestData AddString(string paramName, string value)
        {
            Add(paramName, value);
            return this;
        }

        /// <summary>
        /// Add a json string which will be converted into an object first. 
        /// </summary>
        public GSRequestData AddJSONStringAsObject(string paramName, string jsonString)
        {
            Add(paramName, GSJson.From(jsonString));
            return this;
        }

        /// <summary>
        /// Add a date. Dates are stored as UTC strings in the following format: yyyy-MM-dd'T'HH:mm'Z' 
        /// </summary>
        /// <returns></returns>
        public GSRequestData AddDate(string paramName, DateTime date)
        {
            DateTime utcDateTime = date.ToUniversalTime();
            String formattedDate = utcDateTime.ToString("yyyy-MM-dd'T'HH:mm'Z'");
            Add(paramName, formattedDate);
            return this;
        }

        /// <summary>
        /// Add a number to the container.  
        /// </summary>
        public GSRequestData AddNumber(string paramName, long value)
        {
            Add(paramName, value);
            return this;
        }

        /// <summary>
        /// Add a list of numbers to the container.  
        /// </summary>
        public GSRequestData AddNumberList(String paramName, List<long> child)
        {
            Add(paramName, child);
            return this;
        }

        /// <summary>
        /// Add a number to the container.
        /// </summary>
        public GSRequestData AddNumber(string paramName, float value)
        {
            Add(paramName, value);
            return this;
        }

        /// <summary>
        /// Add a list of numbers to the container.
        /// </summary>
        public GSRequestData AddNumberList(String paramName, List<float> child)
        {
            Add(paramName, child);
            return this;
        }

        /// <summary>
        /// Add a number to the container.
        /// </summary>
        public GSRequestData AddNumber(string paramName, double value)
        {
            Add(paramName, value);
            return this;
        }

        /// <summary>
        /// Add a list of numbers to the container.
        /// </summary>
        public GSRequestData AddNumberList(String paramName, List<double> child)
        {
            Add(paramName, child);
            return this;
        }


        /// <summary>
        /// Add a number to the container.
        /// </summary>
        public GSRequestData AddNumber(string paramName, int value)
        {
            Add(paramName, value);
            return this;
        }


        /// <summary>
        /// Add a list of numbers to the container.
        /// </summary>
        public GSRequestData AddNumberList(String paramName, List<int> child)
        {
            Add(paramName, child);
            return this;
        }


        /// <summary>
        /// Add a child object to the container.
        /// </summary>
        public GSRequestData AddObject(String paramName, GSData child)
        {
            Add(paramName, child.BaseData);
            return this;
        }


        /// <summary>
        /// Add a list of child objects to the container.
        /// </summary>
        public GSRequestData AddObjectList(String paramName, List<GSData> child)
        {
            Add(paramName, child);
            return this;
        }


        /// <summary>
        /// Add a list of strings to the container.
        /// </summary>
        public GSRequestData AddStringList(String paramName, List<String> child)
        {
            Add(paramName, child);
            return this;
        }



        /// <summary>
        /// Add a bool value to the container.
        /// </summary>
        public GSRequestData AddBoolean(String paramName, Boolean value)
        {
            Add(paramName, value);
            return this;
        }

    }
}
