using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    /// <summary>
    /// Interface for data containers
    /// </summary>
    public interface IGSData
    {
        IDictionary<string, object> BaseData { get; }
    }

}
