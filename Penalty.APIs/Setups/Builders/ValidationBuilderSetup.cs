using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;
using Penalty.Application.Common.Responses;

namespace Penalty.APIs.Setups.Builders
{
    public class ValidationBuilderSetup : IApplicationSetup
    {
        public void SetupApplication(IApplicationBuilder app)
        {
            app.UseFluentValidationExceptionHandler();
        }
    }
}
