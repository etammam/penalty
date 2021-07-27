using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Countries.ListOfCountries
{
    public class ListOfCountriesQueryHandler : IRequestHandler<ListOfCountriesQuery, OutputResponse<List<SingleCountryResult>>>
    {
        private readonly ICountry _countryManager;

        public ListOfCountriesQueryHandler(ICountry countryManager)
        {
            _countryManager = countryManager;
        }

        public async Task<OutputResponse<List<SingleCountryResult>>> Handle(ListOfCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _countryManager.GetCountriesAsync();
        }
    }
}
