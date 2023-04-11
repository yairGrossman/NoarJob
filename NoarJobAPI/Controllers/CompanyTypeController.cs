using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        [HttpGet("GetAllCompanyTypes")]
        public JsonResult GetAllCompanyTypes()
        {
            CompanyType companyType = new CompanyType();
            Dictionary<int,string> companyTypesDictionary = companyType.GetAllCompanyTypes();
            return new JsonResult(companyTypesDictionary);
        }
    }
}
