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
    public partial class JobsPage : Form
    {
        private ucChoices UserControlChoices;
        private ucJob UserControlJob;
        private Job[]  jobsArr;
        private User user;

        public ucJob UserControlJobs
        {
            get { return this.UserControlJob; }
        }

        public JobsPage(Job[] jobsArr, User user)
        {
            InitializeComponent();
            this.jobsArr = jobsArr;
            this.user = user;
        }

        /// <summary>
        ///  של בחירות UserControl פונקציה שיוצרת
        /// </summary>
        private void CreateUcChoices()
        {
            this.UserControlChoices = new ucChoices(this, this.user);
            this.UserControlChoices.BackColor = Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.UserControlChoices.Name = "UserControlChoices";
            this.UserControlChoices.TabIndex = 6;
            this.Controls.Add(this.UserControlChoices);
        }

        /// <summary>
        ///  של משרות UserControl פונקציה שיוצרת
        /// </summary>
        private void CreateUcJob()
        {
            this.UserControlJob = new ucJob(this.jobsArr, this, this.user);
            this.UserControlJob.Name = "UserControlJob";
            this.Controls.Add(this.UserControlJob);
        }

        private void JobsPage_Load(object sender, EventArgs e)
        {
            CreateUcJob();
            CreateUcChoices();

            this.UserControlChoices.Location = new Point(this.Width / 2 - this.UserControlChoices.Width / 2, this.UserControlChoices.Location.Y);
            this.UserControlJob.Location = new Point(this.Width / 2 - this.UserControlJob.Width / 2, 330);
        }
    }
}
