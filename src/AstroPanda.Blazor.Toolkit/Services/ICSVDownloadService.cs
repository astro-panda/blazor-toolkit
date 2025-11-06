namespace AstroPanda.Blazor.Toolkit.Services;

public interface ICSVDownloadService<T>
{
    public Task DownloadLocalAsync(string fileName, IEnumerable<T> collection);
}
