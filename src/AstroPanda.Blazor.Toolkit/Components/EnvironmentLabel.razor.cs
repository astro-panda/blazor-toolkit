using Microsoft.AspNetCore.Components;
using MudBlazor;

#if NET8_0_OR_GREATER && BROWSER1_0_OR_GREATER 
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
#endif

namespace AstroPanda.Blazor.Toolkit;
public partial class EnvironmentLabel
{
#if NET8_0_OR_GREATER && BROWSER1_0_OR_GREATER 
    [Inject]
    private IWebAssemblyHostEnvironment _hostEnvironment { get; set; }
#endif

    [Parameter]
    public List<string> HiddenEnvironments { get; set; } = new();

    [Parameter]
    public Color Color { get; set; } = Color.Error;

    [Parameter]
    public Size Size { get; set; } = Size.Medium;

    private string _environment { get; set; } = string.Empty;

    private bool _showLabel = false;


    protected override async Task OnInitializedAsync()
    {
        _environment = GetEnvironment();
        _showLabel = HiddenEnvironments.Contains(_environment) == false;
    }

    private string GetEnvironment()
    {
#if NET8_0_OR_GREATER && BROWSER1_0_OR_GREATER        
        return _hostEnvironment.Environment;
#else
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
#endif
    }
}
