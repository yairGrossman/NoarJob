using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;

namespace NoarJobUI
{
    public partial class ucJob : UserControl
    {
        private Job[] arrJobs;
        private int y = 157;
        private JobManagementPage jobManagement;
        private bool isJobActive;
        private Employer employer;

        /// <summary>
        /// פעולה בונה שנועדה למעסיק
        /// </summary>
        /// <param name="arrJobs"></param>
        /// <param name="isJobActive"></param>
        /// <param name="employer"></param>
        public ucJob(Job[] arrJobs, JobManagementPage jobManagement, bool isJobActive, Employer employer)
        {
            InitializeComponent();
            this.arrJobs = arrJobs;
            this.jobManagement = jobManagement;
            this.isJobActive = isJobActive;
            this.employer = employer;
        }

        private void ucJob_Load(object sender, EventArgs e)
        {
            if (this.arrJobs.Length > 1)
                this.JobsFLP.Size = new Size(572, 638);
            else
                this.JobsFLP.Size = new Size(555, 638);

            this.BringToFront();

            for (int i = 0; i < this.arrJobs.Length; i++)
            {
                this.JobsFLP.Controls.Add(JobPanel(i));
                this.JobsFLP.Controls.Add(ChoseJobPanel(i));
            }

            this.Size = new Size(this.JobsFLP.Width, this.JobsFLP.Height);
        }

