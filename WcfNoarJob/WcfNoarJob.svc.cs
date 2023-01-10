using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfNoarJob
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IWcfNoarJob
    {
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
    }
}
