using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    class Program
    {
        static void Main(string[] args)
        {
            //CitiesBL city = new CitiesBL();
            //Dictionary<int, string> dic = city.GetCities("י");
            //foreach (KeyValuePair<int, string> kvp in dic)
            //{
            //    Console.WriteLine(kvp.Value);
            //}
            //CompanyType companyType = new CompanyType();
            //CompanyType[] companyTypes = companyType.GetAllCompanyTypes();
            //for (int i = 0; i < companyTypes.Length; i++)
            //{
            //    Console.WriteLine(companyTypes[i].CompanyTypeName);
            //}
            //Cv cv = new Cv(29, "sdaa", true);
            //cv.InsertCv("C:\\Users\\fdadfsd\\Downloads\\blabla.docx", 50);
            //cv.UpdateCvActivity();
            //Employer employer = new Employer();
            //employer.GetEmployer("etgarFood@gmail.com", "88");
            //employer.CreateEmployer("self", 100, 2, "חברות אבטחה ישראליות", "netflix", "123", "aelf@gmail.com");
            //Job job = new Job();
            //job.IsActive = false;
            //job.CreateJob("Bip boop", "Boop bip", "Boop bip Boop", 15, "055-5555555", "boopbip@gmail.com", new List<int>() { 31, 40}, new List<int>() { 23}, new List<int>() { 1 });
            //job.UpdateJob("Bip Lollll", "Boop bip", "Boop bip Boop", 15, "055-5555555", "boopbip@gmail.com", new List<int>() { 31, 40 }, new List<int>() { 23 }, new List<int>() { 1 });
            //job.UpdateJobActivity(18);
            //JobsBL jobsBL = new JobsBL();
            //jobsBL.GetJobsSearch(31, new List<int>() { 33}, new List<int>() { 1}, 23, null, -1);
            //jobsBL.GetEmployerJobsByJobActivity(14, true);
            //jobsBL.GetTheMostSoughtJobBL(48, new List<int>() { 33, 32}, new List<int>() { 23 }, new List<int>() { 1 });
            //JobCategoriesBL jobCategoriesBL = new JobCategoriesBL();
            //Dictionary<int, string> dic = jobCategoriesBL.GetParentJobCategories();
            //jobCategoriesBL.ChosenJobCategory = 31;
            //Dictionary<int, string> dic = jobCategoriesBL.GetJobCategoriesByParentID();
            //Dictionary<int, string> dic = jobCategoriesBL.GetParentJobCategoriesByText("מס");
            //Dictionary<int, string> dic = jobCategoriesBL.GetJobCategoriesByParentIDAndByText("ש");
            //JobTypesBL jobTypesBL = new JobTypesBL();
            //Dictionary<int, string> dic = jobTypesBL.GetAllJobTypes();
            //Dictionary<int, string> dic = jobTypesBL.GetAllSubTypes();
            //foreach (KeyValuePair<int, string> kvp in dic)
            //{
            //    Console.WriteLine(kvp.Value);
            //}
            //SameSearchesOfUsersBL sameSearchesOfUsersBL = new SameSearchesOfUsersBL();
            //sameSearchesOfUsersBL.GetSameParentCategory(31);
            //Console.WriteLine(sameSearchesOfUsersBL.CountSameParentCategory);
            //sameSearchesOfUsersBL.GetSameChildCategories(new List<int> { 32, 33});
            //Console.WriteLine(sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategories);
            //sameSearchesOfUsersBL.SameChildCategoriesAndCities(new List<int> { 32, 33 }, new List<int> { 23 });
            //Console.WriteLine(sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategoriesAndCities);
            //sameSearchesOfUsersBL.SameChildCategoriesAndCitiesAndTypes(new List<int> { 32, 33 }, new List<int> { 23 }, new List<int> { 1, 4 });
            //Console.WriteLine(sameSearchesOfUsersBL.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes);
            //SearchAgent searchAgent = new SearchAgent(48);
            //searchAgent.ParentCategoryKvp = new KeyValuePair<int, string>(1, "תוכנה");
            //searchAgent.ChildCategoriesDictionary.Add(5, "DBA");
            //searchAgent.CitiesDictionary.Add(49, "נהריה");
            //searchAgent.TypesDictionary.Add(3, "משרה חלקית");
            //searchAgent.InsertSearchAgentValues();
            //searchAgent.SearchAgentID = 14;
            //searchAgent.UpdateSearchAgentActivity();
            //searchAgent.UpdateSearchAgentValues();
            //SearchAgentsBL searchAgentsBL = new SearchAgentsBL();
            //Job[] jobs = searchAgentsBL.GetJobsBySearchAgent(6, 48);
            //foreach (Job job in jobs)
            //{
            //    Console.WriteLine(job.JobID);
            //    Console.WriteLine(job.Title);
            //    Console.WriteLine(job.Description);
            //    Console.WriteLine(job.Requirements);
            //    Console.WriteLine(job.EmployerName);
            //    Console.WriteLine(job.NumOfEmployees);
            //    Console.WriteLine(job.CompanyTypeName);
            //    Console.WriteLine(job.Phone);
            //    Console.WriteLine(job.Email);
            //    Console.WriteLine(job.IsActive);
            //    Console.WriteLine(job.CompanyName);
            //    Console.WriteLine();
            //    foreach (var kvp in job.CitiesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in job.TypesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in job.CategoriesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine("---------------------------------------------");
            //}
            //List<SearchAgent> searchAgentsLst = searchAgentsBL.GetSearchAgentsByUser(48);
            //foreach (SearchAgent searchAgent in searchAgentsLst)
            //{
            //    Console.WriteLine(searchAgent.SearchAgentID);
            //    Console.WriteLine(searchAgent.UserID);
            //    Console.WriteLine(searchAgent.ParentCategoryKvp.Value);
            //    Console.WriteLine();
            //    foreach (var kvp in searchAgent.ChildCategoriesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in searchAgent.CitiesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in searchAgent.TypesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine("------------------------------------------");
            //}

            //User user = new User();
            //user.CreateUser("pooki@gmail.com", "123", "pooki", "kaka", "098-7878543", 22, "ירושלים");
            //user.SetUser("avram@gmail.com", "123");
            //user.SetUserCvs();
            //foreach (var cv in user.LstCvs)
            //{
            //    Console.WriteLine(cv.CvID);
            //    Console.WriteLine(cv.CvFilePath);
            //    Console.WriteLine(cv.CvIsActive);
            //    Console.WriteLine("-----------------------------------");
            //}
            //Console.WriteLine();

            User_Job user_Job = new User_Job();
            //Job[] jobs = user_Job.GetApplyForJobs(48);
            //Job[] jobs = user_Job.GetLovedJobs(48);
            //foreach (Job job in jobs)
            //{
            //    Console.WriteLine(job.JobID);
            //    Console.WriteLine(job.Title);
            //    Console.WriteLine(job.Description);
            //    Console.WriteLine(job.Requirements);
            //    Console.WriteLine(job.EmployerName);
            //    Console.WriteLine(job.NumOfEmployees);
            //    Console.WriteLine(job.CompanyTypeName);
            //    Console.WriteLine(job.Phone);
            //    Console.WriteLine(job.Email);
            //    Console.WriteLine(job.IsActive);
            //    Console.WriteLine(job.CompanyName);
            //    Console.WriteLine();
            //    foreach (var kvp in job.CitiesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in job.TypesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine();
            //    foreach (var kvp in job.CategoriesDictionary)
            //    {
            //        Console.WriteLine(kvp.Value);
            //    }
            //    Console.WriteLine("---------------------------------------------");
            //}
            //User[] users = user_Job.GetUsersByJobAndTabType(20, 1);
            //foreach (User user in users)
            //{
            //    Console.WriteLine(user.UserID);
            //    Console.WriteLine(user.Email);
            //    Console.WriteLine(user.FirstName);
            //    Console.WriteLine(user.LastName);
            //    Console.WriteLine(user.Phone);
            //    Console.WriteLine(user.CityName);
            //    Console.WriteLine(user.ChosenCvForJob.CvFilePath);
            //    Console.WriteLine("------------------------------");
            //}
            //user_Job.UpdateEmployerNotes(20, 48, "שלום שלום");
            //user_Job.UpdateTabType(20, 48, 1);
            //user_Job.UpdateUserJobType(20, 48, 3);
            //user_Job.CreateUser_Job(18, 48, 25, DateTime.Now);
            //user_Job.CreateUser_Job(18, 48, 2);
        }
    }
}
