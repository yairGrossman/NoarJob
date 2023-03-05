using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpPost("CreateJob")]
        public void CreateJob(string title, string description, string requirements, int employerID,
            string phone, string email, [FromQuery] List<int> jobCategories, [FromQuery] List<int> cities, [FromQuery] List<int> jobTypes)
        {
            Job job = new Job();
            job.CreateJob(title, description, requirements, employerID,
             phone, email, jobCategories, cities, jobTypes);
        }

        [HttpPost("UpdateJob")]
        public void UpdateJob(int jobID, bool isActive, string title, string description, string requirements, int employerID,
            string phone, string email, [FromQuery] List<int> jobCategories, [FromQuery] List<int> cities, [FromQuery] List<int> jobTypes)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.IsActive = isActive;
            job.UpdateJob(title, description, requirements, employerID, phone, email,
                jobCategories, cities, jobTypes);
        }

        [HttpGet("UpdateJobActivity")]
        public JsonResult UpdateJobActivity(int jobID, bool isActive)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.IsActive = isActive;
            bool succeed = job.UpdateJobActivity();
            return new JsonResult(succeed);
        }

        [HttpGet("GetUsersByJobAndTabType")]
        public JsonResult GetUsersByJobAndTabType(int jobID, int tabType)
        {
            Job job = new Job();
            job.JobID = jobID;
            User[] arrUsers = job.GetUsersByJobAndTabType(tabType);
            return new JsonResult(arrUsers);
        }

        [HttpPost("UpdateEmployerNotes")]
        public void UpdateEmployerNotes(int jobID, int userID, string notes)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.UpdateEmployerNotes(userID, notes);
        }

        [HttpGet("UpdateTabType")]
        public void UpdateTabType(int jobID, int userID, int tabType)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.UpdateTabType(userID, tabType);
        }
    }
}
