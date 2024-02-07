using AstroPanda.Blazor.Toolkit.Components;
using Microsoft.JSInterop;

namespace AstroPanda.Blazor.Toolkit.Services;

internal class ContextMenuService : IContextMenuService
{

    private static GenericContextMenu? _activeContextMenu;

    private readonly Lazy<Task<IJSObjectReference>> _embedContextMenuServiceTask;

    public ContextMenuService(IJSRuntime js)
    {
        _embedContextMenuServiceTask = new(() => js.InvokeAsync<IJSObjectReference>("import", "./_content/AstroPanda.Blazor.Toolkit/contextMenuService.js").AsTask());
    }

    public async Task AddContextMenu(GenericContextMenu contextMenu)
    {
        await _embedContextMenuServiceTask.Value;

        if (_activeContextMenu is not null)
            await CloseActiveContextMenu();

        _activeContextMenu = contextMenu;
    }

    [JSInvokable("CloseActiveContextMenu")]
    public async Task CloseActiveContextMenu(bool calledFromContextMenu = false)
    {
        Console.WriteLine("*** The CloseActiveContextMenu method has been called");

        if (_activeContextMenu is null)
            return;

        if (!calledFromContextMenu)
        {
            await _embedContextMenuServiceTask.Value;
            _activeContextMenu.Close();
        }

        if (!calledFromContextMenu)

        _activeContextMenu = null;
    }
}
