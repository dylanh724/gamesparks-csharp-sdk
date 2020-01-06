using System;
using GameSparks.Api.Requests;
using GameSparks.Core;

namespace GameSparks.Api{

    /// <summary>
    /// Provides several static helper functions
    /// </summary>
	public class GSHelper {

		/// <summary>
		/// Sets up a GetDownloadableRequest that will return a GetDownloadableResponse
		/// With a byte[] in it at key "bytes" representing the bytes of the file. To access
		/// use response.JSONData["bytes"]
		/// </summary>
		public static GetDownloadableRequest GetDownloadableRequestAndDownloadFile() {
			GetDownloadableRequest r = new GetDownloadableRequest ();
			r.AddCompleter(new FileDownloader ().GetFileBytesFromUrl);
			return r;
		}

		/// <summary>
		/// Sets up a GetUploadUrlRequest that will upload the bytes supplied to the correct
		/// location after the response has been received
		/// </summary>
		public static GetUploadUrlRequest GetUploadUrlRequestAndUploadFile(byte[] fileData, String fileName) {
			GetUploadUrlRequest r = new GetUploadUrlRequest ();
			r.AddCompleter (new FileUploader (fileData, fileName).Upload);
			return r;
		}
	}
}


