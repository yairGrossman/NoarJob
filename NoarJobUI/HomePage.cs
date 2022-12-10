using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoarJobUI.ServiceReference1;

namespace NoarJobUI
{
    public partial class HomePage : Form
    {
        private WUser user;
        //private Employer employer;
        private MainPage mainPage;
        
        public HomePage(object user, MainPage mainPage)
        {
            InitializeComponent();
            /*
            if (user is Employer)
            {
                this.employer = (Employer)user;
                this.PostingJobPageBtn.Visible = true;
                this.ManageJobsPageBtn.Visible = true;
                this.SearchPageBtn.Visible = false;
                this.HistoryPageBtn.Visible = false;
                this.AutoSearchPageBtn.Visible = false;
            }
            else
            */
            this.user = (WUser)user;

            this.mainPage = mainPage;
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            this.GreenPanel.Controls.Add(this.PostingJobPageBtn);
            this.GreenPanel.Controls.Add(this.ManageJobsPageBtn);
            this.PostingJobPageBtn.Location = new Point(this.SearchPageBtn.Location.X, this.SearchPageBtn.Location.Y);
            this.ManageJobsPageBtn.Location = new Point(this.SearchPageBtn.Location.X, this.HistoryPageBtn.Location.Y);
        }

        
        private void SearchPageBtn_Click(object sender, EventArgs e)
        {
            //SearchPage searchPage = new SearchPage(this.mainPage, this.user);
            //searchPage.Show();
            this.Close();
        }

        private void PostingJobPageBtn_Click(object sender, EventArgs e)
        {
            PostingJobPage postingJobPage;
            //postingJobPage = new PostingJobPage(this.employer, this.mainPage);
            //postingJobPage.Show();
            this.Close();
        }

        private void ManageJobsPageBtn_Click(object sender, EventArgs e)
        {
            JobManagementPage jobManagementPage;
            //jobManagementPage = new JobManagementPage(this.employer, this.mainPage);

            //jobManagementPage.Show();
            this.Close();
        }

        public void DisconnectionBtn_Click(object sender, EventArgs e)
        {
            this.mainPage.Show();
            this.Close();
        }
        
    }
}
