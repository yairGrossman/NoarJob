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
using System.Net.Http;
using System.Configuration;
using Newtonsoft.Json;

namespace NoarJobUI
{
    /// <summary>
    /// יצרתי את זה כי זה יותר מובן מאשר ליצור משתנה מטיפוס מספר שלם שמייצג את התחומים
    /// </summary>
    enum Categories
    {
        Default,
        Domain,
        Role,
        Location,
        JobType
    }

    public partial class ucChoices : UserControl
    {
        private Button[] arrBtn;// מערך של כפתורים
        private JobCategoriesBL jc;// JobCategoriesBL עצם מטיפוס 
        private CitiesBL cities;// CitiesBL עצם מטיפוס  
        private JobTypesBL jt;// JobTypesBL עצם מטיפוס
        private Categories category;// זה נועד בשביל לדעת איזה כפתור נלחץ: כפתור בחירת תחום, כפתור בחירת תפקיד וכולי enum
        private int jobTypeDictionaryLength;// JobType אורך המערך מטיפוס
        private bool DomainLblVisible = false;//אם המשתמש בחר תחום תפקיד אז המשתנה יהפוך לאמת
        private bool RolesDropDownVisible = false;//אם המשתמש בחר תפקיד/ים אז המשתנה יהפוך לאמת
        private bool JobTypesDropDownVisible = false;//אם המשתמש בחר סוגי משרה אז המשתנה יהפוך לאמת
        private bool CitiesDropDownVisible = false;
        private bool ContentPanelVisible = true;
        private PostingJobPage postingJobPage;
        private bool cleanChoiceActive = false;

        #region תכונות
        public JobCategoriesBL JC
        {
            get { return this.jc; }
        }

        public CitiesBL City
        {
            get { return this.cities; }
        }

        public JobTypesBL JT
        {
            get { return this.jt; }
        }
        #endregion 
        /// <summary>
        /// פעולה בונה ליצירת משרה
        /// </summary>
        /// <param name="form"></param>
        public ucChoices(PostingJobPage postingJobPage)
        {
            InitializeComponent();
            this.postingJobPage = postingJobPage;
            this.jc = new JobCategoriesBL();
            this.cities = new CitiesBL();
            this.jt = new JobTypesBL();
        }

        /// <summary>
        /// פעולה בונה שנועדה לדף עדכון משרה של מעסיק
        /// בפעולה זו אני שם את כל הערכים הקיימים של המשרה 
        /// </summary>
        /// <param name="job"></param>
        public ucChoices(PostingJobPage postingJobPage, Job job)
        {
            InitializeComponent();
            this.DomainLbl.Visible = true;
            this.RolesDropDown.Visible = true;
            this.CitiesDropDown.Visible = true;
            this.JobTypesDropDown.Visible = true;
            this.DomainLblVisible = true;
            this.RolesDropDownVisible = true;
            this.CitiesDropDownVisible = true;
            this.JobTypesDropDownVisible = true;
            this.RoleBtn.Enabled = true;
            this.postingJobPage = postingJobPage;
            this.jc = new JobCategoriesBL();
            this.cities = new CitiesBL();
            this.jt = new JobTypesBL();
            int jobCategoryID;
            int citiesID;
            int jobTypeID;

            for (int i = 0; i < job.CategoriesDictionary.Count; i++)
            {
                jobCategoryID = job.CategoriesDictionary.ElementAt(i).Key;
                this.jc.ChosenJobCategoryLst.Add(jobCategoryID);
                if (i > 0)
                {
                    this.RolesDropDown.Items.Add(job.CategoriesDictionary.ElementAt(i).Value);
                }
                else
                    this.DomainLbl.Text = job.CategoriesDictionary.ElementAt(i).Value;
            }

            for (int i = 0; i < job.CitiesDictionary.Count; i++)
            {
                citiesID = job.CitiesDictionary.ElementAt(i).Key;
                this.cities.LstCities.Add(citiesID);
                this.CitiesDropDown.Items.Add(job.CitiesDictionary.ElementAt(i).Value);
            }

            for (int i = 0; i < job.TypesDictionary.Count; i++)
            {
                jobTypeID = job.TypesDictionary.ElementAt(i).Key;
                this.jt.ChosenJobTypeLst.Add(jobTypeID);
                this.JobTypesDropDown.Items.Add(job.TypesDictionary.ElementAt(i).Value);
            }

            this.RolesDropDown.SelectedIndex = 0;
            this.CitiesDropDown.SelectedIndex = 0;
            this.JobTypesDropDown.SelectedIndex = 0;
        }

