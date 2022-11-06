

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Blazor.PrintableArea.Services;

namespace Blazor.PrintableArea
{
    public static class ServiceCollectionExtensions 
    {

        /// <summary>
        /// Registers the print service required for Printable Area to interact with the 
        /// DOM
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPrintableAreaServices(this IServiceCollection services)
        {
            services.TryAddSingleton<IPrintService, PrintService>();            
            return services;
        }

    }
}