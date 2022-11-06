
namespace NoarJobUI
{
    partial class PostingJobPage
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
            this.PostPanel = new System.Windows.Forms.Panel();
            this.CountSameSearchesLbl = new System.Windows.Forms.Label();
            this.SameSearchesLbl = new System.Windows.Forms.Label();
            this.UpdateJobBtn = new System.Windows.Forms.Button();
            this.EmailTxt = new System.Windows.Forms.TextBox();
            this.EmailLbl = new System.Windows.Forms.Label();
            this.PhoneTxt = new System.Windows.Forms.TextBox();
            this.PhoneLbl = new System.Windows.Forms.Label();
            this.PostJobBtn = new System.Windows.Forms.Button();
            this.RequirementsTxt = new System.Windows.Forms.TextBox();
            this.RequirementsLbl = new System.Windows.Forms.Label();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.DescriptionLbl = new System.Windows.Forms.Label();
            this.JobTitleTxt = new System.Windows.Forms.TextBox();
            this.JobTitleLbl = new System.Windows.Forms.Label();
            this.DisconnectionBtn = new System.Windows.Forms.Button();
            this.PostPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PostPanel
            // 
            this.PostPanel.Controls.Add(this.CountSameSearchesLbl);
            this.PostPanel.Controls.Add(this.SameSearchesLbl);
            this.PostPanel.Controls.Add(this.UpdateJobBtn);
            this.PostPanel.Controls.Add(this.EmailTxt);
            this.PostPanel.Controls.Add(this.EmailLbl);
            this.PostPanel.Controls.Add(this.PhoneTxt);
            this.PostPanel.Controls.Add(this.PhoneLbl);
            this.PostPanel.Controls.Add(this.PostJobBtn);
            this.PostPanel.Controls.Add(this.RequirementsTxt);
            this.PostPanel.Controls.Add(this.RequirementsLbl);
            this.PostPanel.Controls.Add(this.DescriptionTxt);
            this.PostPanel.Controls.Add(this.DescriptionLbl);
            this.PostPanel.Controls.Add(this.JobTitleTxt);
            this.PostPanel.Controls.Add(this.JobTitleLbl);
            this.PostPanel.Location = new System.Drawing.Point(259, 199);
            this.PostPanel.Name = "PostPanel";
            this.PostPanel.Size = new System.Drawing.Size(836, 809);
            this.PostPanel.TabIndex = 3;
            // 
            // CountSameSearchesLbl
            // 
            this.CountSameSearchesLbl.AutoSize = true;
            this.CountSameSearchesLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CountSameSearchesLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.CountSameSearchesLbl.Location = new System.Drawing.Point(280, 0);
            this.CountSameSearchesLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CountSameSearchesLbl.Name = "CountSameSearchesLbl";
            this.CountSameSearchesLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CountSameSearchesLbl.Size = new System.Drawing.Size(29, 32);
            this.CountSameSearchesLbl.TabIndex = 19;
            this.CountSameSearchesLbl.Text = "0";
            // 
            // SameSearchesLbl
            // 
            this.SameSearchesLbl.AutoSize = true;
            this.SameSearchesLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SameSearchesLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.SameSearchesLbl.Location = new System.Drawing.Point(309, 0);
            this.SameSearchesLbl.Margin = new System.Windows.Forms.Padding(0);
            this.SameSearchesLbl.Name = "SameSearchesLbl";
            this.SameSearchesLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SameSearchesLbl.Size = new System.Drawing.Size(533, 32);
            this.SameSearchesLbl.TabIndex = 18;
            this.SameSearchesLbl.Text = "מספר האנשים שמחפשים משרה כמו שלך היא:";
            // 
            // UpdateJobBtn
            // 
            this.UpdateJobBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.UpdateJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UpdateJobBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.UpdateJobBtn.Location = new System.Drawing.Point(73, 735);
            this.UpdateJobBtn.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateJobBtn.Name = "UpdateJobBtn";
            this.UpdateJobBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.UpdateJobBtn.Size = new System.Drawing.Size(210, 39);
            this.UpdateJobBtn.TabIndex = 17;
            this.UpdateJobBtn.Text = "עדכן משרה!";
            this.UpdateJobBtn.UseVisualStyleBackColor = false;
            this.UpdateJobBtn.Visible = false;
            this.UpdateJobBtn.Click += new System.EventHandler(this.UpdateJobBtn_Click);
            // 
            // EmailTxt
            // 
            this.EmailTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmailTxt.Location = new System.Drawing.Point(427, 670);
            this.EmailTxt.Multiline = true;
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EmailTxt.Size = new System.Drawing.Size(409, 30);
            this.EmailTxt.TabIndex = 16;
            this.EmailTxt.Text = "למשל: blabla@gmail.com";
            // 
            // EmailLbl
            // 
            this.EmailLbl.AutoSize = true;
            this.EmailLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmailLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.EmailLbl.Location = new System.Drawing.Point(648, 618);
            this.EmailLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EmailLbl.Name = "EmailLbl";
            this.EmailLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EmailLbl.Size = new System.Drawing.Size(187, 32);
            this.EmailLbl.TabIndex = 15;
            this.EmailLbl.Text = "אימייל המשרה:";
            // 
            // PhoneTxt
            // 
            this.PhoneTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PhoneTxt.Location = new System.Drawing.Point(427, 568);
            this.PhoneTxt.Multiline = true;
            this.PhoneTxt.Name = "PhoneTxt";
            this.PhoneTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PhoneTxt.Size = new System.Drawing.Size(409, 30);
            this.PhoneTxt.TabIndex = 14;
            this.PhoneTxt.Text = "למשל: 055-5555555";
            // 
            // PhoneLbl
            // 
            this.PhoneLbl.AutoSize = true;
            this.PhoneLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PhoneLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.PhoneLbl.Location = new System.Drawing.Point(656, 516);
            this.PhoneLbl.Margin = new System.Windows.Forms.Padding(0);
            this.PhoneLbl.Name = "PhoneLbl";
            this.PhoneLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PhoneLbl.Size = new System.Drawing.Size(179, 32);
            this.PhoneLbl.TabIndex = 13;
            this.PhoneLbl.Text = "טלפון המשרה:";
            // 
            // PostJobBtn
            // 
            this.PostJobBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.PostJobBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PostJobBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.PostJobBtn.Location = new System.Drawing.Point(307, 735);
            this.PostJobBtn.Margin = new System.Windows.Forms.Padding(0);
            this.PostJobBtn.Name = "PostJobBtn";
            this.PostJobBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PostJobBtn.Size = new System.Drawing.Size(210, 39);
            this.PostJobBtn.TabIndex = 6;
            this.PostJobBtn.Text = "פרסם משרה!";
            this.PostJobBtn.UseVisualStyleBackColor = false;
            this.PostJobBtn.Click += new System.EventHandler(this.PostJobBtn_Click);
            // 
            // RequirementsTxt
            // 
            this.RequirementsTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RequirementsTxt.Location = new System.Drawing.Point(427, 384);
            this.RequirementsTxt.Multiline = true;
            this.RequirementsTxt.Name = "RequirementsTxt";
            this.RequirementsTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RequirementsTxt.Size = new System.Drawing.Size(409, 114);
            this.RequirementsTxt.TabIndex = 12;
            this.RequirementsTxt.Text = "כאן צריך לרשום אילו דרישות לתפקיד יש,\r\nמה צריך כדי להתאים לתפקיד";
            // 
            // RequirementsLbl
            // 
            this.RequirementsLbl.AutoSize = true;
            this.RequirementsLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RequirementsLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.RequirementsLbl.Location = new System.Drawing.Point(637, 332);
            this.RequirementsLbl.Margin = new System.Windows.Forms.Padding(0);
            this.RequirementsLbl.Name = "RequirementsLbl";
            this.RequirementsLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RequirementsLbl.Size = new System.Drawing.Size(204, 32);
            this.RequirementsLbl.TabIndex = 11;
            this.RequirementsLbl.Text = "דרישות התפקיד:";
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DescriptionTxt.Location = new System.Drawing.Point(427, 195);
            this.DescriptionTxt.Multiline = true;
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DescriptionTxt.Size = new System.Drawing.Size(409, 114);
            this.DescriptionTxt.TabIndex = 10;
            this.DescriptionTxt.Text = "כאן מתארים את התפקיד, מה כולל התפקיד, ותחומי האחריות שעל התפקיד";
            // 
            // DescriptionLbl
            // 
            this.DescriptionLbl.AutoSize = true;
            this.DescriptionLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DescriptionLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.DescriptionLbl.Location = new System.Drawing.Point(656, 145);
            this.DescriptionLbl.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionLbl.Name = "DescriptionLbl";
            this.DescriptionLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DescriptionLbl.Size = new System.Drawing.Size(185, 32);
            this.DescriptionLbl.TabIndex = 9;
            this.DescriptionLbl.Text = "תיאור התפקיד:";
            // 
            // JobTitleTxt
            // 
            this.JobTitleTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.JobTitleTxt.Location = new System.Drawing.Point(427, 94);
            this.JobTitleTxt.Multiline = true;
            this.JobTitleTxt.Name = "JobTitleTxt";
            this.JobTitleTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.JobTitleTxt.Size = new System.Drawing.Size(409, 30);
            this.JobTitleTxt.TabIndex = 8;
            this.JobTitleTxt.Text = "למשל: מוכר בגדים בקניון עיר ימים";
            // 
            // JobTitleLbl
            // 
            this.JobTitleLbl.AutoSize = true;
            this.JobTitleLbl.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.JobTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.JobTitleLbl.Location = new System.Drawing.Point(653, 42);
            this.JobTitleLbl.Margin = new System.Windows.Forms.Padding(0);
            this.JobTitleLbl.Name = "JobTitleLbl";
            this.JobTitleLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.JobTitleLbl.Size = new System.Drawing.Size(188, 32);
            this.JobTitleLbl.TabIndex = 7;
            this.JobTitleLbl.Text = "כותרת המשרה:";
            // 
            // DisconnectionBtn
            // 
            this.DisconnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.DisconnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DisconnectionBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.DisconnectionBtn.Location = new System.Drawing.Point(47, 325);
            this.DisconnectionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DisconnectionBtn.Name = "DisconnectionBtn";
            this.DisconnectionBtn.Size = new System.Drawing.Size(184, 39);
            this.DisconnectionBtn.TabIndex = 17;
            this.DisconnectionBtn.Text = "התנתק מהמשתמש";
            this.DisconnectionBtn.UseVisualStyleBackColor = false;
            this.DisconnectionBtn.Click += new System.EventHandler(this.DisconnectionBtn_Click);
            // 
            // PostingJobPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1132, 1061);
            this.Controls.Add(this.DisconnectionBtn);
            this.Controls.Add(this.PostPanel);
            this.Name = "PostingJobPage";
            this.Text = "PostingJobPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PostingJobPage_Load);
            this.PostPanel.ResumeLayout(false);
            this.PostPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label JobTitleLbl;
        private System.Windows.Forms.TextBox JobTitleTxt;
        public System.Windows.Forms.Label DescriptionLbl;
        private System.Windows.Forms.TextBox DescriptionTxt;
        private System.Windows.Forms.TextBox RequirementsTxt;
        public System.Windows.Forms.Label RequirementsLbl;
        public System.Windows.Forms.Panel PostPanel;
        public System.Windows.Forms.Button PostJobBtn;
        private System.Windows.Forms.TextBox EmailTxt;
        public System.Windows.Forms.Label EmailLbl;
        private System.Windows.Forms.TextBox PhoneTxt;
        public System.Windows.Forms.Label PhoneLbl;
        public System.Windows.Forms.Button UpdateJobBtn;
        public System.Windows.Forms.Button DisconnectionBtn;
        public System.Windows.Forms.Label SameSearchesLbl;
        public System.Windows.Forms.Label CountSameSearchesLbl;
    }
}