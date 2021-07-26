using Microsoft.AspNetCore.Builder;

namespace Penalty.APIs.Setups.Factory
{
    public interface IApplicationSetup
    {
        void SetupApplication(IApplicationBuilder app);
    }
}
