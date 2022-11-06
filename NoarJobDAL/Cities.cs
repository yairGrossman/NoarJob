using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class Cities
    {
        /// <summary>
        /// שאילתה המחזירה ישובים שהשם שלהם מתחיל בפרמטר
        /// </summary>
        /// <param name="city">התחלה של עיר</param>
        /// <returns></returns>
        public static DataTable GetCityByStart(string city)
        {
            string sql = $@"SELECT Cities.CityID,
                                   Cities.CityName
                            FROM   Cities
                            WHERE  CityName LIKE '{city}%';";
            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }
    }
}
