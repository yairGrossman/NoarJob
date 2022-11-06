using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Jobs_JobTypes
    {
        /// <summary>
        /// שאילתה המחזירה את רשימת סוגי המשרות לפי משרה 
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <returns></returns>
        public static DataTable GetAllJobTypesByJobID(int JobID)
        {
            string sql = $@"
                            SELECT Jobs_JobTypes.JobID, 
                                   JobTypes.JobTypeName
                            FROM   JobTypes 
                                   INNER JOIN Jobs_JobTypes ON JobTypes.JobTypeID = Jobs_JobTypes.JobTypeID
                            WHERE  Jobs_JobTypes.JobID={JobID};
                          ";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה ליצירת רשומה בטבלה זו
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="JobTypeID">של סוג המשרה ID</param>
        private static void InsertJob_JobType(int JobID, int JobTypeID)
        {
            string sql = $@"INSERT INTO Jobs_JobTypes (JobID, JobTypeID)
                            VALUES ({JobID}, {JobTypeID});";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה ליצירת רשומות של טבלה זו כחלק מתהליך יצירת רשומת משרה חדשה 
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="JobTypesID">של סוגי המשרה ID</param>
        private static void InsertJob_JobTypes(int JobID, List<int> JobTypesID)
        {
            for (int i = 0; i < JobTypesID.Count; i++)
            {
                InsertJob_JobType(JobID, JobTypesID[i]);
            }
        }

        /// <summary>
        /// שאילתה למחיקת כל סוגי המשרות של משרה ספציפית
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        private static void DeleteAllJob_JobTypes(int JobID)
        {
            string sql = $@"DELETE FROM Jobs_JobTypes 
                            WHERE JobID={JobID};";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון משרה/יצירת משרה
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="JobTypesID"></param>
        public static void SetJob_JobTypes(int JobID, List<int> JobTypesID)
        {
            DeleteAllJob_JobTypes(JobID);
            InsertJob_JobTypes(JobID, JobTypesID);
        }
    }
}
