using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WJobCategories
    {
        private List<int> chosenJobCategoryLst = new List<int>();// התפקידים שהמשתמש בחר
        private int chosenJobCategory = 0;// תחום תפקיד שהמשתמש בחר

        public WJobCategories(JobCategoriesBL jobCategories)
        {
            this.chosenJobCategoryLst = jobCategories.ChosenJobCategoryLst;
            this.chosenJobCategory = jobCategories.ChosenJobCategory;
        }

        [DataMember]
        public List<int> ChosenJobCategoryLst { get => chosenJobCategoryLst; set => chosenJobCategoryLst = value; }
        [DataMember]
        public int ChosenJobCategory { get => chosenJobCategory; set => chosenJobCategory = value; }
    }
}