        #region כרטיס משרה
        /// <summary>
        /// פונקציה שיוצרת פנל של משרה
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Panel JobPanel(int i)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(180)))), ((int)(((byte)(159)))));
            panel.Controls.Add(RequirementsLbl(this.arrJobs[i].Requirements));
            panel.Controls.Add(EmailLbl(this.arrJobs[i].Email));
            panel.Controls.Add(PhoneLbl(this.arrJobs[i].Phone));
            panel.Controls.Add(NumOfEmployeesLbl(this.arrJobs[i].NumOfEmployees));
            panel.Controls.Add(EmployerNameLbl(this.arrJobs[i].EmployerName));
            panel.Controls.Add(DescriptionLbl(this.arrJobs[i].Description));

            panel.Controls.Add(CategoriesDropDown(this.arrJobs[i].CategoriesDictionary));
            panel.Controls.Add(TypesDropDown(this.arrJobs[i].TypesDictionary));
            panel.Controls.Add(CitiesDropDown(this.arrJobs[i].CitiesDictionary));

            panel.Controls.Add(JobCategoryLbl());
            panel.Controls.Add(JobTypeLbl());
            panel.Controls.Add(LocationLbl());
            panel.Controls.Add(CompanyNameLbl(this.arrJobs[i].CompanyName));
            panel.Controls.Add(JobTitleLbl(this.arrJobs[i].Title));
            panel.Controls.Add(CompanyTypeNameLbl(this.arrJobs[i].CompanyTypeName));

            panel.Cursor = System.Windows.Forms.Cursors.Default;
            panel.Name = "JobPanel";
            panel.Size = new System.Drawing.Size(548, 579);
            return panel;
        }

        /// <summary>
        /// פונקציה שיוצרת פנל של 
        /// למחוק את המשרה
        /// לאוהב את המשרה
        /// להגיש מועמדות למשרה
        /// לעדכן את קורות החיים
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Panel ChoseJobPanel(int i)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));


            if (this.isJobActive)
            {
                panel.Controls.Add(this.TrashPic(this.arrJobs[i].JobID));
                panel.Controls.Add(ATSPageBtn(this.arrJobs[i].JobID));
            }
            else
                panel.Controls.Add(this.UploadJobPic(this.arrJobs[i].JobID));

            panel.Controls.Add(this.EditJobBtn(i));

            panel.Location = new System.Drawing.Point(1105, 701);
            panel.Name = "ChoseJobPanel";
            panel.Size = new System.Drawing.Size(548, 46);
            panel.TabIndex = 5;
            return panel;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של סוג שם החברה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label CompanyTypeNameLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(324, 16);
            label.Name = "CompanyTypeNameLbl";
            label.Size = new System.Drawing.Size(200, 18);
            label.RightToLeft = RightToLeft.Yes;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.TabIndex = 0;
            label.Text = "קטגוריית החברה: " + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של שם המעסיק
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label EmployerNameLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(110, 16);
            label.Name = "EmployerNameLbl";
            label.Size = new System.Drawing.Size(200, 18);
            label.TabIndex = 10;
            label.RightToLeft = RightToLeft.Yes;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "שם המעסיק: " + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של כמות  העובדים בחברה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label NumOfEmployeesLbl(int text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(10, 16);
            label.Name = "NumOfEmployeesLbl";
            label.Size = new System.Drawing.Size(152, 18);
            label.TabIndex = 11;
            label.RightToLeft = RightToLeft.Yes;
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Text = "מספר העובדים: " + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של מספר הטלפון של המעסיק
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label PhoneLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(226, 50);
            label.Name = "PhoneLbl";
            label.Size = new System.Drawing.Size(300, 18);
            label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label.TabIndex = 12;
            label.Text = "מספר טלפון: " + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של האימייל של המעסיק
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label EmailLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(226, 83);
            label.Name = "EmailLbl";
            label.Size = new System.Drawing.Size(300, 18);
            label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label.TabIndex = 13;
            label.Text = "אימייל: " + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של כותרת המשרה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label JobTitleLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            label.Location = new System.Drawing.Point(26, 120);
            label.Margin = new System.Windows.Forms.Padding(0);
            label.Name = "JobTitleLbl";
            label.Size = new System.Drawing.Size(500, 26);
            label.RightToLeft = RightToLeft.Yes;
            label.TabIndex = 1;
            label.Text = text;
            label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של שם החברה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label CompanyNameLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(450, this.y);
            label.Name = "CompanyNameLbl";
            label.Size = new System.Drawing.Size(76, 18);
            label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label.TabIndex = 2;
            label.Text = text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת לבל של מיקום המשרה
        /// </summary>
        /// <returns></returns>
        private Label LocationLbl()
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(428, 227);
            label.Name = "LocationLbl";
            label.Size = new System.Drawing.Size(98, 18);
            label.TabIndex = 3;
            label.Text = ":מיקום המשרה";

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת לבל של טיפוס המשרה
        /// </summary>
        /// <returns></returns>
        private Label JobTypeLbl()
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(453, 267);
            label.Name = "JobTypeLbl";
            label.Size = new System.Drawing.Size(73, 18);
            label.TabIndex = 5;
            label.Text = ":סוג משרה";

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת לבל של קטגוריית המשרה
        /// </summary>
        /// <returns></returns>
        private Label JobCategoryLbl()
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.ForeColor = System.Drawing.SystemColors.MenuText;
            label.Location = new System.Drawing.Point(418, 307);
            label.Name = "JobCategoryLbl";
            label.Size = new System.Drawing.Size(108, 18);
            label.TabIndex = 7;
            label.Text = ":קטגוריית משרה";

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת רשימה של ערים בה המשרה נמצאת
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private ComboBox CitiesDropDown(Dictionary<int, string> dictionary)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            comboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            comboBox.FormattingEnabled = true;
            comboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            comboBox.Location = new System.Drawing.Point(289, 224);
            comboBox.Name = "CitiesDropDown";
            comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            comboBox.Size = new System.Drawing.Size(123, 26);
            comboBox.TabIndex = 4;
            foreach (KeyValuePair<int, string> kvp in dictionary)
                comboBox.Items.Add(kvp.Value);

            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        /// <summary>
        /// פונקציה שיוצרת רשימה של טיפוסי משרה שלמשרה יש
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private ComboBox TypesDropDown(Dictionary<int, string> dictionary)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            comboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            comboBox.FormattingEnabled = true;
            comboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            comboBox.Location = new System.Drawing.Point(289, 264);
            comboBox.Name = "TypesDropDown";
            comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            comboBox.Size = new System.Drawing.Size(123, 26);
            comboBox.TabIndex = 6;
            foreach (KeyValuePair<int, string> kvp in dictionary)
                comboBox.Items.Add(kvp.Value);

            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        /// <summary>
        /// פונקציה שיוצרת רשימה של קטגוריות שלמשרה יש
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        private ComboBox CategoriesDropDown(Dictionary<int, string> dictionary)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            comboBox.ForeColor = System.Drawing.SystemColors.MenuText;
            comboBox.FormattingEnabled = true;
            comboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            comboBox.Location = new System.Drawing.Point(289, 304);
            comboBox.Name = "CategoriesDropDown";
            comboBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            comboBox.Size = new System.Drawing.Size(123, 26);
            comboBox.TabIndex = 8;
            foreach (KeyValuePair<int, string> kvp in dictionary)
                comboBox.Items.Add(kvp.Value);

            comboBox.SelectedIndex = 0;
            return comboBox;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של תיאור המשרה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label DescriptionLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.Location = new System.Drawing.Point(31, 347);
            label.Name = "DescriptionLbl";
            label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label.Size = new System.Drawing.Size(495, 88);
            label.TabIndex = 9;
            label.Text = "תיאור:\n" + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת טקסט של דרישות המשרה
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private Label RequirementsLbl(string text)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            label.Location = new System.Drawing.Point(16, 440);
            label.Name = "RequirementsLbl";
            label.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            label.Size = new System.Drawing.Size(510, 130);
            label.TabIndex = 14;
            label.Text = " דרישות:\n" + text;

            return label;
        }

        /// <summary>
        /// פונקציה שיוצרת תמונת כפתור של מחיקת משרה
        /// </summary>
        /// <param name="jobID"></param>
        /// <param name="jobIndex">מיקום המשרה במערך המשרות</param>
        /// <returns></returns>
        private PictureBox TrashPic(int jobID)
        {
            PictureBox pic = new PictureBox();
            pic.Image = global::NoarJobUI.Properties.Resources.trash_can;
            pic.Location = new System.Drawing.Point(498, 3);
            pic.Tag = jobID;
            pic.Size = new System.Drawing.Size(47, 40);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.Click += new EventHandler(this.TrashPic_Click);
            return pic;
        }

        /// <summary>
        /// פונקציה שיוצרת כפתור של עריכת משרה
        /// </summary>
        /// <param name="jobIndex">מיקום המשרה במערך המשרות</param>
        /// <returns></returns>
        private Button EditJobBtn(int jobIndex)
        {
            Button btn = new Button();
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            btn.Location = new System.Drawing.Point(0, 0);
            btn.Size = new System.Drawing.Size(167, 46);
            btn.TabIndex = 2;
            btn.Text = "עריכת משרה";
            btn.Tag = jobIndex;
            btn.UseVisualStyleBackColor = false;
            btn.Click += new EventHandler(this.EditJobBtn_Click);
            return btn;
        }

        /// <summary>
        /// פונקציה שיוצרת תמונת כפתור של העלת משרה לאוויר
        /// </summary>
        /// <param name="jobID"></param>
        /// <param name="jobIndex">מיקום המשרה במערך המשרות</param>
        /// <returns></returns>
        private PictureBox UploadJobPic(int jobID)
        {
            PictureBox pic = new PictureBox();
            pic.Image = global::NoarJobUI.Properties.Resources.Upload_Icon;
            pic.Location = new System.Drawing.Point(498, 3);
            pic.Tag = jobID;
            pic.Size = new System.Drawing.Size(47, 40);
            pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pic.TabIndex = 0;
            pic.TabStop = false;
            pic.Click += new EventHandler(this.UploadJobPic_Click);
            return pic;
        }

        /// <summary>
        /// פונקציה שיוצרת כפתור של העברת המעסיק ל ATS
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        private Button ATSPageBtn(int jobID)
        {
            Button btn = new Button();
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            btn.Location = new System.Drawing.Point(320, 0);
            btn.Size = new System.Drawing.Size(167, 46);
            btn.TabIndex = 2;
            btn.Text = "ניהול מועמדים";
            btn.Tag = jobID;
            btn.UseVisualStyleBackColor = false;
            btn.Click += new EventHandler(this.ATSPageBtn_Click);
            return btn;
        }

        private void ATSPageBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int jobID = (int)button.Tag;
            ATSPage aTSPage = new ATSPage(jobID);
            aTSPage.Show();
            this.jobManagement.Close();
        }
        #endregion

        /// <summary>
        /// כפתור ששולח את המעסיק למסך עדכון משרה
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditJobBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int jobIndex = (int)button.Tag;
            PostingJobPage postingJobPage = new PostingJobPage(this.employer, this.arrJobs[jobIndex]);
            postingJobPage.Show();
            this.jobManagement.Close();
        }

        /// <summary>
        /// פונקציה ששמה משרה בדף משרות ישנות
        /// או מוחקת את המשרה מדף חיפוש המשרות של המשתמש
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrashPic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            int jobID = (int)pic.Tag;

            bool succeeded = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/UpdateJobActivity?jobID={jobID}&isActive=true";
                HttpResponseMessage response = client.GetAsync(path).Result;
                succeeded = response.Content.ReadAsAsync<bool>().Result;
            }

            if (!succeeded)
                MessageBox.Show("משהו השתבש");

            this.jobManagement.JobsInAirBtn_Click(null, null);
        }

        /// <summary>
        /// פונקציה ששמה משרה בדף משרות באוויר
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadJobPic_Click(object sender, EventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            int jobID = (int)pic.Tag;

            bool succeeded = false;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"Job/UpdateJobActivity?jobID={jobID}&isActive=false";
                HttpResponseMessage response = client.GetAsync(path).Result;
                succeeded = response.Content.ReadAsAsync<bool>().Result;
            }

            if (!succeeded)
                MessageBox.Show("משהו השתבש");

            this.jobManagement.OldJobsBtn_Click(null, null);
        }
    }
}
