using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Penalty.APIs.Setups.Bases;
using Penalty.Application.Services.Currencies.ExchangeCurrency;
using Penalty.Application.Services.Currencies.GetListOfSupportedCurrencies;
using Penalty.Application.Services.Currencies.IsCurrencySupported;

namespace Penalty.APIs.Controllers
{
    public class CurrenciesController : CoreController
    {
        [HttpGet(Router.Currencies.GetSupportedCurrencies)]
        public async Task<IActionResult> GetSupportedCurrencies()
        {
            var result = await Mediator.Send(new ListOfSupportedCurrenciesQuery());
            return NewResult(result);
        }

        [HttpGet(Router.Currencies.IsCurrencySupported)]
        public async Task<IActionResult> IsCurrencyCodeSupport([FromRoute] string currencyCode)
        {
            var result = await Mediator.Send(new IsCurrencySupportedQuery()
            {
                CurrencyCode = currencyCode
            });
            return NewResult(result);
        }

        [HttpPost(Router.Currencies.Exchange)]
        public async Task<IActionResult> Exchange([FromBody] ExchangeCurrencyCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}