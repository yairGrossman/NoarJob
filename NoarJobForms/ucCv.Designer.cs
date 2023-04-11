namespace NoarJobUI
{
    partial class ucCv
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CvsPanel = new System.Windows.Forms.Panel();
            this.SaveNoteBtn = new System.Windows.Forms.Button();
            this.DescriptionTxt = new System.Windows.Forms.TextBox();
            this.AddNoteLbl = new System.Windows.Forms.Label();
            this.CvBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CityLbl = new System.Windows.Forms.Label();
            this.PhoneLbl = new System.Windows.Forms.Label();
            this.LastNameLbl = new System.Windows.Forms.Label();
            this.FirstNameLbl = new System.Windows.Forms.Label();
            this.MailLbl = new System.Windows.Forms.Label();
            this.NotSuitableBtn = new System.Windows.Forms.Button();
            this.NextStageBtn = new System.Windows.Forms.Button();
            this.CvsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CvsPanel
            // 
            this.CvsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(180)))), ((int)(((byte)(159)))));
            this.CvsPanel.Controls.Add(this.NextStageBtn);
            this.CvsPanel.Controls.Add(this.NotSuitableBtn);
            this.CvsPanel.Controls.Add(this.SaveNoteBtn);
            this.CvsPanel.Controls.Add(this.DescriptionTxt);
            this.CvsPanel.Controls.Add(this.AddNoteLbl);
            this.CvsPanel.Controls.Add(this.CvBtn);
            this.CvsPanel.Controls.Add(this.label2);
            this.CvsPanel.Controls.Add(this.CityLbl);
            this.CvsPanel.Controls.Add(this.PhoneLbl);
            this.CvsPanel.Controls.Add(this.LastNameLbl);
            this.CvsPanel.Controls.Add(this.FirstNameLbl);
            this.CvsPanel.Controls.Add(this.MailLbl);
            this.CvsPanel.Location = new System.Drawing.Point(3, 3);
            this.CvsPanel.Name = "CvsPanel";
            this.CvsPanel.Size = new System.Drawing.Size(500, 381);
            this.CvsPanel.TabIndex = 0;
            // 
            // SaveNoteBtn
            // 
            this.SaveNoteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.SaveNoteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SaveNoteBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.SaveNoteBtn.Location = new System.Drawing.Point(351, 341);
            this.SaveNoteBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SaveNoteBtn.Name = "SaveNoteBtn";
            this.SaveNoteBtn.Size = new System.Drawing.Size(137, 35);
            this.SaveNoteBtn.TabIndex = 23;
            this.SaveNoteBtn.Text = "שמירת הערה";
            this.SaveNoteBtn.UseVisualStyleBackColor = false;
            this.SaveNoteBtn.Click += new System.EventHandler(this.SaveNoteBtn_Click);
            // 
            // DescriptionTxt
            // 
            this.DescriptionTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DescriptionTxt.Location = new System.Drawing.Point(79, 224);
            this.DescriptionTxt.Multiline = true;
            this.DescriptionTxt.Name = "DescriptionTxt";
            this.DescriptionTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DescriptionTxt.Size = new System.Drawing.Size(409, 114);
            this.DescriptionTxt.TabIndex = 22;
            // 
            // AddNoteLbl
            // 
            this.AddNoteLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AddNoteLbl.ForeColor = System.Drawing.Color.DarkBlue;
            this.AddNoteLbl.Location = new System.Drawing.Point(375, 190);
            this.AddNoteLbl.Name = "AddNoteLbl";
            this.AddNoteLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AddNoteLbl.Size = new System.Drawing.Size(117, 31);
            this.AddNoteLbl.TabIndex = 20;
            this.AddNoteLbl.Text = "הוספת הערה";
            // 
            // CvBtn
            // 
            this.CvBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.CvBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CvBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.CvBtn.Location = new System.Drawing.Point(20, 136);
            this.CvBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CvBtn.Name = "CvBtn";
            this.CvBtn.Size = new System.Drawing.Size(120, 35);
            this.CvBtn.TabIndex = 19;
            this.CvBtn.Text = "קורות חיים";
            this.CvBtn.UseVisualStyleBackColor = false;
            this.CvBtn.Click += new System.EventHandler(this.CvBtn_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(107, 142);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(385, 31);
            this.label2.TabIndex = 18;
            this.label2.Text = "בשביל לפתוח את קובץ קורות החיים לחץ כאן:";
            // 
            // CityLbl
            // 
            this.CityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CityLbl.Location = new System.Drawing.Point(9, 95);
            this.CityLbl.Name = "CityLbl";
            this.CityLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CityLbl.Size = new System.Drawing.Size(210, 31);
            this.CityLbl.TabIndex = 17;
            this.CityLbl.Text = "עיר מגורים: ";
            // 
            // PhoneLbl
            // 
            this.PhoneLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PhoneLbl.Location = new System.Drawing.Point(282, 95);
            this.PhoneLbl.Name = "PhoneLbl";
            this.PhoneLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PhoneLbl.Size = new System.Drawing.Size(210, 31);
            this.PhoneLbl.TabIndex = 16;
            this.PhoneLbl.Text = "מספר נייד: ";
            // 
            // LastNameLbl
            // 
            this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LastNameLbl.Location = new System.Drawing.Point(3, 50);
            this.LastNameLbl.Name = "LastNameLbl";
            this.LastNameLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LastNameLbl.Size = new System.Drawing.Size(216, 31);
            this.LastNameLbl.TabIndex = 15;
            this.LastNameLbl.Text = "שם משפחה: ";
            // 
            // FirstNameLbl
            // 
            this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FirstNameLbl.Location = new System.Drawing.Point(249, 50);
            this.FirstNameLbl.Name = "FirstNameLbl";
            this.FirstNameLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.FirstNameLbl.Size = new System.Drawing.Size(243, 31);
            this.FirstNameLbl.TabIndex = 14;
            this.FirstNameLbl.Text = "שם פרטי: ";
            // 
            // MailLbl
            // 
            this.MailLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MailLbl.Location = new System.Drawing.Point(9, 7);
            this.MailLbl.Name = "MailLbl";
            this.MailLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MailLbl.Size = new System.Drawing.Size(483, 31);
            this.MailLbl.TabIndex = 13;
            this.MailLbl.Text = "כתובת מייל: ";
            // 
            // NotSuitableBtn
            // 
            this.NotSuitableBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.NotSuitableBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NotSuitableBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.NotSuitableBtn.Location = new System.Drawing.Point(215, 341);
            this.NotSuitableBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NotSuitableBtn.Name = "NotSuitableBtn";
            this.NotSuitableBtn.Size = new System.Drawing.Size(131, 35);
            this.NotSuitableBtn.TabIndex = 24;
            this.NotSuitableBtn.Text = "לא מתאים";
            this.NotSuitableBtn.UseVisualStyleBackColor = false;
            this.NotSuitableBtn.Click += new System.EventHandler(this.NotSuitableBtn_Click);
            // 
            // NextStageBtn
            // 
            this.NextStageBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.NextStageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NextStageBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.NextStageBtn.Location = new System.Drawing.Point(77, 341);
            this.NextStageBtn.Margin = new System.Windows.Forms.Padding(0);
            this.NextStageBtn.Name = "NextStageBtn";
            this.NextStageBtn.Size = new System.Drawing.Size(131, 35);
            this.NextStageBtn.TabIndex = 25;
            this.NextStageBtn.Text = "שלב הבא";
            this.NextStageBtn.UseVisualStyleBackColor = false;
            this.NextStageBtn.Click += new System.EventHandler(this.NextStageBtn_Click);
            // 
            // ucCv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CvsPanel);
            this.Name = "ucCv";
            this.Size = new System.Drawing.Size(507, 387);
            this.Load += new System.EventHandler(this.ucCv_Load);
            this.CvsPanel.ResumeLayout(false);
            this.CvsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel CvsPanel;
        public System.Windows.Forms.Button SaveNoteBtn;
        private System.Windows.Forms.TextBox DescriptionTxt;
        private System.Windows.Forms.Label AddNoteLbl;
        public System.Windows.Forms.Button CvBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CityLbl;
        private System.Windows.Forms.Label PhoneLbl;
        private System.Windows.Forms.Label LastNameLbl;
        private System.Windows.Forms.Label FirstNameLbl;
        private System.Windows.Forms.Label MailLbl;
        public System.Windows.Forms.Button NotSuitableBtn;
        public System.Windows.Forms.Button NextStageBtn;
    }
}
