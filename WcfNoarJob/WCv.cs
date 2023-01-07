using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WCv
    {
        private int cvID;//של הקורות חיים ID
        private string cvFilePath;//הכתובת של קובץ הקורות חיים
        private bool cvIsActive;//פעילות קורות החיים

        public WCv(Cv cv)
        {
            this.cvID = cv.CvID;
            this.cvFilePath = cv.CvFilePath;
            this.cvIsActive = cv.CvIsActive;
        }

        [DataMember]
        public int CvID { get => cvID; set => cvID = value; }
        [DataMember]
        public string CvFilePath { get => cvFilePath; set => cvFilePath = value; }
        [DataMember]
        public bool CvIsActive { get => cvIsActive; set => cvIsActive = value; }
    }
}
