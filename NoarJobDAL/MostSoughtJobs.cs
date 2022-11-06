using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public static class MostSoughtJobs
    {
		/// <summary>
		/// שאילתה שמחזירה את המשרות שהמשתמשים הדומים לי הגישו הכי הרבה מעומדויות
		/// </summary>
		/// <param name="ChildCategoriesLst"></param>
		/// <param name="CitiesLst"></param>
		/// <param name="TypesLst"></param>
		/// <returns></returns>
        public static DataTable GetTheMostSoughtJob(List<int> ChildCategoriesLst, List<int> CitiesLst, List<int> TypesLst)
        {
            string sql = $@"	
							SELECT 	top 10
									Users_Jobs.JobID,
									COUNT(Users_Jobs.UserID) as 'Users apply count'
									-- שאילתה שמחזירה את 10 המשרות שמשתמשים שדומים לי שלחו אליהם הכי הרבה מועמדויות
							FROM 	Users_Jobs INNER JOIN 
									(
									  -- שאילתה שמחזירה משתמשים שדומים לי עם אותם תפקידים ערים וסוגי/היקפי משרה
			                          SELECT DISTINCT tblUsersByCategories.UserID
			                          FROM	(
												(
												  -- שאילתה להחזרת המשתמשים שמחפשים אותם תפקידים כמוני
												  SELECT SearchAgents.UserID
												  FROM   SearchAgents
														 INNER JOIN SearchAgentsValues 
														 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
												  WHERE  SearchAgents.IsActive=True
														 AND
														 SearchAgentsValues.ValueType = 2
														 AND
														 SearchAgentsValues.ValueID IN ({String.Join(",", ChildCategoriesLst)})
												) tblUsersByCategories
												INNER JOIN
												(
												  -- שאילתה להחזרת המשתמשים שמחפשים אותם ערים כמוני
												  SELECT SearchAgents.UserID
												  FROM   SearchAgents
														 INNER JOIN SearchAgentsValues 
														 ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
												  WHERE  SearchAgents.IsActive=True
														 AND
														 SearchAgentsValues.ValueType = 3
														 AND
														 SearchAgentsValues.ValueID IN ({String.Join(",", CitiesLst)})
												) tblUsersByCities ON tblUsersByCategories.UserID = tblUsersByCities.UserID)
												INNER JOIN
												(
												   -- שאילתה להחזרת המשתמשים שמחפשים אותם היקפי/סוגי משרה כמוני
												   SELECT SearchAgents.UserID
												   FROM   SearchAgents
														  INNER JOIN SearchAgentsValues 
														  ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
												   WHERE  SearchAgents.IsActive=True
														  AND
														  SearchAgentsValues.ValueType = 4
														  AND
														  SearchAgentsValues.ValueID IN ({String.Join(",", TypesLst)})
												) tblUsersByTypes ON tblUsersByCategories.UserID = tblUsersByTypes.UserID
		                            ) tblMatchUsers ON Users_Jobs.UserID = tblMatchUsers.UserID
							WHERE   Users_Jobs.UserJobType=1
							GROUP BY Users_Jobs.JobID
							ORDER BY COUNT(Users_Jobs.UserID) DESC;
                           ";
			DataTable dt = DAL.DBHelper.GetDataTable(sql);
			return dt;
        }
    }
}
