using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public static class SwaggerBuilderSetup
    {
        public static void SetupSwagger(this IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Penalty Application"));
        }
    }
}
