using AstroPanda.Blazor.Toolkit.Models;

namespace AstroPanda.Blazor.Toolkit.Services;
public interface IDeviceService
{
    public Task<DeviceOrientation> GetOrientation();
    public Task<bool> IsMobile();

    public Action<DeviceOrientation> OrientationChanged { get; set; }

    public Task OnOrientationChange();
}
