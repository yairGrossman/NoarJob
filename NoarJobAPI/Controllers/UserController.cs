using Microsoft.AspNetCore.Mvc;
using NoarJobBL;
using NoarJobDAL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("UserLogin")]
        public JsonResult UserLogin(string email, string password)
        {
            User user = new User();
            bool succeed = user.SetUser(email, password);
            if (succeed)
            {
                return new JsonResult(user);
            }
            return new JsonResult("error");
        }

        [HttpPost("UpdateUser")]
        public void UpdateUser(User userReq)
        {
            User user = new User();
            user.UpdateUser(userReq.UserID, userReq.Email, userReq.FirstName, userReq.LastName, userReq.Phone, userReq.City.Key);
        }

        [HttpGet("CreateUser")]
        public JsonResult CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName)
        {
            User user = new User();
            bool succeed = user.CreateUser(email, userPassword, firstName, lastName, phone, cityID, cityName);
            if (succeed)
            {
                return new JsonResult(user);
            }
            return new JsonResult("error");
        }

        [HttpGet("SetUserCvs")]
        public JsonResult SetUserCvs(int userID)
        {
            User user = new User();
            user.UserID = userID;
            user.SetUserCvs();
            return new JsonResult(user);
        }

        [HttpGet("GetApplyForJobs")]
        public JsonResult GetApplyForJobs(int userID)
        {
            User user = new User();
            user.UserID = userID;
            Job[] arrJobs = user.GetApplyForJobs();
            return new JsonResult(arrJobs);
        }

        [HttpGet("GetLovedJobs")]
        public JsonResult GetLovedJobs(int userID)
        {
            User user = new User();
            user.UserID = userID;
            Job[] arrJobs = user.GetLovedJobs();
            return new JsonResult(arrJobs);
        }

        [HttpGet("UpdateUserJobType")]
        public void UpdateUserJobType(int jobID, int userID, int userJobType)
        {
            User user = new User();
            user.UserID = userID;
            user.UpdateUserJobType(jobID, userJobType);
        }

        [HttpGet("UpdateJobApplication")]
        public void UpdateJobApplication(int jobID, int userID, int userJobType, string dateApplicated, int cvID)
        {
            User user = new User();
            user.UserID = userID;
            user.UpdateUserJobType(jobID, userJobType, dateApplicated, cvID);
        }

        [HttpPost("CreateUser_Job")]
        public void CreateUser_Job([FromForm]int jobID, [FromForm] int userID, [FromForm] int cvID, [FromForm] string dateApplicated)
        {
            User user = new User();
            user.UserID = userID;
            user.CreateUser_Job(jobID, cvID, dateApplicated);
        }

        [HttpGet("CreateUser_JobAtDeleteOrLove")]
        public void CreateUser_JobAtDeleteOrLove(int jobID, int userID, int userJobType)
        {
            User user = new User();
            user.UserID = userID;
            user.CreateUser_Job(jobID, userJobType);
        }

        [HttpPost("Savefile")]
        public async Task<IActionResult> SaveFile([FromForm] IFormFile file, [FromForm] string cvFileName)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file was uploaded");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("Cvs", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var response = new { FilePath = filePath };
            return Ok(response);
        }
    }
}
