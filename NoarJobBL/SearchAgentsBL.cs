using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NoarJobBL
{
    public class SearchAgentsBL
    {
        /// <summary>
        /// פונקציה לחיפוש משרות לפי סוכן
        /// </summary>
        /// <param name="searchAgentID">של סוכן חכם ID</param>
        /// <param name="userID">של המשתמש ID</param>
        /// <returns></returns>
        public Job[] GetJobsBySearchAgent(int searchAgentID, int userID)
        {
            DataTable[] arrDt = SearchAgents.GetJobsBySearchAgent(searchAgentID, userID);
            Job[] arrJobs = JobsBL.GetJobs(arrDt);
            return arrJobs;
        }

        /// <summary>
        /// פונקציה המחזירה את כל הסוכנים החכמים לפי משתמש
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public List<SearchAgent> GetSearchAgentsByUser(int userID)
        {
            DataTable dt = NoarJobDAL.SearchAgents.GetSearchAgentsByUser(userID);
            int valueType;
            List<SearchAgent> searchAgentLst = new List<SearchAgent>();
            SearchAgent searchAgent = null;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                valueType = (int)dt.Rows[i]["ValueType"];
                if (valueType == 1)
                {
                    searchAgent = new SearchAgent((int)dt.Rows[i]["UserID"]);
                    searchAgent.SearchAgentID = (int)dt.Rows[i]["SearchAgentID"];
                    searchAgent.ParentCategoryKvp = new KeyValuePair<int, string>((int)dt.Rows[i]["ValueID"], dt.Rows[i]["ValueName"].ToString());
                    searchAgentLst.Add(searchAgent);
                }
                else if (valueType == 2)
                {
                    searchAgent.ChildCategoriesDictionary.Add((int)dt.Rows[i]["ValueID"], dt.Rows[i]["ValueName"].ToString());
                }
                else if (valueType == 3)
                {
                    searchAgent.CityKvp = new KeyValuePair<int, string>((int)dt.Rows[i]["ValueID"], dt.Rows[i]["ValueName"].ToString());
                }
                else if(valueType == 4)
                {
                    searchAgent.TypesDictionary.Add((int)dt.Rows[i]["ValueID"], dt.Rows[i]["ValueName"].ToString());
                }
                else
                {
                    searchAgent.Text = dt.Rows[i]["ValueName"].ToString();
                }
            }
            return searchAgentLst;
        }
    }
}
