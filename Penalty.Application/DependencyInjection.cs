using System.Diagnostics;
using System.Reflection;
using AspNetCore.ServiceRegistration.Dynamic;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Penalty.Application.Common.Behaviors;

namespace Penalty.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddHttpContextAccessor();
            services.AddServicesOfType<IScopedService>();
            services.AddServicesOfType<ISingletonService>();
            services.AddServicesOfType<ITransientService>();
            services.AddTransient<Stopwatch>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
            return services;
        }
    }
}
