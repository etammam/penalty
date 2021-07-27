using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.ExchangeCurrency
{
    public class ExchangeCurrencyCommandHandler : IRequestHandler<ExchangeCurrencyCommand,OutputResponse<double>>
    {
        private readonly ICurrency _currencyManager;

        public ExchangeCurrencyCommandHandler(ICurrency currencyManager)
        {
            _currencyManager = currencyManager;
        }

        public async Task<OutputResponse<double>> Handle(ExchangeCurrencyCommand request, CancellationToken cancellationToken)
        {
            return await _currencyManager.ExchangeAsync(request);
        }
    }
}