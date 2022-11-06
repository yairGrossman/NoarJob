namespace NoarJobUI
{
    partial class JobManagementPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProjectTitleLbl = new System.Windows.Forms.Label();
            this.ActiveJobPanel = new System.Windows.Forms.Panel();
            this.JobsInAirBtn = new System.Windows.Forms.Button();
            this.OldJobsBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DisconnectionBtn = new System.Windows.Forms.Button();
            this.ActiveJobPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectTitleLbl
            // 
            this.ProjectTitleLbl.AutoSize = true;
            this.ProjectTitleLbl.Font = new System.Drawing.Font("Arial", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProjectTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.ProjectTitleLbl.Location = new System.Drawing.Point(340, 32);
            this.ProjectTitleLbl.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectTitleLbl.Name = "ProjectTitleLbl";
            this.ProjectTitleLbl.Size = new System.Drawing.Size(246, 61);
            this.ProjectTitleLbl.TabIndex = 7;
            this.ProjectTitleLbl.Text = "NoarJob";
            // 
            // ActiveJobPanel
            // 
            this.ActiveJobPanel.Controls.Add(this.JobsInAirBtn);
            this.ActiveJobPanel.Controls.Add(this.OldJobsBtn);
            this.ActiveJobPanel.Location = new System.Drawing.Point(213, 119);
            this.ActiveJobPanel.Name = "ActiveJobPanel";
            this.ActiveJobPanel.Size = new System.Drawing.Size(494, 41);
            this.ActiveJobPanel.TabIndex = 8;
            // 
            // JobsInAirBtn
            // 
            this.JobsInAirBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.JobsInAirBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.JobsInAirBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.JobsInAirBtn.Location = new System.Drawing.Point(244, 0);
            this.JobsInAirBtn.Margin = new System.Windows.Forms.Padding(0);
            this.JobsInAirBtn.Name = "JobsInAirBtn";
            this.JobsInAirBtn.Size = new System.Drawing.Size(245, 38);
            this.JobsInAirBtn.TabIndex = 15;
            this.JobsInAirBtn.Text = "משרות באוויר";
            this.JobsInAirBtn.UseVisualStyleBackColor = false;
            this.JobsInAirBtn.Click += new System.EventHandler(this.JobsInAirBtn_Click);
            // 
            // OldJobsBtn
            // 
            this.OldJobsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.OldJobsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.OldJobsBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.OldJobsBtn.Location = new System.Drawing.Point(0, 0);
            this.OldJobsBtn.Margin = new System.Windows.Forms.Padding(0);
            this.OldJobsBtn.Name = "OldJobsBtn";
            this.OldJobsBtn.Size = new System.Drawing.Size(244, 39);
            this.OldJobsBtn.TabIndex = 16;
            this.OldJobsBtn.Text = "משרות ישנות";
            this.OldJobsBtn.UseVisualStyleBackColor = false;
            this.OldJobsBtn.Click += new System.EventHandler(this.OldJobsBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(181, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 585);
            this.panel2.TabIndex = 9;
            this.panel2.Visible = false;
            // 
            // DisconnectionBtn
            // 
            this.DisconnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.DisconnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DisconnectionBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.DisconnectionBtn.Location = new System.Drawing.Point(756, 41);
            this.DisconnectionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DisconnectionBtn.Name = "DisconnectionBtn";
            this.DisconnectionBtn.Size = new System.Drawing.Size(184, 39);
            this.DisconnectionBtn.TabIndex = 18;
            this.DisconnectionBtn.Text = "התנתק מהמשתמש";
            this.DisconnectionBtn.UseVisualStyleBackColor = false;
            this.DisconnectionBtn.Click += new System.EventHandler(this.DisconnectionBtn_Click);
            // 
            // JobManagementPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(996, 855);
            this.Controls.Add(this.DisconnectionBtn);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ActiveJobPanel);
            this.Controls.Add(this.ProjectTitleLbl);
            this.Name = "JobManagementPage";
            this.Text = "JobManagementPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JobManagementPage_Load);
            this.ActiveJobPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label ProjectTitleLbl;
        private System.Windows.Forms.Panel ActiveJobPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button JobsInAirBtn;
        private System.Windows.Forms.Button OldJobsBtn;
        public System.Windows.Forms.Button DisconnectionBtn;
    }
}