using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Penalty.Integration.Exchange.Models;

namespace Penalty.Integration.Exchange
{
    public class CurrencyExchangeManager : ICurrencyExchange
    {
        private readonly HttpClient _httpClient;

        public CurrencyExchangeManager()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.frankfurter.app")
            };
        }

        public async Task<double> ExchangeAsync(double amount, string from, string to)
        {
            var response = await _httpClient.GetAsync($"/latest?amount={amount}&from={from}");
            var content = JsonConvert.DeserializeObject<ExchangeModel>(await response.Content.ReadAsStringAsync());
            if (content != null) 
                return content.Rates.SingleOrDefault(d => d.Key == to).Value;
            //from the limitation of using a free service some of currency not support
            return amount;
        }

        public async Task<Dictionary<string, string>> GetSupportedCurrenciesAsync()
        {
            var response = await _httpClient.GetAsync("/currencies");
            var content =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());
            return content;
        }
    }
}
