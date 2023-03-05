using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        [HttpGet("GetEmployer")]
        public JsonResult GetEmployer(string companyEmail, string employerPassword)
        {
            Employer employer = new Employer();
            employer.GetEmployer(companyEmail, employerPassword);
            return new JsonResult(employer);
        }

        [HttpGet("CreateEmployer")]
        public JsonResult CreateEmployer(string employerName, int numOfEmployees, int companyTypeID, string companyTypeName,
            string companyName, string employerPassword, string companyEmail)
        {
            Employer employer = new Employer();
            bool succeed = employer.CreateEmployer(employerName, numOfEmployees, companyTypeID, companyTypeName,
             companyName, employerPassword, companyEmail);
            if (succeed)
            {
                return new JsonResult(employer);
            }
            return new JsonResult("error");
        }
    }
}
