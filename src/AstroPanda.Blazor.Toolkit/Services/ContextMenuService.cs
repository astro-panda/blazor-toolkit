using AstroPanda.Blazor.Toolkit.Components;
using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit.Services;

internal class ContextMenuService : IContextMenuService
{

    private static GenericContextMenu? _activeContextMenu;

    public ContextMenuService(IJSRuntime js)
    {
        js.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/contextMenuService.js");
    }

    public void AddContextMenu(GenericContextMenu contextMenu)
    {
        if (_activeContextMenu is not null)
            CloseActiveContextMenu();

        _activeContextMenu = contextMenu;
    }

    [JSInvokable("CloseActiveContextMenu")]
    public void CloseActiveContextMenu(bool calledFromContextMenu = false)
    {
        Console.WriteLine("*** The CloseActiveContextMenu method has been called");

        if (_activeContextMenu is null)
            return;

        _activeContextMenu.Close();

        _activeContextMenu = null;
    }
}
