using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit;

public class ClipboardService : IClipboardService, IAsyncDisposable
{
    private readonly IJSRuntime _jsInterop;
    private readonly Lazy<Task<IJSObjectReference>> _embedClipBoardServiceTask;

    public ClipboardService(IJSRuntime jsInterop)
    {
        _jsInterop = jsInterop;
        _embedClipBoardServiceTask = new(() => _jsInterop.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/clipboardService.js").AsTask());
    }

    public async Task CopyImage(string imageUrl)
    {
        var clipBoardModule = await _embedClipBoardServiceTask.Value;
        await clipBoardModule.InvokeVoidAsync("ClipboardService.copyRemoteImgToClipboard", imageUrl);
    }

    public async Task CopySVGImage(string svgElementId)
    {
        var clipBoardModule = await _embedClipBoardServiceTask.Value;
        await clipBoardModule.InvokeVoidAsync("ClipboardService.copySvgToClipboard", svgElementId);
    }

    public async Task CopyText(string text)
    {
        await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);        
    }

    public async ValueTask DisposeAsync()
    {
        if (_embedClipBoardServiceTask.IsValueCreated)
        {
            var module = await _embedClipBoardServiceTask.Value;
            await module.DisposeAsync();
        }
    }
}
