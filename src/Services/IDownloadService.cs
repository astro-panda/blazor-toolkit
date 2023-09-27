
namespace AstroPanda.Blazor.Toolkit;

public interface IDownloadService : IAsyncDisposable
{
    Task DownloadLocalAsync(string filename, Stream stream);

    Task DownloadRemoteAsync(string filename, string uri); 
}