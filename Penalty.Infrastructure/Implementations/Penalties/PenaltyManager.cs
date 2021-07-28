using System;
using System.Net;
using System.Threading.Tasks;
using Penalty.Application.Common.Responses;
using Penalty.Application.Services.Countries;
using Penalty.Application.Services.Penalties;
using Penalty.Crosscut.Constants;

namespace Penalty.Infrastructure.Implementations.Penalties
{
    public class PenaltyManager : IPenalty
    {
        private readonly ICountry _countryManager;

        public PenaltyManager(ICountry countryManager)
        {
            _countryManager = countryManager;
        }

        public async Task<OutputResponse<int>> OffsetDays(DateTime start, DateTime end, string country)
        {
            var countryHolidays = await _countryManager.GetCountryHolidaysAsync(country);
            var businessDays = start.GetBusinessDays(end, countryHolidays);
            return await Task.FromResult(new OutputResponse<int>()
            {
                Message = ResponseMessages.Success,
                StatusCode = HttpStatusCode.OK,
                Model = businessDays,
                Success = true
            });
        }
    }
}
