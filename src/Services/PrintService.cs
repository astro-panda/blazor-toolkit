using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit
{
    public class PrintService : IPrintService, IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> _embedPrintServiceTask;

        public PrintService(IJSRuntime js)
        {
            _embedPrintServiceTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/printService.js").AsTask());
        }

        public async ValueTask DisposeAsync()
        {
            if (_embedPrintServiceTask.IsValueCreated)
            {
                var module = await _embedPrintServiceTask.Value;
                await module.DisposeAsync();
            }            
        }

        public async Task Print(string targetElementId)
        {
            
            var printService = await _embedPrintServiceTask.Value;

            await printService.InvokeVoidAsync("print", targetElementId);
        }
    }
}
