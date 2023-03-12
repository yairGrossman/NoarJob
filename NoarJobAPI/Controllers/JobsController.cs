using Microsoft.AspNetCore.Mvc;
using NoarJobBL;
using NoarJobAPI.Models;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        [HttpPost("GetJobsSearch")]
        public JsonResult GetJobsSearch([FromBody] JobSearchRequest searchRequest)
        {
            JobsBL jobs = new JobsBL();
            Job[] arrJobs = jobs.GetJobsSearch(searchRequest.ParentCategory, searchRequest.JobCategories, searchRequest.JobTypes, searchRequest.City, searchRequest.Text, searchRequest.UserID);
            return new JsonResult(arrJobs);
        }

        [HttpGet("GetEmployerJobsByJobActivity")]
        public JsonResult GetEmployerJobsByJobActivity(int employerID, bool isActive)
        {
            JobsBL jobs = new JobsBL();
            Job[] arrJobs = jobs.GetEmployerJobsByJobActivity(employerID, isActive);
            return new JsonResult(arrJobs);
        }

        [HttpPost("GetTheMostSoughtJobBL")]
        public JsonResult GetTheMostSoughtJobBL(int userID, [FromQuery] List<int> childCategoriesLst, [FromQuery] List<int> citiesLst, [FromQuery] List<int> typesLst)
        {
            JobsBL jobsBL = new JobsBL();
            Job[] arrJobs = jobsBL.GetTheMostSoughtJobBL(userID, childCategoriesLst, citiesLst, typesLst);
            return new JsonResult(arrJobs);
        }
    }
}
