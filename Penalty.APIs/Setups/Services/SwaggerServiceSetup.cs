using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Penalty.APIs.Setups.Factory;
using Penalty.APIs.Setups.Models;

namespace Penalty.APIs.Setups.Services
{
    public class SwaggerServiceSetup : IServiceSetup
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();
            configuration.Bind(nameof(swaggerOptions),swaggerOptions);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(swaggerOptions.Version,new OpenApiInfo()
                {
                    Title = swaggerOptions.Title,
                    Version = swaggerOptions.Version,
                    Description = swaggerOptions.Description,
                    Contact = new OpenApiContact()
                    {
                        Email = swaggerOptions.Contact.Email,
                        Name = swaggerOptions.Contact.Name
                    }
                });
            });
        }
    }
}
