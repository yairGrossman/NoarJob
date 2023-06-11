using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoarJobBL;
using System.Configuration;
using System.Text.RegularExpressions;

namespace NoarJobUI
{
    public partial class EmployerLoginPage : Form
    {
        private bool loginAccount;//משתנה שמטרתו לבדוק האם המשתמש בחר בהתחברות למערכת או יצירת חשבון
        private KeyValuePair<int,string> chosenCompanyType;//הקטגוריית החברה שבחר המשתמש
        private bool userChoose;//משתנה שמטרתו לבדוק האם המשתמש בחר קטגוריית חברה
        private Point companyEmailLblLoc;
        private Point companyEmailTxtLoc;
        private Point employerPasswordLblLoc;
        private Point employerPasswordTxtLoc;

        public EmployerLoginPage(bool loginAccount)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
            
        }

        /// <summary>
        /// פונקציה שמזיזה כפתורים ומשנה את נראותם
        /// </summary>
        /// <param name="flag">אם שקר אז יוצג מסך ההרשמות אם אמת יוצג מסך ההתחברות</param>
        private void LoginOrSignUpAccount(bool flag)
        {
            this.AccountBtn.Visible = flag;
            this.EmployerNameLbl.Visible = flag;
            this.EmployerNameTxt.Visible = flag;
            this.NumOfEmployeesLbl.Visible = flag;
            this.NumOfEmployeesTxt.Visible = flag;
            this.CompanyNameLbl.Visible = flag;
            this.CompanyTypeLbl.Visible = flag;
            this.CompanyTypeDropDown.Visible = flag;
            this.CompanyNameLbl.Visible = flag;
            this.CompanyNameTxt.Visible = flag;
            this.LoginBtn.Visible = !flag;
            this.SigninBtn.Visible = flag;
            this.SignUpBtn.Visible = !flag;
            if (!flag)
            {
                this.CompanyEmailLbl.Location = new Point(this.CompanyEmailLbl.Location.X, this.EmployerNameLbl.Location.Y);
                this.CompanyEmailTxt.Location = new Point(this.CompanyEmailTxt.Location.X, this.EmployerNameTxt.Location.Y);
                this.EmployerPasswordLbl.Location = new Point(this.EmployerPasswordLbl.Location.X, this.NumOfEmployeesLbl.Location.Y);
                this.EmployerPasswordTxt.Location = new Point(this.EmployerPasswordTxt.Location.X, this.NumOfEmployeesTxt.Location.Y);
                
            }
            else
            {
                this.CompanyEmailLbl.Location = this.companyEmailLblLoc;
                this.CompanyEmailTxt.Location = this.companyEmailTxtLoc;
                this.EmployerPasswordLbl.Location = this.employerPasswordLblLoc;
                this.EmployerPasswordTxt.Location = this.employerPasswordTxtLoc;
                
            }
        }

        private void EmployerLogin_Load(object sender, EventArgs e)
        {
            this.SignUpPanel.Location = new Point(this.Width / 2 - this.SignUpPanel.Width / 2, 100);
            this.SignUpPanel.Controls.Add(this.LoginBtn);
            this.SignUpPanel.Controls.Add(this.SignUpBtn);
            this.LoginBtn.Location = new Point(this.AccountBtn.Location.X, this.AccountBtn.Location.Y);
            this.SignUpBtn.Location = new Point(this.SigninBtn.Location.X, this.SigninBtn.Location.Y);
            this.companyEmailLblLoc = this.CompanyEmailLbl.Location;
            this.companyEmailTxtLoc = this.CompanyEmailTxt.Location;
            this.employerPasswordLblLoc = this.EmployerPasswordLbl.Location;
            this.employerPasswordTxtLoc = this.EmployerPasswordTxt.Location;


            if (this.loginAccount)
            {
                LoginOrSignUpAccount(false);
                this.AccountLbl.Visible = false;
                this.SignUpBtn.Visible = false;
            }
            else
            {
                this.CompanyTypeDropDown.DisplayMember = "Value";
                this.CompanyTypeDropDown.ValueMember = "Key";

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    string path = "CompanyType/GetAllCompanyTypes";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    this.CompanyTypeDropDown.DataSource = response.Content.ReadAsAsync<Dictionary<int,string>>().Result.ToList();
                }
            } 
        }

        /// <summary>
        /// כפתור ליצירת חשבון מעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountBtn_Click(object sender, EventArgs e)
        {
            Regex emailRegex = new Regex(@"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b");

            if (this.EmployerNameTxt.Text != "" && this.NumOfEmployeesTxt.Text != "" && this.userChoose
                && this.CompanyNameTxt.Text != "" && this.CompanyEmailTxt.Text != "" && this.EmployerPasswordTxt.Text != ""
                && emailRegex.IsMatch(this.CompanyEmailTxt.Text))
            {
                Employer employer;
                using (HttpClient client = new HttpClient())
                {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                        string path = $"Employer/CreateEmployer?employerName={this.EmployerNameTxt.Text}"
                                        + $"&numOfEmployees={this.NumOfEmployeesTxt.Text}"
                                        + $"&companyTypeID={this.chosenCompanyType.Key}"
                                        + $"&companyTypeName={this.chosenCompanyType.Value}"
                                        + $"&companyName={this.CompanyNameTxt.Text}"
                                        + $"&employerPassword={this.EmployerPasswordTxt.Text}"
                                        + $"&companyEmail={this.CompanyEmailTxt.Text}";
                        HttpResponseMessage response = client.GetAsync(path).Result;
                        employer = response.Content.ReadAsAsync<Employer>().Result;
                }

                if (employer != null)
                {
                    HomePage homePage = new HomePage(employer);
                    homePage.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("מעסיק זה כבר קיים במערכת");
            }
            else
                MessageBox.Show("לא מילאת את כל הפרטים");
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר המעסיק לחץ על כפתור להתחבר
        /// ומעבירה אותו להתחברות למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SigninBtn_Click(object sender, EventArgs e)
        {
            LoginOrSignUpAccount(false);
            this.SignUpLbl.Text = "התחברות";
            this.SignUpLbl.Location = new Point(this.SignUpLbl.Location.X - 20, this.SignUpLbl.Location.Y);
            this.AccountLbl.Text = "צריך חשבון?";
        }

        /// <summary>
        /// פונקציה שמופעלת כאשר המעסיק לחץ על כפתור להרשם
        /// ומעבירה אותו להרשמה למערכת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            LoginOrSignUpAccount(true);
            this.SignUpLbl.Text = "הרשמה";
            this.SignUpLbl.Location = new Point(this.SignUpLbl.Location.X + 20, this.SignUpLbl.Location.Y);
            this.AccountLbl.Text = "כבר יש לך חשבון?";
        }

        /// <summary>
        /// כפתור ליצירת חשבון של התחברות למעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Employer employer;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Employer/GetEmployer?companyEmail={this.CompanyEmailTxt.Text}&employerPassword={this.EmployerPasswordTxt.Text}";
                HttpResponseMessage response = client.GetAsync(path).Result;
                employer = response.Content.ReadAsAsync<Employer>().Result;
            }

            if (employer != null)
            {
                HomePage homePage = new HomePage(employer);
                homePage.Show();
                this.Hide();
            }
        }
        
        /// <summary>
        /// פונקציה שמופעלת כאשר המעסיק בחר
        /// קטגוריית חברה ושומרת את בחירתו
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.chosenCompanyType = (KeyValuePair<int, string>)this.CompanyTypeDropDown.SelectedItem;
           this.userChoose = true;
        }

        
    }
}
