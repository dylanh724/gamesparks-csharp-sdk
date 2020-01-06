using GameSparks.Core;
using System;
using System.Collections.Generic;


namespace GameSparks.Core
{
    /// <summary>
    /// Internal class for uploading Data via the GameSparks Upload API.
    /// </summary>
    internal class FileUploader
    {
        private byte[] file;
        String fileName;

        public FileUploader(byte[] file, String fileName)
        {
            this.file = file;
            this.fileName = fileName;
        }

        public void Upload(GSObject getUploadUrlResponse)
        {
            GameSparksFormUpload.FileParameter param = new GameSparksFormUpload.FileParameter(file);
            param.FileName = fileName;
            IDictionary<string, object> postParams = new Dictionary<string, object>();
            postParams.Add("file", param);
            if (getUploadUrlResponse.ContainsKey("url"))
            {
                String response = GameSparksFormUpload.MultipartFormDataPost(getUploadUrlResponse.GetString("url"), "GameSparksUploadAPI", postParams);
                getUploadUrlResponse.Add("uploadResponse", GSJson.From(response));
            }
        }
    }

}
