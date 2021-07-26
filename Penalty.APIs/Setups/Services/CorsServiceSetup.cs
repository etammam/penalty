using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Penalty.APIs.Setups.Factory;
using Penalty.APIs.Setups.Models;

namespace Penalty.APIs.Setups.Services
{
    public class CorsServiceSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var accessSettings = new AccessSettings();
            configuration.Bind(nameof(accessSettings),accessSettings);

            services.AddCors(options =>
            {
                options.AddPolicy("platform", builder =>
                {
                    builder.WithOrigins(accessSettings.Origins)
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }
    }
}
