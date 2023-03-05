using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchAgentController : ControllerBase
    {
        [HttpPost("InsertSearchAgentValues")]
        public JsonResult InsertSearchAgentValues(SearchAgent searchAgent)
        {
            searchAgent.InsertSearchAgentValues();
            return new JsonResult(searchAgent);
        }

        [HttpPost("UpdateSearchAgentValues")]
        public void UpdateSearchAgentValues(SearchAgent searchAgent)
        {
            searchAgent.UpdateSearchAgentValues();
        }

        [HttpGet("UpdateSearchAgentActivity")]
        public void UpdateSearchAgentActivity(int searchAgentID)
        {
            SearchAgent searchAgent = new SearchAgent();
            searchAgent.SearchAgentID = searchAgentID;
            searchAgent.UpdateSearchAgentActivity();
        }
    }
}
