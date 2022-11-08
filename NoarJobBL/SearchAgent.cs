﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class SearchAgent
    {
        private int searchAgentID;//של סוכן חכם ID
        private int userID;//של מועמד ID
        private KeyValuePair<int, string> parentCategoryKvp;//תחום תפקיד
        private Dictionary<int, string> childCategoriesDictionary;//תפקידים
        private Dictionary<int, string> citiesDictionary;//ערים
        private Dictionary<int, string> typesDictionary;//סוגי/היקפי משרות

        #region תכונות
        public int SearchAgentID
        {
            get { return this.searchAgentID; }
            set { this.searchAgentID=value; }
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public KeyValuePair<int, string> ParentCategoryKvp
        {
            get { return this.parentCategoryKvp; }
            set { this.parentCategoryKvp = value; }
        }

        public Dictionary<int, string> ChildCategoriesDictionary
        {
            get { return this.childCategoriesDictionary; }
        }

        public Dictionary<int, string> CitiesDictionary
        {
            get { return this.citiesDictionary; }
        }

        public Dictionary<int, string> TypesDictionary
        {
            get { return this.typesDictionary; }
        }
        #endregion

        public SearchAgent(int userID)
        {
            this.userID = userID;
            this.childCategoriesDictionary = new Dictionary<int, string>();
            this.citiesDictionary = new Dictionary<int, string>();
            this.typesDictionary = new Dictionary<int, string>();
        }

        /// <summary>
        /// פונקציית עזר שממירה יומן לרשימה
        /// </summary>
        private List<int> ConvertDictionaryToList(Dictionary<int, string> dictionary)
        {
            List<int> valuesIDLst = new List<int>();
            foreach (KeyValuePair<int, string> kvp in dictionary)
            {
                valuesIDLst.Add(kvp.Key);
            }
            return valuesIDLst;
        }

        /// <summary>
        /// פונקציית עזר ליצירה/עדכון של רשומות בטבלה זו כחלק מתהליך יצירה/עדכון של ערכי הסוכן
        /// </summary>
        private void SetSearchAgentValues()
        {
            List<int> childCategoriesLst = ConvertDictionaryToList(this.childCategoriesDictionary);
            List<int> citiesLst = ConvertDictionaryToList(this.citiesDictionary);
            List<int> typesLst = ConvertDictionaryToList(this.typesDictionary);
            NoarJobDAL.SearchAgentsValues.SetSearchAgentValues(this.searchAgentID, 1, new List<int> { this.parentCategoryKvp.Key });
            NoarJobDAL.SearchAgentsValues.SetSearchAgentValues(this.searchAgentID, 2, childCategoriesLst);
            NoarJobDAL.SearchAgentsValues.SetSearchAgentValues(this.searchAgentID, 3, citiesLst);
            NoarJobDAL.SearchAgentsValues.SetSearchAgentValues(this.searchAgentID, 4, typesLst);
        }

        /// <summary>
        /// פונקציה ליצירה של רשומות בטבלה זו כחלק מתהליך יצירת סוכן
        /// </summary>
        public void InsertSearchAgentValues()
        {
            int searchAgentID = NoarJobDAL.SearchAgents.InsertSearchAgent(this.userID);
            this.searchAgentID = searchAgentID;
            SetSearchAgentValues();
        }

        /// <summary>
        /// פונקציה לעדכון של רשומות בטבלה זו כחלק מתהליך עדכון סוכן
        /// </summary>
        public void UpdateSearchAgentValues()
        {
            SetSearchAgentValues();
        }

        /// <summary>
        /// פונקציה לעדכון הסוכן החכם כלא פעיל
        /// </summary>
        /// <param name="searchAgentID">של סוכן חכם ID</param>
        /// <returns></returns>
        public void UpdateSearchAgentActivity(int searchAgentID)
        {
            NoarJobDAL.SearchAgents.UpdateSearchAgentActivity(searchAgentID);
        }
    }
}