        private void ucChoices_Load(object sender, EventArgs e)
        {
            this.arrBtn = new Button[1];
            this.DomainLbl.Location = new Point(this.DomainBtn.Location.X + 5, this.DomainLbl.Location.Y);
            this.CountDomainLbl.Location = new Point(this.DomainLbl.Location.X - this.CountDomainLbl.Width, this.DomainLbl.Location.Y);

                this.DomainBtn.Location = new Point(this.DomainBtn.Location.X, 23);
                this.RoleBtn.Location = new Point(this.RoleBtn.Location.X, 23);
                this.LocationBtn.Location = new Point(this.LocationBtn.Location.X, 23);
                this.JobTypeBtn.Location = new Point(this.JobTypeBtn.Location.X, 23);
                this.navbar.Size = new Size(831, 82);
                this.ContentPanel.Location = new Point(3, 153);
                this.cities.LstCities = new List<int>();

            this.navbar.Location = new Point(
                                   this.ClientSize.Width / 2 - this.navbar.Size.Width / 2,
                                   100);
            this.ProjectTitleLbl.Location = new Point(
                                   this.ProjectTitleLbl.Location.X,
                                   35);
            this.ContentPanel.Location = new Point(this.navbar.Location.X, this.navbar.Location.Y + this.navbar.Height + 10);
            this.ChooseTxt.Location = new Point(this.DomainBtn.Location.X, 50);
            this.pictureBox1.Location = new Point(this.DomainBtn.Location.X - this.pictureBox1.Width - 10, 50);
            this.ChooseCityLbl.Location = new Point(this.pictureBox1.Location.X - this.ChooseCityLbl.Width - 10, this.pictureBox1.Location.Y);
            this.JobTypeLbl.Location = new Point(this.ChooseTxt.Location.X, 40);
            this.SubTypeLbl.Location = new Point(this.ChooseTxt.Location.X - 300, 40);
            this.CleanChoiceBtn.Location = new Point(this.CleanChoiceBtn.Location.X, this.ChooseTxt.Location.Y);
        }

        /// <summary>
        /// פונקציה ששמה כפתורים על המסך
        /// </summary>
        /// <param name="arr"></param>
        private void AddButtons(Dictionary<int, string> dictionary)
        {
            if (this.ContentPanelVisible)
            {
                this.CleanChoiceBtn.Visible = true;
                if (dictionary != null)
                {
                    int x = this.ChooseTxt.Location.X;
                    int y = this.ChooseTxt.Location.Y + this.ChooseTxt.Height + 10;
                    ClearContentPanel();

                    arrBtn = new Button[dictionary.Count];
                    for (int i = 0; i < arrBtn.Length; i++)
                    {
                        if (i == this.jobTypeDictionaryLength && this.category == Categories.JobType)
                        {
                            x -= 300;
                            y = this.ChooseTxt.Location.Y + this.ChooseTxt.Height + 10;
                        }

                        this.arrBtn[i] = new Button();
                        this.arrBtn[i].Anchor = AnchorStyles.None;
                        this.arrBtn[i].AutoSize = true;
                        this.arrBtn[i].AutoSizeMode = AutoSizeMode.GrowAndShrink;
                        this.arrBtn[i].BackColor = Color.FromArgb(236, 179, 144);
                        this.arrBtn[i].Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
                        this.arrBtn[i].ForeColor = SystemColors.MenuText;
                        this.arrBtn[i].Location = new Point(x, y);
                        this.arrBtn[i].Size = new Size(100, 30);
                        this.arrBtn[i].TabIndex = 2;
                        this.arrBtn[i].TextAlign = ContentAlignment.MiddleRight;
                        this.arrBtn[i].UseVisualStyleBackColor = false;
                        y += this.arrBtn[i].Height + 10;

                        if (this.arrBtn[i].Location.Y + this.arrBtn[i].Height + 15 > this.ContentPanel.Height)
                        {
                            x -= this.arrBtn[i].Width + 30;
                            y = this.ChooseTxt.Location.Y + this.ChooseTxt.Height + 10;
                            this.arrBtn[i].Location = new Point(x, y);
                        }

                        this.arrBtn[i].Tag = dictionary.ElementAt(i).Key;
                        this.arrBtn[i].Text = dictionary.ElementAt(i).Value;

                        if (this.category == Categories.Domain)
                        {
                            this.arrBtn[i].Click += new EventHandler(this.DomainClick);
                        }
                        else if (this.category == Categories.Role)
                        {
                            this.arrBtn[i].Click += new EventHandler(this.RoleClick);
                        }
                        else if (this.category == Categories.Location)
                        {
                            this.arrBtn[i].Click += new EventHandler(this.LocationClick);
                        }
                        else
                        {
                            this.arrBtn[i].Click += new EventHandler(this.JobTypeClick);
                        }

                        this.ContentPanel.Controls.Add(this.arrBtn[i]);
                    }
                }
                

                TurnChoicesInvisible();
                this.ContentPanelVisible = false;
            }
            else
            {
                TurnContentPanelInvisible();
                TurnChoicesVisible();
                this.ContentPanelVisible = true;
                this.CleanChoiceBtn.Visible = false;
            }

        }

