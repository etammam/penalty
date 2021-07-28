using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Penalty.APIs.Setups.Bases;
using Penalty.Application.Common.Responses;
using Penalty.UnitTest.Integrations.Base;
using Xunit;

namespace Penalty.UnitTest.Integrations
{
    public class BusinessDaysCalculatorApiTest : IntegrationTestBase
    {
        [Fact]
        public async Task GetBusinessDaysWithinAWeekOnEgypt_ShouldReturn_5()
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string?, string?>("startDate", (new DateTime(2021, 7, 3)).ToString()),
                new KeyValuePair<string?, string?>("endDate", (new DateTime(2021, 7, 10)).ToString()),
                new KeyValuePair<string?, string>("country","Egypt")
            });
            var response = await TestClient.PostAsync(Router.PenaltyCalculator.CountBusinessDays,formContent);
            var callResponse = JsonConvert.DeserializeObject<OutputResponse<int>>(await response.Content.ReadAsStringAsync());
            callResponse?.Model.Should().Be(5);
        }
    }
}