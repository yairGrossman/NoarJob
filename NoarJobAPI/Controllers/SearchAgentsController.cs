using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAgentsController : ControllerBase
    {
        [HttpGet("GetJobsBySearchAgent")]
        public JsonResult GetJobsBySearchAgent(int searchAgentID, int userID)
        {
            SearchAgentsBL searchAgentsBL = new SearchAgentsBL();
            Job[] arrJobs = searchAgentsBL.GetJobsBySearchAgent(searchAgentID, userID);
            return new JsonResult(arrJobs);
        }

        [HttpGet("GetSearchAgentsByUser")]
        public JsonResult GetSearchAgentsByUser(int userID)
        {
            SearchAgentsBL searchAgentsBL = new SearchAgentsBL();
            List<SearchAgent> searchAgentsLst = searchAgentsBL.GetSearchAgentsByUser(userID);
            return new JsonResult(searchAgentsLst);
        }
    }
}
