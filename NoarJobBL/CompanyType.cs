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
        private int companyTypeID;//מספר קטגוריית החברה
        private string companyTypeName;//שם הקטגורייה של החברה

        #region תכונות
        public int CompanyTypeID 
        { 
            get { return this.companyTypeID; } 
        }
        public string CompanyTypeName 
        {
            get { return this.companyTypeName; }
        }
        #endregion

        /// <summary>
        /// פונקציה שמחזירה את כל קטגוריות החברות
        /// </summary>
        /// <returns></returns>
        public CompanyType[] GetAllCompanyTypes()
        {
            DataTable dt = NoarJobDAL.CompanyTypes.GetAllCompanyTypes();
            CompanyType[] arrCompanyTypes = new CompanyType[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arrCompanyTypes[i] = new CompanyType();
                arrCompanyTypes[i].companyTypeID = (int)dt.Rows[i][0];
                arrCompanyTypes[i].companyTypeName = dt.Rows[i][1].ToString();
            }
            return arrCompanyTypes;
        }
    }
}
