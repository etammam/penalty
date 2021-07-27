using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;

namespace Penalty.Integration.Exchange
{
    public interface ICurrencyExchange
    {
        Task<double> ExchangeAsync(double amount, string from, string to);
        Task<Dictionary<string, string>> GetSupportedCurrenciesAsync();
    }
}
