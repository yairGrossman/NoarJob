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

namespace NoarJobUI
{
    public partial class ATSPage : Form
    {
        private int jobID;
        private User[] users;
        public ATSPage(int jobID)
        {
            InitializeComponent();
            this.jobID = jobID;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/DeleteOldUsersApplyForJob?jobID={this.jobID}";
                HttpResponseMessage response = client.GetAsync(path).Result;
            }
        }

        /// <summary>
        /// פונקציה שמציגה את המועמדים של המעסיק למשרה
        /// לפי הלשונית שהם נמצאים בה
        /// </summary>
        /// <param name="tabType"></param>
        private void GetUsersByTabType(int tabType)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/GetUsersByJobAndTabType?jobID={this.jobID}&tabType={tabType}";
                HttpResponseMessage response = client.GetAsync(path).Result;
                this.users = response.Content.ReadAsAsync<User[]>().Result;
            }

            if (this.users != null)
            {
                ucCv ucCv;
                if(this.users.Length > 1)
                {
                    this.CvsFLP.Size = new Size(this.CvsFLP.Width + 17, this.CvsFLP.Height);
                }
                for (int i = 0; i < this.users.Length; i++)
                {
                    ucCv = new ucCv(this.users[i], tabType, this.jobID, this);
                    this.CvsFLP.Controls.Add(ucCv);
                }
            }
            else
            {
                MessageBox.Show("לא נמצאו אף מועמדים");
            }
        }

        private void ATSPage_Load(object sender, EventArgs e)
        {
            this.TapTypePanel.Location = new Point(this.Width / 2 - this.TapTypePanel.Width / 2, this.TapTypePanel.Location.Y);
            this.CvsFLP.Location = new Point((this.TapTypePanel.Location.X + this.TapTypePanel.Width / 2) - 254, 200);
            GetUsersByTabType(1);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שלא קוטלגו
        /// ומביא את כל המועמדים שלא קוטלגו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotCatalogedBtn_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(1);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שנמצאו מתאימים למשרה
        /// ומביא את כל המועמדים שנמצאו מתאימים למשרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoundSuitableBtn_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(2);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שנמצאו לא מתאימים למשרה
        /// ומביא את כל המועמדים שנמצאו  לרמתאימים למשרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotFoundSuitableBtn_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(3);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שעברו רעיון טלפוני למשרה
        /// ומביא את כל המועמדים שעברו רעיון טלפוני למשרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TelephoneInterviewBאמ_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(4);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שעברו רעיון מקצועי למשרה
        /// ומביא את כל המועמדים שעברו רעיון מקצועי למשרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProfessionalInterviewBtn_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(5);
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר לוחצים על הכפתור של המעומדים שעברו חתימת חוזה למשרה
        /// ומביא את כל המועמדים שעברו חתימת חוזה למשרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmploymentContractBtn_Click(object sender, EventArgs e)
        {
            this.CvsFLP.Controls.Clear();
            GetUsersByTabType(6);
        }
    }
}
