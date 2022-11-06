using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    /// <summary>
    /// מחלקה לפעולה תומכת החלטה
    /// </summary>
    public class SameSearchesOfUsersBL
    {
        private int countSameParentCategory;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategories;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategoriesAndCities;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים כמו של המשרה שהמעסיק רוצה לפרסם
        private int countSameParentCategoryAndChildCategoriesAndCitiesAndTypes;//סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים ואותם היקפי/סוגי משרה כמו של המשרה שהמעסיק רוצה לפרסם


        public int CountSameParentCategory
        {
            get { return this.countSameParentCategory; }
        }

        public int CountSameParentCategoryAndChildCategories
        {
            get { return this.countSameParentCategoryAndChildCategories; }
        }

        public int CountSameParentCategoryAndChildCategoriesAndCities
        {
            get { return this.countSameParentCategoryAndChildCategoriesAndCities; }
        }

        public int CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes
        {
            get { return this.countSameParentCategoryAndChildCategoriesAndCitiesAndTypes; }
        }


        public SameSearchesOfUsersBL()
        {
            this.countSameParentCategory = 0;
            this.countSameParentCategoryAndChildCategories = 0;
            this.countSameParentCategoryAndChildCategoriesAndCities = 0;
            this.countSameParentCategoryAndChildCategoriesAndCitiesAndTypes = 0;
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד שהמעסיק בחר 
        /// </summary>
        /// <param name="parentCategory"></param>
        public void GetSameParentCategory(int parentCategory)
        {
            this.countSameParentCategory = NoarJobDAL.SameSearchesOfUsers.SameParentCategory(parentCategory);
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים שהמעסיק בחר 
        /// </summary>
        /// <param name="childCategoriesLst"></param>
        public void GetSameChildCategories(List<int> childCategoriesLst)
        {
            this.countSameParentCategoryAndChildCategories = NoarJobDAL.SameSearchesOfUsers.SameChildCategories(childCategoriesLst);
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים שהמעסיק בחר 
        /// </summary>
        /// <param name="citiesLst"></param>
        public void SameChildCategoriesAndCities(List<int> childCategoriesLst, List<int> citiesLst)
        {
            this.countSameParentCategoryAndChildCategoriesAndCities = NoarJobDAL.SameSearchesOfUsers.SameChildCategoriesAndCities(childCategoriesLst, citiesLst);
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו סוגי משרות שהמעסיק בחר 
        /// </summary>
        /// <param name="typesLst"></param>
        public void SameChildCategoriesAndCitiesAndTypes(List<int> childCategoriesLst, List<int> citiesLst, List<int> typesLst)
        {
            this.countSameParentCategoryAndChildCategoriesAndCitiesAndTypes = NoarJobDAL.SameSearchesOfUsers.SameChildCategoriesAndCitiesAndTypes(childCategoriesLst, citiesLst, typesLst);
        }
    }
}
