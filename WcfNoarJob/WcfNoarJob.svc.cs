using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Security;
using static System.Net.Mime.MediaTypeNames;

namespace WcfNoarJob
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IWcfNoarJob
    {
        #region קשור למחלקת משתמש
        /// <summary>
        /// פונקציה שיוצרת משתמש חדש במידה שהוא לא קיים כבר במערכת
        /// ומחזירה אמת אם הוא היה כבר קיים במערכת ושקר אחרת
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userPassword"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName)
        {
            User user = new User();
            bool succeed = user.CreateUser(email, userPassword, firstName, lastName, phone, cityID, cityName);
            if (succeed)
            {
                WUser wUser = new WUser(user);
                return wUser;
            }
            return null;
        }

        /// <summary>
        /// פונקציה שמחברת משתמש למערכת במידה וקיים ומחזירה אותו
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public WUser UserLogin(string email, string password)
        {
            User user = new User();
            bool succeed = user.SetUser(email, password);
            if (succeed)
            {
                WUser wUser = new WUser(user);
                return wUser;
            }
            return null;
        }

        /// <summary>
        /// פונקציה ששמה את רשומות קורות החיים של משתמש ספציפי בתוך רשימת קורות החיים
        /// </summary>
        public WUser SetUserCvs(WUser wUser)
        {
            User user = new User();
            user.UserID = wUser.UserID;
            user.SetUserCvs();
            foreach (Cv cv in user.LstCvs)
            {
                WCv Wcv = new WCv(cv);
                wUser.LstCvs.Add(Wcv);
            }
            return wUser;
        }
        #endregion

        #region קשור למחלקת ערים
        /// <summary>
        /// פונקציה שמקבלת חלק משם של ישוב או את שם הישוב המלא
        /// ומחזירה יומן של ישובים שמתחילים במחרוזת שהמשתמש חיפש
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetCities(string city)
        {
            CitiesBL citiesBL = new CitiesBL();
            Dictionary<int, string> citiesDictionary = citiesBL.GetCities(city);
            return citiesDictionary;
        }
        #endregion

        #region קשור למחלקת קטגוריות של חברות
        /// <summary>
        /// פונקציה שמחזירה את כל קטגוריות החברות
        /// </summary>
        /// <returns></returns>
        public WCompanyType[] GetAllCompanyTypes()
        {
            CompanyType companyType = new CompanyType();
            CompanyType[] companyTypeArr = companyType.GetAllCompanyTypes();
            WCompanyType[] wcompanyTypeArr = new WCompanyType[companyTypeArr.Length];
            for (int i = 0; i < wcompanyTypeArr.Length; i++)
            {
                wcompanyTypeArr[i] = new WCompanyType(companyTypeArr[i]);
            }
            return wcompanyTypeArr;
        }
        #endregion

        #region קשור למחלקת קורות חיים
        /// <summary>
        /// פונקציה להוספה של רשומת קורות חיים חדשים למשתמש
        /// </summary>
        /// <param name="cvFilePath">המיקום של קובץ קורות החיים</param>
        /// <param name="userID">של משתמש ID</param>
        public void InsertCv(string cvFilePath, int userID, WUser wUser)
        {
            Cv cv = new Cv();
            cv.InsertCv(cvFilePath, userID);
            WCv wCv = new WCv(cv);
            wUser.LstCvs.Add(wCv);
        }

        /// <summary>
        /// פונקציה לעדכון רשומת קורות חיים ללא פעיל
        /// </summary>
        public WCv UpdateCvActivity(WCv wCv)
        {
            Cv cv = new Cv();
            cv.CvID = wCv.CvID;
            cv.UpdateCvActivity();
            wCv.CvIsActive = false;
            return wCv;
        }
        #endregion

        #region קשור למחלקת מעסיק
        /// <summary>
        /// למעסיק Login פונקצית 
        /// </summary>
        /// <param name="companyEmail"></param>
        /// <param name="employerPassword"></param>
        /// <returns></returns>
        public WEmployer EmployerLogin(string companyEmail, string employerPassword)
        {
            Employer employer = new Employer();
            bool succeed = employer.GetEmployer(companyEmail, employerPassword);
            if (succeed)
            {
                WEmployer wEmployer = new WEmployer(employer);
                return wEmployer;
            }
            return null;
        }

        /// <summary>
        /// פונקציה שיוצרת מעסיק חדש
        /// </summary>
        public WEmployer CreateEmployer(string employerName, int numOfEmployees, int companyTypeID, string companyTypeName,
            string companyName, string employerPassword, string companyEmail)
        {
            Employer employer = new Employer();
            bool succeed = employer.CreateEmployer( employerName,  numOfEmployees,  companyTypeID,  companyTypeName,
             companyName,  employerPassword,  companyEmail);
            if (succeed)
            {
                WEmployer wEmployer = new WEmployer(employer);
                return wEmployer;
            }
            return null;
        }
        #endregion

        #region קשור למחלקת משרה
        /// <summary>
        /// פונקציה שיוצרת משרה חדשה
        /// </summary>
        public WJob CreateJob(string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes)
        {
            Job job = new Job();
            job.CreateJob( title,  description,  requirements,  employerID,
             phone,  email,  jobCategories,  cities,  jobTypes);

            WJob wJob = new WJob(job);
            return wJob;
        }

        /// <summary>
        /// פונקציה שמעדכנת משרה
        /// </summary>
        /// <param name="employerID"></param>
        /// <param name="jobCategories"></param>
        /// <param name="cities"></param>
        /// <param name="jobTypes"></param>
        public void UpdateJob(WJob wJob, string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes)
        {
            Job job = new Job();
            job.JobID = wJob.JobID;
            job.IsActive = wJob.IsActive;
            job.UpdateJob(title, description, requirements, employerID,
             phone, email, jobCategories, cities, jobTypes);
        }

        /// <summary>
        /// פונקציה שמשנה את פעילות המשרה
        /// </summary>
        public bool UpdateJobActivity(WJob wJob)
        {
            Job job = new Job();
            job.JobID = wJob.JobID;
            job.IsActive = wJob.IsActive;
            bool succeed = job.UpdateJobActivity();
            return succeed;
        }
        #endregion

        #region קשור למחלקת הרבים של משרה
        /// <summary>
        /// פונקציה שהופכת מערך של משרות של הלוגיק למערך של משרות של הדאבל יו סי אף
        /// </summary>
        /// <param name="arrJobs"></param>
        /// <returns></returns>
        private WJob[] ConvertJobsToWJob(Job[] arrJobs)
        {
            WJob[] wArrJobs = new WJob[arrJobs.Length];
            for (int i = 0; i < arrJobs.Length; i++)
            {
                wArrJobs[i] = new WJob(arrJobs[i]);
            }
            return wArrJobs;
        }

        /// <summary>
        /// מחזירה מערך של משרות לפי מה שהמשתמש חיפש
        /// </summary>
        public WJob[] GetJobsSearch(int parentCategory, List<int> jobCategories, List<int> jobTypes, int city, string text, int userID)
        {
            JobsBL jobsBL = new JobsBL();
            Job[] arrJobs = jobsBL.GetJobsSearch(parentCategory, jobCategories, jobTypes, city, text, userID);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }

        /// <summary>
        /// מחזירה מערך של משרות המעסיק לפי פעילות המשרות
        /// </summary>
        public WJob[] GetEmployerJobsByJobActivity(int employerID, bool isActive)
        {
            JobsBL jobsBL = new JobsBL();
            Job[] arrJobs = jobsBL.GetEmployerJobsByJobActivity(employerID, isActive);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }

        /// <summary>
        /// פונקציה שמחזירה את המשרות שהמשתמשים הדומים לי הגישו הכי הרבה מעומדויות
        /// </summary>
        public WJob[] GetTheMostSoughtJobBL(int userID, List<int> childCategoriesLst, List<int> citiesLst, List<int> typesLst)
        {
            JobsBL jobsBL = new JobsBL();
            Job[] arrJobs = jobsBL.GetTheMostSoughtJobBL(userID, childCategoriesLst ,citiesLst ,typesLst);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }
        #endregion

        #region קשור למחלקת קטגוריות משרה
        /// <summary>
        /// פונקציה שמחזירה יומן שבו כל תחומי התפקיד
        /// </summary>
        public Dictionary<int, string> GetParentJobCategories()
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            return jobCategories.GetParentJobCategories();
        }

        /// <summary>
        /// פונקציה שמחזירה מערך שבו כל התפקידים
        /// </summary>
        public Dictionary<int, string> GetJobCategoriesByParentID(WJobCategories wJobCategories)
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            jobCategories.ChosenJobCategory = wJobCategories.ChosenJobCategory;
            return jobCategories.GetJobCategoriesByParentID();
        }

        /// <summary>
        /// פונקציה שמחזירה את כל תחומי התפקיד שנמצא בהם המחרוזת שהמשתמש הקליד
        /// </summary>
        public Dictionary<int, string> GetParentJobCategoriesByText(string text)
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            return jobCategories.GetParentJobCategoriesByText(text);
        }

        /// <summary>
        /// פונקציה שמחזירה את כל התפקידים שנמצא בהם המחרוזת שהמשתמש הקליד
        /// </summary>
        public Dictionary<int, string> GetJobCategoriesByParentIDAndByText(WJobCategories wJobCategories, string text)
        {
            JobCategoriesBL jobCategories = new JobCategoriesBL();
            jobCategories.ChosenJobCategory = wJobCategories.ChosenJobCategory;
            return jobCategories.GetJobCategoriesByParentIDAndByText(text);
        }
        #endregion

        #region קשור למחלקת טיפוסי משרה
        /// <summary>
        /// פונקציה המחזירה את כל היקפי המשרות
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllJobTypes()
        {
            JobTypesBL jobTypes = new JobTypesBL();
            return jobTypes.GetAllJobTypes();
        }

        /// <summary>
        /// פונקציה המחזירה את כל סוגי המשרות
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, string> GetAllSubTypes()
        {
            JobTypesBL jobTypes = new JobTypesBL();
            return jobTypes.GetAllSubTypes();
        }
        #endregion

        #region קשור למחלקת חיפושים של משתמשים דומים
        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד שהמעסיק בחר 
        /// </summary>
        /// <param name="parentCategory"></param>
        public WSameSearchesOfUsers GetSameParentCategory(int parentCategory, WSameSearchesOfUsers wSSOU)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.GetSameParentCategory(parentCategory);
            wSSOU.CountSameParentCategory = sameSearchesOfUsers.CountSameParentCategory;
            return wSSOU;
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים שהמעסיק בחר 
        /// </summary>
        /// <param name="childCategoriesLst"></param>
        public WSameSearchesOfUsers GetSameChildCategories(List<int> childCategoriesLst, WSameSearchesOfUsers wSSOU)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.GetSameChildCategories(childCategoriesLst);
            wSSOU.CountSameParentCategoryAndChildCategories = sameSearchesOfUsers.CountSameParentCategoryAndChildCategories;
            return wSSOU;
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים שהמעסיק בחר 
        /// </summary>
        /// <param name="citiesLst"></param>
        public WSameSearchesOfUsers SameChildCategoriesAndCities(List<int> childCategoriesLst, List<int> citiesLst, WSameSearchesOfUsers wSSOU)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCities(childCategoriesLst, citiesLst);
            wSSOU.CountSameParentCategoryAndChildCategoriesAndCities = sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCities;
            return wSSOU;
        }

        /// <summary>
        /// פונקציה שעושה סכום למספר המשתמשים שחיפשו אותו תחום תפקיד ואותם תפקידים ואותם ערים ואותם סוגי משרות שהמעסיק בחר 
        /// </summary>
        /// <param name="typesLst"></param>
        public WSameSearchesOfUsers SameChildCategoriesAndCitiesAndTypes(List<int> childCategoriesLst, 
            List<int> citiesLst, List<int> typesLst, WSameSearchesOfUsers wSSOU)
        {
            SameSearchesOfUsersBL sameSearchesOfUsers = new SameSearchesOfUsersBL();
            sameSearchesOfUsers.SameChildCategoriesAndCitiesAndTypes(childCategoriesLst, citiesLst, typesLst);
            wSSOU.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes = sameSearchesOfUsers.CountSameParentCategoryAndChildCategoriesAndCitiesAndTypes;
            return wSSOU;
        }
        #endregion

        #region קשור למחלקת סוכן חכם

        public WSearchAgent ResetWSearchAgent(WSearchAgent wSearchAgent, int userID)
        {
            wSearchAgent.UserID = userID;
            wSearchAgent.ChildCategoriesDictionary = new Dictionary<int, string>();
            wSearchAgent.CitiesDictionary = new Dictionary<int, string>();
            wSearchAgent.TypesDictionary = new Dictionary<int, string>();
            return wSearchAgent;
        }

        /// <summary>
        /// פונקציה ליצירה של רשומות בטבלה זו כחלק מתהליך יצירת סוכן
        /// </summary>
        public void InsertSearchAgentValues(WSearchAgent wSearchAgent)
        {
            SearchAgent searchAgent = new SearchAgent(wSearchAgent.UserID);
            searchAgent.ParentCategoryKvp = wSearchAgent.ParentCategoryKvp;
            searchAgent.ChildCategoriesDictionary = wSearchAgent.ChildCategoriesDictionary;
            searchAgent.CitiesDictionary = wSearchAgent.CitiesDictionary;
            searchAgent.TypesDictionary = wSearchAgent.TypesDictionary;
            searchAgent.InsertSearchAgentValues();
            wSearchAgent.SearchAgentID = searchAgent.SearchAgentID;
        }

        /// <summary>
        /// פונקציה לעדכון של רשומות בטבלה זו כחלק מתהליך עדכון סוכן
        /// </summary>
        public void UpdateSearchAgentValues(WSearchAgent wSearchAgent)
        {
            SearchAgent searchAgent = new SearchAgent(wSearchAgent.UserID);
            searchAgent.ParentCategoryKvp = wSearchAgent.ParentCategoryKvp;
            searchAgent.ChildCategoriesDictionary = wSearchAgent.ChildCategoriesDictionary;
            wSearchAgent.CitiesDictionary = wSearchAgent.CitiesDictionary;
            searchAgent.TypesDictionary = wSearchAgent.TypesDictionary;
            searchAgent.UpdateSearchAgentValues();
        }

        /// <summary>
        /// פונקציה לעדכון הסוכן החכם כלא פעיל
        /// </summary>
        public void UpdateSearchAgentActivity(int userID, int searchAgentID)
        {
            SearchAgent searchAgent = new SearchAgent(userID);
            searchAgent.SearchAgentID = searchAgentID;
            searchAgent.UpdateSearchAgentActivity();
        }
        #endregion

        #region קשור למחלקת הרבים של סוכן חכם
        /// <summary>
        /// פונקציה לחיפוש משרות לפי סוכן
        /// </summary>
        public WJob[] GetJobsBySearchAgent(int searchAgentID, int userID)
        {
            SearchAgentsBL searchAgentsBL = new SearchAgentsBL();
            Job[] arrJobs = searchAgentsBL.GetJobsBySearchAgent(searchAgentID, userID);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }

        /// <summary>
        /// פונקציה המחזירה את כל הסוכנים החכמים לפי משתמש
        /// </summary>
        public List<WSearchAgent> GetSearchAgentsByUser(int userID)
        {
            SearchAgentsBL searchAgentsBL = new SearchAgentsBL();
            List<SearchAgent> searchAgentsLst = searchAgentsBL.GetSearchAgentsByUser(userID);
            List<WSearchAgent> wSearchAgentsLst = ConvertSAgentLstToWSAgentLst(searchAgentsLst);
            return wSearchAgentsLst;
        }

        private List<WSearchAgent> ConvertSAgentLstToWSAgentLst(List<SearchAgent> searchAgentsLst)
        {
            List<WSearchAgent> wSearchAgentsLst = new List<WSearchAgent>();
            foreach (SearchAgent searchAgent in searchAgentsLst)
            {
                wSearchAgentsLst.Add(new WSearchAgent (searchAgent));
            }

            return wSearchAgentsLst;
        }
        #endregion

        #region קשור למחלקת הקישור של משרה ומועמד
        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש הגיש אליהם מועמדות
        /// </summary>
        public WJob[] GetApplyForJobs(int userID)
        {
            User_Job user_Job = new User_Job();
            Job[] arrJobs = user_Job.GetApplyForJobs(userID);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }

        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש אהב
        /// </summary>
        public WJob[] GetLovedJobs(int userID)
        {
            User_Job user_Job = new User_Job();
            Job[] arrJobs = user_Job.GetLovedJobs(userID);
            WJob[] wArrJobs = ConvertJobsToWJob(arrJobs);
            return wArrJobs;
        }

        /// <summary>
        /// פונקציה המחזירה את רשימת המועמדים של משרה לפי משרה וגם לפי סוג הקיטלוג
        /// </summary>
        public WUser[] GetUsersByJobAndTabType(int jobID, int tabType)
        {
            User_Job user_Job = new User_Job();
            User[] arrUsers = user_Job.GetUsersByJobAndTabType(jobID, tabType);
            WUser[] wArrUsers = ConvertUsersToWUsers(arrUsers);
            return wArrUsers;
        }

        private WUser[] ConvertUsersToWUsers(User[] arrUsers)
        {
            WUser[] wArrUsers = new WUser[arrUsers.Length];
            for (int i = 0; i < arrUsers.Length; i++)
            {
                wArrUsers[i] = new WUser(arrUsers[i]);
            }
            return wArrUsers;
        }

        /// <summary>
        /// פונקציה לעדכון הערת המעסיק למועמד
        /// </summary>
        public void UpdateEmployerNotes(int jobID, int userID, string notes)
        {
            User_Job user_Job = new User_Job();
            user_Job.UpdateEmployerNotes(jobID, userID, notes);
        }

        /// <summary>
        /// ATSפונקצית עדכון להעברת מועמד בין הקיטלוגים השונים במערכת ה
        /// </summary>
        public void UpdateTabType(int jobID, int userID, int tabType)
        {
            User_Job user_Job = new User_Job();
            user_Job.UpdateTabType(jobID, userID, tabType);
        }

        /// <summary>
        /// פונקצית עדכון שמעבירה את הסוג שהמשתמש בחר למשרה
        /// אחד שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה
        /// </summary>
        public void UpdateUserJobType(int jobID, int userID, int userJobType)
        {
            User_Job user_Job = new User_Job();
            user_Job.UpdateUserJobType(jobID, userID, userJobType);
        }

        /// <summary>
        /// פונקציה ליצירת רשומה חדשה בעת הגשת מועמדות של משתמש למשרה
        /// </summary>
        public void CreateUser_Job(int jobID, int userID, int cvID, DateTime dateApplicated)
        {
            User_Job user_Job = new User_Job();
            user_Job.CreateUser_Job(jobID, userID, cvID, dateApplicated);
        }


        /// <summary>
        /// פונקציה ליצירת רשומה חדשה בעת מחיקת משרה/אהבת משרה
        /// </summary>
        public void CreateUser_JobAtDeleteOrLove(int jobID, int userID, int userJobType)
        {
            User_Job user_Job = new User_Job();
            user_Job.CreateUser_Job(jobID, userID, userJobType);
        }
        #endregion
    }
}
