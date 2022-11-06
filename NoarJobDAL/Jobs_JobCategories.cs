using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Jobs_JobCategories
    {
        /// <summary>
        /// שאילתה המחזירה את רשימת קטגוריות המשרה לפי משרה 
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <returns></returns>
        public static DataTable GetAllJobCategoriesByJob(int JobID)
        {
            string sql = $@"
                             SELECT Jobs_JobCategories.JobID, 
                                    JobCategories.JobCategoryName
                             FROM   JobCategories 
                                    INNER JOIN Jobs_JobCategories 
                                    ON JobCategories.JobCategoryID = Jobs_JobCategories.JobCategoryID
                             WHERE  Jobs_JobCategories.JobID = {JobID};
                            ";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה ליצירת רשומה בטבלה זו
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="JobCategoryID">של קטגוריית המשרה ID</param>
        private static void InsertJob_Category(int JobID, int JobCategoryID)
        {
            string sql = $@"INSERT INTO Jobs_JobCategories (JobID, JobCategoryID)
                            VALUES({JobID}, {JobCategoryID});";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה ליצירת רשומות של טבלה זו כחלק מתהליך יצירת רשומת משרה חדשה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="JobCategoriesID">של קטגוריות המשרה ID</param>
        private static void InsertJob_JobCategories(int JobID, List<int> JobCategoriesID)
        {
            for (int i = 0; i < JobCategoriesID.Count; i++)
            {
                InsertJob_Category(JobID, JobCategoriesID[i]);
            }
        }

        /// <summary>
        /// שאילתה למחיקת כל הקטגוריות של משרה ספציפית
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        private static void DeleteAllJob_JobCategories(int JobID)
        {
            string sql = $@"DELETE FROM Jobs_JobCategories
                            WHERE JobID={JobID};";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון משרה/יצירת משרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="JobCategoriesID">של קטגוריות המשרה ID</param>
        public static void SetJob_JobCategories(int JobID, List<int> JobCategoriesID)
        {
            DeleteAllJob_JobCategories(JobID);
            InsertJob_JobCategories(JobID, JobCategoriesID);
        }
    }
}
