using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using AstroPanda.Blazor.Toolkit;

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
        return services;
    }

}
