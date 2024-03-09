using BlazorComponentBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MudBlazor.Services;

namespace AstroPanda.Blazor.Toolkit;
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the services from the Blazor Toolkit
    /// DOM
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddBlazorToolkit(this IServiceCollection services)
    {
#if !BROWSER
        throw new NotSupportedException("The Blazor Toolkit for Server side rendering must use AddBlazorServerToolkit");
#endif

        services.TryAddSingleton<IPrintService, PrintService>();
        services.TryAddSingleton<IDownloadService, DownloadService>();
        services.TryAddSingleton<IClipboardService, ClipboardService>();

        services.AddScoped<IComponentBus, ComponentBus>();
        services.AddScoped(sp => sp.GetRequiredService<IComponentBus>() as ComponentBus ?? new ComponentBus());

        services.AddHttpClient();
        services.AddMudServices();
        return services;
    }

    public static IServiceCollection AddBlazorServerToolkit(this IServiceCollection services)
    {
#if BROWSER
        throw new NotSupportedException("The Blazor Toolkit for WASM rendering must use AddBlazorToolkit");
#endif

        services.TryAddScoped<IPrintService, PrintService>();
        services.TryAddScoped<IDownloadService, DownloadService>();
        services.TryAddScoped<IClipboardService, ClipboardService>();

        services.AddScoped<IComponentBus, ComponentBus>();
        services.AddScoped(sp => sp.GetRequiredService<IComponentBus>() as ComponentBus ?? new ComponentBus());

        services.AddHttpClient();
        services.AddMudServices();
        return services;
    }

}
