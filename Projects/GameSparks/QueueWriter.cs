using System;
using System.IO;

namespace GameSparks.Core
{
    /// <summary>
    /// Writes durable events to disc. 
    /// </summary>
	public class QueueWriter : IQueueWriter
	{

		private StreamWriter sw;



        /// <summary>
        /// Initialize the writer for a given file name. 
        /// </summary>
        public void Initialize(string fileName)
		{
			sw = new StreamWriter (fileName, false);
		}

        /// <summary>
        /// Write a single line to the queue. 
        /// </summary>
        /// <param name="line"></param>
		public void WriteLine(String line){
			if (sw != null) {
				sw.WriteLine (line);
				sw.Flush ();
			}
		}

        /// <summary>
        /// Dispose this instance. 
        /// </summary>
		public void Dispose(){
			if (sw != null) {
				sw.Flush ();
				sw.Close ();
				sw.Dispose ();
			}
		}

    }
}

