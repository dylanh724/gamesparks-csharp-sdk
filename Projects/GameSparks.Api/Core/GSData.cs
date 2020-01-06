using System;
using System.Collections.Generic;
using System.Globalization;

#pragma warning disable 612,618

namespace GameSparks.Core
{
    /// <summary>
    /// Basic data container for all (json) supported data types. 
    /// </summary>
	public class GSData : IGSData
	{
		protected IDictionary<string,object> _data = new Dictionary<string, object> ();

        /// <summary>
        /// Underlying data dictionary. 
        /// </summary>
		public IDictionary<string,object> BaseData {
			get{ return _data; }
		}

        /// <summary>
        /// Convert this container to a Json string. 
        /// </summary>
		public String JSON{
			get{return GSJson.To (_data);}
		}

        /// <summary>
        /// Create a new, empty instance. 
        /// </summary>
		public GSData (){}

        // TODO: Check if we should rather deep copy the wrapper than just use the data reference. 
		/// <summary>
        /// Create a new instance and use the data of the given wrapper as BaseData.
		/// </summary>
		/// <param name="wrapper"></param>
        public GSData (GSData wrapper){this._data = wrapper._data;}

        // TODO: Check if we should rather deep copy the wrapper than just use the data reference. 
        /// <summary>
        /// Create a new instance and use the given data as BaseData.
        /// </summary>
        /// <param name="data"></param>
		public GSData (IDictionary<string,object> data){
			foreach (KeyValuePair<string, object> entry in data) {
				object value = ToGSType (entry.Value);
				_data.Add(entry.Key, value);
			}
		}

        static object ToGSType(object value){
			if (value == null) {
				return null;
			}
			if(value is IDictionary<string,object>){
				value = new GSData ((Dictionary<string,object>)value);
			}
			return value;
		}

        /// <summary>
        /// 
        /// </summary>
		public bool ContainsKey(String key){
			return _data.ContainsKey (key);
		}

