
namespace NoarJobUI
{
    partial class MainPage
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
            this.ChooseUserLbl = new System.Windows.Forms.Label();
            this.CandidateBtn = new System.Windows.Forms.Button();
            this.EmployerBtn = new System.Windows.Forms.Button();
            this.AnonymousBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectTitleLbl
            // 
            this.ProjectTitleLbl.AutoSize = true;
            this.ProjectTitleLbl.Font = new System.Drawing.Font("Arial", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProjectTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.ProjectTitleLbl.Location = new System.Drawing.Point(38, 9);
            this.ProjectTitleLbl.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectTitleLbl.Name = "ProjectTitleLbl";
            this.ProjectTitleLbl.Size = new System.Drawing.Size(246, 61);
            this.ProjectTitleLbl.TabIndex = 5;
            this.ProjectTitleLbl.Text = "NoarJob";
            // 
            // ChooseUserLbl
            // 
            this.ChooseUserLbl.AutoSize = true;
            this.ChooseUserLbl.Font = new System.Drawing.Font("Arial", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ChooseUserLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.ChooseUserLbl.Location = new System.Drawing.Point(6, 83);
            this.ChooseUserLbl.Margin = new System.Windows.Forms.Padding(0);
            this.ChooseUserLbl.Name = "ChooseUserLbl";
            this.ChooseUserLbl.Size = new System.Drawing.Size(302, 46);
            this.ChooseUserLbl.TabIndex = 6;
            this.ChooseUserLbl.Text = "בחר דרך הזדהות";
            // 
            // CandidateBtn
            // 
            this.CandidateBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.CandidateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CandidateBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.CandidateBtn.Location = new System.Drawing.Point(49, 159);
            this.CandidateBtn.Margin = new System.Windows.Forms.Padding(0);
            this.CandidateBtn.Name = "CandidateBtn";
            this.CandidateBtn.Size = new System.Drawing.Size(210, 39);
            this.CandidateBtn.TabIndex = 7;
            this.CandidateBtn.Text = "כניסה כמועמד";
            this.CandidateBtn.UseVisualStyleBackColor = false;
            this.CandidateBtn.Click += new System.EventHandler(this.CandidateBtn_Click);
            // 
            // EmployerBtn
            // 
            this.EmployerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.EmployerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmployerBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.EmployerBtn.Location = new System.Drawing.Point(49, 217);
            this.EmployerBtn.Margin = new System.Windows.Forms.Padding(0);
            this.EmployerBtn.Name = "EmployerBtn";
            this.EmployerBtn.Size = new System.Drawing.Size(210, 39);
            this.EmployerBtn.TabIndex = 8;
            this.EmployerBtn.Text = "כניסה כמעסיק";
            this.EmployerBtn.UseVisualStyleBackColor = false;
            this.EmployerBtn.Click += new System.EventHandler(this.EmployerBtn_Click);
            // 
            // AnonymousBtn
            // 
            this.AnonymousBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.AnonymousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AnonymousBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.AnonymousBtn.Location = new System.Drawing.Point(49, 272);
            this.AnonymousBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AnonymousBtn.Name = "AnonymousBtn";
            this.AnonymousBtn.Size = new System.Drawing.Size(210, 39);
            this.AnonymousBtn.TabIndex = 9;
            this.AnonymousBtn.Text = "כניסה ללא משתמש";
            this.AnonymousBtn.UseVisualStyleBackColor = false;
            this.AnonymousBtn.Click += new System.EventHandler(this.AnonymousBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ProjectTitleLbl);
            this.panel1.Controls.Add(this.AnonymousBtn);
            this.panel1.Controls.Add(this.ChooseUserLbl);
            this.panel1.Controls.Add(this.EmployerBtn);
            this.panel1.Controls.Add(this.CandidateBtn);
            this.panel1.Location = new System.Drawing.Point(194, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 333);
            this.panel1.TabIndex = 10;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(982, 836);
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label ProjectTitleLbl;
        public System.Windows.Forms.Label ChooseUserLbl;
        public System.Windows.Forms.Button CandidateBtn;
        public System.Windows.Forms.Button EmployerBtn;
        public System.Windows.Forms.Button AnonymousBtn;
        private System.Windows.Forms.Panel panel1;
    }
}