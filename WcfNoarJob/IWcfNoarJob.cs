using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NoarJobBL;

namespace WcfNoarJob
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWcfNoarJob
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName);
        [OperationContract]
        WUser UserLogin(string email, string password);
        //[OperationContract]
       // WUser SetUserCvs(WUser wUser);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class WUser
    {
        private int userID;//מספר המשתמש
        private string email;//אימייל
        private string firstName;//שם פרטי
        private string lastName;//שם משפחה
        private string phone;//מספר הטלפון של המועמד
        private string cityName;//שם העיר שבה גר המשתמש
        private List<Cv> lstCvs;//מערך קורות החיים של המשתמש
        private Cv chosenCvForJob;//קורות חיים ספציפיים שהמשתמש החליט לשלוח למשרה

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
        public List<Cv> LstCvs { get => lstCvs; set => lstCvs = value; }
        [DataMember]
        public Cv ChosenCvForJob { get => chosenCvForJob; set => chosenCvForJob = value; }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
