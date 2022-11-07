using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoarJobDAL;

namespace NoarJobBL
{
    public class User
    {
        protected int userID;//מספר המשתמש
        protected string email;//אימייל
        private string userPassword;//סיסמא
        protected string firstName;//שם פרטי
        protected string lastName;//שם משפחה
        private string phone;//מספר הטלפון של המועמד
        private string cityName;//שם העיר שבה גר המשתמש
        private Cv[] arrCvs;//מערך קורות החיים של המשתמש
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
            this.chosenCvForJob = new Cv(cvID, cvFilePath, isActive);
        }

        public User()
        {

        }

        public int UserID
        {
            get { return this.userID; }
        }

        public string Email
        {
            get { return this.email; }
        }

        public string UserPassword
        {
            get { return this.userPassword; }
        }

        /// <summary>
        /// פונקציה ששמה את רשומות קורות החיים של משתמש ספציפי בתוך מערך קורות החיים
        /// </summary>
        public void SetUserCvs()
        {
            DataTable dt = NoarJobDAL.Cvs.GetUserCvs(this.userID);
            this.arrCvs = new Cv[dt.Rows.Count];

            for (int i = 0; i < arrCvs.Length; i++)
            {
                this.arrCvs[i] = new Cv((int)dt.Rows[i]["CvID"], dt.Rows[i]["CvFilePath"].ToString(), (bool)dt.Rows[i]["IsActive"]);
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
    }
}
