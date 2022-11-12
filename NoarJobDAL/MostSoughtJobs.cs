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
									COUNT(Users_Jobs.UserID) as UsersApplyCount
							FROM 	(
										Users_Jobs 
										INNER JOIN 
										(
											SELECT DISTINCT tblUsersByCategories.UserID
											FROM	(
														(
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
															SELECT SearchAgents.UserID
															FROM   SearchAgents
																	INNER JOIN SearchAgentsValues 
																	ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
															WHERE  SearchAgents.IsActive=True
																	AND
																	SearchAgentsValues.ValueType = 3
																	AND
																	SearchAgentsValues.ValueID IN ({String.Join(",", CitiesLst)})
														) tblUsersByCities ON tblUsersByCategories.UserID = tblUsersByCities.UserID
													)
													INNER JOIN
													(
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
									)
									INNER JOIN 
								    Jobs ON Users_Jobs.JobID=Jobs.JobID
							WHERE   Users_Jobs.UserJobType=1
									AND
									Jobs.IsActive=true
						   GROUP BY Users_Jobs.JobID
						   ORDER BY COUNT(Users_Jobs.UserID) DESC;
                           ";
			DataTable dt = DAL.DBHelper.GetDataTable(sql);
			return dt;
        }
    }
}
