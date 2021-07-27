using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.IsCurrencySupported
{
    public class IsCurrencySupportedQueryHandler : IRequestHandler<IsCurrencySupportedQuery,OutputResponse<bool>>
    {
        private readonly ICurrency _currencyManager;

        public IsCurrencySupportedQueryHandler(ICurrency currencyManager)
        {
            _currencyManager = currencyManager;
        }

        public async Task<OutputResponse<bool>> Handle(IsCurrencySupportedQuery request, CancellationToken cancellationToken)
        {
            return await _currencyManager.IsCurrencySupport(request.CurrencyCode);
        }
    }
}