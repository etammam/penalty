using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Penalty.Application.Common.Responses;
using Penalty.Application.Services.Countries;
using Penalty.Application.Services.Countries.ListOfCountries;
using Penalty.Crosscut.Constants;
using Penalty.Infrastructure.Persistence;

namespace Penalty.Infrastructure.Implementations
{
    public class CountryManager : ICountry
    {
        private readonly IStore _storeManager;
        private readonly IMapper _mapperManager;
        public CountryManager(IStore storeManager, IMapper mapperManager)
        {
            _storeManager = storeManager;
            _mapperManager = mapperManager;
        }

        public Task<OutputResponse<List<SingleCountryResult>>> GetCountriesAsync()
        {
            var penalties = _storeManager.Read<List<Domain.Entities.Penalty>>("penalties.json");
            return Task.FromResult(new OutputResponse<List<SingleCountryResult>>()
            {
                Message = ResponseMessages.Success,
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Model = _mapperManager.Map<List<SingleCountryResult>>(penalties)
            });
        }
    }
}
