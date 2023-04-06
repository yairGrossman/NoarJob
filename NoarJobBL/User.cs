using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NoarJobDAL;

namespace NoarJobBL
{
    public class User
    {
        private int userID;//מספר המשתמש
        private string email;//אימייל
        private string userPassword;//סיסמא
        private string firstName;//שם פרטי
        private string lastName;//שם משפחה
        private string phone;//מספר הטלפון של המועמד
        private string cityName;//שם העיר שבה גר המשתמש
        private List<Cv> lstCvs;//מערך קורות החיים של המשתמש
        private Cv chosenCvForJob;//קורות חיים ספציפיים שהמשתמש החליט לשלוח למשרה

        /// <summary>
        /// פעולה בונה שנועדה בשביל שהמעסיק יראה את את המועמדים ששלחו למשרה שלו מועמדות
        /// </summary>
        public User(int userID, int cvID, string email, string firstName, string lastName, string phone, string cityName, string cvFilePath, bool isActive)
        {
            this.userID = userID;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.cityName = cityName;
            this.lstCvs = new List<Cv>();
            this.chosenCvForJob = new Cv(cvID, cvFilePath, isActive);
        }

        public User()
        {
            this.lstCvs = new List<Cv>();
        }

        #region תכונות
        public int UserID
        {
            get { return this.userID; }
            set {this.userID = value;}
        }

        public string Email
        {
            get { return this.email; }
        }

        public string UserPassword
        {
            get { return this.userPassword; }
        }

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public string Phone
        {
            get { return this.phone; }
        }

        public string CityName
        {
            get { return this.cityName; }
        }

        public List<Cv> LstCvs
        {
            get { return this.lstCvs; }
        }

        public Cv ChosenCvForJob
        {
            get { return this.chosenCvForJob; }
        }
        #endregion

        /// <summary>
        /// פונקציה ששמה את רשומות קורות החיים של משתמש ספציפי בתוך מערך קורות החיים
        /// </summary>
        public void SetUserCvs()
        {
            DataTable dt = NoarJobDAL.Cvs.GetUserCvs(this.userID);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.lstCvs.Add(new Cv((int)dt.Rows[i]["CvID"], dt.Rows[i]["CvFilePath"].ToString(), (bool)dt.Rows[i]["IsActive"]));
            }
        }

        /// <summary>
        /// פונקציה שמקבלת משתמש במידה שהוא קיים במערכת ושמה את הנתונים שלא בשדות המחלקה
        /// ומחזירה אמת אם המשתמש קיים ושקר אחרת
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SetUser(string email, string password)
        {
            DataTable dt = Users.GetUser(email, password);
            if (dt != null && dt.Rows.Count > 0)
            {
                this.userID = (int)dt.Rows[0]["UserID"];
                this.email = dt.Rows[0]["Email"].ToString();
                this.userPassword = dt.Rows[0]["UserPassword"].ToString();
                this.firstName = dt.Rows[0]["FirstName"].ToString();
                this.lastName = dt.Rows[0]["LastName"].ToString();
                this.phone = dt.Rows[0]["Phone"].ToString();
                this.cityName = dt.Rows[0]["CityName"].ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// פונקציה שיוצרת משתמש חדש במידה שהוא לא קיים כבר במערכת
        /// ומחזירה אמת אם הוא היה כבר קיים במערכת ושקר אחרת
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userPassword"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public bool CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName)
        {
            DataTable dt = Users.GetUser(email, userPassword);
            if (dt == null || dt.Rows.Count == 0)
            {
                int UserID = Users.InsertUser(email, userPassword, firstName, lastName, phone, cityID);
                this.userID = UserID;
                this.email = email;
                this.userPassword = userPassword;
                this.firstName = firstName;
                this.lastName = lastName;
                this.phone = phone;
                this.cityName = cityName;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש הגיש אליהם מועמדות
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Job[] GetApplyForJobs()
        {
            DataTable[] arrDt = NoarJobDAL.Users_Jobs.GetApplyForOrLovedJobs(this.userID, 1);
            Job[] arrJob = JobsBL.GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש אהב
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Job[] GetLovedJobs()
        {
            DataTable[] arrDt = NoarJobDAL.Users_Jobs.GetApplyForOrLovedJobs(this.userID, 2);
            Job[] arrJob = JobsBL.GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// שאילתת עדכון שמעבירה את הסוג שהמשתמש בחר למשרה
        /// שתיים אהבתי את המשרה, 3 - מחקתי את המשרה
        /// </summary>
        public void UpdateUserJobType(int jobID, int userJobType)
        {
            NoarJobDAL.Users_Jobs.UpdateUserJobType(jobID, this.userID, userJobType);
        }

        /// <summary>
        /// שאילתת עדכון שמעבירה את הסוג שהמשתמש בחר למשרה
        /// לשליחת מועמדות
        /// </summary>
        public void UpdateUserJobType(int jobID, int userJobType, DateTime dateApplicated, int cvID)
        {
            Users_Jobs.UpdateUserJobType(jobID, this.userID, userJobType, dateApplicated, cvID);
        }

            /// <summary>
            /// פונקציה ליצירת רשומה חדשה בעת הגשת מועמדות של משתמש למשרה
            /// </summary>
            public void CreateUser_Job(int jobID, int cvID, DateTime dateApplicated)
        {
            Users_Jobs.InsertUser_Job(jobID, this.userID, cvID, dateApplicated);
        }

        /// <summary>
        /// פונקציה ליצירת רשומה חדשה בעת מחיקת משרה/אהבת משרה
        /// </summary>
        public void CreateUser_Job(int jobID, int userJobType)
        {
            Users_Jobs.InsertUser_Job(jobID, this.userID, userJobType);
        }
    }
}
