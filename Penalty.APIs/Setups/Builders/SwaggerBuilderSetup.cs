using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public class SwaggerBuilderSetup : IApplicationSetup
    {
        public void SetupApplication(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ifrag Application"));
        }
    }
}
