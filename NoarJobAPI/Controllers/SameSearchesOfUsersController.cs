using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

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

        [HttpGet("GetSameChildCategories")]
        public JsonResult GetSameChildCategories([FromQuery] List<int> childCategoriesLst)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.GetSameChildCategories(childCategoriesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategories);
        }

        [HttpGet("SameChildCategoriesAndCities")]
        public JsonResult SameChildCategoriesAndCities([FromQuery] List<int> childCategoriesLst, [FromQuery] List<int> citiesLst)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCities(childCategoriesLst, citiesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCities);
        }

        [HttpGet("SameChildCategoriesAndCitiesAndTypes")]
        public JsonResult SameChildCategoriesAndCitiesAndTypes([FromQuery] List<int> childCategoriesLst, [FromQuery] List<int> citiesLst, [FromQuery] List<int> typesLst)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCitiesAndTypes(childCategoriesLst, citiesLst, typesLst);
            return new JsonResult(sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes);
        }
    }
}
