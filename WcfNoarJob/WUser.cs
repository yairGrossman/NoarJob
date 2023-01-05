using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WUser
    {
        private int userID;//מספר המשתמש
        private string email;//אימייל
        private string firstName;//שם פרטי
        private string lastName;//שם משפחה
        private string phone;//מספר הטלפון של המועמד
        private string cityName;//שם העיר שבה גר המשתמש
        private List<WCv> lstCvs;//מערך קורות החיים של המשתמש
        private WCv chosenCvForJob;//קורות חיים ספציפיים שהמשתמש החליט לשלוח למשרה

        public WUser(User user)
        {
            this.userID = user.UserID;
            this.email = user.Email;
            this.firstName = user.FirstName;
            this.lastName = user.LastName;
            this.phone = user.Phone;
            this.cityName = user.CityName;
        }

        [DataMember]
        public int UserID { get => userID; set => userID = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public string FirstName { get => firstName; set => firstName = value; }
        [DataMember]
        public string LastName { get => lastName; set => lastName = value; }
        [DataMember]
        public string Phone { get => phone; set => phone = value; }
        [DataMember]
        public string CityName { get => cityName; set => cityName = value; }
        [DataMember]
        public List<WCv> LstCvs { get => lstCvs; set => lstCvs = value; }
        [DataMember]
        public WCv ChosenCvForJob { get => chosenCvForJob; set => chosenCvForJob = value; }
    }
}