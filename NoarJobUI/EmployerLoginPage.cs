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
    public partial class EmployerLoginPage : Form
    {
        private bool loginAccount;//משתנה שמטרתו לבדוק האם המשתמש בחר בהתחברות למערכת או יצירת חשבון
        private string firstName;//שם פרטי
        private string lastName;//שם משפחה
        private string email;//האמייל של המשתמש
        private string userPassword;//הסיסמא של המשתמש
        private Employer employer;//עצם מטיפוס מעסיק
        private CompanyType companyTypes;//עצם מטיפוס קטגוריית חברה
        private CompanyType chosenCompanyType;//הקטגוריית החברה שבחר המשתמש
        private bool userChoose;//משתנה שמטרתו לבדוק האם המשתמש בחר קטגוריית חברה
        private MainPage mainPage;
        private Point companyEmailLblLoc;
        private Point companyEmailTxtLoc;
        private Point employerPasswordLblLoc;
        private Point employerPasswordTxtLoc;

        public EmployerLoginPage(bool loginAccount, string firstName, string lastName, string email, string userPassword, MainPage mainPage)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.userPassword = userPassword;
            this.mainPage = mainPage;
        }

        public EmployerLoginPage(bool loginAccount, MainPage mainPage)
        {
            InitializeComponent();
            this.loginAccount = loginAccount;
            this.employer = new Employer();
            this.companyTypes = new CompanyType();
            this.mainPage = mainPage;
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
                this.CompanyTypeDropDown.DisplayMember = "CompanyTypeName";
                this.CompanyTypeDropDown.ValueMember = "CompanyTypeID";
                this.CompanyTypeDropDown.DataSource = companyTypes.GetAllCompanyTypes();
            }
            
        }

        /// <summary>
        /// כפתור ליצירת חשבון מעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccountBtn_Click(object sender, EventArgs e)
        {
            if (this.EmployerNameTxt.Text != "" && this.NumOfEmployeesTxt.Text != "" && this.userChoose
                && this.CompanyNameTxt.Text != "" && this.CompanyEmailTxt.Text != "" && this.EmployerPasswordTxt.Text != "")
            {
                bool succeeded = employer.CreateEmployer(this.EmployerNameTxt.Text, int.Parse(this.NumOfEmployeesTxt.Text), this.chosenCompanyType.CompanyTypeID,
                                 this.chosenCompanyType.CompanyTypeName, this.CompanyNameTxt.Text,
                                 this.EmployerPasswordTxt.Text, this.CompanyEmailTxt.Text);
                if (succeeded)
                {
                    HomePage homePage = new HomePage(this.employer, this.mainPage);
                    homePage.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("מעסיק זה כבר קיים במערכת");
            }
            else
                MessageBox.Show("לא מילאת את כל הפרטים");
        }

        private void SigninBtn_Click(object sender, EventArgs e)
        {
            LoginOrSignUpAccount(false);
            this.AccountLbl.Text = "צריך חשבון?";
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            LoginOrSignUpAccount(true);
            this.AccountLbl.Text = "כבר יש לך חשבון?";
        }

        /// <summary>
        /// כפתור ליצירת חשבון של התחברות למעסיק
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            bool succeeded = this.employer.GetEmployer(this.CompanyEmailTxt.Text, this.EmployerPasswordTxt.Text);

            if (succeeded)
            {
                HomePage homePage = new HomePage(this.employer, this.mainPage);
                homePage.Show();
                this.Close();
            }
        }
        
        private void CompanyTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
           this.chosenCompanyType = (CompanyType)this.CompanyTypeDropDown.SelectedItem;
           this.userChoose = true;
        }

        
    }
}
