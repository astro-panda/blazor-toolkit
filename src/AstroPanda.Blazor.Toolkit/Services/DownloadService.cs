using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit;

public class DownloadService : IDownloadService
{
    private readonly Lazy<Task<IJSObjectReference>> _embedDownloadServiceTask;

    public DownloadService(IJSRuntime js)
    {
        _embedDownloadServiceTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/downloadService.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (_embedDownloadServiceTask.IsValueCreated)
        {
            var module = await _embedDownloadServiceTask.Value;
            await module.DisposeAsync();
        }
    }

    public async Task DownloadLocalAsync(string filename, Stream stream)
    {
        var jsDownloadService = await _embedDownloadServiceTask.Value;
        using var streamRef = new DotNetStreamReference(stream);
        await jsDownloadService.InvokeVoidAsync("downloadStream", filename, streamRef);
    }

    public async Task DownloadRemoteAsync(string filename, string uri)
    {
        var jsDownloadService = await _embedDownloadServiceTask.Value;
        await jsDownloadService.InvokeVoidAsync("downloadFile", filename, uri);
    }
}