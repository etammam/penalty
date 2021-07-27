using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Penalty.APIs.Setups.Bases;
using Penalty.Application.Services.Countries.ListOfCountries;

namespace Penalty.APIs.Controllers
{
    public class PenaltiesController : CoreController
    {
        [HttpGet(Router.Country.GetListOfCountries)]
        public async Task<IActionResult> GetListOfCountries()
        {
            var result = await Mediator.Send(new ListOfCountriesQuery());
            return NewResult(result);
        }
    }
}
