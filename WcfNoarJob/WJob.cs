using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfNoarJob
{
    [DataContract]
    public class WJob
    {
        private int jobID;//מספר המשרה
        private string title;//כותרת המשרה
        private string description;//תיאור המשרה
        private string requirements;//דרישות של המשרה
        private string employerName;//שם המעסיק
        private int numOfEmployees;//מספר העובדים שיש למעסיק בחברה
        private string companyTypeName;//שם הקטגורייה של החברה
        private string phone;//מספר טלפון של המשרה
        private string email;//האימייל של המשרה
        private bool isActive;//המשרה באוויר או לא
        private string companyName;//שם החברה

        private Dictionary<int, string> citiesDictionary;//רשימת הערים שהמשרה נמצאת בה
        private Dictionary<int, string> typesDictionary;//רשימת סוגי המשרות שלמשרה יש 
        private Dictionary<int, string> categoriesDictionary;//רשימת הקטגוריות שלמשרה יש


        public WJob(Job job)
        {
            this.jobID = job.JobID;
            this.title = job.Title;
            this.description = job.Description;
            this.requirements = job.Requirements;
            this.employerName = job.EmployerName;
            this.numOfEmployees = job.NumOfEmployees;
            this.companyTypeName = job.CompanyTypeName;
            this.phone = job.Phone;
            this.email = job.Email;
            this.isActive = job.IsActive;
            this.companyName = job.CompanyName;
        }

        [DataMember]
        public int JobID { get => jobID; set => jobID = value; }
        [DataMember]
        public string Title { get => title; set => title = value; }
        [DataMember]
        public string Description { get => description; set => description = value; }
        [DataMember]
        public string Requirements { get => requirements; set => requirements = value; }
        [DataMember]
        public string EmployerName { get => employerName; set => employerName = value; }
        [DataMember]
        public int NumOfEmployees { get => numOfEmployees; set => numOfEmployees = value; }
        [DataMember]
        public string CompanyTypeName { get => companyTypeName; set => companyTypeName = value; }
        [DataMember]
        public string Phone { get => phone; set => phone = value; }
        [DataMember]
        public string Email { get => email; set => email = value; }
        [DataMember]
        public bool IsActive { get => isActive; set => isActive = value; }
        [DataMember]
        public string CompanyName { get => companyName; set => companyName = value; }
        [DataMember]
        public Dictionary<int, string> CitiesDictionary { get => citiesDictionary; set => citiesDictionary = value; }
        [DataMember]
        public Dictionary<int, string> TypesDictionary { get => typesDictionary; set => typesDictionary = value; }
        [DataMember]
        public Dictionary<int, string> CategoriesDictionary { get => categoriesDictionary; set => categoriesDictionary = value; }
    }
}