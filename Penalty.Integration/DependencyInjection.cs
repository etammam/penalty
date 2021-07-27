using Microsoft.Extensions.DependencyInjection;
using Penalty.Integration.Exchange;

namespace Penalty.Integration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIntegrationLayer(this IServiceCollection services)
        {
            //Setup Services
            services.AddSingleton<ICurrencyExchange, ExchangerateCurrencyExchangeManager>();
            return services;
        }
    }
}
