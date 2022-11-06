using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Jobs
    {
        /// <summary>
        /// שאילתה להחזרת רשומות משרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <returns></returns>
        public static DataTable[] GetJobs(int[] arrJobsID, int UserID)
        {
            string sql = $@"
                             SELECT Jobs.JobID, 
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
                             FROM   CompanyTypes 
                                    INNER JOIN (Employers 
                                    INNER JOIN (Jobs 
                                    LEFT JOIN Users_Jobs 
                                    ON (Jobs.JobID = Users_Jobs.JobID 
                                        AND 
                                        Users_Jobs.UserJobType = 1 
                                        AND 
                                        Users_Jobs.UserID = {UserID})) 
                                    ON Employers.EmployerID = Jobs.EmployerID) 
                                    ON CompanyTypes.CompanyTypeID = Employers.CompanyTypeID
                             WHERE  Jobs.JobID IN ({String.Join(",", arrJobsID)});
                           ";

            DataTable dtJobs = DAL.DBHelper.GetDataTable(sql);
            int[] jobsIDArr = new int[dtJobs.Rows.Count];

            for (int i = 0; i < jobsIDArr.Length; i++)
                jobsIDArr[i] = (int)dtJobs.Rows[i][0];

            DataTable dtJobsCities = GetJobsCities(jobsIDArr);
            DataTable dtJobsTypes = GetJobsTypes(jobsIDArr);
            DataTable dtJobsCategories = GetJobsCategories(jobsIDArr);
            return new DataTable[] { dtJobs, dtJobsCities, dtJobsTypes, dtJobsCategories };
        }

        /// <summary>
        /// שאילתה להחזרת רשומות של משרות לפי מעסיק וגם לפי אם המשרות פעילות או לא
        /// </summary>
        /// <param name="EmployerID">של המעסיק ID</param>
        /// <param name="IsActive">האם משרה פעילה</param>
        /// <returns></returns>
        public static DataTable[] GetJobsByEmployerAndJobActivity(int EmployerID, bool IsActive)
        {
            string sql = $@"
                            SELECT Jobs.JobID, 
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
                             FROM   CompanyTypes 
                                    INNER JOIN (Employers INNER JOIN Jobs ON Employers.EmployerID = Jobs.EmployerID) 
                                    ON CompanyTypes.CompanyTypeID = Employers.CompanyTypeID
                            WHERE   Employers.EmployerID={EmployerID} AND Jobs.IsActive={IsActive};";

            
            DataTable dtJobs = DAL.DBHelper.GetDataTable(sql);
            int[] jobsIDArr = new int[dtJobs.Rows.Count];

            for (int i = 0; i < jobsIDArr.Length; i++)
                jobsIDArr[i] = (int)dtJobs.Rows[i][0];

            DataTable dtJobsCities = GetJobsCities(jobsIDArr);
            DataTable dtJobsTypes = GetJobsTypes(jobsIDArr);
            DataTable dtJobsCategories = GetJobsCategories(jobsIDArr);
            return new DataTable[] { dtJobs, dtJobsCities, dtJobsTypes, dtJobsCategories };
        }

        /// <summary>
        /// שאילתה ליצירת רשומת משרה חדשה
        /// </summary>
        /// <param name="Title">כותרת המשרה</param>
        /// <param name="Description">תיאור המשרה</param>
        /// <param name="Requirements">דרישות המשרה</param>
        /// <param name="EmployerID">של המעסיק ID</param>
        /// <param name="Phone">טלפון המעסיק</param>
        /// <param name="Email">אימייל המעסיק</param>
        /// <returns></returns>
        public static int InsertJob(string Title, string Description, string Requirements, int EmployerID, string Phone, string Email, List<int> JobCategories, List<int> Cities, List<int> JobTypes)
        {
            string sql = $@"
                             INSERT INTO Jobs (Title, Description, Requirements, EmployerID, Phone, Email, IsActive)
                             VALUES ('{Title}', '{Description}', '{Requirements}', {EmployerID}, '{Phone}', '{Email}', true);
                           ";

            int JobID = DAL.DBHelper.ExecuteInsertGetIdentity(sql);
            Jobs_JobCategories.SetJob_JobCategories(JobID, JobCategories);
            Jobs_Cities.SetJob_Cities(JobID, Cities);
            Jobs_JobTypes.SetJob_JobTypes(JobID, JobTypes);
            return JobID;
        }

        /// <summary>
        /// שאילתה לעדכון פרטי רשומת משרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="Title">כותרת המשרה</param>
        /// <param name="Description">תיאור המשרה</param>
        /// <param name="Requirements">דרישות המשרה</param>
        /// <param name="EmployerID">של המעסיק ID</param>
        /// <param name="Phone">טלפון המעסיק</param>
        /// <param name="IsActive">האם משרה פעילה</param>
        /// <returns></returns>
        public static int UpdateJob(int JobID, string Title, string Description, string Requirements, int EmployerID, string Phone, string Email, bool IsActive,
            List<int> JobCategories, List<int> Cities, List<int> JobTypes)
        {
            string sql = $@"
                             UPDATE Jobs SET Jobs.Title = '{Title}', 
                                             Jobs.Description = '{Description}', 
                                             Jobs.Requirements = '{Requirements}', 
                                             Jobs.EmployerID = {EmployerID}, 
                                             Jobs.Phone = '{Phone}', 
                                             Jobs.Email = '{Email}', 
                                             Jobs.IsActive = {IsActive}
                             WHERE           Jobs.JobID={JobID};
                           ";

            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            Jobs_JobCategories.SetJob_JobCategories(JobID, JobCategories);
            Jobs_Cities.SetJob_Cities(JobID, Cities);
            Jobs_JobTypes.SetJob_JobTypes(JobID, JobTypes);
            return rows;
        }

        /// <summary>
        /// שאילתה לעדכון רשומת משרה כלא פעילה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <returns></returns>
        public static int UpdateJobActivity(int JobID, bool IsActive)
        {
            string sql = $@"UPDATE Jobs SET Jobs.IsActive = {!IsActive}
                            WHERE  Jobs.JobID={JobID};";
            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }


        /// <summary>
        /// שאילתה להחזרת רשומות של משרות לפי הגדרות החיפוש של המשתמש
        /// </summary>
        /// <param name="JobCategories">של קטגוריות משרה ID</param>
        /// <param name="JobTypes">של סוגי משרה ID</param>
        /// <param name="Cities">של ערים ID</param>
        /// <param name="Text">טקסט</param>
        /// <returns></returns>
        public static DataTable[] JobsSearch(int ParentCategory, List<int> JobCategories, List<int> JobTypes, int City, string Text, int UserID)
        {
            string sql = $@"
                             SELECT Jobs.JobID, 
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
                             FROM   CompanyTypes 
                                    INNER JOIN (Employers 
                                    INNER JOIN (Jobs 
                                    LEFT JOIN Users_Jobs 
                                    ON (Jobs.JobID = Users_Jobs.JobID 
                                        AND 
                                        Users_Jobs.UserJobType = 1 
                                        AND 
                                        Users_Jobs.UserID = {UserID})) 
                                    ON Employers.EmployerID = Jobs.EmployerID) 
                                    ON CompanyTypes.CompanyTypeID = Employers.CompanyTypeID
                           ";

            string JobCategoriesQuery = "";
            if(JobCategories != null && JobCategories.Count != 0)
            {
                JobCategoriesQuery = $@"
                    Jobs.JobID IN (
					        select jc.JobID from Jobs_JobCategories jc WHERE jc.JobCategoryID IN ({String.Join(",", JobCategories)})
			        )
                ";
            }
            else if (ParentCategory != 0)
            {
                JobCategoriesQuery = $@"
                    Jobs.JobID IN (
					        select jc.JobID from Jobs_JobCategories jc WHERE jc.JobCategoryID = {ParentCategory}
			        )
                ";
            }

            string JobTypesQuery = "";
            if (JobTypes != null && JobTypes.Count != 0)
            {
                JobTypesQuery = $@"
                    Jobs.JobID IN (
					        select jt.JobID from Jobs_JobTypes jt WHERE jt.JobTypeID IN ({String.Join(",", JobTypes)})
			        )
                ";
            }

            string CitiesQuery = "";
            if (City != 0)
            {
                CitiesQuery = $@"
                    Jobs.JobID IN (
					        select jc.JobID from Jobs_Cities jc WHERE jc.CityID = {City}
			        )
                ";
            }

            string TextQuery = "";
            if(Text != null)
            {
                TextQuery = $@"
                    (
                       Jobs.Title Like '%{Text}%'
                       OR
                       Jobs.Description Like '%{Text}%'
                    )
                ";
            }

            string UserQuery = "";
            if(UserID != -1)
            {
                UserQuery = $@"
                    Jobs.JobID NOT IN (
                            SELECT  uj.JobID
                            FROM    Users_Jobs uj
                            WHERE   uj.UserID = {UserID}
                                    AND
                                    uj.UserJobType = 3
                    )
                ";
            }

            if (JobCategoriesQuery != "" || JobTypesQuery != "" || CitiesQuery != "" || TextQuery != "" || UserQuery != "")
            {
                sql += "WHERE Jobs.IsActive=True AND " +
                        ((JobCategoriesQuery != "") ? JobCategoriesQuery + " AND " : "") +
                        ((JobTypesQuery != "") ? JobTypesQuery + " AND " : "") +
                        ((CitiesQuery != "") ? CitiesQuery + " AND " : "") +
                        ((TextQuery != "") ? TextQuery + " AND " : "") +
                        ((UserQuery != "") ? UserQuery + " AND " : "");
                        
                sql = sql.Substring(0, sql.Length - 5);
            }

            DataTable dtJobs = DAL.DBHelper.GetDataTable(sql);
            int[] jobsIDArr = new int[dtJobs.Rows.Count];

            for (int i = 0; i < jobsIDArr.Length; i++)
                jobsIDArr[i] = (int)dtJobs.Rows[i][0];

            DataTable dtJobsCities = GetJobsCities(jobsIDArr);
            DataTable dtJobsTypes = GetJobsTypes(jobsIDArr);
            DataTable dtJobsCategories = GetJobsCategories(jobsIDArr);
            return new DataTable[] { dtJobs, dtJobsCities, dtJobsTypes, dtJobsCategories };
        }

        /// <summary>
        /// שאילתה שמחזירה את כל הערים של כל המשרות לפי הגדרות החיפוש של המשתמש
        /// </summary>
        /// <param name="jobsIDs"></param>
        /// <returns></returns>
        public static DataTable GetJobsCities(int[] jobsIDs)
        {
            string sql = $@"SELECT Jobs_Cities.JobID, 
                                   Cities.CityName,
                                   Jobs_Cities.CityID  
                           FROM    Cities 
                                   INNER JOIN Jobs_Cities 
                                   ON Cities.CityID = Jobs_Cities.CityID
                           WHERE   Jobs_Cities.JobID IN ({String.Join(",", jobsIDs)})";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה שמחזירה את כל סוגי המשרות של כל המשרות לפי הגדרות החיפוש של המשתמש
        /// </summary>
        /// <param name="jobsIDs"></param>
        /// <returns></returns>
        public static DataTable GetJobsTypes(int[] jobsIDs)
        {
            string sql = $@"SELECT Jobs_JobTypes.JobID, 
                                   JobTypes.JobTypeName,
                                   Jobs_JobTypes.JobTypeID
                            FROM   JobTypes 
                                   INNER JOIN Jobs_JobTypes 
                                   ON JobTypes.JobTypeID = Jobs_JobTypes.JobTypeID
                            WHERE  Jobs_JobTypes.JobID IN ({String.Join(",", jobsIDs)})";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה שמחזירה את כל הקטגוריות של כל המשרות לפי הגדרות החיפוש של המשתמש
        /// </summary>
        /// <param name="jobsIDs"></param>
        /// <returns></returns>
        public static DataTable GetJobsCategories(int[] jobsIDs)
        {
            string sql = $@"SELECT Jobs_JobCategories.JobID, 
                                   JobCategories.JobCategoryName,
                                   Jobs_JobCategories.JobCategoryID
                            FROM   JobCategories 
                                   INNER JOIN Jobs_JobCategories 
                                   ON JobCategories.JobCategoryID = Jobs_JobCategories.JobCategoryID
                            WHERE  Jobs_JobCategories.JobID IN ({String.Join(",", jobsIDs)});";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }
    }
}
