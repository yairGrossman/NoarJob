using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypesController : ControllerBase
    {
        [HttpGet("GetAllJobTypes")]
        public JsonResult GetAllJobTypes()
        {
            JobTypesBL jobTypes = new JobTypesBL();
            Dictionary<int, string> dic = jobTypes.GetAllJobTypes();
            return new JsonResult(dic);
        }

        [HttpGet("GetAllSubTypes")]
        public JsonResult GetAllSubTypes()
        {
            JobTypesBL jobTypes = new JobTypesBL();
            Dictionary<int, string> dic = jobTypes.GetAllSubTypes();
            return new JsonResult(dic);
        }
    }
}
