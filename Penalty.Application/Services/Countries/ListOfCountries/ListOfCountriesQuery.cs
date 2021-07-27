using System.Collections.Generic;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Countries.ListOfCountries
{
    public class ListOfCountriesQuery : IRequest<OutputResponse<List<SingleCountryResult>>>
    {
        
    }
}
