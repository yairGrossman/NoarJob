using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoarJobBL;

namespace NoarJobUI
{
    public partial class PostingJobPage : Form
    {
        private Job job;
        private Employer employer;
        private ucChoices ucChoicesJob;
        private MainPage mainPage;

        /// <summary>
        /// פעולה בונה שנועדה לפרסום משרה
        /// </summary>
        /// <param name="employer"></param>
        /// <param name="mainPage"></param>
        public PostingJobPage(Employer employer, MainPage mainPage)
        {
            InitializeComponent();
            this.employer = employer;
            this.job = new Job();
            CreateUcChoicesJob(false);
            this.mainPage = mainPage;
        }

        /// <summary>
        /// פעולה בונה שנועדה לעדכון משרה
        /// </summary>
        /// <param name="user"></param>
        /// <param name="job"></param>
        /// <param name="mainPage"></param>
        public PostingJobPage(Employer employer, Job job, MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
            this.employer = employer;

            this.job = job;
            this.UpdateJobBtn.Location = new Point(this.PostJobBtn.Location.X, this.PostJobBtn.Location.Y);
            this.UpdateJobBtn.Visible = true;
            this.PostJobBtn.Visible = false;
            this.JobTitleTxt.Text = job.Title;
            this.DescriptionTxt.Text = job.Description;
            this.RequirementsTxt.Text = job.Requirements;
            this.PhoneTxt.Text = job.Phone;
            this.EmailTxt.Text = job.Email;
            CreateUcChoicesJob(true);
        }

        /// <summary>
        ///  של בחירות UserControl פונקציה שיוצרת
        /// </summary>
        /// /// <param name="isEditJob">האם המעסיק במסך עדכון משרה</param>
        private void CreateUcChoicesJob(bool isEditJob)
        {
            if(isEditJob)
                this.ucChoicesJob = new ucChoices(this, this.job);
            else
                this.ucChoicesJob = new ucChoices(this);

            this.ucChoicesJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ucChoicesJob.Location = new System.Drawing.Point(259, -25);
            this.ucChoicesJob.Name = "ucChoicesJob";
            this.ucChoicesJob.Size = new System.Drawing.Size(836, 734);
            this.ucChoicesJob.TabIndex = 4;

            this.Controls.Add(this.ucChoicesJob);
        }

        private void PostingJobPage_Load(object sender, EventArgs e)
        {

            this.PostPanel.BringToFront();
            this.PostPanel.Location = new Point(this.Width / 2 - this.PostPanel.Width / 2, this.PostPanel.Location.Y);
            this.ucChoicesJob.Location = new Point(this.Width / 2 - this.ucChoicesJob.Width / 2, this.ucChoicesJob.Location.Y);
            this.DisconnectionBtn.Location = new Point(this.ucChoicesJob.Location.X + this.ucChoicesJob.Width + 40, this.ucChoicesJob.Location.Y + this.DisconnectionBtn.Height);

            this.JobTitleTxt.GotFocus += new EventHandler(RemoveJobTitleTxt);
            this.JobTitleTxt.LostFocus += new EventHandler(AddJobTitleTxt);

            this.DescriptionTxt.GotFocus += new EventHandler(RemoveDescriptionTxt); 
            this.DescriptionTxt.LostFocus += new EventHandler(AddDescriptionTxt); 

            this.RequirementsTxt.GotFocus += new EventHandler(RemoveRequirementsTxt);  
            this.RequirementsTxt.LostFocus += new EventHandler(AddRequirementsTxt);  

            this.PhoneTxt.GotFocus += new EventHandler(RemovePhoneTxt);
            this.PhoneTxt.LostFocus += new EventHandler(AddPhoneTxt);

            this.EmailTxt.GotFocus += new EventHandler(RemoveEmailTxt);
            this.EmailTxt.LostFocus += new EventHandler(AddEmailTxt);
        }

        /// <summary>
        /// כפתור שיוצר משרה חדשה למעסיק במערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostJobBtn_Click(object sender, EventArgs e)
        {
            if (this.JobTitleTxt.Text != "למשל: מוכר בגדים בקניון עיר ימים" 
                && this.DescriptionTxt.Text != "כאן מתארים את התפקיד, מה כולל התפקיד, ותחומי האחריות שעל התפקיד" 
                && this.RequirementsTxt.Text != "כאן צריך לרשום אילו דרישות לתפקיד יש,\r\nמה צריך כדי להתאים לתפקיד" 
                && this.PhoneTxt.Text != "למשל: 055-5555555"
                && this.EmailTxt.Text != "למשל: blabla@gmail.com" && this.ucChoicesJob.JC.ChosenJobCategoryLst.Count > 0 
                && this.ucChoicesJob.City.LstCities.Count > 0 && this.ucChoicesJob.JT.ChosenJobTypeLst.Count > 0)
            {

                this.job.CreateJob(this.JobTitleTxt.Text, this.DescriptionTxt.Text, this.RequirementsTxt.Text, this.employer.EmployerID, 
                    this.PhoneTxt.Text, this.EmailTxt.Text, this.ucChoicesJob.JC.ChosenJobCategoryLst, this.ucChoicesJob.City.LstCities, 
                    this.ucChoicesJob.JT.ChosenJobTypeLst);

                MessageBox.Show("המשרה נרשמה במערכת!");
                JobManagementPage jobManagementPage;
                jobManagementPage = new JobManagementPage(this.employer, this.mainPage);

                jobManagementPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("לא מילאת את כל הפרטים");
            }
        }