        /// <summary>
        /// כאשר לוחצים על אחד מהכפתורים של היקף משרה 
        /// או סוג משרה הכפתור משנה את ציבעו ונשמר הבחירה של המשתמש
        /// jt בתוך העצם  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void JobTypeClick(object sender, EventArgs e)
        {
            this.cleanChoiceActive = false;
            this.JobTypesDropDownVisible = true;
            Button btn = (Button)sender;
            //אם הכפתור לא בצבעו המקורי אז אני מחזיר את צבעו לבצע הרגיל
            //ומוחק את הבחירה שלו
            if (btn.BackColor != Color.FromArgb(236, 179, 144))
            {
                btn.BackColor = Color.FromArgb(236, 179, 144);
                this.jt.ChosenJobTypeLst.Remove((int)btn.Tag);
                this.JobTypesDropDown.Items.Remove(btn.Text);
                
                int count;
                if (this.cities.LstCities.Count != 0)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                        var sameSearchesOfUsersReq = new
                        {
                            ChildCategoriesLst = this.jc.ChosenJobCategoryLst,
                            CitiesLst = this.cities.LstCities,
                            TypesLst = this.jt.ChosenJobTypeLst
                        };

                        var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/SameChildCategoriesAndCitiesAndTypes", content);
                        count = response.Content.ReadAsAsync<int>().Result;
                    }
                    this.CountTypesLbl.Text = $"({count})";
                }
                else
                {
                    count = 0;
                }

                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();

