using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class CitiesBL
    {
        private List<int> lstCities;//היישובים שהמעסיק בחר
        private int chosenCity;// היישוב שהמשתמש בחר

        #region תכונות
        public List<int> LstCities
        {
            get { return this.lstCities; }
            set { this.lstCities = value; }
        }

        /// <summary>
        /// chosenCity של ישוב ומכניסה אותו לתוך השדה ID תכונה שמקבלת  
        /// </summary>
        public int ChosenCity
        {
            get { return this.chosenCity; }
            set { this.chosenCity = value; }
        }
        #endregion

        /// <summary>
        /// פונקציה שמקבלת חלק משם של ישוב או את שם הישוב המלא
        /// ומחזירה יומן של ישובים שמתחילים במחרוזת שהמשתמש חיפש
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetCities(string city)
        {
            DataTable dt = NoarJobDAL.Cities.GetCityByStart(city);
            Dictionary<int, string> citiesDictionary = new Dictionary<int, string>();//יומן של ערים
            int cityID;//של עיר ID
            string cityName;//שם העיר
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cityID = (int)dt.Rows[i]["CityID"];
                cityName = dt.Rows[i]["CityName"].ToString();
                citiesDictionary.Add(cityID, cityName);
            }
            return citiesDictionary;
        }
    }
}