        /// <summary>
        /// 
        /// </summary>
		public string GetString(String name){
			if(_data.ContainsKey(name) && _data [name] is string){
				return _data[name].ToString();
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public int? GetInt(String name){
			if(_data.ContainsKey(name)){
				if (_data [name] is double) {
					return Convert.ToInt32 ((double)_data [name]);
				} else if (_data [name] is int) {
					return (int)_data [name];
				}
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public long? GetLong(String name){
			if(_data.ContainsKey(name)){
				if (_data [name] is double) {
					return Convert.ToInt64 ((double)_data [name]);
				} else if (_data [name] is long) {
					return (long)_data [name];
				}
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		/// 
		public long? GetNumber(String name){
			//return GetLong (name);
			if(_data.ContainsKey(name)){
				if (_data [name] is double) {
					return Convert.ToInt64 ((double)_data [name]);
				} else if (_data [name] is float) {
					return Convert.ToInt64 ((float)_data [name]);
				}  else if (_data [name] is long) {
					return (long)_data [name];
				}  else if (_data [name] is int) {
					return Convert.ToInt64(_data [name]);
				}
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public double? GetDouble(String name){
			if(_data.ContainsKey(name) && _data[name] != null &&_data[name] is double){
				return (double)_data [name];
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public float? GetFloat(String name){
			if(_data.ContainsKey(name)){
				if (_data [name] is double) {
					return Convert.ToSingle ((double)_data [name]);
				} else if (_data [name] is float) {
					return (float)_data [name];
				}
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public bool? GetBoolean(String name){
			if(_data.ContainsKey(name) && _data [name] is bool){
				return (bool)_data [name];
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public DateTime? GetDate(String name){
			if(_data.ContainsKey(name) && _data [name] is string){
				return DateTime.ParseExact (_data [name].ToString(), "yyyy-MM-dd'T'HH:mm'Z'", CultureInfo.InvariantCulture);
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public List<string> GetStringList(String name){
			List<object> values = GetObjectList (name);
			List<string> values2 = null;
			if(values == null && _data.ContainsKey(name)){
				if (_data [name] is List<string>) {
					values2 = (List<string>)_data [name];
				}
			}
			if (values != null || values2 != null) {
				List<string> ret = new List<string> ();
				if (values != null) {
					foreach (object value in values) {
						if (value is string) {
							ret.Add (value.ToString ());
						}
					}
				} else {
					foreach (object value in values2) {
						if (value is string) {
							ret.Add (value.ToString ());
						}
					}
				}

				return ret;
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public List<float> GetFloatList(String name){
			List<object> values = GetObjectList (name);
			List<float> values2 = null;
			if(values == null && _data.ContainsKey(name)){
				if (_data [name] is List<float>) {
					values2 = (List<float>)_data [name];
				}
			}
			if (values != null || values2 != null) {
				List<float> ret = new List<float> ();
				if (values != null) {
					foreach (object value in values) {
						if (value is double) {
							ret.Add (Convert.ToSingle ((double)value));
						} else if (value is float) {
							ret.Add ((float)value);
						}
					}
				} else {
					foreach (object value in values2) {
						if (value is double) {
							ret.Add (Convert.ToSingle ((double)value));
						} else if (value is float) {
							ret.Add ((float)value);
						}
					}
				}

				return ret;
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public List<double> GetDoubleList(String name){
			List<object> values = GetObjectList (name);
			List<double> values2 = null;
			if(values == null && _data.ContainsKey(name)){
				if (_data [name] is List<double>) {
					values2 = (List<double>)_data [name];
				}
			}
			if (values != null || values2 != null) {
				List<double> ret = new List<double> ();
				if (values != null) {
					foreach (object value in values) {
						if (value is double) {
							ret.Add ((double)value);
						}
					}
				} else {
					foreach (object value in values2) {
						if (value is double) {
							ret.Add ((double)value);
						}
					}
				}
				return ret;
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		public List<bool> GetBooleanList(String name)
		{
			List<object> values = GetObjectList(name);
			List<bool> values2 = null;
			if (values == null && _data.ContainsKey(name))
			{
				if (_data[name] is List<bool>)
				{
					values2 = (List<bool>)_data[name];
				}
			}
			if (values != null || values2 != null)
			{
				List<bool> ret = new List<bool>();
				if (values != null)
				{
					foreach (object value in values)
					{
						if (value is bool)
						{
							ret.Add((bool)value);
						}
					}
				}
				else
				{
					foreach (object value in values2)
					{
						if (value is bool)
						{
							ret.Add((bool)value);
						}
					}
				}

				return ret;
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public List<int> GetIntList(String name){
			List<object> values = GetObjectList (name);
			List<int> values2 = null;
			if(values == null && _data.ContainsKey(name)){
				if (_data [name] is List<int>) {
					values2 = (List<int>)_data [name];
				}
			}
			if (values != null || values2 != null) {
				List<int> ret = new List<int> ();
				if (values != null) {
					foreach (object value in values) {
						if (value is double) {
							ret.Add (Convert.ToInt32 ((double)value));
						} else if (value is int) {
							ret.Add ((int)value);
						}
					}
				} else {
					foreach (object value in values2) {
						if (value is double) {
							ret.Add (Convert.ToInt32 ((double)value));
						} else if (value is int) {
							ret.Add ((int)value);
						}
					}
				}

				return ret;
			}
			return null;
		}

        /// <summary>
        /// 
        /// </summary>
		public List<long> GetLongList(String name){
			List<object> values = GetObjectList (name);
			List<long> values2 = null;
			if(values == null && _data.ContainsKey(name)){
				if (_data [name] is List<long>) {
					values2 = (List<long>)_data [name];
				}
			}
			if (values != null || values2 != null) {
				List<long> ret = new List<long> ();
				if (values != null) {
					foreach (object value in values) {
						if (value is double) {
							ret.Add (Convert.ToInt64 ((double)value));
						} else if (value is long) {
							ret.Add ((long)value);
						}
					}
				} else {
					foreach (object value in values2) {
						if (value is double) {
							ret.Add (Convert.ToInt64 ((double)value));
						} else if (value is long) {
							ret.Add ((long)value);
						}
					}
				}

				return ret;
			}
			return null;
		}

		public List<GSData> GetGSDataList(String name){

			List<object> values = GetObjectList (name);
			if (values != null) {
				List<GSData> ret = new List<GSData> ();
				foreach(object value in values){
					if (value is GSData) {
						ret.Add ((GSData)_data [name]);
					} else if (value is Dictionary<String,Object>) {
						ret.Add(new GSData ((Dictionary<String,Object>)value));
					}
				}
				return ret;
			}
			return null;
		}

		public GSData GetGSData(String name){
			if(_data.ContainsKey(name)){
				Object o = _data [name];
				if (o is GSData) {
					return (GSData)_data [name];
				} else if (o is Dictionary<String,Object>) {
					return new GSData ((Dictionary<String,Object>)o);
				}

			}
			return null;
		}


        /// <summary>
        /// 
        /// </summary>
		[Obsolete("GetObjectList is deprecated, please use GetGSDataList instead.")]
        public List<object> GetObjectList(String name){
			if(_data.ContainsKey(name)){
				if (_data [name] is List<object>) {
					return (List<object>)_data [name];
				}
			}
			return null;
		}

		/// <summary>
		/// 
		/// </summary>
		[Obsolete("GetObject is deprecated, please use GetGSData instead.")]
		public GSData GetObject(String name){
			if(_data.ContainsKey(name)){
				Object o = _data [name];
				if (o is GSData) {
					return (GSData)_data [name];
				} else if (o is Dictionary<String,Object>) {
					return new GSData ((Dictionary<String,Object>)o);
				}

			}
			return null;
		}

	}

}

#pragma warning restore 612, 618