namespace AstroPanda.Blazor.Toolkit.Models;

public class ContextMenuOpenedMessage
{
    public ContextMenuOpenedMessage() { }

    public ContextMenuOpenedMessage(Guid contextMenuId)
    {
        ContextMenuId = contextMenuId;
    }

    /// <summary>
    /// The Id of the Context Menu that just opened
    /// </summary>
    public Guid ContextMenuId { get; set; }
}
