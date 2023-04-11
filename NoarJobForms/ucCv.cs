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
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace NoarJobUI
{
    public partial class ucCv : UserControl
    {
        private User user;
        private int tabType;
        private int jobID;
        private ATSPage aTSPage;
        public ucCv(User user, int tabType, int jobID, ATSPage aTSPage)
        {
            InitializeComponent();
            this.user = user;
            this.tabType = tabType;
            this.jobID = jobID;
            this.aTSPage = aTSPage;
        }

        private void ucCv_Load(object sender, EventArgs e)
        {
            this.MailLbl.Text += this.user.Email;
            this.FirstNameLbl.Text += this.user.FirstName;
            this.LastNameLbl.Text += this.user.LastName;
            this.PhoneLbl.Text += this.user.Phone;
            this.CityLbl.Text += this.user.City.Value;
            this.DescriptionTxt.Text = this.user.Notes;
        }

        private async void CvBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5063/");
                var response = await client.GetAsync(this.user.ChosenCvForJob.CvFilePath);
                if (response.IsSuccessStatusCode)
                {
                    var fileName = this.user.ChosenCvForJob.FileName + ".docx";
                    var downloadFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                    var filePath = Path.Combine(downloadFolderPath, fileName);
                    using (var fileStream = File.Create(filePath))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }
                    Process.Start(filePath); // Open the file with the default application.
                }
            }
        }

        private void SaveNoteBtn_Click(object sender, EventArgs e)
        {
            string notes = this.DescriptionTxt.Text;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/UpdateEmployerNotes?jobID={this.jobID}&userID={this.user.UserID}&notes={notes}";
                HttpResponseMessage response = client.GetAsync(path).Result;
            }
            MessageBox.Show("!ההערה נשמרה במערכת");
        }

        private void NotSuitableBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/UpdateTabType?jobID={this.jobID}&userID={this.user.UserID}&tabType=3";
                HttpResponseMessage response = client.GetAsync(path).Result;
            }
            this.aTSPage.CvsFLP.Controls.Remove(this);
        }

        private void NextStageBtn_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path;
                if (this.tabType == 2) 
                {
                    path = $"Job/UpdateTabType?jobID={this.jobID}&userID={this.user.UserID}&tabType={this.tabType + 2}";
                    this.aTSPage.CvsFLP.Controls.Remove(this);
                }
                else 
                {
                    if (this.tabType != 6)
                    {
                        path = $"Job/UpdateTabType?jobID={this.jobID}&userID={this.user.UserID}&tabType={this.tabType + 1}";
                        this.aTSPage.CvsFLP.Controls.Remove(this);
                    }
                    else
                        path = $"Job/UpdateTabType?jobID={this.jobID}&userID={this.user.UserID}&tabType={this.tabType}";
                }
                HttpResponseMessage response = client.GetAsync(path).Result;
            }
        }
    }
}
