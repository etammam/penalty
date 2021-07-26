using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
using Serilog;

namespace Penalty.Application.Common.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public UnhandledExceptionBehavior(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                Console.ForegroundColor = ConsoleColor.Red;
                _logger.Error(ex, "Ifrag Request: Unhandled Exception for Request {Name} {@Request}", requestName, JsonConvert.SerializeObject(request));
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }
        }
    }
}
