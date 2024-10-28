using Microsoft.AspNetCore.Components;

namespace AstroPanda.Blazor.Toolkit;

public class ContextMenuService : IContextMenuService
{
    public event Action<ContextMenuReference> OnInstanceAdded;
    public event Action OnInstanceCloseRequested;

    public IContextMenuReference Open<T>(double x, double y) where T : ComponentBase, new() => Open<T>(x, y, builder => { });

    public IContextMenuReference Open<T>(double x, double y, Action<T> builder) where T : ComponentBase, new()
    {
        T instance = new T();
        builder(instance);

        return Open(x, y, instance);
    }

    private IContextMenuReference Open<T>(double x, double y, T contentComponent) where T : ComponentBase, new()
    {
        Guid contextMenuId = Guid.NewGuid();
        ContextMenuReference contextMenuRef = new ContextMenuReference(new Tuple<double, double>(x, y), contextMenuId, this);
        Type componentType = contentComponent.GetType();

        var contextMenuContent = new RenderFragment(builder => {
            int i = 0;
            builder.OpenComponent(i++, componentType);
            foreach (var param in componentType.GetProperties())
            {
                builder.AddAttribute(i++, param.Name, param.GetValue(contentComponent));
            }
            builder.AddComponentReferenceCapture(i, inst => contextMenuRef.InjectContextMenu(inst));
            builder.CloseComponent();
        });

        var contextMenuInstance = new RenderFragment(builder => {
            builder.OpenComponent<ContextMenu>(0);
            builder.SetKey(contextMenuId);
            builder.AddAttribute(1, "Id", contextMenuId);
            builder.AddAttribute(2, "Content", contextMenuContent);
            builder.AddAttribute(3, "X", x);
            builder.AddAttribute(4, "Y", y);
            builder.CloseComponent();
        });

        contextMenuRef.InjectContent(contextMenuInstance);
        OnInstanceAdded?.Invoke(contextMenuRef);

        return contextMenuRef;
    }

    public void Close() => OnInstanceCloseRequested?.Invoke();
}