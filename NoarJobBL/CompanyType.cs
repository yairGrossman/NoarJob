using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoarJobDAL;

namespace NoarJobBL
{
    public class CompanyType
    {
        /// <summary>
        /// פונקציה שמחזירה את כל קטגוריות החברות
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllCompanyTypes()
        {
            DataTable dt = NoarJobDAL.CompanyTypes.GetAllCompanyTypes();
            Dictionary<int,string> companyTypesDictionary = new Dictionary<int, string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                companyTypesDictionary.Add((int)dt.Rows[i][0], dt.Rows[i][1].ToString());
            }
            return companyTypesDictionary;
        }
    }
}
