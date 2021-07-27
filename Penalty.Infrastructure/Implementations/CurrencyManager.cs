using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Penalty.Application.Common.Responses;
using Penalty.Application.Services.Currencies;
using Penalty.Application.Services.Currencies.ExchangeCurrency;
using Penalty.Crosscut.Constants;
using Penalty.Integration.Exchange;

namespace Penalty.Infrastructure.Implementations
{
    public class CurrencyManager : ICurrency
    {
        private readonly ICurrencyExchange _currencyExchangeManager;

        public CurrencyManager(ICurrencyExchange currencyExchangeManager)
        {
            _currencyExchangeManager = currencyExchangeManager;
        }


        public async Task<OutputResponse<double>> ExchangeAsync(ExchangeCurrencyCommand command)
        {
            var supportedCurrencies = await _currencyExchangeManager.GetSupportedCurrenciesAsync();
            if (supportedCurrencies.ContainsKey(command.From) && supportedCurrencies.ContainsKey(command.To))
            {
                var exchangeValue = await _currencyExchangeManager.ExchangeAsync(command.Amount, command.From, command.To);
                return new OutputResponse<double>()
                {
                    Success = true,
                    Message = ResponseMessages.Success,
                    Model = exchangeValue,
                    StatusCode = HttpStatusCode.OK
                };
            }

            return new OutputResponse<double>
            {
                Success = false,
                Message = "sorry, the exchange service not support this currency codes",
                Model = 0,
                StatusCode = HttpStatusCode.BadRequest,
            };
        }

        public async Task<OutputResponse<Dictionary<string, string>>> GetSupportedCurrenciesAsync()
        {
            return await Task.FromResult(new OutputResponse<Dictionary<string, string>>()
            {
                Message = ResponseMessages.Success,
                StatusCode = HttpStatusCode.OK,
                Success = true,
                Model = await _currencyExchangeManager.GetSupportedCurrenciesAsync()
            });
        }

        public async Task<OutputResponse<bool>> IsCurrencySupport(string currencyCode)
        {
            var supportedCurrencies = await _currencyExchangeManager.GetSupportedCurrenciesAsync();
            return new OutputResponse<bool>()
            {
                Model = supportedCurrencies.ContainsKey(currencyCode),
                Message = ResponseMessages.Success,
                StatusCode = HttpStatusCode.OK,
                Success = true,
            };
        }
    }
}