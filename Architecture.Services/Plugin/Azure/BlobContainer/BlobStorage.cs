using Architecture.Utility;
using Azure.Storage.Files.DataLake;
using Azure.Storage.Sas;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Architecture.Services.Plugin.Azure.BlobContainer
{
    public class BlobStorage
    {
        private readonly string ConnectionStrings_AccessKey;
        private readonly IConfiguration _config;
        public BlobStorage(IConfiguration config)
        {
            _config = config;
            ConnectionStrings_AccessKey = _config["Azure:Blob:Connectionstring"];
        }

        /// <summary>
        /// Upload Files from base64 string to blob storage
        /// </summary>
        /// <param name="base64string"></param>
        /// <param name="containerName"></param>
        /// <param name="UploadFileName"> if blank or null then GUID will be used for the filename</param>
        /// <param name="DynamicName">if true then generate new filename as GUID</param>
        /// <returns></returns>
        public async Task<string> UploadFileFromBase64(string base64string, string containerName, string UploadFileName = "", bool DynamicName = true)
        {
            if (CloudStorageAccount.TryParse(ConnectionStrings_AccessKey, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();
                string fileName = string.Empty;
                if (DynamicName || UploadFileName.CheckIsNull())
                    fileName = Guid.NewGuid().ToString();
                else
                {
                    fileName = UploadFileName;
                }
                var picblob = container.GetBlockBlobReference(fileName);

                byte[] imageBytes = Convert.FromBase64String(base64string);
                picblob.UploadFromByteArray(imageBytes, 0, imageBytes.Count());

                var pathToSave = picblob.Uri;
                return pathToSave.ToString();
            }
            return "";
        }
        /// <summary>
        /// Upload Files from the local file path string to blob storage
        /// </summary>
        /// <param name="filePath">Local System file path like D:/image.jpg</param>
        /// <param name="containerName"></param>
        /// <param name="UploadFileName"> if blank or null then GUID will be used for the filename</param>
        /// <param name="DynamicName">if true then generate new filename as GUID</param>
        /// <returns></returns>
        public async Task<string> UploadFileFromFileURL(string filePath, string containerName, string UploadFileName = "", bool DynamicName = true)
        {
            if (CloudStorageAccount.TryParse(ConnectionStrings_AccessKey, out CloudStorageAccount storageAccount))
            {
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                await container.CreateIfNotExistsAsync();
                string imageName = string.Empty;
                string fileName = string.Empty;
                if (DynamicName || UploadFileName.CheckIsNull())
                    fileName = Guid.NewGuid().ToString();
                else
                {
                    fileName = UploadFileName;
                }
                var picblob = container.GetBlockBlobReference(fileName);

                picblob.UploadFromFile(filePath);
                var pathToSave = picblob.Uri;
                return pathToSave.ToString();
            }
            return "";
        }
        /// <summary>
        /// GENERATE the SAS Read Token for the Blob URL. To Restrict for several time period
        /// DO NOT USE THIS DEPRYCATED
        /// </summary>
        /// <param name="resourceUri"></param>
        /// <param name="keyName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string createToken(string resourceUri, string keyName, string key)
        {
            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var week = 60 * 60 * 24 * 7;
            var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + week);
            string stringToSign = HttpUtility.UrlEncode(resourceUri) + "\n" + expiry;
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign)));
            var sasToken = String.Format(CultureInfo.InvariantCulture, "SharedAccessSignature sr={0}&sig={1}&se={2}&skn={3}", HttpUtility.UrlEncode(resourceUri), HttpUtility.UrlEncode(signature), expiry, keyName);
            return sasToken;
        }
        /// <summary>
        ///  GENERATE the SAS Read Token for the Blob URL. To Restrict for several time period
        /// </summary>
        /// <param name="FileURL"></param>
        /// <param name="sasMinutesValid"></param>
        /// <param name="delete"></param>
        /// <param name="write"></param>
        /// <param name="list"></param>
        /// <param name="read"></param>
        /// <returns></returns>
        public string GetSasForBlob(string FileURL, int sasMinutesValid,
            bool delete = false, bool write = false, bool list = false, bool read = false)
        {
            if (CloudStorageAccount.TryParse(ConnectionStrings_AccessKey, out CloudStorageAccount storageAccount))
            {
                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference(GetContainerName(FileURL));
                CloudBlockBlob blob = container.GetBlockBlobReference(Path.Combine(GetBlobName(FileURL), URLUtilities.GetFileName(FileURL)));
                SharedAccessBlobPermissions permission = SharedAccessBlobPermissions.None;
                if (delete)
                {
                    permission = SharedAccessBlobPermissions.Delete;
                }
                else if (write)
                {
                    permission = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;
                }
                else if (list)
                {
                    permission = SharedAccessBlobPermissions.List;
                }
                else if (read)
                {
                    permission = SharedAccessBlobPermissions.Read;
                }
                var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
                {
                    Permissions = permission,
                    SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-15),
                    SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(sasMinutesValid),
                });
                return string.Format(CultureInfo.InvariantCulture, "{0}{1}", blob.Uri, sasToken);
            }
            else
            {
                Console.WriteLine(@"DataLakeDirectoryClient must be authorized with Shared Key 
                          credentials to create a service SAS.");
                return null;
            }
        }
        private static Uri GetServiceReadSasUriForDirectory(DataLakeDirectoryClient directoryClient,
                                           string storedPolicyName = null)
        {
            if (directoryClient.CanGenerateSasUri)
            {
                // Create a SAS token that's valid for one hour.
                DataLakeSasBuilder sasBuilder = new DataLakeSasBuilder()
                {
                    // Specify the file system name, the path, and indicate that
                    // the client object points to a directory.
                    FileSystemName = directoryClient.FileSystemName,
                    Resource = "d",
                    IsDirectory = true,
                    Path = directoryClient.Path,
                };

                // If no stored access policy is specified, create the policy
                // by specifying expiry and permissions.
                if (storedPolicyName == null)
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);
                    sasBuilder.SetPermissions(DataLakeSasPermissions.Read);
                }
                else
                {
                    sasBuilder.Identifier = storedPolicyName;
                }

                // Get the SAS URI for the specified directory.
                Uri sasUri = directoryClient.GenerateSasUri(sasBuilder);
                Console.WriteLine("SAS URI for ADLS directory is: {0}", sasUri);
                Console.WriteLine();

                return sasUri;
            }
            else
            {
                Console.WriteLine(@"DataLakeDirectoryClient must be authorized with Shared Key 
                          credentials to create a service SAS.");
                return null;
            }
        }
        //To Find the BlobName ({FIRSTFOLDERNAME})from below URL
        //https://{URL}/{CONTAINERNAME}/{FIRSTFOLDERNAME}/{FOLDERNAME}/{FILENAME}.{EXTENTION}/
        private string GetBlobName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string blobName = "";

            if (parts.Length > 0)
                blobName = parts[4];
            else
                blobName = hrefLink;

            return blobName;
        }

        //To Find the Contaner Name from below URL
        //https://{URL}/{CONTAINERNAME}/{FIRSTFOLDERNAME}/{FOLDERNAME}/{FILENAME}.{EXTENTION}/
        private string GetContainerName(string hrefLink)
        {
            string[] parts = hrefLink.Split('/');
            string containerName = "";

            if (parts.Length > 0)
                containerName = parts[3];
            else
                containerName = hrefLink;

            return containerName;
        }
    }
}
