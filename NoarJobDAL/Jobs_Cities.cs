using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Jobs_Cities
    {
        /// <summary>
        /// שאילתה המחזירה את רשימת היישובים לפי משרה 
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <returns></returns>
        public static DataTable GetAllCitiesByJobID(int JobID)
        {
            string sql = $@"
                              SELECT Jobs_Cities.JobID,
                                     Cities.CityName
                              FROM   Cities INNER JOIN Jobs_Cities ON Cities.CityID = Jobs_Cities.CityID
                              WHERE  Jobs_Cities.JobID={JobID};
                           ";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה ליצירת רשומה בטבלה זו
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="CityID">של עיר ID</param>
        private static void InsertJob_City(int JobID, int CityID)
        {
            string sql = $@"INSERT INTO Jobs_Cities (JobID, CityID)
                            VALUES ({JobID}, {CityID});";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה ליצירת רשומות של טבלה זו כחלק מתהליך יצירת רשומת משרה חדשה 
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="CitiesID">של ערים ID</param>
        private static void InsertJob_Cities(int JobID, List<int> CitiesID)
        {
            for (int i = 0; i < CitiesID.Count; i++)
            {
                InsertJob_City(JobID, CitiesID[i]);
            }
        }

        /// <summary>
        /// שאילתה למחיקת כל הערים של משרה ספציפית
        /// </summary>
        /// <param name="JobID"></param>
        private static void DeleteAllJob_Cities(int JobID)
        {
            string sql = $@"DELETE FROM Jobs_Cities 
                            WHERE JobID={JobID};";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון משרה/יצירת משרה
        /// </summary>
        /// <param name="JobID"></param>
        /// <param name="CitiesID"></param>
        public static void SetJob_Cities(int JobID, List<int> CitiesID)
        {
            DeleteAllJob_Cities(JobID);
            InsertJob_Cities(JobID, CitiesID);
        }
    }
}
