using Microsoft.AspNetCore.Mvc;
using NoarJobBL;
using NoarJobAPI.Models;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        [HttpPost("CreateJob")]
        public void CreateJob([FromBody] JobRequest jobRequest)
        {
            Job job = new Job();
            job.CreateJob(jobRequest.Title, jobRequest.Description, jobRequest.Requirements, jobRequest.EmployerID,
             jobRequest.Phone, jobRequest.Email, jobRequest.JobCategories, jobRequest.Cities, jobRequest.JobTypes);
        }

        [HttpPost("UpdateJob")]
        public void UpdateJob([FromBody] JobRequest jobRequest)
        {
            Job job = new Job();
            job.JobID = jobRequest.JobID;
            job.IsActive = jobRequest.IsActive;
            job.UpdateJob(jobRequest.Title, jobRequest.Description, jobRequest.Requirements, 
                jobRequest.EmployerID, jobRequest.Phone, jobRequest.Email,
                jobRequest.JobCategories, jobRequest.Cities, jobRequest.JobTypes);
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

        [HttpGet("UpdateEmployerNotes")]
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

        [HttpGet("DeleteOldUsersApplyForJob")]
        public void DeleteOldUsersApplyForJob(int jobID)
        {
            Job job = new Job();
            job.JobID = jobID;
            job.DeleteOldUsersApplyForJob();
        }
    }
}
