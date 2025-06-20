using AstroPanda.Blazor.Toolkit.Models;

using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit.Services;
public class DeviceService : IDeviceService, IAsyncDisposable
{
    private readonly IJSRuntime _jsInterop;
    private readonly Lazy<Task<IJSObjectReference>> _deviceServiceTask;
    public DeviceService(IJSRuntime jsInterop)
    {
        _jsInterop = jsInterop;
        _deviceServiceTask = new(() => _jsInterop.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/deviceService.js").AsTask());
    }

    public async Task<bool> IsMobile()
    {
        var deviceModule = await _deviceServiceTask.Value;
        return await deviceModule.InvokeAsync<bool>("DeviceService.isMobile");
    }

    public async Task<DeviceOrientation> GetOrientation()
    {
        var deviceModule = await _deviceServiceTask.Value;
        return await deviceModule.InvokeAsync<DeviceOrientation>("DeviceService.getOrientation");
    }
    public Action<DeviceOrientation> OrientationChanged { get; set; }

    public async Task OnOrientationChange()
    {
        var orientation = await GetOrientation();
        OrientationChanged?.Invoke(orientation);
    }

    public async ValueTask DisposeAsync()
    {
        if (_deviceServiceTask.IsValueCreated)
        {
            var module = await _deviceServiceTask.Value;
            await module.DisposeAsync();
        }
    }
}
