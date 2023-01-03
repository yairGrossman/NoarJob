using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;

            //PrintDt(new DataTable[] { Cities.GetCityByStart("נת") });
            //PrintDt(new DataTable[] { CompanyTypes.GetAllCompanyTypes() });
            //PrintDt(new DataTable[] { Cvs.GetUserCvs(48) });
            ////Console.WriteLine(Cvs.InsertUserCv("file:///C:/Users/Adar/Documents/blabla.docx", 48));
            //Console.WriteLine(Cvs.UpdateCvActivity(25, false));
            //PrintDt(new DataTable[] { Employers.GetEmployerByID(12) });
            //Console.WriteLine(Employers.IsEmployerExist("smartTech@gmail.com", "00", "סמארט טק"));
            //Console.WriteLine(Employers.UpdateEmployerByID(12, "חיים כהן", 1000, 30, "סמארט טק"));
            //Console.WriteLine(Employers.InsertEmployer("אלון", 200, 1,"Moofasa", "123", "123"));
            //PrintDt(new DataTable[] { JobCategories.GetParentJobCategories() });
            //PrintDt(new DataTable[] { JobCategories.GetJobCategoriesByParentID(19) });
            //PrintDt(new DataTable[] { JobCategories.GetParentJobCategoriesByText("ו") });
            //PrintDt(new DataTable[] { JobCategories.GetJobCategoriesByParentIDByText(1, "מ") });
            ////Jobs_Cities.SetJob_Cities(15, new List<int> {24, 22});
            ////Jobs_JobCategories.SetJob_JobCategories(1, new int[] {1, 5, 9});
            //PrintDt(Jobs_Cities.GetAllCitiesByJobID(1));
            //PrintDt(Jobs_JobCategories.GetAllJobCategoriesByJob(1));
            ////Jobs_JobTypes.SetJob_JobTypes(1, new int[] { 1, 2 });
            //PrintDt(Jobs_JobTypes.GetAllJobTypesByJobID(1));
            ////Console.WriteLine(Jobs.InsertJob("test", "test", "test", 12, "056-5656565", "Yair@gmail.com", new List<int> { 1}, new List<int> { 23}, new List<int> { 1 }));
            ////Console.WriteLine(Jobs.UpdateJob(26,"test", "test", "test", 12, "056-5656565", "Yair@gmail.com", false, new List<int> { 1 }, new List<int> { 23 }, new List<int> { 1 }));
            ////Console.WriteLine(Jobs.UpdateJobActivity(2));
            //PrintDt(Jobs.GetJobs(new int[] {15, 20}, 48));
            //PrintDt(Jobs.GetJobsByEmployerAndJobActivity(14, false));
            ////Console.WriteLine(Users.InsertUser("Lior@gmail.com", "098kjh765", "Lior", "Gilboa", "000-0000000",23));
            //Console.WriteLine(Users.UpdateUser(7, "Smart@gmail.com", "7654390", "Smart", "Brown", "000-0000000", 23));
            //PrintDt(new DataTable[] { Users.GetUser("test", "test") });
            ////Console.WriteLine(SearchAgents.InsertSearchAgent(48));
            ////Console.WriteLine(SearchAgents.UpdateSearchAgentActivity(15));
            ////SearchAgentsValues.SetSearchAgentValues(15, 4, new List<int> { 1, 2});
            //PrintDt(JobTypes.GetAllJobTypes());
            //PrintDt(JobTypes.GetAllSubTypes());

            //PrintDt(Jobs.JobsSearch(1,new List<int> { 3 }, null, 0, null, 48));
            //PrintDt(Jobs.JobsSearch(0, null, null, 0, "מוכר", -1));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(6, 48));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(4, 9));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(5, 8));

            //PrintDt(new DataTable[] { SearchAgents.GetSearchAgentsByUser(48) });

            //PrintDt(Users_Jobs.GetLovedJobs(8));
            //Console.ReadKey();
            //PrintDt(Jobs.JobsSearch(null, null, null, "עוזר", -1));
            //Console.ReadKey();

            //Console.WriteLine(Jobs.InsertJob("aaa", "bbb", "ccc", 1, "09999999999", "gdfgfd@gmail.com", 
            // new List<int> { 1, 5}, new List<int> { 1, 3}, new List<int> {1, 3 }));

            //Console.WriteLine(SameSearchesOfUsers.SameParentCategory(31));
            //Console.WriteLine(SameSearchesOfUsers.SameChildCategoriesAndCities(new List<int> { 32, 33 }, new List<int> {23}));
            //DataTable[] arrDt = SearchAgents.GetSearchAgentsByUser(48);
            //DataTable dt = MostSoughtJobs.GetTheMostSoughtJob(new List<int> {33 }, new List<int> { 23}, new List<int> { 1});
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    Console.WriteLine(dt.Rows[i]["JobID"]);
            //    Console.WriteLine(dt.Rows[i]["UsersApplyCount"]);
            //}
        }

        public static void PrintDt(DataTable[] dt)
        {
            for (int h = 0; h < dt.Length; h++)
            {
                int[] maxArr = new int[dt[h].Columns.Count];

                for (int i = 0; i < dt[h].Columns.Count; i++)
                {                     
                    if (maxArr[i] < dt[h].Columns[i].ColumnName.Length)
                    {                 
                        maxArr[i] = dt[h].Columns[i].ColumnName.Length;
                    }

                    for (int j = 0; j < dt[h].Rows.Count; j++)
                    {                     
                        if (maxArr[i] < dt[h].Rows[j][i].ToString().Length)
                        {                 
                            maxArr[i] = dt[h].Rows[j][i].ToString().Length;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                for (int i = 0; i < dt[h].Columns.Count; i++)
                {
                    Console.Write("| " + dt[h].Columns[i].ColumnName + (new string(' ', (maxArr[i] - dt[h].Columns[i].ColumnName.Length) + 1)));
                }
                Console.WriteLine();
                Console.ResetColor();
                for (int i = 0; i < dt[h].Rows.Count; i++)
                {
                    for (int j = 0; j < dt[h].Columns.Count; j++)
                    {
                        Console.Write("| " + dt[h].Rows[i][j] + (new string(' ', (maxArr[j] - dt[h].Rows[i][j].ToString().Length) + 1)));
                    }
                    Console.WriteLine();
                }
            }
            

        }

    }
}
