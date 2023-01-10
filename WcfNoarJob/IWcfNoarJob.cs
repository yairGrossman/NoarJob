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
        WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName);

        [OperationContract]
        WUser UserLogin(string email, string password);

        [OperationContract]
        Dictionary<int, string> GetCities(string city);

        [OperationContract]
        WCompanyType[] GetAllCompanyTypes();

        [OperationContract]
        void InsertCv(string cvFilePath, int userID, WUser wUser);

        [OperationContract]
        WCv UpdateCvActivity(WCv wCv);

        [OperationContract]
        WEmployer EmployerLogin(string companyEmail, string employerPassword);

        [OperationContract]
        WEmployer CreateEmployer(string employerName, int numOfEmployees, int companyTypeID, string companyTypeName,
            string companyName, string employerPassword, string companyEmail);

        [OperationContract]
        WJob CreateJob(string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes);

        [OperationContract]
        void UpdateJob(WJob wJob, string title, string description, string requirements, int employerID,
            string phone, string email, List<int> jobCategories, List<int> cities, List<int> jobTypes);
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
