using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobDAL
{
    public class JobTypes
    {
        /// <summary>
        /// שאילתה המחזירה את כל היקפי המשרות
        /// </summary>
        public static DataTable GetAllJobTypes()
        {
            string sql = @"SELECT JobTypes.JobTypeID, 
                                  JobTypes.JobTypeName, 
                                  JobTypes.SubTypeID
                           FROM   JobTypes
                           WHERE  JobTypes.SubTypeID=1;";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }

        /// <summary>
        /// שאילתה המחזירה את כל סוגי המשרות
        /// </summary>
        public static DataTable GetAllSubTypes()
        {
            string sql = @"SELECT JobTypes.JobTypeID, 
                                  JobTypes.JobTypeName, 
                                  JobTypes.SubTypeID
                           FROM   JobTypes
                           WHERE  JobTypes.SubTypeID=2;";

            DataTable dt = DAL.DBHelper.GetDataTable(sql);
            return dt;
        }
    }
}
