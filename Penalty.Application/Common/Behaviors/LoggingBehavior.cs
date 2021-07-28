using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Penalty.Application.Common.Interfaces;
using Serilog;

namespace Penalty.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;

        public LoggingBehavior(ILogger logger,
            ICurrentUser currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUser.UserId() ?? string.Empty;
            var userName = string.Empty;
            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _currentUser.GetUserNameAsync(userId);
            }
            _logger.Information("Penalty Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName, userId, userName, request);
        }
    }
}
