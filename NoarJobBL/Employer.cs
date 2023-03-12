using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoarJobDAL;

namespace NoarJobBL
{
    public class Employer
    {
        private int employerID;
        private string employerName;//שם המעסיק
        private int numOfEmployees;//מספר העובדים בחברה
        private string companyTypeName;//קטגוריית החברה
        private string companyName;//שם החברה
        private string employerPassword;//הסיסמא של המעסיק
        private string companyEmail;//האימייל של החברה

        public int EmployerID{get { return this.employerID; } set { this.employerID = value; } }

        public string EmployerName{get { return this.employerName; }set { this.employerName = value; }}

        public int NumOfEmployees{get { return this.numOfEmployees; }set { this.numOfEmployees = value; }}

        public string CompanyTypeName{get { return this.companyTypeName; }set { this.companyTypeName = value; }}

        public string CompanyName{get { return this.companyName; }set { this.companyName = value; }}

        public string EmployerPassword{get { return this.employerPassword; }set { this.employerPassword = value; }}

        public string CompanyEmail{get { return this.companyEmail; }set { this.companyEmail = value; }}


        /// <summary>
        /// פונקציה שמכניסה את נתוני המעסיק לשדות המחלקה
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private void SetData(int employerID, string employerName, int numOfEmployees, string companyTypeName, 
            string companyName, string employerPassword, string companyEmail)
        {
            this.employerID = employerID;
            this.employerName = employerName;
            this.numOfEmployees = numOfEmployees;
            this.companyTypeName = companyTypeName;
            this.companyName = companyName;
            this.employerPassword = employerPassword;
            this.companyEmail = companyEmail;
        }


        /// <summary>
        /// למעסיק Login פונקצית 
        /// </summary>
        /// <param name="companyEmail"></param>
        /// <param name="employerPassword"></param>
        /// <returns></returns>
        public bool GetEmployer(string companyEmail, string employerPassword)
        {
            DataTable dt = Employers.GetEmployer(companyEmail, employerPassword);
            if (dt != null && dt.Rows.Count > 0)
            {
                SetData(
                    (int)dt.Rows[0]["EmployerID"], 
                    dt.Rows[0]["EmployerName"].ToString(), 
                    (int)dt.Rows[0]["NumOfEmployees"], 
                    dt.Rows[0]["CompanyTypeName"].ToString(), 
                    dt.Rows[0]["CompanyName"].ToString(), 
                    dt.Rows[0]["EmployerPassword"].ToString(),
                    dt.Rows[0]["CompanyEmail"].ToString()
                    );

                return true;
            }
            return false;
        }

        /// <summary>
        /// פונקציה שיוצרת מעסיק חדש
        /// </summary>
        /// <param name="employerName"></param>
        /// <param name="numOfEmployees"></param>
        /// <param name="companyTypeID"></param>
        /// <param name="companyTypeName"></param>
        /// <param name="companyName"></param>
        /// <param name="employerPassword"></param>
        /// <param name="companyEmail"></param>
        /// <returns></returns>
        public bool CreateEmployer(string employerName, int numOfEmployees, int companyTypeID, string companyTypeName, 
            string companyName, string employerPassword, string companyEmail)
        {
            int isExists = Employers.IsEmployerExist(companyEmail, employerPassword, companyName);
            if (isExists == 0)
            {
                int employerID = Employers.InsertEmployer(employerName, numOfEmployees, companyTypeID, companyName, employerPassword, companyEmail);

                SetData(employerID, employerName, numOfEmployees, companyTypeName, companyName, employerPassword, companyEmail);

                return true;
            }
            return false;
        }
    }
}
