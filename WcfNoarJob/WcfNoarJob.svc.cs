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
            wUser.LstCvs = user.LstCvs;
            return wUser;
        }
        

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
