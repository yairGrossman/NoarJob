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
        public async Task<IActionResult> InsertCv([FromForm] int userID, [FromForm] string cvFileName, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file was uploaded");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("Cvs", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Cv cv = new Cv();
            cv.InsertCv(filePath, userID, cvFileName);
            return Ok(cv);
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
