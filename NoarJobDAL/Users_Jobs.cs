using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Users_Jobs
    {
        /// <summary>
        /// שאילתה המחזירה את רשימת המועמדים של משרה לפי משרה וגם לפי סוג הקיטלוג
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="TabType">אחד - מועמד לא קוטלג,
        /// 2 - מועמד נמצא מתאים למשרה,
        /// 3 - מועמד לא נמצא מתאים למשרה,
        /// 4 - מועמד עבר ראיון טלפוני,
        /// 5 - מועמד עבר ראיון מקצועי,
        /// 6 - מועמד עבר חתימה על החוזה</param>
        /// <returns></returns>
        public static DataTable GetUsersByJobAndTabType(int JobID, int TabType)
        {
            string sql = $@"
                            SELECT Users_Jobs.JobID, 
                                   Users_Jobs.UserID,  
                                   Users_Jobs.CvID,
                                   Users_Jobs.Notes,
                                   Cvs.CvFilePath, 
                                   Cvs.IsActive, 
                                   Users.Email, 
                                   Users.FirstName, 
                                   Users.LastName, 
                                   Users.Phone, 
                                   Cities.CityName
                            FROM   Cvs 
                                   INNER JOIN (Cities 
                                   INNER JOIN (Users 
                                   INNER JOIN Users_Jobs 
                                   ON Users.UserID = Users_Jobs.UserID) 
                                   ON Cities.CityID = Users.CityID) 
                                   ON (Users.UserID = Cvs.UserID) AND (Cvs.CvID = Users_Jobs.CvID)
                            WHERE  Users_Jobs.JobID={JobID} 
                                   AND
                                   Users_Jobs.TabType={TabType} 
                                   AND 
                                   Cvs.IsActive=True;
                           ";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה להחזרת המשרות שהמשתמש אהב  או הגיש אלהים מועמדות
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static DataTable[] GetApplyForOrLovedJobs(int UserID, int UserJobType)
        {
            string sql = $@"
                            SELECT Users_Jobs.UserID, 
                                   Jobs.JobID, 
                                   Users_Jobs.UserID, 
                                   Users_Jobs.DateApplicated, 
                                   Jobs.Title, 
                                   Jobs.Description, 
                                   Jobs.Requirements, 
                                   Employers.EmployerName, 
                                   Employers.NumOfEmployees, 
                                   CompanyTypes.CompanyTypeName, 
                                   Jobs.Phone, 
                                   Jobs.Email, 
                                   Jobs.IsActive,
                                   Employers.CompanyName
                            FROM   Employers 
                                   INNER JOIN (Jobs INNER JOIN Users_Jobs 
                                   ON Jobs.JobID = Users_Jobs.JobID) 
                                   ON Employers.EmployerID = Jobs.EmployerID
                            WHERE  Users_Jobs.UserID={UserID}
                                   AND 
                                   Users_Jobs.UserJobType={UserJobType};
                           ";

            DataTable dtJobs = DAL.DBHelper.GetDataTable(sql);
            int[] jobsIDArr = new int[dtJobs.Rows.Count];

            for (int i = 0; i < jobsIDArr.Length; i++)
                jobsIDArr[i] = (int)dtJobs.Rows[i][0];

            DataTable dtJobsCities = Jobs.GetJobsCities(jobsIDArr);
            DataTable dtJobsTypes = Jobs.GetJobsTypes(jobsIDArr);
            DataTable dtJobsCategories = Jobs.GetJobsCategories(jobsIDArr);
            return new DataTable[] { dtJobs, dtJobsCities, dtJobsTypes, dtJobsCategories };
        }

        /// <summary>
        /// שאילתה ליצירת רשומה חדשה בעת הגשת מועמדות של משתמש למשרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="UserID">של משתמש ID</param>
        /// /// <param name="DateApplicated">תאריך הגשת המועמדות של המשתמש למשרה</param>
        /// <param name="CvID">של קורות חיים ID</param>
        public static void InsertUser_Job(int JobID, int UserID, int CvID, DateTime DateApplicated)
        {
            string sql = $@"
                         INSERT INTO Users_Jobs (JobID, UserID, CvID, DateApplicated, UserJobType, TabType)
                         VALUES ({JobID}, {UserID}, {CvID} {DateApplicated}, 1, 1);
                        ";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה ליצירת רשומה חדשה בעת מחיקת משרה/אהבת משרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="UserID">של משתמש ID</param>
        /// /// <param name="UserJobType">אחד - שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה</param>
        public static void InsertUser_Job(int JobID, int UserID, int UserJobType)
        {
            string sql = $@"
                         INSERT INTO Users_Jobs (JobID, UserID, UserJobType)
                         VALUES ({JobID}, {UserID}, {UserJobType});
                        ";

            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה לעדכון הערת המעסיק למועמד
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="UserID">של משתמש ID</param>
        /// <param name="notes">הערות של המעסיק</param>
        public static void UpdateEmployerNotes(int JobID, int UserID, string notes)
        {
            string sql = $@"
                            UPDATE Users_Jobs SET Users_Jobs.Notes = '{notes}'
                            WHERE Users_Jobs.JobID={JobID} AND Users_Jobs.UserID={UserID};
                           ";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// ATSשאילתת עדכון להעברת מועמד בין הקיטלוגים השונים במערכת ה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="UserID">של משתמש ID</param>
        /// <param name="TabType">אחד - מועמד לא קוטלג,
        /// 2 - מועמד נמצא מתאים למשרה,
        /// 3 - מועמד לא נמצא מתאים למשרה,
        /// 4 - מועמד עבר ראיון טלפוני,
        /// 5 - מועמד עבר ראיון מקצועי,
        /// 6 - מועמד עבר חתימה על החוזה</param>
        public static void UpdateTabType(int JobID, int UserID, int TabType)
        {
            string sql = $@"
                            UPDATE Users_Jobs SET Users_Jobs.TabType = {TabType}
                            WHERE  Users_Jobs.JobID={JobID} AND Users_Jobs.UserID={UserID};
                           ";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתת עדכון שמעבירה את הסוג שהמשתמש בחר למשרה
        /// אחד שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="UserID"></param>
        /// <param name="UserJobType"></param>
        public static void UpdateUserJobType(int JobID, int UserID, int UserJobType)
        {
            string sql;
            if (UserJobType == 1)
            {
                sql = $@"
                    UPDATE Users_Jobs SET Users_Jobs.UserJobType = {UserJobType},
                                          Users_Jobs.TabType = 1;
                    WHERE  Users_Jobs.JobID={JobID} AND Users_Jobs.UserID={UserID};
                   ";
            }
            else
            {
                sql = $@"
                    UPDATE Users_Jobs SET Users_Jobs.UserJobType = {UserJobType},
                                          Users_Jobs.TabType = 0;
                    WHERE  Users_Jobs.JobID={JobID} AND Users_Jobs.UserID={UserID};
                   ";
            }
            
            DAL.DBHelper.ExecuteNonQuery(sql);
        }
    }
}
