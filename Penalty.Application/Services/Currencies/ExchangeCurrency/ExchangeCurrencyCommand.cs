using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.ExchangeCurrency
{
    public class ExchangeCurrencyCommand : IRequest<OutputResponse<double>>
    {
        public double Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}