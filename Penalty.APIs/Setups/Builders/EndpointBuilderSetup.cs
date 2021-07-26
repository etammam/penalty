using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public class EndpointBuilderSetup : IApplicationSetup
    {
        public void SetupApplication(IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
