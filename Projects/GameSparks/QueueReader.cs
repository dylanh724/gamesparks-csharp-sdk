using System;
using System.IO;

namespace GameSparks.Core
{
    /// <summary>
    /// Reads durable events from disc. 
    /// </summary>
    public class QueueReader : IQueueReader
    {

        private StreamReader sr;
        private string fileName;

        /// <summary>
        /// Initialize read access to the given file. 
        /// </summary>
        public void Initialize(string fileName)
        {
            this.fileName = fileName;
            if (File.Exists(fileName))
            {
                sr = File.OpenText(fileName);
            }
        }

        /// <summary>
        /// Dispose this instance.
        /// </summary>
        public void Dispose()
        {
            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
            }
            /*try
            {
                File.Delete(fileName);
            }
            catch { }*/
        }

        /// <summary>
        /// Reads the stream to the end and automatically disposes this instance. Can be used/implemented async. 
        /// </summary>
        public String ReadFully()
        {
            if (sr == null)
            {
                return null;
            }

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string line = null;
            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    sb.AppendLine(line);
                }

            } while (line != null);
            Dispose();
            return sb.ToString();
        }

    }
}
