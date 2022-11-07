using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class JobTypesBL
    {
        private List<int> chosenJobTypeLst = new List<int>();// טיפוסי המשרה שהמשתמש בחר 

        public List<int> ChosenJobTypeLst
        {
            get { return this.chosenJobTypeLst; }
        }

        /// <summary>
        /// פונקציה שמחזירה יומן של סוגי/היקפי משרה
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private Dictionary<int, string> ShowData(DataTable dt)
        {
            Dictionary<int, string> typesLst = new Dictionary<int, string>();// יומן של סוגי/היקפי המשרה
            int jobTypeID;//של סוג/היקף המשרה IDה
            string jobTypeName;//שם סוג/היקף המשרה
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jobTypeID = (int)dt.Rows[i][0];
                jobTypeName = dt.Rows[i][1].ToString();
                typesLst.Add(jobTypeID, jobTypeName);
            }
            return typesLst;
        }

        /// <summary>
        /// פונקציה המחזירה את כל היקפי המשרות
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllJobTypes()
        {
            DataTable dt = JobTypes.GetAllJobTypes();
            Dictionary<int, string> dictionary = ShowData(dt);
            return dictionary;
        }

        /// <summary>
        /// פונקציה המחזירה את כל סוגי המשרות
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllSubTypes()
        {
            DataTable dt = JobTypes.GetAllSubTypes();
            Dictionary<int, string> dictionary = ShowData(dt);
            return dictionary;
        }
    }
}
