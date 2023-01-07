using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfNoarJob
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IWcfNoarJob
    {
        public WUser CreateUser(string email, string userPassword, string firstName, string lastName, string phone, int cityID, string cityName)
        {
            User user = new User();
            bool succeed = user.CreateUser(email, userPassword, firstName, lastName, phone, cityID, cityName);
            if (succeed)
            {
                WUser wUser = new WUser(user);
                return wUser;
            }
            return null;
        }

        public WUser UserLogin(string email, string password)
        {
            User user = new User();
            bool succeed = user.SetUser(email, password);
            if (succeed)
            {
                WUser wUser = new WUser(user);
                return wUser;
            }
            return null;
        }
        
        public WUser SetUserCvs(WUser wUser)
        {
            User user = new User();
            user.UserID = wUser.UserID;
            user.SetUserCvs();
            foreach (Cv cv in user.LstCvs)
            {
                WCv Wcv = new WCv(cv);
                wUser.LstCvs.Add(Wcv);
            }
            return wUser;
        }
        
        public Dictionary<int, string> GetCities(string city)
        {
            CitiesBL citiesBL = new CitiesBL();
            Dictionary<int, string> citiesDictionary = citiesBL.GetCities(city);
            return citiesDictionary;
        }
        
        public WCompanyType[] GetAllCompanyTypes()
        {
            CompanyType companyType = new CompanyType();
            CompanyType[] companyTypeArr = companyType.GetAllCompanyTypes();
            WCompanyType[] wcompanyTypeArr = new WCompanyType[companyTypeArr.Length];
            for (int i = 0; i < wcompanyTypeArr.Length; i++)
            {
                wcompanyTypeArr[i] = new WCompanyType(companyTypeArr[i]);
            }
            return wcompanyTypeArr;
        }

        public void InsertCv(string cvFilePath, int userID, WUser wUser)
        {
            Cv cv = new Cv();
            cv.InsertCv(cvFilePath, userID);
            WCv wCv = new WCv(cv);
            wUser.LstCvs.Add(wCv);
        }


        public WCv UpdateCvActivity(WCv wCv)
        {
            Cv cv = new Cv();
            cv.CvID = wCv.CvID;
            cv.UpdateCvActivity();
            wCv.CvIsActive = false;
            return wCv;
        }
    }
}
