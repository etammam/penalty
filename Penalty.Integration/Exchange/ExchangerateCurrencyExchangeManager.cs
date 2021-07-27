using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Penalty.Integration.Exchange.Models;

namespace Penalty.Integration.Exchange
{
    public class ExchangerateCurrencyExchangeManager : ICurrencyExchange
    {
        private readonly HttpClient _httpClient;

        public ExchangerateCurrencyExchangeManager()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://v6.exchangerate-api.com")
            };
        }

        public async Task<double> ExchangeAsync(double amount, string from, string to)
        {
            var response = await _httpClient.GetAsync($"/v6/86cc5bd795899ce31cf39b02/latest/{from}");
            var content =
                JsonConvert.DeserializeObject<ExchangerateExchangeModel>(await response.Content.ReadAsStringAsync());
            if (content != null)
            {
                var exchangeValue = content.ConversionRate.SingleOrDefault(d => d.Key == to);
                return exchangeValue.Value * amount;
            }

            return amount;
        }

        public async Task<Dictionary<string, string>> GetSupportedCurrenciesAsync()
        {
            var response = await _httpClient.GetAsync("/v6/86cc5bd795899ce31cf39b02/latest/USD");
            var content =
                JsonConvert.DeserializeObject<ExchangerateExchangeModel>(await response.Content.ReadAsStringAsync());
            var result = new Dictionary<string, string>();
            if (content == null) return result;
            foreach (var (key, value) in content.ConversionRate)
            {
                result.Add(key, value.ToString(CultureInfo.InvariantCulture));
            }
            return result;
        }
    }
}