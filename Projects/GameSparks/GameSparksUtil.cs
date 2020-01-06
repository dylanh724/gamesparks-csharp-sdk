using System;
using System.IO;
using System.Security.Cryptography;

using System.Net.Sockets;

namespace GameSparks.Core
{
    /// <summary>
    /// Static utility class. 
    /// </summary>
	public static class GameSparksUtil
	{
        /// <summary>
        /// Standard implementation of SHA-256 HMac in C#. 
        /// This is not working on WebGL and IL2CPP. Custom implementations are needed in this case. 
        /// </summary>
        /// <returns></returns>
		public static string MakeHmac(string strToHmac, string secret)
		{
			var encoding = new System.Text.UTF8Encoding();
			byte[] keyByte = encoding.GetBytes(secret);
			byte[] messageBytes = encoding.GetBytes(strToHmac);
			using (var hmacsha256 = new HMACSHA256(keyByte))
			{
				byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
				string sig = Convert.ToBase64String(hashmessage);
				return sig;
			}
		}

		/// <summary>
		/// Given Stream will be closed. This is framework specific code. 
		/// </summary>
        public static void CompleteStream(Stream stream){
			stream.Close ();
		}

        /// <summary>
        /// Returns true if the SDK can try to connect to the service. This is framework specific code. 
        /// </summary>
		public static Boolean ShouldConnect{
            get
            {
                return true;
            }
		}

        internal static void LogError(string p)
        {
            Write("Error: " + p);

        }
        internal static void Log(string p)
        {
            Write("Log: " + p);

        }

        internal static void LogException(Exception e)
        {
            Write("Exception: " + e.ToString());
        }

        private static void Write(string p)
        {
            if (LogMessageHandler != null)
                LogMessageHandler("GSUtil: " + p);
            System.Diagnostics.Debugger.Log(0, "GSUtil", p);
        }

        /// <summary>
        /// This can be used to register for internal SDK logging. 
        /// </summary>
        public static System.Action<string> LogMessageHandler;
	}
}

