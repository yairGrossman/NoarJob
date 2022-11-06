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

            //PrintDt(Cities.GetCityByStart("Ne"));
            //PrintDt(CompanyTypes.GetAllCompanyTypes());
            //PrintDt(Cvs.GetUserCvs(1));
            ////Console.WriteLine(Cvs.InsertUserCv("file:///C:/Users/Adar/Documents/blabla.docx", "Adar", "Barak", "Adar@gmail.com", "055-7836462", 12, 18));
            //PrintDt(Cvs.GetUserCvs(3));
            ////Console.WriteLine(Cvs.UpdateCvActivity(5, true));
            //PrintDt(Employers.GetEmployerByID(1));
            ////Console.WriteLine(Employers.UpdateEmployerByID(1, "Yair", 500, 1));
            ////Console.WriteLine(Employers.InsertEmployer("Alon", 200, 1));
            //PrintDt(JobCategories.GetParentJobCategories());
            //PrintDt(JobCategories.GetJobCategoriesByParentID(19));
            //PrintDt(JobCategories.GetParentJobCategoriesByText("ו"));
            //PrintDt(JobCategories.GetJobCategoriesByParentIDByText(1, "מ"));
            ////Jobs_Cities.SetJob_Cities(1, new int[] {1, 2, 3});
            ////Jobs_JobCategories.SetJob_JobCategories(1, new int[] {1, 5, 9});
            //PrintDt(Jobs_Cities.GetAllCitiesByJobID(1));
            //PrintDt(Jobs_JobCategories.GetAllJobCategoriesByJob(1));
            ////Jobs_JobTypes.SetJob_JobTypes(1, new int[] { 1, 2 });
            //PrintDt(Jobs_JobTypes.GetAllJobTypesByJobID(1));
            ////Console.WriteLine(Jobs.InsertJob("מוכר נעליים בקניון עיר ימים", "לחברת נעליים בעמ דרוש מוכר בחנות נעליים, עבודה ממש משתלמת.", "חובה נעלי נייק, התייחסות בצורה נחמדה ללקוחות, יכולת עבודה בצוות.", 1, "056-5656565", "Yair@gmail.com"));
            ////Console.WriteLine(Jobs.UpdateJob(1, "מוכר בגדים בקניון עיר ימים", "לחברת בגדים בעמ דרוש מוכר בחנות בגדים, עבודה ממש משתלמת", "חובה חולצת נייק, התייחסות בצורה נחמדה ללקוחות, יכולת עבודה בצוות", 2, "059-7965432", "Alon@gmail.com", false));
            ////Console.WriteLine(Jobs.UpdateJobActivity(2));
            //PrintDt(Jobs.GetJob(1));
            //PrintDt(Jobs.GetJobsByEmployerAndJobActivity(6, false));
            ////Console.WriteLine(Users.InsertUser(1, "Lior@gmail.com", "098kjh765", "Lior", "Gilboa"));
            ////Console.WriteLine(Users.UpdateUser(7, 2, "Smart@gmail.com", "7654390", "Smart", "Brown"));
            //PrintDt(Users.GetUser(7));
            ////Console.WriteLine(SearchAgents.InsertSearchAgent(7));
            ////Console.WriteLine(SearchAgents.UpdateSearchAgentActivity(3));
            ////Console.WriteLine(SearchAgentsValues.InsertSearchAgentValues(3, 4, 1));
            ////Console.WriteLine(SearchAgentsValues.UpdateSearchAgentValues(6, 3, 3 , 10));
            //PrintDt(JobTypes.GetAllJobTypes());
            //PrintDt(JobTypes.GetAllSubTypes());

            //PrintDt(Jobs.JobsSearch(new List<int> {1}, null, new List<int> { 1 }, null, 8));
            //PrintDt(Jobs.JobsSearch(null, null, null, "בקניון", -1));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(3, 7));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(4, 9));
            //PrintDt(SearchAgents.GetJobsBySearchAgent(5, 8));

            //DataTable[] valueTypeDtArr = SearchAgents.GetSearchAgentsByUser(9);
            //for (int i = 0; i < valueTypeDtArr.Length; i++)
            //{
            //    PrintDt(valueTypeDtArr[i]);
            //}

            //PrintDt(Users_Jobs.GetLovedJobs(8));
            //Console.ReadKey();
            //PrintDt(Jobs.JobsSearch(null, null, null, "עוזר", -1));
            //Console.ReadKey();

            //Console.WriteLine(Jobs.InsertJob("aaa", "bbb", "ccc", 1, "09999999999", "gdfgfd@gmail.com", 
            // new List<int> { 1, 5}, new List<int> { 1, 3}, new List<int> {1, 3 }));

            //Console.WriteLine(SameSearchesOfUsers.SameParentCategory(31));
            //Console.WriteLine(SameSearchesOfUsers.SameChildCategoriesAndCities(new List<int> { 32, 33 }, new List<int> {23}));
            //DataTable[] arrDt = SearchAgents.GetSearchAgentsByUser(48);
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
