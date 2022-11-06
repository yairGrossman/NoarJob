using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class JobCategoriesBL
    {
        private List<int> chosenJobCategoryLst = new List<int>();// התפקידים שהמשתמש בחר
        private int chosenJobCategory = 0;// תחום תפקיד שהמשתמש בחר

        public List<int> ChosenJobCategoryLst
        {
            get { return this.chosenJobCategoryLst; }
        }

        public int ChosenJobCategory
        {
            get { return this.chosenJobCategory; }
            set { this.chosenJobCategory = value; }
        }

        /// <summary>
        /// פונקציה שמחזירה יומן של קטגוריות
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private Dictionary<int, string> ShowData(DataTable dt)
        {
            Dictionary<int, string> jobCategoriesDictionary = new Dictionary<int, string>();//יומן של קטגוריות
            int jobCategoryID;//של קטגוריית המשרה ID
            string jobCategoryName;//שם קטגוריית המשרה
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jobCategoryID = (int)dt.Rows[i][0];
                jobCategoryName = dt.Rows[i][1].ToString();
                jobCategoriesDictionary.Add(jobCategoryID, jobCategoryName);
            }
            return jobCategoriesDictionary;
        }

        /// <summary>
        /// פונקציה שמחזירה יומן שבו כל תחומי התפקיד
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetParentJobCategories()
        {
            DataTable dt = JobCategories.GetParentJobCategories();
            return ShowData(dt);
        }

        /// <summary>
        /// פונקציה שמחזירה מערך שבו כל התפקידים
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetJobCategoriesByParentID()
        {
            DataTable dt = JobCategories.GetJobCategoriesByParentID(this.chosenJobCategory);
            return ShowData(dt);
        }

        /// <summary>
        /// פונקציה שמחזירה את כל תחומי התפקיד שנמצא בהם המחרוזת שהמשתמש הקליד
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetParentJobCategoriesByText(string text)
        {
            DataTable dt = JobCategories.GetParentJobCategoriesByText(text);
            return ShowData(dt);
        }

        /// <summary>
        /// פונקציה שמחזירה את כל התפקידים שנמצא בהם המחרוזת שהמשתמש הקליד
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetJobCategoriesByParentIDAndByText(string text)
        {
            DataTable dt = JobCategories.GetJobCategoriesByParentIDByText(this.chosenJobCategory, text);
            return ShowData(dt);
        }
    }
}
