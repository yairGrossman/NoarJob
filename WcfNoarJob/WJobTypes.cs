using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WJobTypes
    {
        private List<int> chosenJobTypeLst = new List<int>();// טיפוסי המשרה שהמשתמש בחר 

        public WJobTypes(JobTypesBL jobTypes)
        {
            this.chosenJobTypeLst = jobTypes.ChosenJobTypeLst;
        }

        [DataMember]
        public List<int> ChosenJobTypeLst { get => chosenJobTypeLst; set => chosenJobTypeLst = value; }
    }
}