using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WEmployer
    {
        private int employerID;
        private string employerName;//שם המעסיק
        private int numOfEmployees;//מספר העובדים בחברה
        private string companyTypeName;//קטגוריית החברה
        private string companyName;//שם החברה
        private string employerPassword;//הסיסמא של המעסיק
        private string companyEmail;//האימייל של החברה

        public WEmployer(Employer employer)
        {
            this.employerID = employer.EmployerID;
            this.employerName = employer.EmployerName;
            this.numOfEmployees = employer.NumOfEmployees;
            this.companyTypeName = employer.CompanyTypeName;
            this.companyName = employer.CompanyName;
            this.employerPassword = employer.EmployerPassword;
            this.companyEmail = employer.CompanyEmail;
        }

        [DataMember]
        public int EmployerID { get => employerID; set => employerID = value; }
        [DataMember]
        public string EmployerName { get => employerName; set => employerName = value; }
        [DataMember]
        public int NumOfEmployees { get => numOfEmployees; set => numOfEmployees = value; }
        [DataMember]
        public string CompanyTypeName { get => companyTypeName; set => companyTypeName = value; }
        [DataMember]
        public string CompanyName { get => companyName; set => companyName = value; }
        [DataMember]
        public string EmployerPassword { get => employerPassword; set => employerPassword = value; }
        [DataMember]
        public string CompanyEmail { get => companyEmail; set => companyEmail = value; }
    }
}