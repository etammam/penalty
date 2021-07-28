using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Penalty.APIs;

namespace Penalty.UnitTest.Integrations.Base
{
    public class IntegrationTestBase
    {
        protected readonly HttpClient TestClient;

        public IntegrationTestBase()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    
                });
            TestClient = appFactory.CreateClient();
        }
    }
}