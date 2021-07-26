using AspNetCore.ServiceRegistration.Dynamic;
using Microsoft.Extensions.DependencyInjection;

namespace Penalty.Integration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegrationLayer(this IServiceCollection services)
        {
            //Setup Services
            services.AddServicesOfType<IScopedService>();
            services.AddServicesOfType<ISingletonService>();
            services.AddServicesOfType<ITransientService>();
            return services;
        }
    }
}
