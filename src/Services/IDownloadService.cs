
namespace AstroPanda.Blazor.Toolkit;

public interface IDownloadService
{
    Task DownloadLocalAsync(string fileName, Stream stream);

    Task DownloadRemoteAsync(string uri); 
}