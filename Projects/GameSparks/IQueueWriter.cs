using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameSparks.Core
{
    /// <summary>
    /// Interface for multiplatform file io (write)
    /// </summary>
    public interface IQueueWriter : IDisposable
    {
        /// <summary>
        /// Write a single line of content to the file. 
        /// </summary>
        void WriteLine(string contentToWrite);
        /// <summary>
        /// Initialize write access to the given file
        /// </summary>
        void Initialize(string fileName);
    }
}
