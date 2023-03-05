using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class Cv
    {
        private int cvID;//של הקורות חיים ID
        private string cvFilePath;//הכתובת של קובץ הקורות חיים
        private bool cvIsActive;//פעילות קורות החיים

        

        public string CvFilePath
        {
            get { return cvFilePath; }
        }

        public bool CvIsActive
        {
            get { return cvIsActive; }
        }

        public int CvID { get {return cvID; } set { cvID = value; } }

        public Cv(int cvID, string cvFilePath, bool isActive)
        {
            this.cvFilePath = cvFilePath;
            this.cvIsActive = isActive;
            this.CvID = cvID;
        }

        public Cv()
        {

        }

        /// <summary>
        /// פונקציה להוספה של רשומת קורות חיים חדשים למשתמש
        /// </summary>
        /// <param name="cvFilePath">המיקום של קובץ קורות החיים</param>
        /// <param name="userID">של משתמש ID</param>
        public void InsertCv(string cvFilePath, int userID)
        {
            this.CvID = NoarJobDAL.Cvs.InsertUserCv(cvFilePath, userID);
            this.cvFilePath = cvFilePath;
            this.cvIsActive = true;
        }

        /// <summary>
        /// פונקציה לעדכון רשומת קורות חיים ללא פעיל
        /// </summary>
        public void UpdateCvActivity()
        {
            NoarJobDAL.Cvs.UpdateCvActivity(this.CvID, false);
            this.cvIsActive = false;
        }
    }
}
