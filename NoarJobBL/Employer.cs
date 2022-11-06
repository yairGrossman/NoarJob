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

        public int EmployerID
        {
            get { return this.employerID; }
        }

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

        public bool GetEmployer(string companyEmail, string employerPassword)
        {
            DataTable dt = Employers.GetEmployer(companyEmail, employerPassword);
            if (dt != null && dt.Rows.Count > 0)
            {
                SetData(
                    (int)dt.Rows[0][0], 
                    dt.Rows[0][1].ToString(), 
                    (int)dt.Rows[0][2], 
                    dt.Rows[0][3].ToString(), 
                    dt.Rows[0][4].ToString(), 
                    dt.Rows[0][5].ToString(),
                    dt.Rows[0][6].ToString()
                    );

                return true;
            }
            return false;
        }

        /// <summary>
        /// פונקיה שיוצרת מעסיק חדש
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
