using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using Penalty.Application.Common.Responses;
using Penalty.Application.Services.Countries.ListOfCountries;

namespace Penalty.Application.Services.Countries
{
    public interface ICountry : ISingletonService
    {
        Task<OutputResponse<List<SingleCountryResult>>> GetCountriesAsync();
        Task<OutputResponse<SingleCountryResult>> GetSingleCountryByNameAsync(string countryName);
        Task<string[]> GetCountryHolidaysAsync(string country);
    }
}
