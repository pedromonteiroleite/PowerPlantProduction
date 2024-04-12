namespace Application.Common.Interfaces;

public interface IStorageAccountService
{
    Task DownloadBlob(string blobUri, string filePath);
}
