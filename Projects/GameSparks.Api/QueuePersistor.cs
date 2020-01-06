using System;
using System.Collections.Generic;
using GameSparks.Core;
using System.IO;
using System.Text;
using System.Threading;

namespace GameSparks.Api
{
	internal class QueuePersistor{

		public static void Write(GSInstance gsInstance, List<GSRequest> queue) {
            try
            {
                String path = GetPath(gsInstance);    

				File.WriteAllText(path, String.Empty);
                
				QueueWriter qw = new QueueWriter();  

                qw.Initialize(path);      
                
				foreach (var request in queue)
                {
                    if (request != null)
                    {
                        IDictionary<String, Object> queuedItem = new Dictionary<string, object>();                                        
                        String json = request.JSON;
                        if (json != null)
                        {
                            Log(gsInstance, "write " + json);

                            queuedItem.Add("rq", json);
                            queuedItem.Add("sg", gsInstance.GSPlatform.MakeHmac(json, gsInstance.GSPlatform.ApiSecret));

                            qw.WriteLine(GSJson.To(queuedItem));
                        }
                    }
                }
                Log(gsInstance, "Writing Data to disk. ");

                qw.Dispose();               
            }
            catch (Exception e)
            {
                Log(gsInstance, e.ToString());
            }
		}

        public static LinkedList<GSRequest> Read(GSInstance gsInstance)
        {
            Log(gsInstance, "Reading Persistent Queue");

			LinkedList<GSRequest> persistantQueue = new LinkedList<GSRequest> ();
            String path = GetPath(gsInstance);
			QueueReader qr = new QueueReader();

            qr.Initialize(path);
            
			string content = qr.ReadFully();
            
			qr.Dispose();

            if (content != null)
            {
                using (StringReader reader = new StringReader(content))
                {
                    string line = null;

                    do
                    {
                        line = reader.ReadLine();
                        if (line != null && line.Trim().Length > 0)
                        {
                            GSRequest request = StringToRequest(gsInstance, line);
							
                            if (request != null)
                            {
                                Log(gsInstance, "read " + request.JSON);
                                persistantQueue.AddLast(request);
                            }
                        }
                    }
                    while (line != null);
                }
            }

            return persistantQueue;
		}

        private const string DataFileName = "gs_{0}_{1}.dat";

        private static string GetFileName(GSInstance gsInstance)
        {
            return string.Format(DataFileName, gsInstance.Name, gsInstance.GSPlatform.UserId);
        }

        private static string GetPath(GSInstance gsInstance)
        {
            return Path.Combine(gsInstance.GSPlatform.PersistentDataPath, GetFileName(gsInstance));
        }

		private static GSRequest StringToRequest(GSInstance gsInstance, String requestString){

			object parsed = GSJson.From (requestString);

			if (parsed is IDictionary<string,object>) {
				String json = ((IDictionary<string,object>)parsed) ["rq"].ToString();
				String signature = ((IDictionary<string,object>)parsed) ["sg"].ToString();
                String properSig = gsInstance.GSPlatform.MakeHmac(json, gsInstance.GSPlatform.ApiSecret);

				if (properSig.Equals (signature)) {
					return new GSRequest ((IDictionary<string,object>)GSJson.From (json));
				}
			}

			return null;
		}

        static void Log(GSInstance gsInstance, string message)
        {
            if (gsInstance.TraceMessages)
                gsInstance.GSPlatform.DebugMsg("Queue: " + message);
        }
	}
}

