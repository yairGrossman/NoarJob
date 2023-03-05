﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoarJobBL;

namespace NoarJobAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAllCompanyTypes()
        {
            CompanyType companyType = new CompanyType();
            CompanyType[] arrCompanyTypes = companyType.GetAllCompanyTypes();
            return new JsonResult(arrCompanyTypes);
        }
    }
}
