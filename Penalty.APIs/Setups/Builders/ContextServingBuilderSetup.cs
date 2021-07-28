using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public static class ContextServingBuilderSetup 
    {
        public static void ContextServingSetup(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
        }
    }
}
