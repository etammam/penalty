using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Penalty.Application.Common.Interfaces;
using Serilog;

namespace Penalty.Application.Common.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger _logger;
        private readonly ICurrentUser _currentUser;
        public PerformanceBehavior(
            Stopwatch timer,
            ILogger logger,
            ICurrentUser currentUser)
        {
            _timer = timer;
            _logger = logger;
            _currentUser = currentUser;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();
            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUser.UserId() ?? string.Empty;
                var userName = string.Empty;

                if (!string.IsNullOrEmpty(userId))
                {
                    userName = await _currentUser.GetUserNameAsync(userId);
                }

                _logger.Warning(
                    "Ifrag Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                    requestName, elapsedMilliseconds, userId, userName, request);
            }

            return response;
        }
    }
}
