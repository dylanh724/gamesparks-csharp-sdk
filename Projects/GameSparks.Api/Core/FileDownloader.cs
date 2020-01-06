using System;
using System.IO;
using System.Net;
using System.Threading;

namespace GameSparks.Core
{
    internal class FileDownloader
    {

        private HttpWebRequest webRequest;
        private AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        private byte[] responseBytes;

        public void GetFileBytesFromUrl(GSObject getUploadUrlResponse)
        {
            if (getUploadUrlResponse.ContainsKey("url"))
            {
                webRequest = (HttpWebRequest)HttpWebRequest.Create(getUploadUrlResponse.GetString("url"));
                webRequest.BeginGetResponse(new AsyncCallback(ResponseCallback), webRequest);
                if (autoResetEvent.WaitOne(120000))
                {
                    getUploadUrlResponse.Add("bytes", responseBytes);
                }
            }
        }

        private void ResponseCallback(IAsyncResult asyncResult)
        {
            HttpWebRequest webRequest = (HttpWebRequest)asyncResult.AsyncState;

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.EndGetResponse(asyncResult);

            MemoryStream tempStream = new MemoryStream();
            Stream inStream = webResponse.GetResponseStream();

            byte[] buffer = new byte[16 * 1024]; // Fairly arbitrary size
            int bytesRead;

            while ((bytesRead = inStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                tempStream.Write(buffer, 0, bytesRead);
            }
            responseBytes = tempStream.ToArray();

            autoResetEvent.Set();

        }
    }
}