using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class User_Job
    {
        private int jobID;//מספר המשרה מטבלת משרות
        private int userID;//מספר המשתמש מטבלת משתמשים
        private DateTime dateApplicated;//תאריך הגשת המועמדות של המשתמש למשרה
        private int userJobType;//אחד - שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה
        private int tabType;//אחד - מועמד לא קוטלג, 2 - מועמד נמצא מתאים למשרה, 3 - מועמד לא נמצא מתאים למשרה ,
                            //4 - מועמד עבר ראיון טלפוני, 5 - מועמד עבר ראיון מקצועי, 6 - מועמד עבר חתימה על החוזה

        private List<string> notesLst;//הערות של המעסיק

        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש הגיש אליהם מועמדות
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Job[] GetApplyForJobs(int userID)
        {
            DataTable[] arrDt = NoarJobDAL.Users_Jobs.GetApplyForOrLovedJobs(userID, 1);
            Job[] arrJob = JobsBL.GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה המחזירה את המשרות שהמשתמש אהב
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Job[] GetLovedJobs(int userID)
        {
            DataTable[] arrDt = NoarJobDAL.Users_Jobs.GetApplyForOrLovedJobs(userID, 2);
            Job[] arrJob = JobsBL.GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה המחזירה את רשימת המועמדים של משרה לפי משרה וגם לפי סוג הקיטלוג
        /// </summary>
        /// <param name="jobID"></param>
        /// <param name="tabType"></param>
        /// <returns></returns>
        public User[] GetUsersByJobAndTabType(int jobID, int tabType)
        {
            DataTable dt = Users_Jobs.GetUsersByJobAndTabType(jobID, tabType);
            User[] arrUsers = new User[dt.Rows.Count];
            this.jobID = jobID;
            for (int i = 0; i < arrUsers.Length; i++)
            {
                this.notesLst.Add(dt.Rows[i]["Notes"].ToString());
                arrUsers[i] = new User(
                    (int)dt.Rows[i]["UserID"],
                    (int)dt.Rows[i]["CvID"],
                    dt.Rows[i]["Email"].ToString(),
                    dt.Rows[i]["FirstName"].ToString(),
                    dt.Rows[i]["LastName"].ToString(),
                    dt.Rows[i]["Phone"].ToString(),
                    dt.Rows[i]["CityName"].ToString(),
                    dt.Rows[i]["CvFilePath"].ToString(),
                    (bool)dt.Rows[i]["IsActive"]
                    );
            }
            return arrUsers;
        }

        /// <summary>
        /// פונקציה לעדכון הערת המעסיק למועמד
        /// </summary>
        /// <param name="jobID">של משרה ID</param>
        /// <param name="userID">של משתמש ID</param>
        /// <param name="notes">הערות של המעסיק</param>
        public void UpdateEmployerNotes(int jobID, int userID, string notes)
        {
            NoarJobDAL.Users_Jobs.UpdateEmployerNotes(jobID,  userID,  notes);
        }

        /// <summary>
        /// ATSפונקצית עדכון להעברת מועמד בין הקיטלוגים השונים במערכת ה
        /// </summary>
        /// <param name="jobID">של משרה ID</param>
        /// <param name="userID">של משתמש ID</param>
        /// <param name="tabType">אחד - מועמד לא קוטלג,
        /// 2 - מועמד נמצא מתאים למשרה,
        /// 3 - מועמד לא נמצא מתאים למשרה,
        /// 4 - מועמד עבר ראיון טלפוני,
        /// 5 - מועמד עבר ראיון מקצועי,
        /// 6 - מועמד עבר חתימה על החוזה</param>
        public void UpdateTabType(int jobID, int userID, int tabType)
        {
            NoarJobDAL.Users_Jobs.UpdateTabType(jobID,  userID,  tabType);
        }

        /// <summary>
        /// פונקצית עדכון שמעבירה את הסוג שהמשתמש בחר למשרה
        /// אחד שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה
        /// </summary>
        /// <param name="jobID"></param>
        /// <param name="userID"></param>
        /// <param name="userJobType"></param>
        public void UpdateUserJobType(int jobID, int userID, int userJobType)
        {
            NoarJobDAL.Users_Jobs.UpdateUserJobType(jobID,  userID,  userJobType);
        }

        /// <summary>
        /// פונקציה ליצירת רשומה חדשה בעת הגשת מועמדות של משתמש למשרה
        /// </summary>
        /// <param name="jobID">של משרה ID</param>
        /// <param name="userID">של משתמש ID</param>
        /// /// <param name="dateApplicated">תאריך הגשת המועמדות של המשתמש למשרה</param>
        public void CreateUser_Job(int jobID, int userID, int cvID, DateTime dateApplicated)
        {
            this.jobID = jobID;
            this.userID = userID;
            this.dateApplicated = dateApplicated;
            Users_Jobs.InsertUser_Job(jobID, userID, cvID, dateApplicated);
        }

        /// <summary>
        /// פונקציה ליצירת רשומה חדשה בעת מחיקת משרה/אהבת משרה
        /// </summary>
        /// <param name="JobID">של משרה ID</param>
        /// <param name="UserID">של משתמש ID</param>
        /// /// <param name="UserJobType">אחד - שליחת מועמדות, 2 - אהבתי את המשרה, 3 - מחקתי את המשרה</param>
        public void CreateUser_Job(int jobID, int userID, int userJobType)
        {
            this.jobID = jobID;
            this.userID = userID;
            this.userJobType = userJobType;
            Users_Jobs.InsertUser_Job(jobID, userID, userJobType);
        }
    }
}
