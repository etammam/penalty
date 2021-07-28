using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Penalty.APIs.Setups.Bases;
using Penalty.Application.Services.Penalties;
using Penalty.Application.Services.Penalties.CountBusinessDays;

namespace Penalty.APIs.Controllers
{
    public class PenaltyController : CoreController
    {
        [HttpPost(Router.PenaltyCalculator.CountBusinessDays)]
        public async Task<IActionResult> GetOffsetDays([FromForm] GetBusinessDaysCountCommand command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }
    }
}