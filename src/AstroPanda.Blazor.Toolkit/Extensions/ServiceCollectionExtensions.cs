using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AstroPanda.Blazor.Toolkit;
using BlazorComponentBus;
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
        services.TryAddSingleton<IPrintService, PrintService>();
        services.TryAddSingleton<IDownloadService, DownloadService>();

        services.AddScoped<IComponentBus, ComponentBus>();
        services.AddScoped<ComponentBus>(sp => sp.GetRequiredService<IComponentBus>() as ComponentBus);

        services.AddMudServices();
        return services;
    }

}
