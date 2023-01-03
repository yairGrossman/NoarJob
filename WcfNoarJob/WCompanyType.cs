using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    public class WCompanyType
    {
        private int companyTypeID;//מספר קטגוריית החברה
        private string companyTypeName;//שם הקטגורייה של החברה

        public int CompanyTypeID { get => companyTypeID; set => companyTypeID = value; }
        public string CompanyTypeName { get => companyTypeName; set => companyTypeName = value; }

        public WCompanyType(CompanyType companyType)
        {
            this.companyTypeID = companyType.CompanyTypeID;
            this.companyTypeName = companyType.CompanyTypeName;
        }

    }
}