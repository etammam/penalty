using System;
using System.Threading.Tasks;
using AspNetCore.ServiceRegistration.Dynamic;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Penalties
{
    public interface IPenalty : IScopedService
    {
        Task<OutputResponse<int>> OffsetDays(DateTime start, DateTime end, string country);
    }
}
