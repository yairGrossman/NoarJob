using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WSearchAgent
    {
        private int searchAgentID;//של סוכן חכם ID
        private int userID;//של מועמד ID
        private KeyValuePair<int, string> parentCategoryKvp;//תחום תפקיד
        private Dictionary<int, string> childCategoriesDictionary;//תפקידים
        private Dictionary<int, string> citiesDictionary;//ערים
        private Dictionary<int, string> typesDictionary;//סוגי/היקפי משרות

        public WSearchAgent(SearchAgent searchAgent)
        {
            this.searchAgentID = searchAgent.SearchAgentID;
            this.userID = searchAgent.UserID;
            this.parentCategoryKvp = searchAgent.ParentCategoryKvp;
            this.childCategoriesDictionary = searchAgent.ChildCategoriesDictionary;
            this.citiesDictionary = searchAgent.CitiesDictionary;
            this.typesDictionary = searchAgent.TypesDictionary;
        }

        public WSearchAgent(int userID)
        {
            this.userID = userID;
            this.childCategoriesDictionary = new Dictionary<int, string>();
            this.citiesDictionary = new Dictionary<int, string>();
            this.typesDictionary = new Dictionary<int, string>();
        }

        [DataMember]
        public int SearchAgentID { get => searchAgentID; set => searchAgentID = value; }
        [DataMember]
        public int UserID { get => userID; set => userID = value; }
        [DataMember]
        public KeyValuePair<int, string> ParentCategoryKvp { get => parentCategoryKvp; set => parentCategoryKvp = value; }
        [DataMember]
        public Dictionary<int, string> ChildCategoriesDictionary { get => childCategoriesDictionary; set => childCategoriesDictionary = value; }
        [DataMember]
        public Dictionary<int, string> CitiesDictionary { get => citiesDictionary; set => citiesDictionary = value; }
        [DataMember]
        public Dictionary<int, string> TypesDictionary { get => typesDictionary; set => typesDictionary = value; }
    }
}