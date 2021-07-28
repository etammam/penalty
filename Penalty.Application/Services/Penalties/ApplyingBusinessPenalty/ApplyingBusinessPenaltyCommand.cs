using System;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Penalties.ApplyingBusinessPenalty
{
    public class ApplyingBusinessPenaltyCommand : IRequest<OutputResponse<ApplyingBusinessPenaltyResult>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Country { get; set; }
    }
}
