using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Cvs
    {
        /// <summary>
        /// שאילתה המחזירה את רשומות קורות החיים של משתמש ספציפי
        /// </summary>
        /// <param name="UserID">של המשתמש ID</param>
        /// <returns></returns>
        public static DataTable GetUserCvs(int UserID)
        {
            string sql = $@"SELECT Cvs.CvID, 
                                   Cvs.UserID, 
                                   Cvs.CvFilePath, 
                                   Cvs.IsActive
                            FROM   Cvs
                            WHERE  Cvs.UserID={UserID};";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }


        /// <summary>
        /// שאילתה לעדכון רשומת קורות חיים ללא פעיל
        /// </summary>
        /// <param name="cvID">של קורות חיים ID</param>
        /// <returns></returns>
        public static int UpdateCvActivity(int cvID, bool IsActive)
        {
            string sql = $@"UPDATE Cvs SET Cvs.IsActive = {IsActive}
                            WHERE  Cvs.CvID={cvID};";
            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }

        
        /// <summary>
        /// שאילתה להוספה של רשומת קורות חיים חדשים למשתמש
        /// </summary>
        /// <param name="cvFilePath">המיקום של קובץ קורות החיים</param>
        /// <param name="userID">של משתמש ID</param>
        /// <returns></returns>
        public static int InsertUserCv(string cvFilePath, int userID)
        {
            string sql = $@"INSERT INTO Cvs (CvFilePath, UserID, IsActive)
                            VALUES ('{cvFilePath}', {userID}, true);";

            int cvID = DAL.DBHelper.ExecuteInsertGetIdentity(sql);
            return cvID;
        }
    }
}
