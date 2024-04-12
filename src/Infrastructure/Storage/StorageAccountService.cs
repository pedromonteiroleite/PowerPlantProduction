using Application.Common.Interfaces;
using Azure.Identity;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Storage;

public class StorageAccountService : IStorageAccountService
{

    private readonly IConfiguration _configuration;

    public StorageAccountService(IConfiguration configuration)
    {
        _configuration = configuration;

    }

    private BlobClient GetClient(string blobUri)
    {
        var tenantId = _configuration.GetValue<string>("AzureAD:TenantId");
        var clientId = _configuration.GetValue<string>("AzureAD:ClientId");
        var clientSecret = _configuration.GetValue<string>("AzureAD:ClientSecret");

        var clientSecretCredential = new ClientSecretCredential(tenantId, clientId, clientSecret);
        return new BlobClient(new Uri(blobUri), clientSecretCredential);
    }

    public async Task DownloadBlob(string blobUri, string filePath)
    {
        var client = GetClient(blobUri);
        await client.DownloadToAsync(filePath);
    }

}
