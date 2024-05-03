namespace Application.Common.Interfaces;

public interface IStorageAccountService
{
    //Task DownloadBlob(ClientCredentials clientCredentials, string blobUri, string filePath);
    Task DownloadBlob(string blobUri, string filePath);
}
