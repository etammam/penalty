using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Penalty.APIs.Setups.Builders;
using Penalty.APIs.Setups.Factory;
using Penalty.Application.Common.Responses;

namespace Penalty.APIs
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.SetupSwagger();
            app.ContextServingSetup();
            app.SetupCors();
            app.UseFluentValidationExceptionHandler();
            app.SetupEndpointConfiguration();
        }
    }
}