        /// <summary>
        /// כפתור שמעדכן משרה של מעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobBtn_Click(object sender, EventArgs e)
        {
            if (this.JobTitleTxt.Text != "למשל: מוכר בגדים בקניון עיר ימים"
                && this.DescriptionTxt.Text != "כאן מתארים את התפקיד, מה כולל התפקיד, ותחומי האחריות שעל התפקיד"
                && this.RequirementsTxt.Text != "כאן צריך לרשום אילו דרישות לתפקיד יש,\r\nמה צריך כדי להתאים לתפקיד"
                && this.PhoneTxt.Text != "למשל: 055-5555555"
                && this.EmailTxt.Text != "למשל: blabla@gmail.com" && this.ucChoicesJob.JC.ChosenJobCategoryLst.Count > 0
                && this.ucChoicesJob.City.LstCities.Count > 0 && this.ucChoicesJob.JT.ChosenJobTypeLst.Count > 0)
            {

                this.job.UpdateJob(this.JobTitleTxt.Text, this.DescriptionTxt.Text, this.RequirementsTxt.Text, this.employer.EmployerID,
                    this.PhoneTxt.Text, this.EmailTxt.Text, this.ucChoicesJob.JC.ChosenJobCategoryLst, this.ucChoicesJob.City.LstCities,
                    this.ucChoicesJob.JT.ChosenJobTypeLst);

                MessageBox.Show("המשרה עודכנה במערכת!");

                JobManagementPage jobManagementPage;
                jobManagementPage = new JobManagementPage(this.employer, this.mainPage);

                jobManagementPage.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("לא מילאת את כל הפרטים");
            }
        }

        private void AddJobTitleTxt(object sender, EventArgs e)
        {
            if (this.JobTitleTxt.Text == "")
            {
                this.JobTitleTxt.Text = "למשל: מוכר בגדים בקניון עיר ימים";
            }
        }

        private void RemoveJobTitleTxt(object sender, EventArgs e)
        {
            if (this.JobTitleTxt.Text == "למשל: מוכר בגדים בקניון עיר ימים")
            {
                this.JobTitleTxt.Text = "";
            }
        }

        private void AddDescriptionTxt(object sender, EventArgs e)
        {
            if (this.DescriptionTxt.Text == "")
            {
                this.DescriptionTxt.Text = "כאן מתארים את התפקיד, מה כולל התפקיד, ותחומי האחריות שעל התפקיד";
            }
        }

        private void RemoveDescriptionTxt(object sender, EventArgs e)
        {
            if (this.DescriptionTxt.Text == "כאן מתארים את התפקיד, מה כולל התפקיד, ותחומי האחריות שעל התפקיד")
            {
                this.DescriptionTxt.Text = "";
            }
        }

        private void AddRequirementsTxt(object sender, EventArgs e)
        {
            if (this.RequirementsTxt.Text == "")
            {
                this.RequirementsTxt.Text = "כאן צריך לרשום אילו דרישות לתפקיד יש,\r\nמה צריך כדי להתאים לתפקיד";
            }
        }

        private void RemoveRequirementsTxt(object sender, EventArgs e)
        {
            if (this.RequirementsTxt.Text == "כאן צריך לרשום אילו דרישות לתפקיד יש,\r\nמה צריך כדי להתאים לתפקיד")
            {
                this.RequirementsTxt.Text = "";
            }
        }

        private void AddPhoneTxt(object sender, EventArgs e)
        {
            if (this.PhoneTxt.Text == "")
            {
                this.PhoneTxt.Text = "למשל: 055-5555555";
            }
        }

        private void RemovePhoneTxt(object sender, EventArgs e)
        {
            if (this.PhoneTxt.Text == "למשל: 055-5555555")
            {
                this.PhoneTxt.Text = "";
            }
        }

        private void AddEmailTxt(object sender, EventArgs e)
        {
            if (this.EmailTxt.Text == "")
            {
                this.EmailTxt.Text = "למשל: blabla@gmail.com";
            }
        }

        private void RemoveEmailTxt(object sender, EventArgs e)
        {
            if (this.EmailTxt.Text == "למשל: blabla@gmail.com")
            {
                this.EmailTxt.Text = "";
            }
        }

        private void DisconnectionBtn_Click(object sender, EventArgs e)
        {
            this.mainPage.Show();
            this.Close();
        }
    }
}
