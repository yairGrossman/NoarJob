using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WSameSearchesOfUsers
    {
        private int countSameParentCategory;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategories;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategoriesAndCities;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategoriesAndCitiesAndTypes;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים ואותם היקפי/סוגי משרה כמו של המשרה שהמעסיק רוצה לפרסם

        public WSameSearchesOfUsers(SameSearchesOfUsersBL sameSearchesOfUsersBL)
        {
            this.countSameParentCategory = sameSearchesOfUsersBL.CountSameParentCategory;
            this.countSameParentCategoryAndChildCategories = sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategories;
            this.countSameParentCategoryAndChildCategoriesAndCities = sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategoriesAndCities;
            this.countSameParentCategoryAndChildCategoriesAndCitiesAndTypes = sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes;
        }

        [DataMember]
        public int CountSameParentCategory { get => countSameParentCategory; set => countSameParentCategory = value; }
        [DataMember]
        public int CountSameParentCategoryAndChildCategories { get => countSameParentCategoryAndChildCategories; set => countSameParentCategoryAndChildCategories = value; }
        [DataMember]
        public int CountSameParentCategoryAndChildCategoriesAndCities { get => countSameParentCategoryAndChildCategoriesAndCities; set => countSameParentCategoryAndChildCategoriesAndCities = value; }
        [DataMember]
        public int CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes { get => countSameParentCategoryAndChildCategoriesAndCitiesAndTypes; set => countSameParentCategoryAndChildCategoriesAndCitiesAndTypes = value; }
    }
}