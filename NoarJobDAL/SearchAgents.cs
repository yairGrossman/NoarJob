using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class SearchAgents
    {
        /// <summary>
        /// שאילתה לחיפוש משרות לפי סוכן
        /// </summary>
        /// <param name="SearchAgentID">של סוכן חכם ID</param>
        /// <param name="UserID">של המשתמש ID</param>
        /// <returns></returns>
        public static DataTable[] GetJobsBySearchAgent(int SearchAgentID, int UserID)
        {
            string ParentCategorySql = $@"SELECT  SearchAgentsValues.ValueID
                                         FROM    SearchAgents 
                                                 INNER JOIN SearchAgentsValues 
                                                 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                         WHERE   SearchAgents.SearchAgentID={SearchAgentID} 
                                                 AND 
                                                 SearchAgents.UserID={UserID} 
                                                 AND 
                                                 SearchAgentsValues.ValueType = 1;";

            string JobCategoriesSql = $@"SELECT  SearchAgentsValues.ValueID
                                         FROM    SearchAgents 
                                                 INNER JOIN SearchAgentsValues 
                                                 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                         WHERE   SearchAgents.SearchAgentID={SearchAgentID} 
                                                 AND 
                                                 SearchAgents.UserID={UserID} 
                                                 AND 
                                                 SearchAgentsValues.ValueType = 2;
                           ";

            string CitiesSql = $@"SELECT  SearchAgentsValues.ValueID
                                  FROM    SearchAgents 
                                          INNER JOIN SearchAgentsValues 
                                          ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                  WHERE   SearchAgents.SearchAgentID={SearchAgentID} 
                                          AND 
                                          SearchAgents.UserID={UserID} 
                                          AND 
                                          SearchAgentsValues.ValueType=3;
                           ";

            string JobTypesSql = $@"SELECT  SearchAgentsValues.ValueID
                                    FROM    SearchAgents 
                                            INNER JOIN SearchAgentsValues 
                                            ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                    WHERE   SearchAgents.SearchAgentID={SearchAgentID} 
                                            AND 
                                            SearchAgents.UserID={UserID} 
                                            AND 
                                            SearchAgentsValues.ValueType=4;
                           ";

            string TextSql = $@"SELECT  SearchAgentsValues.ValueTxt
                                    FROM    SearchAgents 
                                            INNER JOIN SearchAgentsValues 
                                            ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                    WHERE   SearchAgents.SearchAgentID={SearchAgentID} 
                                            AND 
                                            SearchAgents.UserID={UserID} 
                                            AND 
                                            SearchAgentsValues.ValueType=5;
                           ";

            int ParentCategory = DAL.DBHelper.GetScalar(ParentCategorySql);
            List<int> JobCategoriesLst = ConvertDtToList(DAL.DBHelper.GetDataTable(JobCategoriesSql));
            List<int> JobTypesLst = ConvertDtToList(DAL.DBHelper.GetDataTable(JobTypesSql));
            int CityId = DAL.DBHelper.GetScalar(CitiesSql);
            string Text = DAL.DBHelper.GetDataTable(TextSql).Rows[0][0].ToString();

            return Jobs.JobsSearch(ParentCategory, JobCategoriesLst, JobTypesLst, CityId, Text, UserID);
        }

        /// <summary>
        /// פונקציה שהופכת טבלת נתונים למערך חד מימדי
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<int> ConvertDtToList(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                List<int> lst = new List<int>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add((int)dt.Rows[i][0]);
                }
                return lst;
            }
            return null;
        }

        /// <summary>
        /// שאילתה המחזירה את כל הסוכנים החכמים לפי משתמש
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static DataTable GetSearchAgentsByUser(int UserID)
        {
            string sql = $@"
                           SELECT 
                                  SearchAgents.SearchAgentID,
                                  SearchAgents.UserID,
                                  SearchAgentsValues.ValueType,
                                  SearchAgents.IsActive,
                                  JobCategories.JobCategoryName  as ValueName,
                                  SearchAgentsValues.ValueID
                           FROM   (SearchAgents
                                  INNER JOIN SearchAgentsValues
                                  ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID)
                                  INNER JOIN JobCategories
                                  ON SearchAgentsValues.ValueID = JobCategories.JobCategoryID
                           WHERE  (((SearchAgents.UserID) = {UserID})
                                  AND
                                  ((SearchAgentsValues.ValueType) = 1))

                           union all

                           SELECT 
                                  SearchAgents.SearchAgentID,
                                  SearchAgents.UserID,
                                  SearchAgentsValues.ValueType,
                                  SearchAgents.IsActive,
                                  JobCategories.JobCategoryName,
                                  SearchAgentsValues.ValueID
                          FROM    (SearchAgents
                                  INNER JOIN SearchAgentsValues
                                  ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID)
                                  INNER JOIN JobCategories
                                  ON SearchAgentsValues.ValueID = JobCategories.JobCategoryID
                          WHERE   (((SearchAgents.UserID) = {UserID})
                                  AND
                                  ((SearchAgentsValues.ValueType) = 2))

                          union all

                          SELECT SearchAgents.SearchAgentID,
                                 SearchAgents.UserID,
                                 SearchAgentsValues.ValueType,
                                 SearchAgents.IsActive, 
                                 Cities.CityName,
                                 SearchAgentsValues.ValueID
                          FROM   (SearchAgents 
                                 INNER JOIN SearchAgentsValues 
                                 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID) 
                                 INNER JOIN Cities 
                                 ON SearchAgentsValues.ValueID = Cities.CityID
                          WHERE  (((SearchAgents.UserID)={UserID}) 
                                 AND 
                          ((SearchAgentsValues.ValueType)=3))

                          union all
                    
                          SELECT 
                                 SearchAgents.SearchAgentID,
                                 SearchAgents.UserID,
                                 SearchAgentsValues.ValueType,
                                 SearchAgents.IsActive, 
                                 JobTypes.JobTypeName,
                                 SearchAgentsValues.ValueID
                          FROM   (SearchAgents 
                                 INNER JOIN SearchAgentsValues 
                                 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID) 
                                 INNER JOIN JobTypes 
                                 ON SearchAgentsValues.ValueID = JobTypes.JobTypeID
                          WHERE  (((SearchAgents.UserID)={UserID}) 
                                 AND 
                                 ((SearchAgentsValues.ValueType)=4))

                          union all
                    
                          SELECT 
                                 SearchAgents.SearchAgentID,
                                 SearchAgents.UserID,
                                 SearchAgentsValues.ValueType,
                                 SearchAgents.IsActive,
                                 SearchAgentsValues.ValueTxt,
                                 SearchAgentsValues.ValueID
                          FROM   (SearchAgents 
                                 INNER JOIN SearchAgentsValues 
                                 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID)
                          WHERE  (((SearchAgents.UserID)={UserID}) 
                                 AND 
                                 ((SearchAgentsValues.ValueType)=5))
                    
                          order by SearchAgents.SearchAgentID, SearchAgentsValues.ValueType
                          ";
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה ליצירת רשומה חדשה כחלק מתהליך יצירת סוכן חכם חדש
        /// </summary>
        /// <param name="UserID">של המשתמש ID</param>
        /// <returns></returns>
        public static int InsertSearchAgent(int UserID)
        {
            string sql = $@"
                             INSERT INTO SearchAgents (UserID, IsActive) 
                             VALUES({UserID}, true);
                           ";

            int searchAgentID = DAL.DBHelper.ExecuteInsertGetIdentity(sql);
            return searchAgentID;
        }

        /// <summary>
        /// שאילתה לעדכון הסוכן החכם כלא פעיל
        /// </summary>
        /// <param name="SearchAgentID">של סוכן חכם ID</param>
        /// <returns></returns>
        public static int UpdateSearchAgentActivity(int SearchAgentID)
        {
            string sql = $@"UPDATE SearchAgents SET SearchAgents.IsActive = False
                            WHERE  SearchAgents.SearchAgentID={SearchAgentID};";
            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }
    }
}
