using Architecture.Utility;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;
using System;
using System.IO;

namespace Architecture.Services.Plugin.GoogleCloudHelper.CloudStorage
{
    /// <summary>
    /// Class to upload files on the Google Cloud Storage
    /// </summary>
    public static class GoogleCloudStorage
    {
        /// <summary>
        /// Stores the file on the Google Cloud Storage
        /// </summary>
        /// <param name="bucketName">The bucket name for the company.</param>
        /// <param name="localPath">The path to read the file.</param>
        /// <param name="objectName">File name.</param>
        /// <returns></returns>
        public static string UploadFile(string bucketName, string localPath, string objectName = null)
        {
            try
            {
                CreateBucket(bucketName);
            }
            catch (Google.GoogleApiException e)
            {
                if (e.Error.Code == 409)
                {
                    // The bucket already exists.
                    Console.WriteLine(e.Error.Message);
                }
            }
            var storage = StorageClient.Create(Getcredentials());
            using (var f = File.OpenRead(localPath))
            {
                objectName ??= Path.GetFileName(localPath);
                storage.UploadObject(bucketName, objectName, null, f);
            }
            var data = storage.GetObject(bucketName, objectName);
            return data.SelfLink;
        }

        private static Bucket CreateBucket(string bucketName)
        {
            var cred = Getcredentials();
            var storage = StorageClient.Create(cred);
            var projectId = ((ServiceAccountCredential)cred.UnderlyingCredential).ProjectId;
            var bucket = storage.CreateBucket(projectId, bucketName);
            return bucket;
        }

        private static GoogleCredential Getcredentials()
        {
            GoogleCredential credential = null;
            using (var jsonStream = new FileStream(ArchitectureDefaults.GOOGLE_CLOUD_STORAGE_CREDENTIAL_FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                credential = GoogleCredential.FromStream(jsonStream);
            }
            return credential;
        }
    }
}
