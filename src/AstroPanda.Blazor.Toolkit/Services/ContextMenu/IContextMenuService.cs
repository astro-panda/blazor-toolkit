using Microsoft.AspNetCore.Components;

namespace AstroPanda.Blazor.Toolkit.Services;

public interface IContextMenuService
{
    IContextMenuReference Open<T>(double x, double y) where T : ComponentBase, new();
    IContextMenuReference Open<T>(double x, double y, Action<T> builder) where T : ComponentBase, new();
    void Close();
}
