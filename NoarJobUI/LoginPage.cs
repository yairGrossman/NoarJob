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
    public partial class LoginPage : Form
    {
        private WUser user;// עצם מטיפוס משתמש
        private MainPage mainPage;

        public LoginPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            this.SignUpPanel.Location = new Point(this.Width / 2 - this.SignUpPanel.Width / 2, 200);
            this.SignUpPanel.Controls.Add(this.LoginBtn);
            this.SignUpPanel.Controls.Add(this.SignUpBtn);
            this.LoginBtn.Location = new Point(this.AccountBtn.Location.X, this.AccountBtn.Location.Y);
            this.SignUpBtn.Location = new Point(this.SigninBtn.Location.X, this.SigninBtn.Location.Y);
        }

        /// <summary>
        /// כפתור שגורם ליצירת משתמש חדש
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountBtn_Click(object sender, EventArgs e)
        {
            if (this.FirstNameTxt.Text != "" && this.LastNameTxt.Text != "" && this.EmailTxt.Text != "" && this.PasswordTxt.Text != "")
            {
                /*
                bool succeeded = this.user.CreateUser(this.EmailTxt.Text, this.PasswordTxt.Text, this.FirstNameTxt.Text, this.LastNameTxt.Text);
                if (succeeded)
                {
                    HomePage homePage = new HomePage(this.user, this.mainPage);
                    homePage.Show();
                    this.Close();
                }
                */
            }
            else
                MessageBox.Show("לא מילאת את כל הפרטים");
        }

        /// <summary>
        /// כפתור שמחבר אותך למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            HomePage homePage;
            WcfNoarJobClient wcfNoarJobClient = new WcfNoarJobClient();
            this.user = wcfNoarJobClient.UserLogin(this.EmailTxt.Text,this.PasswordTxt.Text);
            wcfNoarJobClient.Close();
            //homePage = new HomePage(this.user, this.mainPage);
            if (this.user != null)
            { 
                //homePage.Show();
               // this.Close();
            }
            else
                MessageBox.Show("משתמש לא קיים");
        }

        /// <summary>
        /// כפתור שגורם להופעת כרטיס התחברות למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SigninBtn_Click(object sender, EventArgs e)
        {
            this.FirstNameLbl.Visible = false;
            this.FirstNameTxt.Visible = false;
            this.LastNameLbl.Visible = false;
            this.LastNameTxt.Visible = false;
            this.EmailLbl.Location = new Point(351, 161);
            this.EmailTxt.Location = new Point(52, 167);
            this.PasswordLbl.Location = new Point(343, 210);
            this.PasswordTxt.Location = new Point(52, 216);
            this.SignUpLbl.Text = "Sign in";
            this.AccountBtn.Visible = false;
            this.SigninBtn.Visible = false;
            this.LoginBtn.Visible = true;
            this.AccountLbl.Text = "צריך חשבון?";
            this.SignUpBtn.Visible = true;
        }

        /// <summary>
        /// כפתור שגורם להופעת כרטיס הרשמות למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            this.EmailLbl.Location = new Point(351, 263);
            this.EmailTxt.Location = new Point(89, 269);
            this.PasswordLbl.Location = new Point(343, 312);
            this.PasswordTxt.Location = new Point(81, 318);
            this.FirstNameLbl.Visible = true;
            this.FirstNameTxt.Visible = true;
            this.LastNameLbl.Visible = true;
            this.LastNameTxt.Visible = true;
            this.SignUpLbl.Text = "Sign Up";
            this.AccountBtn.Visible = true;


            this.SigninBtn.Visible = true;
            this.LoginBtn.Visible = false;
            this.AccountLbl.Text = "כבר יש לך חשבון?";
            this.SignUpBtn.Visible = false;
        }
    }
}
