using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoriesController : ControllerBase
    {
        [HttpGet("GetParentJobCategories")]
        public JsonResult GetParentJobCategories()
        {
            JobCategoriesBL jobCategoriesBL = new JobCategoriesBL();
            Dictionary<int, string> dic = jobCategoriesBL.GetParentJobCategories();
            return new JsonResult(dic);
        }

        [HttpGet("GetJobCategoriesByParentID")]
        public JsonResult GetJobCategoriesByParentID(int chosenJobCategory)
        {
            JobCategoriesBL jobCategoriesBL = new JobCategoriesBL();
            jobCategoriesBL.ChosenJobCategory = chosenJobCategory;
            Dictionary<int, string> dic = jobCategoriesBL.GetJobCategoriesByParentID();
            return new JsonResult(dic);
        }

        [HttpGet("GetParentJobCategoriesByText")]
        public JsonResult GetParentJobCategoriesByText(string text)
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            Dictionary<int, string> dic = jobCategories.GetParentJobCategoriesByText(text);
            return new JsonResult(dic);
        }

        [HttpGet("GetJobCategoriesByParentIDAndByText")]
        public JsonResult GetJobCategoriesByParentIDAndByText(int chosenJobCategory, string text)
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            jobCategories.ChosenJobCategory = chosenJobCategory;
            Dictionary<int, string> dic = jobCategories.GetParentJobCategoriesByText(text);
            return new JsonResult(dic);
        }
    }
}
