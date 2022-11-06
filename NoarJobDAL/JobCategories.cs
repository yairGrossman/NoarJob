using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class JobCategories
    {
        /// <summary>
        /// (שאילתה להחזרת כל תחומי התפקיד (קטגוריות ברמת אב
        /// </summary>
        /// <returns></returns>
        public static DataTable GetParentJobCategories()
        {
            string sql = @"
                            SELECT  JobCategoryID,
                                    JobCategoryName
                            FROM    JobCategories
                            WHERE   JobCategoryID = JobCategoryParentID;
                            ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// (שאילתה להחזרת כל התפקידים לפי תחום התפקיד (קטגוריות בן של אב נבחר
        /// </summary>
        /// <param name="JobCategoryParentID">של מספר רשומת האב ID</param>
        /// <returns></returns>
        public static DataTable GetJobCategoriesByParentID(int JobCategoryParentID)
        {
            string sql = $@"
                            SELECT  JobCategoryID,
                                    JobCategoryName
                            FROM    JobCategories
                            WHERE   JobCategoryParentID = {JobCategoryParentID}
                                    AND
                                    JobCategoryID <> {JobCategoryParentID};
                            ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה לחיפוש תחום תפקיד לפי טקסט
        /// </summary>
        /// <param name="text">טקסט</param>
        /// <returns></returns>
        public static DataTable GetParentJobCategoriesByText(string text)
        {
            string sql = $@"
                            SELECT  JobCategoryID,
                                    JobCategoryName
                            FROM    JobCategories
                            WHERE   JobCategoryID = JobCategoryParentID
                                    AND
                                    JobCategoryName LIKE '%{text}%';
                            ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה לחיפוש תפקיד לפי טקסט
        /// </summary>
        /// <param name="JobCategoryParentID">של מספר רשומת האב ID</param>
        /// <param name="text">טקסט</param>
        /// <returns></returns>
        public static DataTable GetJobCategoriesByParentIDByText(int JobCategoryParentID, string text)
        {
            string sql = $@"
                            SELECT  JobCategoryID,
                                    JobCategoryName
                            FROM    JobCategories
                            WHERE   JobCategoryParentID = {JobCategoryParentID}
                                    AND
                                    JobCategoryID <> {JobCategoryParentID}
                                    AND
                                    JobCategoryName LIKE '%{text}%';
                            ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }
    }
}
