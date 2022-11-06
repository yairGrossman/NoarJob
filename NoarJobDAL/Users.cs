using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Users
    {
        /// <summary>
        /// שאילתה להחזרת רשומת משתמש
        /// </summary>
        /// <param name="UserID">של המשתמש ID</param>
        /// <returns></returns>
        public static DataTable GetUser(string Email, string UserPassword)
        {
            string sql = $@"
                             SELECT Users.UserID, 
                                    Users.Email, 
                                    Users.UserPassword,
                                    Users.FirstName, 
                                    Users.LastName,
                                    Users.Phone,
                                    Users.CityID, 
                                    Cities.CityName
                             FROM   Users
                                    INNER JOIN Cities 
                                    ON Users.CityID = Cities.CityID;
                             WHERE  Users.Email='{Email}' 
                                    AND 
                                    Users.UserPassword='{UserPassword}';
                           ";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה ליצירת רשומת משתמש חדש
        /// </summary>
        /// <param name="Email">אימייל</param>
        /// <param name="UserPassword">סיסמא</param>
        /// <param name="FirstName">שם פרטי</param>
        /// <param name="LastName">שם משפחה</param>
        /// <returns></returns>
        public static int InsertUser(string Email, string UserPassword, string FirstName, string LastName, string Phone, int CityID)
        {
            string sql = $@"
                             INSERT INTO Users (Email, UserPassword, FirstName, LastName, Phone, CityID) 
                             VALUES('{Email}', '{UserPassword}', '{FirstName}', '{LastName}', '{Phone}', {CityID});
                           ";

            int UserID = DAL.DBHelper.ExecuteInsertGetIdentity(sql);
            return UserID;
        }

        /// <summary>
        /// שאילתה לעדכון רשומת משתמש
        /// </summary>
        /// <param name="UserID">של המשתמש ID</param>
        /// <param name="UserType">סוג המשתמש: 1-מעסיק, 2 - מועמד</param>
        /// <param name="Email">אימייל</param>
        /// <param name="UserPassword">סיסמא</param>
        /// <param name="FirstName">שם פרטי</param>
        /// <param name="LastName">שם משפחה</param>
        /// <returns></returns>
        public static int UpdateUser(int UserID, string Email, string UserPassword, string FirstName, string LastName, string Phone, int CityID)
        {
            string sql = $@" 
                              UPDATE Users SET Users.Email = '{Email}', 
                                               Users.[UserPassword] = '{UserPassword}', 
                                               Users.FirstName = '{FirstName}', 
                                               Users.LastName = '{LastName}',
                                               Users.Phone = '{Phone}',
                                               Users.CityID = {CityID}
                              WHERE            Users.UserID={UserID};
                           ";

            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }
    }
}
