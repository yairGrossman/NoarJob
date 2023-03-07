
namespace NoarJobUI
{
    partial class HomePage
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
            this.ManageJobsPageBtn = new System.Windows.Forms.Button();
            this.PostingJobPageBtn = new System.Windows.Forms.Button();
            this.GreenPanel = new System.Windows.Forms.Panel();
            this.AutoSearchPageBtn = new System.Windows.Forms.Button();
            this.HistoryPageBtn = new System.Windows.Forms.Button();
            this.SearchPageBtn = new System.Windows.Forms.Button();
            this.ProjectTitleLbl = new System.Windows.Forms.Label();
            this.DisconnectionBtn = new System.Windows.Forms.Button();
            this.GreenPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ManageJobsPageBtn
            // 
            this.ManageJobsPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.ManageJobsPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ManageJobsPageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.ManageJobsPageBtn.Location = new System.Drawing.Point(762, 246);
            this.ManageJobsPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.ManageJobsPageBtn.Name = "ManageJobsPageBtn";
            this.ManageJobsPageBtn.Size = new System.Drawing.Size(244, 39);
            this.ManageJobsPageBtn.TabIndex = 15;
            this.ManageJobsPageBtn.Text = "כניסה לדף ניהול משרות";
            this.ManageJobsPageBtn.UseVisualStyleBackColor = false;
            this.ManageJobsPageBtn.Visible = false;
            this.ManageJobsPageBtn.Click += new System.EventHandler(this.ManageJobsPageBtn_Click);
            // 
            // PostingJobPageBtn
            // 
            this.PostingJobPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.PostingJobPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PostingJobPageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PostingJobPageBtn.Location = new System.Drawing.Point(762, 171);
            this.PostingJobPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PostingJobPageBtn.Name = "PostingJobPageBtn";
            this.PostingJobPageBtn.Size = new System.Drawing.Size(244, 39);
            this.PostingJobPageBtn.TabIndex = 14;
            this.PostingJobPageBtn.Text = "כניסה לדף פרסום משרה";
            this.PostingJobPageBtn.UseVisualStyleBackColor = false;
            this.PostingJobPageBtn.Visible = false;
            this.PostingJobPageBtn.Click += new System.EventHandler(this.PostingJobPageBtn_Click);
            // 
            // GreenPanel
            // 
            this.GreenPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(180)))), ((int)(((byte)(159)))));
            this.GreenPanel.Controls.Add(this.AutoSearchPageBtn);
            this.GreenPanel.Controls.Add(this.HistoryPageBtn);
            this.GreenPanel.Controls.Add(this.SearchPageBtn);
            this.GreenPanel.Controls.Add(this.ProjectTitleLbl);
            this.GreenPanel.Location = new System.Drawing.Point(315, 106);
            this.GreenPanel.Name = "GreenPanel";
            this.GreenPanel.Size = new System.Drawing.Size(444, 406);
            this.GreenPanel.TabIndex = 13;
            // 
            // AutoSearchPageBtn
            // 
            this.AutoSearchPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.AutoSearchPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AutoSearchPageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.AutoSearchPageBtn.Location = new System.Drawing.Point(95, 285);
            this.AutoSearchPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AutoSearchPageBtn.Name = "AutoSearchPageBtn";
            this.AutoSearchPageBtn.Size = new System.Drawing.Size(265, 39);
            this.AutoSearchPageBtn.TabIndex = 10;
            this.AutoSearchPageBtn.Text = "כניסה לדף חיפוש אוטומטי";
            this.AutoSearchPageBtn.UseVisualStyleBackColor = false;
            this.AutoSearchPageBtn.Click += new System.EventHandler(this.AutoSearchPageBtn_Click);
            // 
            // HistoryPageBtn
            // 
            this.HistoryPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.HistoryPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.HistoryPageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.HistoryPageBtn.Location = new System.Drawing.Point(26, 197);
            this.HistoryPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.HistoryPageBtn.Name = "HistoryPageBtn";
            this.HistoryPageBtn.Size = new System.Drawing.Size(396, 39);
            this.HistoryPageBtn.TabIndex = 9;
            this.HistoryPageBtn.Text = "כניסה לדף היסטוריית שליחת מועמדות";
            this.HistoryPageBtn.UseVisualStyleBackColor = false;
            // 
            // SearchPageBtn
            // 
            this.SearchPageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.SearchPageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SearchPageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SearchPageBtn.Location = new System.Drawing.Point(104, 113);
            this.SearchPageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPageBtn.Name = "SearchPageBtn";
            this.SearchPageBtn.Size = new System.Drawing.Size(244, 39);
            this.SearchPageBtn.TabIndex = 8;
            this.SearchPageBtn.Text = "כניסה לדף חיפוש משרות";
            this.SearchPageBtn.UseVisualStyleBackColor = false;
            //this.SearchPageBtn.Click += new System.EventHandler(this.SearchPageBtn_Click);
            // 
            // ProjectTitleLbl
            // 
            this.ProjectTitleLbl.AutoSize = true;
            this.ProjectTitleLbl.Font = new System.Drawing.Font("Arial", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProjectTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.ProjectTitleLbl.Location = new System.Drawing.Point(102, 12);
            this.ProjectTitleLbl.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectTitleLbl.Name = "ProjectTitleLbl";
            this.ProjectTitleLbl.Size = new System.Drawing.Size(246, 61);
            this.ProjectTitleLbl.TabIndex = 6;
            this.ProjectTitleLbl.Text = "NoarJob";
            // 
            // DisconnectionBtn
            // 
            this.DisconnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.DisconnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DisconnectionBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.DisconnectionBtn.Location = new System.Drawing.Point(575, 31);
            this.DisconnectionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DisconnectionBtn.Name = "DisconnectionBtn";
            this.DisconnectionBtn.Size = new System.Drawing.Size(184, 39);
            this.DisconnectionBtn.TabIndex = 16;
            this.DisconnectionBtn.Text = "התנתק מהמשתמש";
            this.DisconnectionBtn.UseVisualStyleBackColor = false;
            this.DisconnectionBtn.Click += new System.EventHandler(this.DisconnectionBtn_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1101, 717);
            this.Controls.Add(this.DisconnectionBtn);
            this.Controls.Add(this.ManageJobsPageBtn);
            this.Controls.Add(this.PostingJobPageBtn);
            this.Controls.Add(this.GreenPanel);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.GreenPanel.ResumeLayout(false);
            this.GreenPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button ManageJobsPageBtn;
        public System.Windows.Forms.Button PostingJobPageBtn;
        private System.Windows.Forms.Panel GreenPanel;
        public System.Windows.Forms.Button AutoSearchPageBtn;
        public System.Windows.Forms.Button HistoryPageBtn;
        public System.Windows.Forms.Button SearchPageBtn;
        public System.Windows.Forms.Label ProjectTitleLbl;
        public System.Windows.Forms.Button DisconnectionBtn;
    }
}