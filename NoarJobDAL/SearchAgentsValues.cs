using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class SearchAgentsValues
    {
        /// <summary>
        /// שאילתה ליצירת רשומה חדשה של מילת מפתח לסוכן חכם
        /// </summary>
        /// <param name="SearchAgentID"></param>
        /// <param name="ValueTxt"></param>
        public static void InsertSearchAgentValueText(int SearchAgentID, string ValueTxt)
        {
            string sql = $@"
                             INSERT INTO SearchAgentsValues (SearchAgentID, ValueType, ValueTxt) 
                             VALUES({SearchAgentID}, 5, '{ValueTxt}');
                           ";

            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה ליצירת רשומה חדשה של פרטי הסוכן חכם
        /// </summary>
        /// <param name="SearchAgentID">של סוכן חכם ID</param>
        /// <param name="ValueType">תחום תפקיד - 1, 2 - קטגורית תפקיד, 3 - ישוב, 4  - סוג משרה</param>
        /// <param name="ValueID">של רשומה בטבלה מסויימת לפי סוג הערך ID</param>
        /// <returns></returns>
        private static int InsertSearchAgentValues(int SearchAgentID, int ValueType, int ValueID)
        {
            string sql = $@"
                             INSERT INTO SearchAgentsValues (SearchAgentID, ValueType, ValueID) 
                             VALUES({SearchAgentID}, {ValueType}, {ValueID});
                           ";

            int rows = DAL.DBHelper.ExecuteNonQuery(sql);
            return rows;
        }

        /// <summary>
        /// שאילתה ליצירת רשומות של טבלה זו כחלק מתהליך יצירת רשומת משרה חדשה 
        /// </summary>
        private static void InsertSearchAgentValues(int SearchAgentID, int ValueType, List<int> ValuesID)
        {
            for (int i = 0; i < ValuesID.Count; i++)
            {
                InsertSearchAgentValues(SearchAgentID, ValueType, ValuesID[i]);
            }
        }

        /// <summary>
        /// שאילתה למחיקת כל הרשומות של סוכן ספציפי וגם לפי סוג הקטגורייה
        /// </summary>
        private static void DeleteAllSearchAgentValues(int SearchAgentID, int ValueType)
        {
            string sql = $@"DELETE FROM SearchAgentsValues 
                            WHERE SearchAgentID={SearchAgentID}
                                  AND
                                  ValueType={ValueType};";
            DAL.DBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון סוכן/יצירת סוכן
        /// </summary>
        public static void SetSearchAgentValues(int SearchAgentID, int ValueType, List<int> ValuesID)
        {
            DeleteAllSearchAgentValues(SearchAgentID, ValueType);
            InsertSearchAgentValues(SearchAgentID, ValueType, ValuesID);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון סוכן/יצירת סוכן כאשר מתקבל תעודת זהות אחת
        /// </summary>
        public static void SetSearchAgentValues(int SearchAgentID, int ValueType, int ValuesID)
        {
            DeleteAllSearchAgentValues(SearchAgentID, ValueType);
            InsertSearchAgentValues(SearchAgentID, ValueType, ValuesID);
        }

        /// <summary>
        /// שאילתה לעדכון/יצירה של רשומות בטבלה זו כחלק מתהליך עדכון סוכן/יצירת סוכן כאשר מתקבל מילת מפתח
        /// </summary>
        public static void SetSearchAgentValues(int SearchAgentID, string ValueTxt)
        {
            DeleteAllSearchAgentValues(SearchAgentID, 5);
            InsertSearchAgentValueText(SearchAgentID, ValueTxt);
        }
    }
}
