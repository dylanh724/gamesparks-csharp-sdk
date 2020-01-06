using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace GameSparks.Core
{
    internal static class GameSparksFormUpload
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static string MultipartFormDataPost(string postUrl, string userAgent, IDictionary<string, object> postParameters)
        {
            string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
            string contentType = "multipart/form-data; boundary=" + formDataBoundary;

            byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

            GameSparksFormUpload2.SetServerCertificateValidationCallback();
     
            HttpWebResponse webResponse = PostForm(postUrl, userAgent, contentType, formData);
            StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
            
            return responseReader.ReadToEnd();
        }

        private static byte[] GetMultipartFormData(IDictionary<string, object> postParameters, string boundary)
        {
            Stream formDataStream = new System.IO.MemoryStream();
            bool needsCLRF = false;

            foreach (var param in postParameters)
            {
                // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                // Skip it on the first parameter, add it to subsequent parameters.
                if (needsCLRF)
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                needsCLRF = true;

                if (param.Value is FileParameter)
                {
                    FileParameter fileToUpload = (FileParameter)param.Value;

                    // Add just the first part of this param, since we will write the file data directly to the Stream
                    string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                        boundary,
                        param.Key,
                        fileToUpload.FileName ?? param.Key,
                        fileToUpload.ContentType ?? "application/octet-stream");

                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                    // Write the file data directly to the Stream, rather than serializing it to a string.
                    formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                }
                else
                {
                    string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                        boundary,
                        param.Key,
                        param.Value);
                    formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                }
            }

            // Add the end of the request.  Start with a newline
            string footer = "\r\n--" + boundary + "--\r\n";
            formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

            // Dump the Stream into a byte[]
            formDataStream.Position = 0;
            byte[] formData = new byte[formDataStream.Length];
            formDataStream.Read(formData, 0, formData.Length);

            GameSparksUtil.CompleteStream(formDataStream);

            return formData;
        }

        private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
        {
            HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;

            if (request == null)
            {
                throw new NullReferenceException("request is not a http request");
            }

            try
            {
                request.Method = "POST";
                request.ContentType = contentType;
                request.CookieContainer = new CookieContainer();

                IDictionary<string, object> asyncResultValues = new Dictionary<string, object>();
                asyncResultValues.Add("r", request);
                asyncResultValues.Add("d", formData);
                AutoResetEvent are = new AutoResetEvent(false);
                asyncResultValues.Add("a", are);
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), asyncResultValues);
                are.WaitOne();
                return asyncResultValues["response"] as HttpWebResponse;
            }
            catch (Exception e)
            {
                GS.GSPlatform.DebugMsg(e.ToString());

                return null;
            }
        }

        private static void GetRequestStreamCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                IDictionary<string, object> asyncResultValues = (IDictionary<string, object>)asynchronousResult.AsyncState;

                HttpWebRequest request = (HttpWebRequest)asyncResultValues["r"];
                byte[] formData = (byte[])asyncResultValues["d"];
                Stream requestStream = request.EndGetRequestStream(asynchronousResult);
                requestStream.Write(formData, 0, formData.Length);
                GameSparksUtil.CompleteStream(requestStream);
                request.BeginGetResponse(new AsyncCallback(GetResponseCallback), asyncResultValues);
            }
            catch (Exception e)
            {
                GS.GSPlatform.DebugMsg(e.ToString());
            }
        }

        private static void GetResponseCallback(IAsyncResult asynchronousResult)
        {
            try
            {
                IDictionary<string, object> asyncResultValues = (IDictionary<string, object>)asynchronousResult.AsyncState;

                HttpWebRequest request = (HttpWebRequest)asyncResultValues["r"];
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
                asyncResultValues.Add("response", response);
                AutoResetEvent are = (AutoResetEvent)asyncResultValues["a"];
                are.Set();
            }
            catch (Exception e)
            {
                GS.GSPlatform.DebugMsg(e.ToString());
            }
        }

        public class FileParameter
        {
            public byte[] File { get; set; }
            public string FileName { get; set; }
            public string ContentType { get; set; }
            public FileParameter(byte[] file) : this(file, null) { }
            public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
            public FileParameter(byte[] file, string filename, string contenttype)
            {
                File = file;
                FileName = filename;
                ContentType = contenttype;
            }
        }
    }
}