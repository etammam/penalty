using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Responses;

namespace Penalty.Application.Services.Penalties.CountBusinessDays
{
    public class GetBusinessDaysCountCommandHandler : IRequestHandler<GetBusinessDaysCountCommand,OutputResponse<int>>
    {
        private readonly IPenalty _penaltyManager;

        public GetBusinessDaysCountCommandHandler(IPenalty penaltyManager)
        {
            _penaltyManager = penaltyManager;
        }

        public async Task<OutputResponse<int>> Handle(GetBusinessDaysCountCommand request, CancellationToken cancellationToken)
        {
            return await _penaltyManager.OffsetDays(request.StartDate, request.EndDate, request.Country);
        }
    }
}