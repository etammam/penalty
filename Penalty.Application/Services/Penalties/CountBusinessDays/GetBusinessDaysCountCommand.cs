using System;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Penalties.CountBusinessDays
{
    public class GetBusinessDaysCountCommand : IRequest<OutputResponse<int>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; }
    }
}