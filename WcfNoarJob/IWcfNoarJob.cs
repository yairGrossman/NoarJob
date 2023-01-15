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

        [OperationContract]
        bool UpdateJobActivity(WJob wJob);

        [OperationContract]
        WJob[] GetJobsSearch(int parentCategory, List<int> jobCategories, List<int> jobTypes, int city, string text, int userID);

        [OperationContract]
        WJob[] GetEmployerJobsByJobActivity(int employerID, bool isActive);

        [OperationContract]
        WJob[] GetTheMostSoughtJobBL(int userID, List<int> childCategoriesLst, List<int> citiesLst, List<int> typesLst);

        [OperationContract]
        Dictionary<int, string> GetParentJobCategories();

        [OperationContract]
        Dictionary<int, string> GetJobCategoriesByParentID(WJobCategories wJobCategories);

        [OperationContract]
        Dictionary<int, string> GetParentJobCategoriesByText(string text);

        [OperationContract]
        Dictionary<int, string> GetJobCategoriesByParentIDAndByText(WJobCategories wJobCategories, string text);

        [OperationContract]
        Dictionary<int, string> GetAllJobTypes();

        [OperationContract]
        Dictionary<int, string> GetAllSubTypes();

        [OperationContract]
        WSameSearchesOfUsers GetSameParentCategory(int parentCategory, WSameSearchesOfUsers wSSOU);

        [OperationContract]
        WSameSearchesOfUsers GetSameChildCategories(List<int> childCategoriesLst, WSameSearchesOfUsers wSSOU);

        [OperationContract]
        WSameSearchesOfUsers SameChildCategoriesAndCities(List<int> childCategoriesLst, List<int> citiesLst, WSameSearchesOfUsers wSSOU);

        [OperationContract]
        WSameSearchesOfUsers SameChildCategoriesAndCitiesAndTypes(List<int> childCategoriesLst, List<int> citiesLst, List<int> typesLst, WSameSearchesOfUsers wSSOU);

        [OperationContract]
        WSearchAgent ResetWSearchAgent(WSearchAgent wSearchAgent, int userID);

        [OperationContract]
        void InsertSearchAgentValues(WSearchAgent wSearchAgent);

        [OperationContract]
        void UpdateSearchAgentValues(WSearchAgent wSearchAgent);

        [OperationContract]
        void UpdateSearchAgentActivity(int userID, int searchAgentID);

        [OperationContract]
        WJob[] GetJobsBySearchAgent(int searchAgentID, int userID);

        [OperationContract]
        List<WSearchAgent> GetSearchAgentsByUser(int userID);

        [OperationContract]
        WJob[] GetApplyForJobs(int userID);

        [OperationContract]
        WJob[] GetLovedJobs(int userID);

        [OperationContract]
        WUser[] GetUsersByJobAndTabType(int jobID, int tabType);

        [OperationContract]
        void UpdateEmployerNotes(int jobID, int userID, string notes);

        [OperationContract]
        void UpdateTabType(int jobID, int userID, int tabType);

        [OperationContract]
        void UpdateUserJobType(int jobID, int userID, int userJobType);

        [OperationContract]
        void CreateUser_Job(int jobID, int userID, int cvID, DateTime dateApplicated);

        [OperationContract]
        void CreateUser_JobAtDeleteOrLove(int jobID, int userID, int userJobType);
    }
}
