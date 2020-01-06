using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    ///
    /// Interface for multiplatform file io (read)
    ///
    public interface IQueueReader : IDisposable
    {
        /// <summary>
        /// Reads the queue completely and syncronous.
        /// </summary>
        /// <returns></returns>
        string ReadFully();

        /// <summary>
        /// Initialize the reader for the given filename. 
        /// </summary>
        void Initialize(string fileName);
        
    }
}
