using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class CompanyTypes
    {
        /// <summary>
        /// שאילתה המחזירה את כל הרשומות מהטבלה
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllCompanyTypes()
        {
            string sql = @"SELECT CompanyTypes.CompanyTypeID, 
                                  CompanyTypes.CompanyTypeName
                           FROM CompanyTypes;";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }
    }
}
