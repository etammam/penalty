using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Penalties.ApplyingBusinessPenalty
{
    public class ApplyingBusinessPenaltyCommandHandler : IRequestHandler<ApplyingBusinessPenaltyCommand,OutputResponse<ApplyingBusinessPenaltyResult>>
    {
        private readonly IPenalty _penaltyManager;

        public ApplyingBusinessPenaltyCommandHandler(IPenalty penaltyManager)
        {
            _penaltyManager = penaltyManager;
        }

        public async Task<OutputResponse<ApplyingBusinessPenaltyResult>> Handle(ApplyingBusinessPenaltyCommand request, CancellationToken cancellationToken)
        {
            return await _penaltyManager.ApplyingPenaltyAsync(request);
        }
    }
}
