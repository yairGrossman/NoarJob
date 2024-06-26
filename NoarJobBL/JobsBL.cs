﻿using NoarJobDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoarJobBL
{
    public class JobsBL
    {
        /// <summary>
        /// פונקציה שמקבלת תז של משרות ותז של מועמד ומחזירה מערך למשרות
        /// </summary>
        /// <param name="arrJobsID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        private Job[] GetJobsByID(int[] arrJobsID, int userID)
        {
            DataTable[] arrDt = NoarJobDAL.Jobs.GetJobs(arrJobsID, userID);
            Job[] arrJob = GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה שמכניסה את נתוני הטבלה שקיבלתי לתוך שדות המחלקה
        /// ומחזירה מערך של משרות לפי מה שהמשתמש חיפש
        /// </summary>
        /// <param name="jobCategories"></param>
        /// <param name="jobTypes"></param>
        /// <param name="city"></param>
        /// <param name="text"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Job[] GetJobsSearch(int parentCategory, List<int> jobCategories, List<int> jobTypes, int city, string text, int userID)
        {
            DataTable[] arrDt = NoarJobDAL.Jobs.JobsSearch(parentCategory, jobCategories, jobTypes, city, text, userID);
            Job[] arrJob = GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה שמכניסה את נתוני הטבלה שקיבלתי לתוך שדות המחלקה
        /// ומחזירה מערך של משרות המעסיק לפי פעילות המשרות
        /// </summary>
        /// <param name="employerID"></param>
        /// <param name="isActive"></param>
        /// <returns></returns>
        public Job[] GetEmployerJobsByJobActivity(int employerID, bool isActive)
        {
            DataTable[] arrDt = Jobs.GetJobsByEmployerAndJobActivity(employerID, isActive);
            Job[] arrJob = GetJobs(arrDt);
            return arrJob;
        }

        /// <summary>
        /// פונקציה שמחזירה את המשרות שהמשתמשים הדומים לי הגישו הכי הרבה מעומדויות
        /// </summary>
        public Job[] GetTheMostSoughtJobBL(int userID, List<int> childCategoriesLst, List<int> citiesLst, List<int> typesLst)
        {
            DataTable dt = NoarJobDAL.MostSoughtJobs.GetTheMostSoughtJob(childCategoriesLst, citiesLst, typesLst);
            int[] arrJobsID = ConvertDtToArr(dt);
            if(arrJobsID.Length == 0)
                return null;

            Job[] arrJob = GetJobsByID(arrJobsID, userID);
            return arrJob;
        }

        /// <summary>
        /// פונקציה שממירה טבלת נתונים למערך
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private int[] ConvertDtToArr(DataTable dt)
        {
            int[] arr = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                arr[i] = (int)dt.Rows[i][0];
            }
            return arr;
        }

        /// <summary>
        /// פונקציה שמקבלת טבלת נתונים של משרות והופכת אותה למערך של משרות
        /// </summary>
        /// <param name="arrDt"></param>
        /// <returns></returns>
        public static Job[] GetJobs(DataTable[] arrDt)
        {
            Job[] jobsArr = new Job[arrDt[0].Rows.Count];
            int jobID;//מספר המשרה
            string dateApplicated;//התאריך שבו המועמד שלח קורות חיים למשרה
            int userJobType;//סוג הקשר של המועמד למשרה: אחד שליחת מועמדות, 2-אהבת משרה, 3-מחיקת משרה
            string title;//כותרת המשרה
            string description;//תיאור המשרה
            string requirements;//דרישות של המשרה
            string employerName;//שם המעסיק
            int numOfEmployees;//מספר העובדים שיש למעסיק בחברה
            string companyTypeName;//שם הקטגורייה של החברה
            string phone;//מספר טלפון של המשרה
            string email;//האימייל של המשרה
            bool isActive;//המשרה באוויר או לא
            string companyName;//שם החברה
            for (int i = 0; i < jobsArr.Length; i++)
            {
                jobID = (int)arrDt[0].Rows[i]["JobID"];
                if(arrDt[0].Columns.Contains("DateApplicated") && arrDt[0].Rows[i]["DateApplicated"] != DBNull.Value)
                    dateApplicated = ((DateTime)arrDt[0].Rows[i]["DateApplicated"]).ToString("MM/dd/yyyy");
                else
                    dateApplicated = "";

                if (arrDt[0].Columns.Contains("UserJobType") && arrDt[0].Rows[i]["UserJobType"] != DBNull.Value)
                    userJobType = (int)arrDt[0].Rows[i]["UserJobType"];
                else
                    userJobType = 0;

                
                
                title = arrDt[0].Rows[i]["Title"].ToString();
                description = arrDt[0].Rows[i]["Description"].ToString();
                requirements = arrDt[0].Rows[i]["Requirements"].ToString();
                employerName = arrDt[0].Rows[i]["EmployerName"].ToString();
                numOfEmployees = (int)arrDt[0].Rows[i]["NumOfEmployees"];
                companyTypeName = arrDt[0].Rows[i]["CompanyTypeName"].ToString();
                phone = arrDt[0].Rows[i]["Phone"].ToString();
                email = arrDt[0].Rows[i]["Email"].ToString();
                isActive = (bool)arrDt[0].Rows[i]["IsActive"];
                companyName = arrDt[0].Rows[i]["CompanyName"].ToString();
                jobsArr[i] = new Job(jobID,
                                     dateApplicated,
                                     userJobType,
                                     title,
                                     description,
                                     requirements,
                                     employerName,
                                     numOfEmployees,
                                     companyTypeName,
                                     phone,
                                     email,
                                     isActive,
                                     companyName,
                                     arrDt[1],
                                     arrDt[2],
                                     arrDt[3]);
            }
            return jobsArr;
        }
    }
}
