using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.GetListOfSupportedCurrencies
{
    public class ListOfSupportedCurrenciesQueryHandler : IRequestHandler<ListOfSupportedCurrenciesQuery,OutputResponse<Dictionary<string,string>>>
    {
        private readonly ICurrency _currencyManager;

        public ListOfSupportedCurrenciesQueryHandler(ICurrency currencyManager)
        {
            _currencyManager = currencyManager;
        }

        public async Task<OutputResponse<Dictionary<string, string>>> Handle(ListOfSupportedCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return await _currencyManager.GetSupportedCurrenciesAsync();
        }
    }
}