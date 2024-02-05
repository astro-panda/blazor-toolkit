using AstroPanda.Blazor.Toolkit.Components;

namespace AstroPanda.Blazor.Toolkit.Services;

/// <summary>
/// A service for tracking the active <see cref="GenericContextMenu"/>s
/// </summary>
public interface IContextMenuService
{
    /// <summary>
    /// Takes in a <see cref="GenericContextMenu"/> and makes it the active Context Menu, closing the previously active one
    /// </summary>
    /// <param name="contextMenu">The <see cref="GenericContextMenu"/> to make the active one</param>
    public void AddContextMenu(GenericContextMenu contextMenu);

    /// <summary>
    /// Closes the active <see cref="GenericContextMenu"/>
    /// </summary>
    public void CloseActiveContextMenu();
}