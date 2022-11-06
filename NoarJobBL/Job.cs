using System.Collections.Generic;
using System.Data;

namespace NoarJobBL
{
    //חדש
    public class Job
    {
        private int jobID;//מספר המשרה
        private string title;//כותרת המשרה
        private string description;//תיאור המשרה
        private string requirements;//דרישות של המשרה
        private string employerName;//שם המעסיק
        private int numOfEmployees;//מספר העובדים שיש למעסיק בחברה
        private string companyTypeName;//שם הקטגורייה של החברה
        private string phone;//מספר טלפון של המשרה
        private string email;//האימייל של המשרה
        private bool isActive;//המשרה באוויר או לא
        private string companyName;//שם החברה

        private Dictionary<int, string> citiesDictionary;//רשימת הערים שהמשרה נמצאת בה
        private Dictionary<int, string> typesDictionary;//רשימת סוגי המשרות שלמשרה יש 
        private Dictionary<int, string> categoriesDictionary;//רשימת הקטגוריות שלמשרה יש 

        public Job(int jobID, 
            string title, 
            string description, 
            string requirements, 
            string employerName, 
            int numOfEmployees, 
            string companyTypeName, 
            string phone, 
            string email, 
            bool isActive, 
            string companyName, 
            DataTable dtCities,
            DataTable dtTypes,
            DataTable dtCategories)
        {
            this.jobID = jobID;
            this.title = title;
            this.description = description;
            this.requirements = requirements;
            this.employerName = employerName;
            this.numOfEmployees = numOfEmployees;
            this.companyTypeName = companyTypeName;
            this.phone = phone;
            this.email = email;
            this.isActive = isActive;
            this.companyName = companyName;

            this.citiesDictionary = new Dictionary<int, string>();
            this.typesDictionary = new Dictionary<int, string>();
            this.categoriesDictionary = new Dictionary<int, string>();
            ConvertDtToDictionary(this.citiesDictionary, dtCities, jobID);
            ConvertDtToDictionary(this.typesDictionary, dtTypes, jobID);
            ConvertDtToDictionary(this.categoriesDictionary, dtCategories, jobID);
        }

        public Job()
        {
            this.citiesDictionary = new Dictionary<int, string>();
            this.typesDictionary = new Dictionary<int, string>();
            this.categoriesDictionary = new Dictionary<int, string>();
        }

        #region תכונות
        public int JobID
        {
            get { return this.jobID; }
        }

        public string Title
        {
            get { return this.title; }
        }

        public string Description
        {
            get { return this.description; }
        }

        public string Requirements
        {
            get { return this.requirements; }
        }

        public string EmployerName
        {
            get { return this.employerName; }
        }

        public int NumOfEmployees
        {
            get { return this.numOfEmployees; }
        }

        public string CompanyTypeName
        {
            get { return this.companyTypeName; }
        }

        public string Phone
        {
            get { return this.phone; }
        }

        public string Email
        {
            get { return this.email; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
        }

        public string CompanyName
        {
            get { return this.companyName; }
        }

        public Dictionary<int, string> CitiesDictionary
        {
            get { return this.citiesDictionary; }
        }

        public Dictionary<int, string> TypesDictionary
        {
            get { return this.typesDictionary; }
        }

        public Dictionary<int, string> CategoriesDictionary
        {
            get { return this.categoriesDictionary; }
        }
        #endregion

        /// <summary>
        /// פונקציה שממירה טבלת נתונים ליומן
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="jobID"></param>
        private void ConvertDtToDictionary(Dictionary<int, string> dictionary, DataTable dt, int jobID)
        {
            int id;
            string value;
            if (dt != null)
            {
                DataRow[] dr = dt.Select("JobID = " + jobID);
                foreach (DataRow row in dr)
                {
                    id = (int)row[2];
                    value = row[1].ToString();
                    dictionary.Add(id, value);
                }
            }
        }

        /// <summary>
        /// פונקציה שיוצרת משרה חדשה
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="requirements"></param>
        /// <param name="employerID"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="jobCategories"></param>
        /// <param name="cities"></param>
        /// <param name="jobTypes"></param>
        public void CreateJob(string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes)
        {
            NoarJobDAL.Jobs.InsertJob(title, description, requirements, employerID, phone, email, jobCategories, cities, jobTypes);
        }

        /// <summary>
        /// פונקציה שמעדכנת משרה
        /// </summary>
        /// <param name="employerID"></param>
        /// <param name="jobCategories"></param>
        /// <param name="cities"></param>
        /// <param name="jobTypes"></param>
        public void UpdateJob(string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes)
        {
            NoarJobDAL.Jobs.UpdateJob(this.jobID, title, description, requirements, employerID, phone, email, this.isActive,
                jobCategories, cities, jobTypes);
        }

        /// <summary>
        /// פונקציה שמשנה את פעילות המשרה
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public bool UpdateJobActivity(int jobID)
        {
            int rows = NoarJobDAL.Jobs.UpdateJobActivity(jobID, this.isActive);
            if (rows > 0)
            {
                return true;
            }
            return false;
        }
    }
}
