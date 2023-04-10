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
    public partial class ATSPage : Form
    {
        public ATSPage()
        {
            InitializeComponent();
        }

        private void ATSPage_Load(object sender, EventArgs e)
        {
            this.TapTypePanel.Location = new Point(this.Width / 2 - this.TapTypePanel.Width / 2, this.TapTypePanel.Location.Y);
            ucCv ucCv = new ucCv();
            ucCv.Location = new Point((this.TapTypePanel.Location.X + this.TapTypePanel.Width / 2) - ucCv.Width / 2, 200);
            this.Controls.Add(ucCv);
        }
    }
}
