using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Employers
    {
        /// <summary>
        /// שאילתה שמחזירה רשומת מעסיק
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static DataTable GetEmployer(string Email, string Password)
        {
            string sql = $@"
                            SELECT Employers.EmployerID, 
                                   Employers.EmployerName, 
                                   Employers.NumOfEmployees, 
                                   CompanyTypes.CompanyTypeName, 
                                   Employers.CompanyName, 
                                   Employers.EmployerPassword, 
                                   Employers.CompanyEmail
                            FROM   CompanyTypes INNER JOIN Employers 
                                   ON CompanyTypes.CompanyTypeID = Employers.CompanyTypeID
                            WHERE  Employers.CompanyEmail='{Email}'
                                   AND 
                                   Employers.EmployerPassword='{Password}';
                           ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה שמחזירה מעסיק לפי התז שלו
        /// </summary>
        /// <param name="EmployerID"></param>
        /// <returns></returns>
        public static DataTable GetEmployerByID(int EmployerID)
        {
            string sql = $@"
                            SELECT Employers.EmployerName, 
                                   Employers.NumOfEmployees, 
                                   CompanyTypes.CompanyTypeName, 
                                   Employers.CompanyName, 
                                   Employers.EmployerPassword, 
                                   Employers.CompanyEmail
                            FROM   CompanyTypes 
                                   INNER JOIN Employers 
                                   ON CompanyTypes.CompanyTypeID = Employers.CompanyTypeID
                            WHERE  Employers.EmployerID={EmployerID};
                           ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה שבודקת האם מעסיק קיים במערכת
        /// </summary>
        /// <param name="Email">האמייל של המעסיק</param>
        /// <param name="EmployerPassword">הסיסמא של המעסיק</param>
        /// <param name="CompanyName">שם החברה</param>
        /// <returns></returns>
        public static int IsEmployerExist(string Email)
        {
            string sql = $@"
                            SELECT COUNT(1)
                            FROM   Employers
                            WHERE  Employers.CompanyEmail='{Email}';
                           ";

            int isExists = DAL.DBHelper.GetScalar(sql);
            return isExists;
        }

        /// <summary>
        /// שאילתה לעדכון פרטי רשומת מעסיק
        /// </summary>
        /// <param name="employerID">של המעסיק ID</param>
        /// <param name="employerName">שם המעסיק</param>
        /// <param name="numOfEmployees">מספר העובדים בחברה של המעסיק</param>
        /// <param name="companyTypeID">של קטגוריית החברה ID</param>
        /// <param name="companyName">שם החברה</param>
        /// <returns></returns>
        public static int UpdateEmployerByID(int employerID, string employerName, int numOfEmployees,
            int companyTypeID, string companyName)
        {
            string sql = $@"UPDATE Employers SET Employers.EmployerName = '{employerName}', 
                                                 Employers.NumOfEmployees = {numOfEmployees}, 
                                                 Employers.CompanyTypeID = {companyTypeID},
                                                 Employers.CompanyName = '{companyName}'
                            WHERE                Employers.EmployerID={employerID};";

            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }

        /// <summary>
        /// שאילתה ליצירת רשומת מעסיק חדש לאחר הרשמה
        /// </summary>
        /// <param name="employerName">שם המעסיק</param>
        /// <param name="numOfEmployees">מספר העובדים בחברה של המעסיק</param>
        /// <param name="companyTypeID">של קטגוריית החברה ID</param>
        /// <param name="companyName">שם החברה</param>
        /// <param name="employerPassword">סיסמא</param>
        /// <param name="companyEmail">האמייל של החברה</param>
        /// <returns></returns>
        public static int InsertEmployer(string employerName, int numOfEmployees,
            int companyTypeID, string companyName, string employerPassword, string companyEmail)
        {
            string sql = $@"INSERT INTO Employers (EmployerName, NumOfEmployees, CompanyTypeID, CompanyName, EmployerPassword, CompanyEmail)
                            VALUES ('{employerName}', {numOfEmployees}, {companyTypeID}, '{companyName}', '{employerPassword}', '{companyEmail}');";

            int EmployerID = DAL.DBHelper.ExecuteInsertGetIdentity(sql);
            return EmployerID;
        }
    }
}
