using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Azure
{
    public class CeateItem
    {
        public async Task<string> CeateNew(string blobPath)
        {
            String StorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1";
            string name = "publiclibrary";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(name);

            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions()
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(Path.GetFileName(blobPath));
            using (var filestream = System.IO.File.OpenRead(blobPath))
            {
                await blockBlob.UploadFromStreamAsync(filestream);
            }
            return blockBlob.Uri.ToString();
        }
    }
}
