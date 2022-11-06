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
    public partial class JobManagementPage : Form
    {
        private ucJob UserControlJob;
        private JobsBL jobs;
        private Employer employer;
        private Job[] arrJobs;
        private MainPage mainPage;
        public JobManagementPage(Employer employer, MainPage mainPage)
        {
            InitializeComponent();
            this.employer = employer;
            this.jobs = new JobsBL();
            this.arrJobs = this.jobs.GetEmployerJobsByJobActivity(this.employer.EmployerID, true);
            this.mainPage = mainPage;
        }

        /// <summary>
        ///  של משרות UserControl פונקציה שיוצרת
        /// </summary>
        private void CreateUcJob(bool isJobActive)
        {
            this.UserControlJob = new ucJob(this.arrJobs, this, isJobActive, this.employer, this.mainPage);
            
            this.UserControlJob.Name = "UserControlJob";
            this.UserControlJob.Location = new Point(this.Width / 2 - this.UserControlJob.Width / 2, 177);
            this.Controls.Add(this.UserControlJob);
        }

        private void JobManagementPage_Load(object sender, EventArgs e)
        {
            CreateUcJob(true);
            this.ActiveJobPanel.Location = new Point(this.ActiveJobPanel.Location.X + (this.UserControlJob.Location.X - 181), this.ActiveJobPanel.Location.Y);
            this.ProjectTitleLbl.Location = new Point(this.ProjectTitleLbl.Location.X + (this.UserControlJob.Location.X - 181), this.ProjectTitleLbl.Location.Y);
            this.DisconnectionBtn.Location = new Point(this.UserControlJob.Location.X + this.UserControlJob.Width + 10, (this.ProjectTitleLbl.Location.Y + this.DisconnectionBtn.Height) / 2);
            this.JobsInAirBtn.Enabled = false;
        }

        /// <summary>
        /// כפתור משראה את המשרות שבאוויר של המעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void JobsInAirBtn_Click(object sender, EventArgs e)
        {
            this.JobsInAirBtn.Enabled = false;
            this.OldJobsBtn.Enabled = true;
            this.Controls.Remove(this.UserControlJob);
            this.arrJobs = this.jobs.GetEmployerJobsByJobActivity(this.employer.EmployerID, true);
            CreateUcJob(true);
        }

        /// <summary>
        /// כפתור משראה את המשרות הישנות של המעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OldJobsBtn_Click(object sender, EventArgs e)
        {
            this.JobsInAirBtn.Enabled = true;
            this.OldJobsBtn.Enabled = false;
            this.Controls.Remove(this.UserControlJob);
            this.arrJobs = this.jobs.GetEmployerJobsByJobActivity(this.employer.EmployerID, false);
            CreateUcJob(false);
        }

        private void DisconnectionBtn_Click(object sender, EventArgs e)
        {
            this.mainPage.Show();
            this.Close();
        }
    }
}
