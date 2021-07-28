using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public static class CorsBuilderSetup
    {
        public static void SetupCors(this IApplicationBuilder app)
        {
            app.UseCors("platform");
        }
    }
}
