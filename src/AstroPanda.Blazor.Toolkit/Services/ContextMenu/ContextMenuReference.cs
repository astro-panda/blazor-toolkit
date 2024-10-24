using AstroPanda.Blazor.Toolkit.Components;
using Microsoft.AspNetCore.Components;

namespace AstroPanda.Blazor.Toolkit.Services;

public class ContextMenuReference : IContextMenuReference
{
    private IContextMenuService _contextMenuService { get; set; }

    internal Guid Id { get; set; } = Guid.NewGuid();

    internal RenderFragment Content { get; private set; }

    public ContextMenu ContextMenu { get; private set; }

    public ContextMenuReference(Tuple<double, double> xy, Guid instanceId, IContextMenuService contextMenuService)
    {
        XY = xy;
        _contextMenuService = contextMenuService;
    }

    public Tuple<double, double> XY { get; set; }

    internal void InjectContent(RenderFragment renderFragment)
    {
        Content = renderFragment;
    }

    internal void InjectContextMenu(object inst)
    {
        ContextMenu = inst as ContextMenu;
    }
}
