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
    public partial class HomePage : Form
    {
        private Employer employer;
        
        public HomePage(Employer employer)
        {
            InitializeComponent();
            this.employer = employer;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            this.GreenPanel.Controls.Add(this.PostingJobPageBtn);
            this.GreenPanel.Controls.Add(this.ManageJobsPageBtn);
        }

        /// <summary>
        /// פונקציה של כפתור שמעביר את המעסיק למסך פרסום משרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostingJobPageBtn_Click(object sender, EventArgs e)
        {
            PostingJobPage postingJobPage;
            postingJobPage = new PostingJobPage(this.employer);
            postingJobPage.Show();
            this.Close();
        }

        /// <summary>
        /// פונקציה של כפתור שמעביר את המעסיק למסך ניהול משרות
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManageJobsPageBtn_Click(object sender, EventArgs e)
        {
            JobManagementPage jobManagementPage;
            jobManagementPage = new JobManagementPage(this.employer);

            jobManagementPage.Show();
            this.Close();
        }
    }
}
