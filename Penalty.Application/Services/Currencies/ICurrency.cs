using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using Penalty.Application.Common.Responses;
using Penalty.Application.Services.Currencies.ExchangeCurrency;

namespace Penalty.Application.Services.Currencies
{
    public interface ICurrency : ISingletonService
    {
        Task<OutputResponse<double>> ExchangeAsync(ExchangeCurrencyCommand command);
        Task<OutputResponse<Dictionary<string, string>>> GetSupportedCurrenciesAsync();
        Task<OutputResponse<bool>> IsCurrencySupport(string currencyCode);
    }
}