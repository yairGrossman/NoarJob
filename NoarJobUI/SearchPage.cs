using NoarJobBL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NoarJobUI
{
    public partial class SearchPage : Form
    {
        private ucChoices UserControlChoices;
        private MainPage mainPage;
        private User user;
        public SearchPage(MainPage mainPage, User user)
        {
            InitializeComponent();
            this.mainPage = mainPage;
            this.user = user;
        }

        public SearchPage(MainPage mainPage)
        {
            InitializeComponent();
            this.mainPage = mainPage;
        }

        /// <summary>
        ///  של בחירות UserControl פונקציה שיוצרת
        /// </summary>
        private void CreateUcChoices()
        {
            this.UserControlChoices = new ucChoices(this, this.user);
            this.UserControlChoices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.UserControlChoices.Location = new System.Drawing.Point(202, 50);
            this.UserControlChoices.Name = "UserControlChoices";
            this.UserControlChoices.Size = new System.Drawing.Size(836, 734);
            this.UserControlChoices.TabIndex = 0;

            this.UserControlChoices.Location = new Point(this.Width / 2 - this.UserControlChoices.Width / 2,
                                                        this.UserControlChoices.Location.Y);
            this.Controls.Add(this.UserControlChoices);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            CreateUcChoices();
            this.DisconnectionBtn.Location = new Point(this.UserControlChoices.Location.X + this.UserControlChoices.Width - this.DisconnectionBtn.Width, 25);
        }

        private void DisconnectionBtn_Click(object sender, EventArgs e)
        {
            this.mainPage.Show();
            this.Close();
        }
    }
}
