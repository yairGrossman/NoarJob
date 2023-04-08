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
        private string fileName;//שם קובץ קורות החיים



        public string CvFilePath
        {
            get { return cvFilePath; }
        }

        public bool CvIsActive
        {
            get { return cvIsActive; }
        }

        public int CvID { get {return cvID; } set { cvID = value; } }

        public string FileName
        {
            get { return this.fileName; }
        }

        public Cv(int cvID, string cvFilePath, bool isActive, string fileName)
        {
            this.cvFilePath = cvFilePath;
            this.cvIsActive = isActive;
            this.CvID = cvID;
            this.fileName = fileName;
        }

        public Cv()
        {

        }

        /// <summary>
        /// פונקציה להוספה של רשומת קורות חיים חדשים למשתמש
        /// </summary>
        /// <param name="cvFilePath">המיקום של קובץ קורות החיים</param>
        /// <param name="userID">של משתמש ID</param>
        public void InsertCv(string cvFilePath, int userID, string fileName)
        {
            this.CvID = NoarJobDAL.Cvs.InsertUserCv(cvFilePath, userID, fileName);
            this.cvFilePath = cvFilePath;
            this.cvIsActive = true;
            this.fileName = fileName;
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
