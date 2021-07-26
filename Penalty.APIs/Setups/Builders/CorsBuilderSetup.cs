﻿using Microsoft.AspNetCore.Builder;
using Penalty.APIs.Setups.Factory;

namespace Penalty.APIs.Setups.Builders
{
    public class CorsBuilderSetup : IApplicationSetup
    {
        public void SetupApplication(IApplicationBuilder app)
        {
            app.UseCors("platform");
        }
    }
}