                if (this.JobTypesDropDown.Items.Count == 0)
                {
                    this.JobTypesDropDownVisible = false;
                }
            }
            else
            {
                btn.BackColor = Color.FromArgb(148, 180, 159);
                this.jt.ChosenJobTypeLst.Add((int)btn.Tag);
                this.JobTypesDropDown.Items.Add(btn.Text);
                int count;

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    var sameSearchesOfUsersReq = new
                    {
                        ChildCategoriesLst = this.jc.ChosenJobCategoryLst,
                        CitiesLst = this.cities.LstCities,
                        TypesLst = this.jt.ChosenJobTypeLst
                    };

                    var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/SameChildCategoriesAndCitiesAndTypes", content);
                    count = response.Content.ReadAsAsync<int>().Result;
                }
                this.CountTypesLbl.Text = $"({count})";

                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();
            }
        }

        /// <summary>
        /// כאשר לוחצים על כפתור של עיר 
        /// הכפתור משנה את ציבעו ונשמר הבחירה של המשתמש
        /// cities בתוך העצם
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LocationClick(object sender, EventArgs e)
        {
            this.cleanChoiceActive = false;
            Button btn = (Button)sender;
            //אם הכפתור לא בצבעו המקורי אז אני מחזיר את צבעו לבצע הרגיל
            //ומוחק את הבחירה שלו
            if (btn.BackColor != Color.FromArgb(236, 179, 144))
            {
                btn.BackColor = Color.FromArgb(236, 179, 144);
                this.cities.LstCities.Remove((int)btn.Tag);
                this.CitiesDropDown.Items.Remove(btn.Text);

                int count;
                if (this.cities.LstCities.Count != 0)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                        var sameSearchesOfUsersReq = new
                        {
                            ChildCategoriesLst = this.jc.ChosenJobCategoryLst,
                            CitiesLst = this.cities.LstCities
                        };

                        var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/SameChildCategoriesAndCities", content);
                        count = response.Content.ReadAsAsync<int>().Result;
                    }
                    this.CountCitiesLbl.Text = $"({count})";
                }
                else
                {
                    count = 0;
                }

                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();

                if (this.CitiesDropDown.Items.Count == 0)
                {
                    this.CitiesDropDownVisible = false;
                }
            }
            else
            {
                btn.BackColor = Color.FromArgb(148, 180, 159);
                this.cities.LstCities.Add((int)btn.Tag);
                this.CitiesDropDown.Items.Add(btn.Text);
                int count;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    var sameSearchesOfUsersReq = new
                    {
                        ChildCategoriesLst = this.jc.ChosenJobCategoryLst,
                        CitiesLst = this.cities.LstCities
                    };

                    var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/SameChildCategoriesAndCities", content);
                    count = response.Content.ReadAsAsync<int>().Result;
                }
                this.CountCitiesLbl.Text = $"({count})";
                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();
                this.CitiesDropDownVisible = true;
                this.ContentPanelVisible = false;
            }
        }

        /// <summary>
        /// כאשר לוחצים על אחד מהכפתורים של התפקידים 
        /// הכפתור משנה את ציבעו ונשמר הבחירה של המשתמש
        /// jc בתוך העצם  
        /// </summary>
        private async void RoleClick(object sender, EventArgs e)
        {
            this.cleanChoiceActive = false;
            this.RolesDropDownVisible = true;
            Button btn = (Button)sender;
            //אם הכפתור צבוע כבר ולחוצים עליו אז הוא חוזר לצבועו הרגיל
            //ChosenJobCategoryLst ונמחק הטג של הכפתור מ
            //rolesLst ונמחק הטסקסט של הכפתור מ
            if (btn.BackColor != Color.FromArgb(236, 179, 144))
            {
                btn.BackColor = Color.FromArgb(236, 179, 144);
                this.jc.ChosenJobCategoryLst.Remove((int)btn.Tag);
                this.RolesDropDown.Items.Remove(btn.Text);

                int count;
                if (this.jc.ChosenJobCategoryLst.Count != 0)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                        var sameSearchesOfUsersReq = new
                        {
                            ChildCategoriesLst = this.jc.ChosenJobCategoryLst
                        };

                        var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/GetSameChildCategories", content);
                        count = response.Content.ReadAsAsync<int>().Result;
                    }
                    this.CountRolesLbl.Text = $"({count})";
                }
                else
                {
                    count = 0;
                }


                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();

                if (this.RolesDropDown.Items.Count == 0)
                {
                    this.RolesDropDownVisible = false;
                }
            }
            else
            {
                btn.BackColor = Color.FromArgb(148, 180, 159);
                this.jc.ChosenJobCategoryLst.Add((int)btn.Tag);
                this.RolesDropDown.Items.Add(btn.Text);
                int count;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    var sameSearchesOfUsersReq = new
                    {
                        ChildCategoriesLst = this.jc.ChosenJobCategoryLst
                    };

                    var jsonContent = JsonConvert.SerializeObject(sameSearchesOfUsersReq);

                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("SameSearchesOfUsers/GetSameChildCategories", content);
                    count = response.Content.ReadAsAsync<int>().Result;
                }
                this.CountRolesLbl.Text = $"({count})";
                this.postingJobPage.CountSameSearchesLbl.Text = count.ToString();
            }
        }

        /// <summary>
        /// כאשר לוחצים על אחד מהכפתורים של תחומי תפקיד 
        /// הכפתור משנה את ציבעו ונשמר הבחירה של המשתמש
        /// jc בתוך העצם  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DomainClick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.arrBtn.Length; i++)
            {
                this.arrBtn[i].BackColor = Color.FromArgb(236, 179, 144);
            }

            Button btn = (Button)sender;
            this.jc.ChosenJobCategory = (int)btn.Tag;
            int sameParentCategory;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"SameSearchesOfUsers/GetSameParentCategory?parentCategory={this.jc.ChosenJobCategory}";
                HttpResponseMessage response = client.GetAsync(path).Result;
                sameParentCategory = response.Content.ReadAsAsync<int>().Result;
            }
            this.CountDomainLbl.Text = $"({sameParentCategory})";
            this.postingJobPage.CountSameSearchesLbl.Text = sameParentCategory.ToString();

            btn.BackColor = Color.FromArgb(148, 180, 159);
            this.DomainLbl.Text = btn.Text;
            this.RoleBtn.Enabled = true;
            this.cleanChoiceActive = false;
            this.DomainLblVisible = true;
        }

        /// <summary>
        /// כאשר לוחצים על הכפתור: בחירת תחום
        /// מופיעים כל תחומי התפקיד בתור כפתורים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DomainBtn_Click(object sender, EventArgs e)
        {
            //אם הקטגוריה היא לא הקטגוריה של הכפתור זה אומר שהמשתמש עבר לכפתור אחר לכן לא צריך
            //להראות לו את הכפתורים שהוא בחר
            if (this.category != Categories.Domain)
            {
                this.ContentPanelVisible = true;
                this.cleanChoiceActive = false;
            }

            this.ChooseTxt.Text = "";
            this.ChooseCityLbl.Visible = false;
            this.JobTypeLbl.Visible = false;
            this.SubTypeLbl.Visible = false;
            this.ChooseTxt.Visible = true;
            this.pictureBox1.Visible = true;
            this.category = Categories.Domain;
            Dictionary<int, string> jcDictionary;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = "JobCategories/GetParentJobCategories";
                HttpResponseMessage response = client.GetAsync(path).Result;
                jcDictionary = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
            }
            AddButtons(jcDictionary);
            if(!this.cleanChoiceActive)
               PaintButton(this.jc.ChosenJobCategory);
        }

        /// <summary>
        /// כאשר לוחצים על הכפתור: בחירת תפקיד
        /// מופיעים כל התפקידים של אותו תחום תפקיד שהמשתמש בחר
        /// בתור כפתורים
        /// </summary>
        private void RoleBtn_Click(object sender, EventArgs e)
        {
            //אם הקטגוריה היא לא הקטגוריה של הכפתור זה אומר שהמשתמש עבר לכפתור אחר לכן לא צריך
            //להראות לו את הכפתורים שהוא בחר
            if (this.category != Categories.Role)
            {
                this.ContentPanelVisible = true;
                this.cleanChoiceActive = false;
            }

            this.ChooseTxt.Text = "";
            this.ChooseCityLbl.Visible = false;
            this.JobTypeLbl.Visible = false;
            this.SubTypeLbl.Visible = false;
            this.ChooseTxt.Visible = true;
            this.pictureBox1.Visible = true;
            this.category = Categories.Role;
            Dictionary<int, string> jcDictionary;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = $"JobCategories/GetJobCategoriesByParentID?chosenJobCategory={this.jc.ChosenJobCategory}";
                HttpResponseMessage response = client.GetAsync(path).Result;
                jcDictionary = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
            }
            AddButtons(jcDictionary);
            if (!this.cleanChoiceActive)
                PaintButtons(this.jc.ChosenJobCategoryLst);
        }

        /// <summary>
        /// כאשר לוחצים על הכפתור: בחירת מיקום
        /// יהיה ניתן לחפש עיר על ידי קופסת הטקסט
        /// </summary>
        private void LocationBtn_Click(object sender, EventArgs e)
        {
            ClearContentPanel();
            //אם הקטגוריה היא לא הקטגוריה של הכפתור זה אומר שהמשתמש עבר לכפתור אחר לכן לא צריך
            //להראות לו את הכפתורים שהוא בחר
            if (this.category != Categories.Location)
            {
                this.ContentPanelVisible = true;
                this.cleanChoiceActive = false;
            }

            this.ChooseTxt.Text = "";
            this.category = Categories.Location;
            this.ChooseCityLbl.Visible = true;
            this.JobTypeLbl.Visible = false;
            this.SubTypeLbl.Visible = false;
            this.ChooseTxt.Visible = true;
            this.pictureBox1.Visible = true;
            AddButtons(null);
        }

        /// <summary>
        /// כאשר לוחצים על הכפתור: בחירת סוג משרה
        /// מופיעים כל היקפי המשרה וסוגי המשרה 
        /// בתור כפתורים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JobTypeBtn_Click(object sender, EventArgs e)
        {
            //אם הקטגוריה היא לא הקטגוריה של הכפתור זה אומר שהמשתמש עבר לכפתור אחר לכן לא צריך
            //להראות לו את הכפתורים שהוא בחר
            if (this.category != Categories.JobType)
            {
                this.ContentPanelVisible = true;
                this.cleanChoiceActive = false;
            }

            this.JobTypeLbl.Visible = true;
            this.SubTypeLbl.Visible = true;
            this.ChooseCityLbl.Visible = false;
            this.ChooseTxt.Visible = false;
            this.pictureBox1.Visible = false;
            this.category = Categories.JobType;

            Dictionary<int, string> allJobTypes;
            Dictionary<int, string> allSubTypes;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                string path = "JobTypes/GetAllJobTypes";
                HttpResponseMessage response = client.GetAsync(path).Result;
                allJobTypes = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;

                path = "JobTypes/GetAllSubTypes";
                response = client.GetAsync(path).Result;
                allSubTypes = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
            }

            Dictionary<int, string> dictionary = TurnTypeDicAndSubDicToOneDic(allJobTypes, allSubTypes);
            AddButtons(dictionary);
            if (!this.cleanChoiceActive)
                PaintButtons(this.jt.ChosenJobTypeLst);
        }

        /// <summary>
        /// כאשר משנים הטקסט בקופסת הטקסט
        /// ,אז ניתן יהיה לחפש תחום תפקיד מסויים
        /// תפקיד מסויים
        /// ועיר מסויימת
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChoseTxt_TextChanged(object sender, EventArgs e)
        {
            Dictionary<int, string> jcDictionary;
            this.ContentPanelVisible = true;

            if (this.category == Categories.Domain)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    string path = $"JobCategories/GetParentJobCategoriesByText?text={this.ChooseTxt.Text}";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    jcDictionary = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
                }
                AddButtons(jcDictionary);
                PaintButton(this.jc.ChosenJobCategory);
            }
            else if (this.category == Categories.Role)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                    string path = $"JobCategories/GetJobCategoriesByParentIDAndByText?chosenJobCategory={this.jc.ChosenJobCategory}&text={this.ChooseTxt.Text}";
                    HttpResponseMessage response = client.GetAsync(path).Result;
                    jcDictionary = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
                }
                AddButtons(jcDictionary);
                PaintButtons(this.jc.ChosenJobCategoryLst);
            }
            else
            {
                if (this.ChooseTxt.Text != "")
                {
                    Dictionary<int, string> citiesDictionary;
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]);
                        string path = $"Cities/GetCities?text={this.ChooseTxt.Text}";
                        HttpResponseMessage response = client.GetAsync(path).Result;
                        citiesDictionary = response.Content.ReadAsAsync<Dictionary<int, string>>().Result;
                    }
                    AddButtons(citiesDictionary);

                    if (!this.cleanChoiceActive)
                    {
                       PaintButtons(this.City.LstCities);
                    }
                }
                else
                {
                    AddButtons(null);
                    ClearContentPanel();
                }
            }

        }

        /// <summary>
        /// JobType פונקציה שהופכת שני מערכים של
        /// JobType למערך אחד של
        /// </summary>
        /// <param name="jobTypeArr"></param>
        /// <param name="subTypeArr"></param>
        /// <returns></returns>
        public Dictionary<int, string> TurnTypeDicAndSubDicToOneDic(Dictionary<int, string> jobTypeDictionary, Dictionary<int, string> subTypeDictionary)
        {
            this.jobTypeDictionaryLength = jobTypeDictionary.Count;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            foreach (KeyValuePair<int, string> kvp in jobTypeDictionary)
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            foreach (KeyValuePair<int, string> kvp in subTypeDictionary)
            {
                dictionary.Add(kvp.Key, kvp.Value);
            }

            return dictionary;
        }

        /// <summary>
        /// פוקנציה שהופכת את הצבע של הכפתורים שהמשתמש בחר
        /// </summary>
        /// <param name="idLst"></param>
        public void PaintButtons(List<int> idLst)
        {
            for (int i = 0; i < idLst.Count; i++)
            {
                for (int j = 0; j < this.arrBtn.Length; j++)
                {
                    if ((int)this.arrBtn[j].Tag == idLst[i])
                    {
                        this.arrBtn[j].BackColor = Color.FromArgb(148, 180, 159);
                    }
                }
            }
        }

        /// <summary>
        /// פונקציה שהופכת את הצבע של הכפתור שהמשתמש בחר
        /// </summary>
        /// <param name="id"></param>
        public void PaintButton(int id)
        {
            for (int i = 0; i < this.arrBtn.Length; i++)
            {
                if ((int)this.arrBtn[i].Tag == id)
                {
                    this.arrBtn[i].BackColor = Color.FromArgb(148, 180, 159);
                    return;
                }
            }
        }

        /// <summary>
        /// כפתור שמעביר את המשתמש לחיפוש על ידי תחומים
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchByDomainBtn_Click(object sender, EventArgs e)
        {
            this.DomainBtn.Visible = true;
            this.RoleBtn.Visible = true;
            this.LocationBtn.Visible = true;
            this.JobTypeBtn.Visible = true;
            this.ContentPanel.Visible = true;
        }

        /// <summary>
        /// פונקציה שהופכת התוכן שבתוך פנל התוכן לבלתי נראה
        /// </summary>
        private void TurnContentPanelInvisible()
        {
            this.ChooseTxt.Visible = false;
            this.pictureBox1.Visible = false;
            this.ChooseCityLbl.Visible = false;
            this.JobTypeLbl.Visible = false;
            this.SubTypeLbl.Visible = false;
            ClearContentPanel();
        }

        /// <summary>
        /// פונקציה שהופכת את הבחירות של המשתמש לבלתי נראות
        /// </summary>
        private void TurnChoicesInvisible()
        {
            this.DomainLbl.Visible = false;
            this.RolesDropDown.Visible = false;
            this.LocationLbl.Visible = false;
            this.JobTypesDropDown.Visible = false;
            this.CitiesDropDown.Visible = false;
            this.BringToFront();

            
                this.CountDomainLbl.Visible = false;
                this.CountRolesLbl.Visible = false;
                this.CountCitiesLbl.Visible = false;
                this.CountTypesLbl.Visible = false;
        }

        /// <summary>
        /// פונקציה שהופכת את הבחירות של המשתמש לנראות
        /// </summary>
        private void TurnChoicesVisible()
        {
            this.DomainLbl.Visible = this.DomainLblVisible;
            this.RolesDropDown.Visible = this.RolesDropDownVisible;
            this.JobTypesDropDown.Visible = this.JobTypesDropDownVisible;

                    this.CitiesDropDown.Visible = this.CitiesDropDownVisible;
                    this.CountDomainLbl.Visible = true;
                    this.CountRolesLbl.Visible = true;
                    this.CountCitiesLbl.Visible = true;
                    this.CountTypesLbl.Visible = true;
                    this.postingJobPage.PostPanel.BringToFront();
        }

        /// <summary>
        /// פונקציה שמנקה את הכפתורים מהמסך
        /// </summary>
        private void ClearContentPanel()
        {
            for (int i = 0; i < arrBtn.Length; i++)
            {
                this.ContentPanel.Controls.Remove(arrBtn[i]);
            }
        }

        /// <summary>
        /// כפתור שמנקה את הבחירה/ות של אותו קטגורייה שבחר המשתמש
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CleanChoice_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.arrBtn.Length; i++)
            {
                this.arrBtn[i].BackColor = Color.FromArgb(236, 179, 144);
            }
            
            

            this.cleanChoiceActive = true;
            if (this.category == Categories.Domain)
            {
                this.DomainLblVisible = false;
                this.RoleBtn.Enabled = false;
            }
            else if (this.category == Categories.Role)
            {
                this.RolesDropDownVisible = false;
                this.RolesDropDown.Items.Clear();
                this.jc.ChosenJobCategoryLst.Clear();
            }
            else if (this.category == Categories.Location)
            {
                    this.CitiesDropDownVisible = false;
                    this.CitiesDropDown.Items.Clear();
                    this.cities.LstCities.Clear();
            }
            else
            {
                this.JobTypesDropDownVisible = false;
                this.JobTypesDropDown.Items.Clear();
                this.jt.ChosenJobTypeLst.Clear();
            }
        }
    }
}
