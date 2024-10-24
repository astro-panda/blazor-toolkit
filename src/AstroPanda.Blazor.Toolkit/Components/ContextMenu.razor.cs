using Microsoft.AspNetCore.Components;

namespace AstroPanda.Blazor.Toolkit.Components
{
    public partial class ContextMenu
    {
        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public double X { get; set; }
        [Parameter]
        public double Y { get; set; }

        [CascadingParameter]
        private ContextMenuProvider Parent { get; set; }

        public void SetCoordinates(Tuple<double, double> xy)
        {
            X = xy.Item1;
            Y = xy.Item2;
        }

        public void Close()
        {
            Parent.CloseAll();
        }
    }
}
