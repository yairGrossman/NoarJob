using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoarJobUI
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.Width / 2 - this.panel1.Width / 2, 200);

        }

        /// <summary>
        /// כפתור שמוביל אותך למסך הרשמות/התחברות למערכת בתור מועמד
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CandidateBtn_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage(this);
            loginPage.Show();
            this.Hide();
        }

        /// <summary>
        /// כפתור שמוביל אותך למסך הרשמות/התחברות למערכת בתור מעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployerBtn_Click(object sender, EventArgs e)
        {
            EmployerLoginPage loginPage = new EmployerLoginPage(false, this);
            loginPage.Show();
            this.Hide();
        }

        /// <summary>
        /// כפתור שמוביל אותך למסך חיפוש משרות ללא משתמש
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnonymousBtn_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage(this);
            searchPage.Show();
            this.Hide();
        }

    }
}
