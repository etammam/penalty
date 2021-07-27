using System.Collections.Generic;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Currencies.GetListOfSupportedCurrencies
{
    public class ListOfSupportedCurrenciesQuery : IRequest<OutputResponse<Dictionary<string,string>>>
    {
        
    }
}