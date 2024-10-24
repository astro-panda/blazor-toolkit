using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using AstroPanda.Blazor.Toolkit.Services;

namespace AstroPanda.Blazor.Toolkit.Components
{
    public partial class ContextMenuProvider : IDisposable
    {
        [Inject]
        private IContextMenuService _contextMenuService { get; set; }

        [Inject]
        private NavigationManager _navigationManager { get; set; }

        private List<ContextMenuReference> _contextMenus { get; set; } = new List<ContextMenuReference>();


        protected override void OnInitialized()
        {
            ((ContextMenuService)_contextMenuService).OnInstanceAdded += AddInstance;
            ((ContextMenuService)_contextMenuService).OnInstanceCloseRequested += CloseAll;

            if (_navigationManager != null)
                _navigationManager.LocationChanged += HandleLocationChanged;
        }

        private void AddInstance(ContextMenuReference contextMenu)
        {
            _contextMenus.Clear();
            _contextMenus.Add(contextMenu);
            StateHasChanged();
        }

        public void CloseAll()
        {
            _contextMenus.Clear();
            StateHasChanged();
        }

        private void HandleLocationChanged(object sender, LocationChangedEventArgs args)
        {
            CloseAll();
        }

        public void Dispose()
        {
            if (_navigationManager != null)
                _navigationManager.LocationChanged -= HandleLocationChanged;
        }
    }
}
