using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    public class WCv
    {
        private int cvID;//של הקורות חיים ID
        private string cvFilePath;//הכתובת של קובץ הקורות חיים
        private bool cvIsActive;//פעילות קורות החיים

        public int CvID { get => cvID; set => cvID = value; }
        public string CvFilePath { get => cvFilePath; set => cvFilePath = value; }
        public bool CvIsActive { get => cvIsActive; set => cvIsActive = value; }

        public WCv(Cv cv)
        {
            this.cvID = cv.CvID;
            this.cvFilePath = cv.CvFilePath;
            this.cvIsActive = cv.CvIsActive;
        }
    }
}
