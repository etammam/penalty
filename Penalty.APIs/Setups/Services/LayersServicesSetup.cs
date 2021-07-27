using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Penalty.APIs.Setups.Factory;
using Penalty.Application;
using Penalty.Infrastructure;
using Penalty.Integration;

namespace Penalty.APIs.Setups.Services
{
    public class LayersServicesSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationLayer();
            services.AddInfrastructureLayer(configuration);
            services.AddIntegrationLayer();
        }
    }
}
