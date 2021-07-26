using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Penalty.APIs.Setups.Factory
{
    public interface IServiceSetup
    {
        void InstallService(IServiceCollection services, IConfiguration configuration);
    }
}
