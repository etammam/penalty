using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public static class EndpointBuilderSetup
    {
        public static void SetupEndpointConfiguration(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
