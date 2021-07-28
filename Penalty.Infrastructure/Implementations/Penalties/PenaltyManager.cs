using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Penalty.Application.Common.Responses;
using Penalty.Application.Common.Responses.Models;
using Penalty.Application.Services.Countries;
using Penalty.Application.Services.Penalties;
using Penalty.Application.Services.Penalties.ApplyingBusinessPenalty;
using Penalty.Crosscut.Constants;
using Penalty.Integration.Exchange;
using Serilog;

namespace Penalty.Infrastructure.Implementations.Penalties
{
    public class PenaltyManager : IPenalty
    {
        private readonly ICountry _countryManager;
        private readonly ICurrencyExchange _currencyExchange;
        private readonly ILogger _logger;
        public PenaltyManager(ICountry countryManager, ICurrencyExchange currencyExchange, ILogger logger)
        {
            _countryManager = countryManager;
            _currencyExchange = currencyExchange;
            _logger = logger;
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

        public async Task<OutputResponse<ApplyingBusinessPenaltyResult>> ApplyingPenaltyAsync(ApplyingBusinessPenaltyCommand command)
        {
            try
            {
                var countryHolidays = await _countryManager.GetCountryHolidaysAsync(command.Country);
                var countryInformation = (await _countryManager.GetSingleCountryByNameAsync(command.Country)).Model;
                var businessDays = command.StartDate.GetBusinessDays(command.EndDate, countryHolidays);
                var exchangedValue =
                    await _currencyExchange.ExchangeAsync(countryInformation.Fine, "USD", countryInformation.Currency);
                return await Task.FromResult(new OutputResponse<ApplyingBusinessPenaltyResult>()
                {
                    Message = ResponseMessages.Success,
                    StatusCode = HttpStatusCode.OK,
                    Success = true,
                    Model = new ApplyingBusinessPenaltyResult()
                    {
                        Country = command.Country,
                        Currency = countryInformation.Currency,
                        StartDate = command.StartDate,
                        EndDate = command.EndDate,
                        ExchangedValue = exchangedValue,
                        FineInUsd = countryInformation.Fine,
                        Holidays = countryHolidays,
                        CountedBusinessDays = businessDays,
                        PenaltyValue = businessDays * exchangedValue
                    }
                });
            }
            catch (Exception exception)
            {
                _logger.Error(exception,"Penalty Management");
                return new OutputResponse<ApplyingBusinessPenaltyResult>()
                {
                    Errors = new List<ErrorModel>()
                    {
                        new ErrorModel()
                        {
                            Property = "Overall",
                            ErrorCode = "3001",
                            Message = exception.Message
                        }
                    },
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ResponseMessages.Failure,
                    Model = null,
                    Success = false
                };
            }
        }
    }
}
