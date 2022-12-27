using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WCities
    {
        private List<int> lstCities;//היישובים שהמעסיק בחר
        private int chosenCity;// היישוב שהמשתמש בחר

        public WCities(CitiesBL cities)
        {
            this.lstCities = cities.LstCities;
            this.chosenCity = cities.ChosenCity;
        }

        [DataMember]
        public List<int> LstCities { get => lstCities; set => lstCities = value; }
        [DataMember]
        public int ChosenCity { get => chosenCity; set => chosenCity = value; }
    }
}