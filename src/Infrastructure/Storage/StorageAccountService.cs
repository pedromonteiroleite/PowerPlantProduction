using Application.Common.Interfaces;
using Azure.Identity;
using Azure.Storage.Blobs;
using Infrastructure.Identity;

namespace Infrastructure.Storage;

public class StorageAccountService : IStorageAccountService
{

    //public async Task DownloadBlob(ClientCredentials clientCredentials, string blobUri, string filePath)
    //{
    //    var clientSecretCredential = new ClientSecretCredential(clientCredentials.TenantId, clientCredentials.ClientId, clientCredentials.ClientSecret);
    //    var client = new BlobClient(new Uri(blobUri), clientSecretCredential);
    //    await client.DownloadToAsync(filePath);
    //}
    public Task DownloadBlob(string blobUri, string filePath)
    {
        throw new NotImplementedException();
    }
}
