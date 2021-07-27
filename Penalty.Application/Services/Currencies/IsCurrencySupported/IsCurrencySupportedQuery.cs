using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.IsCurrencySupported
{
    public class IsCurrencySupportedQuery : IRequest<OutputResponse<bool>>
    {
        public string CurrencyCode { get; set; }
    }
}