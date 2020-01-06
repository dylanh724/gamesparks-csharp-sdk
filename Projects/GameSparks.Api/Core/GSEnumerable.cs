using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    /// <summary>
    /// Factory for arrays of typed GSData
    /// </summary>
    public class GSEnumerable<T> : IEnumerable<T>
    {
        private List<object> m_list;
        Func<GSData, T> creator;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data which will be used to create the instances from</param>
        /// <param name="creator">factory method to use for creation of the instances</param>
        public GSEnumerable(List<object> data, Func<GSData, T> creator)
        {
            if (data != null)
            {
                m_list = data;
            }
            else
            {
                m_list = new List<object>();
            }
            this.creator = creator;
        }

        /// <summary>
        /// For each entry in the array, runs the creator. 
        /// </summary>
        /// <returns>An instance of T for every entry in the array</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (object item in m_list)
            {
                if (item is IDictionary<string, object>)
                {
                    yield return (T)creator(new GSData((IDictionary<string, object>)item));
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

	
}
