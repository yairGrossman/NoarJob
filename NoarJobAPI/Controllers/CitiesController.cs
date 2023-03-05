using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetCities(string text)
        {
            CitiesBL cities = new CitiesBL();
            Dictionary<int, string> cidCities = cities.GetCities(text);
            return new JsonResult(cidCities);
        }
    }
}
