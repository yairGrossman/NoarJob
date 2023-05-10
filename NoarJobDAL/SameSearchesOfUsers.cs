using System;
using System.Collections.Generic;
using System.Data;

namespace NoarJobDAL
{
    public static class SameSearchesOfUsers
    {
        /// <summary>
        /// שאילתה שמחזירה את מספר המועמדים שחיפשו אותו תחום תפקיד
        /// כמו של המשרה שהמעסיק רוצה לפרסם
        /// </summary>
        /// <param name="ParentCategoryID">תז של תחום תפקיד</param>
        /// <returns></returns>
        public static int SameParentCategory(int ParentCategoryID)
        {
            string sql = $@"
                            SELECT COUNT(SearchAgents.UserID)
                            FROM   SearchAgentsValues
                                   INNER JOIN SearchAgents
                                   ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                            WHERE  SearchAgents.IsActive=True
                                   AND
                                   SearchAgentsValues.ValueType = 1
                                   AND
                                   SearchAgentsValues.ValueID={ParentCategoryID}
                                   AND 
                                   DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30;
                           ";

            int numOfRows = DAL.DBHelper.GetScalar(sql);
            return numOfRows;
        }

        /// <summary>
        /// שאילתה שמחזירה את מספר המועמדים שחיפשו אותו תחום תפקיד ואותם תפקידים
        /// כמו של המשרה שהמעסיק רוצה לפרסם
        /// </summary>
        /// <param name="ChildCategoriesLst">תז של תפקידים</param>
        /// <returns></returns>
        public static int SameChildCategories(List<int> ChildCategoriesLst)
        {
            string sql = $@"
                            SELECT COUNT(Tbl.UserID)
                            FROM   (
                                     SELECT DISTINCT SearchAgents.UserID
                                     FROM   SearchAgents
                                            INNER JOIN SearchAgentsValues 
                                            ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
                                     WHERE  SearchAgents.IsActive=True
                                            AND
                                            SearchAgentsValues.ValueType = 2
                                            AND
                                            SearchAgentsValues.ValueID IN ({String.Join(",", ChildCategoriesLst)})
                                            AND 
                                            DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
                                   ) Tbl;
                           ";

            int numOfRows = DAL.DBHelper.GetScalar(sql);
            return numOfRows;
        }

        /// <summary>
        /// שאילתה שמחזירה את מספר המועמדים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים
        /// כמו של המשרה שהמעסיק רוצה לפרסם
        /// </summary>
        /// <param name="ChildCategoriesLst">תז של תפקידים</param>
        /// <returns></returns>
        public static int SameChildCategoriesAndCities(List<int> ChildCategoriesLst, List<int> CitiesLst)
        {
            string sql = $@"
                            SELECT 	COUNT(tblMatchUsers.UserID)
                            FROM 	(
			                          SELECT DISTINCT tblUsersByCategories.UserID
			                          FROM	(
						                      SELECT SearchAgents.UserID
						                      FROM   SearchAgents
								                     INNER JOIN SearchAgentsValues 
								                     ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
						                      WHERE  SearchAgents.IsActive=True
								                     AND
								                     SearchAgentsValues.ValueType = 2
								                     AND
								                     SearchAgentsValues.ValueID IN ({String.Join(",", ChildCategoriesLst)})
                                                     AND 
                                                     DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
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
                                                     AND 
                                                     DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
					                       ) tblUsersByCities ON tblUsersByCategories.UserID = tblUsersByCities.UserID
					
		                            ) tblMatchUsers;
                           ";

            int numOfRows = DAL.DBHelper.GetScalar(sql);
            return numOfRows;
        }

        /// <summary>
        /// שאילתה שמחזירה את מספר המועמדים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים ואותם סוגי/היקפי משרה
        /// כמו של המשרה שהמעסיק רוצה לפרסם
        /// </summary>
        /// <param name="ChildCategoriesLst">תז של תפקידים</param>
        /// <returns></returns>
        public static int SameChildCategoriesAndCitiesAndTypes(List<int> ChildCategoriesLst, List<int> CitiesLst, List<int> TypesLst)
        {
            string sql = $@"
                            SELECT 	COUNT(tblMatchUsers.UserID)
                            FROM 	(
			                          SELECT DISTINCT tblUsersByCategories.UserID
			                          FROM	((
						                      SELECT SearchAgents.UserID
						                      FROM   SearchAgents
								                     INNER JOIN SearchAgentsValues 
								                     ON SearchAgents.SearchAgentID = SearchAgentsValues.SearchAgentID
						                      WHERE  SearchAgents.IsActive=True
								                     AND
								                     SearchAgentsValues.ValueType = 2
								                     AND
								                     SearchAgentsValues.ValueID IN ({String.Join(",", ChildCategoriesLst)})
                                                     AND 
                                                     DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
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
                                                     AND 
                                                     DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
					                        ) tblUsersByCities ON tblUsersByCategories.UserID = tblUsersByCities.UserID)
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
                                                      AND 
                                                      DATEDIFF(""d"", SearchAgents.CreatedDate, #{DateTime.Now}#) <= 30
                                            ) tblUsersByTypes ON tblUsersByCategories.UserID = tblUsersByTypes.UserID
					
		                            ) tblMatchUsers;
                           ";

            int numOfRows = DAL.DBHelper.GetScalar(sql);
            return numOfRows;
        }
    }
}
