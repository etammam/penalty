using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Services
{
    public class JsonNamingServiceSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddJsonOptions(options =>
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);
        }
    }
}
