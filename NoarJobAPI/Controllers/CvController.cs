using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvController : ControllerBase
    {
        [HttpPost("InsertCv")]
        public JsonResult InsertCv(string cvFilePath, int userID)
        {
            Cv cv = new Cv();
            cv.InsertCv(cvFilePath, userID);
            return new JsonResult(cv);
        }

        [HttpGet("UpdateCvActivity")]
        public JsonResult UpdateCvActivity(int cvID)
        {
            Cv cv = new Cv();
            cv.CvID = cvID;
            cv.UpdateCvActivity();
            return new JsonResult(cv);
        }
    }
}
