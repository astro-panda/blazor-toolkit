using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit;

public class ClipboardService : IClipboardService, IAsyncDisposable
{
    private readonly IJSRuntime _jsInterop;
    private IJSObjectReference? module;    

    public ClipboardService(IJSRuntime jsInterop, ISnackbar snackbar)
    {
        _jsInterop = jsInterop;        
    }

    public async Task CopyImage(string imageUrl)
    {
        module = await _jsInterop.InvokeAsync<IJSObjectReference>("import", "./clipboardService.js");
        await module.InvokeVoidAsync("ClipboardService.copyRemoteImgToClipboard", imageUrl);
    }

    public async Task CopySVGImage(string svgElementId)
    {
        module = await _jsInterop.InvokeAsync<IJSObjectReference>("import", "./clipboardService.js");
        await module.InvokeVoidAsync("ClipboardService.copySvgToClipboard", svgElementId);
    }

    public async Task CopyText(string text)
    {
        await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);        
    }

    public async ValueTask DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
