using Microsoft.AspNetCore.Mvc;
using NoarJobBL;
using NoarJobAPI.Models;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SameSearchesOfUsersController : ControllerBase
    {
        [HttpGet("GetSameParentCategory")]
        public JsonResult GetSameParentCategory(int parentCategory)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.GetSameParentCategory(parentCategory);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategory);
        }

        [HttpPost("GetSameChildCategories")]
        public JsonResult GetSameChildCategories([FromBody] SameSearchesOfUsersReq sameSearchesOfUsersReq)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.GetSameChildCategories(sameSearchesOfUsersReq.ChildCategoriesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategories);
        }

        [HttpPost("SameChildCategoriesAndCities")]
        public JsonResult SameChildCategoriesAndCities([FromBody]SameSearchesOfUsersReq sameSearchesOfUsersReq)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCities(sameSearchesOfUsersReq.ChildCategoriesLst, sameSearchesOfUsersReq.CitiesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCities);
        }

        [HttpPost("SameChildCategoriesAndCitiesAndTypes")]
        public JsonResult SameChildCategoriesAndCitiesAndTypes([FromBody] SameSearchesOfUsersReq sameSearchesOfUsersReq)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCitiesAndTypes(sameSearchesOfUsersReq.ChildCategoriesLst, sameSearchesOfUsersReq.CitiesLst, sameSearchesOfUsersReq.TypesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes);
        }
    }
}
