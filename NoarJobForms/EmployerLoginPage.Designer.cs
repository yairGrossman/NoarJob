
namespace NoarJobUI
{
    partial class EmployerLoginPage
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
            this.SignUpPanel = new System.Windows.Forms.Panel();
            this.SigninBtn = new System.Windows.Forms.Button();
            this.AccountLbl = new System.Windows.Forms.Label();
            this.CompanyEmailLbl = new System.Windows.Forms.Label();
            this.CompanyEmailTxt = new System.Windows.Forms.TextBox();
            this.AccountBtn = new System.Windows.Forms.Button();
            this.CompanyNameLbl = new System.Windows.Forms.Label();
            this.CompanyNameTxt = new System.Windows.Forms.TextBox();
            this.CompanyTypeDropDown = new System.Windows.Forms.ComboBox();
            this.EmployerPasswordLbl = new System.Windows.Forms.Label();
            this.EmployerPasswordTxt = new System.Windows.Forms.TextBox();
            this.CompanyTypeLbl = new System.Windows.Forms.Label();
            this.NumOfEmployeesLbl = new System.Windows.Forms.Label();
            this.NumOfEmployeesTxt = new System.Windows.Forms.TextBox();
            this.EmployerNameLbl = new System.Windows.Forms.Label();
            this.EmployerNameTxt = new System.Windows.Forms.TextBox();
            this.SignUpLbl = new System.Windows.Forms.Label();
            this.ProjectTitleLbl = new System.Windows.Forms.Label();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.SignUpBtn = new System.Windows.Forms.Button();
            this.SignUpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SignUpPanel
            // 
            this.SignUpPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(180)))), ((int)(((byte)(159)))));
            this.SignUpPanel.Controls.Add(this.SigninBtn);
            this.SignUpPanel.Controls.Add(this.AccountLbl);
            this.SignUpPanel.Controls.Add(this.CompanyEmailLbl);
            this.SignUpPanel.Controls.Add(this.CompanyEmailTxt);
            this.SignUpPanel.Controls.Add(this.AccountBtn);
            this.SignUpPanel.Controls.Add(this.CompanyNameLbl);
            this.SignUpPanel.Controls.Add(this.CompanyNameTxt);
            this.SignUpPanel.Controls.Add(this.CompanyTypeDropDown);
            this.SignUpPanel.Controls.Add(this.EmployerPasswordLbl);
            this.SignUpPanel.Controls.Add(this.EmployerPasswordTxt);
            this.SignUpPanel.Controls.Add(this.CompanyTypeLbl);
            this.SignUpPanel.Controls.Add(this.NumOfEmployeesLbl);
            this.SignUpPanel.Controls.Add(this.NumOfEmployeesTxt);
            this.SignUpPanel.Controls.Add(this.EmployerNameLbl);
            this.SignUpPanel.Controls.Add(this.EmployerNameTxt);
            this.SignUpPanel.Controls.Add(this.SignUpLbl);
            this.SignUpPanel.Controls.Add(this.ProjectTitleLbl);
            this.SignUpPanel.Location = new System.Drawing.Point(223, 18);
            this.SignUpPanel.Name = "SignUpPanel";
            this.SignUpPanel.Size = new System.Drawing.Size(491, 591);
            this.SignUpPanel.TabIndex = 18;
            // 
            // SigninBtn
            // 
            this.SigninBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.SigninBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SigninBtn.ForeColor = System.Drawing.Color.GhostWhite;
            this.SigninBtn.Location = new System.Drawing.Point(135, 538);
            this.SigninBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SigninBtn.Name = "SigninBtn";
            this.SigninBtn.Size = new System.Drawing.Size(76, 26);
            this.SigninBtn.TabIndex = 26;
            this.SigninBtn.Text = "להתחבר";
            this.SigninBtn.UseVisualStyleBackColor = false;
            this.SigninBtn.Click += new System.EventHandler(this.SigninBtn_Click);
            // 
            // AccountLbl
            // 
            this.AccountLbl.AutoSize = true;
            this.AccountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AccountLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.AccountLbl.Location = new System.Drawing.Point(221, 538);
            this.AccountLbl.Margin = new System.Windows.Forms.Padding(0);
            this.AccountLbl.Name = "AccountLbl";
            this.AccountLbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AccountLbl.Size = new System.Drawing.Size(177, 26);
            this.AccountLbl.TabIndex = 25;
            this.AccountLbl.Text = "כבר יש לך חשבון?";
            this.AccountLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CompanyEmailLbl
            // 
            this.CompanyEmailLbl.AutoSize = true;
            this.CompanyEmailLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyEmailLbl.ForeColor = System.Drawing.Color.Black;
            this.CompanyEmailLbl.Location = new System.Drawing.Point(287, 368);
            this.CompanyEmailLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyEmailLbl.Name = "CompanyEmailLbl";
            this.CompanyEmailLbl.Size = new System.Drawing.Size(183, 26);
            this.CompanyEmailLbl.TabIndex = 25;
            this.CompanyEmailLbl.Text = "האימייל של החברה";
            // 
            // CompanyEmailTxt
            // 
            this.CompanyEmailTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.CompanyEmailTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyEmailTxt.ForeColor = System.Drawing.Color.Black;
            this.CompanyEmailTxt.Location = new System.Drawing.Point(25, 371);
            this.CompanyEmailTxt.Name = "CompanyEmailTxt";
            this.CompanyEmailTxt.Size = new System.Drawing.Size(259, 23);
            this.CompanyEmailTxt.TabIndex = 24;
            // 
            // AccountBtn
            // 
            this.AccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.AccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.AccountBtn.ForeColor = System.Drawing.Color.GhostWhite;
            this.AccountBtn.Location = new System.Drawing.Point(148, 478);
            this.AccountBtn.Margin = new System.Windows.Forms.Padding(0);
            this.AccountBtn.Name = "AccountBtn";
            this.AccountBtn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AccountBtn.Size = new System.Drawing.Size(210, 39);
            this.AccountBtn.TabIndex = 23;
            this.AccountBtn.Text = "צור חשבון";
            this.AccountBtn.UseVisualStyleBackColor = false;
            this.AccountBtn.Click += new System.EventHandler(this.AccountBtn_Click);
            // 
            // CompanyNameLbl
            // 
            this.CompanyNameLbl.AutoSize = true;
            this.CompanyNameLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyNameLbl.ForeColor = System.Drawing.Color.Black;
            this.CompanyNameLbl.Location = new System.Drawing.Point(361, 318);
            this.CompanyNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyNameLbl.Name = "CompanyNameLbl";
            this.CompanyNameLbl.Size = new System.Drawing.Size(112, 26);
            this.CompanyNameLbl.TabIndex = 20;
            this.CompanyNameLbl.Text = "שם החברה";
            // 
            // CompanyNameTxt
            // 
            this.CompanyNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.CompanyNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyNameTxt.ForeColor = System.Drawing.Color.Black;
            this.CompanyNameTxt.Location = new System.Drawing.Point(25, 321);
            this.CompanyNameTxt.Name = "CompanyNameTxt";
            this.CompanyNameTxt.Size = new System.Drawing.Size(259, 23);
            this.CompanyNameTxt.TabIndex = 19;
            // 
            // CompanyTypeDropDown
            // 
            this.CompanyTypeDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.CompanyTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompanyTypeDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyTypeDropDown.ForeColor = System.Drawing.SystemColors.MenuText;
            this.CompanyTypeDropDown.FormattingEnabled = true;
            this.CompanyTypeDropDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CompanyTypeDropDown.Location = new System.Drawing.Point(25, 271);
            this.CompanyTypeDropDown.Name = "CompanyTypeDropDown";
            this.CompanyTypeDropDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CompanyTypeDropDown.Size = new System.Drawing.Size(282, 26);
            this.CompanyTypeDropDown.TabIndex = 18;
            this.CompanyTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.CompanyTypeDropDown_SelectedIndexChanged);
            // 
            // EmployerPasswordLbl
            // 
            this.EmployerPasswordLbl.AutoSize = true;
            this.EmployerPasswordLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmployerPasswordLbl.ForeColor = System.Drawing.Color.Black;
            this.EmployerPasswordLbl.Location = new System.Drawing.Point(397, 421);
            this.EmployerPasswordLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EmployerPasswordLbl.Name = "EmployerPasswordLbl";
            this.EmployerPasswordLbl.Size = new System.Drawing.Size(73, 26);
            this.EmployerPasswordLbl.TabIndex = 15;
            this.EmployerPasswordLbl.Text = "סיסמה";
            // 
            // EmployerPasswordTxt
            // 
            this.EmployerPasswordTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.EmployerPasswordTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmployerPasswordTxt.ForeColor = System.Drawing.Color.Black;
            this.EmployerPasswordTxt.Location = new System.Drawing.Point(25, 424);
            this.EmployerPasswordTxt.Name = "EmployerPasswordTxt";
            this.EmployerPasswordTxt.Size = new System.Drawing.Size(259, 23);
            this.EmployerPasswordTxt.TabIndex = 14;
            this.EmployerPasswordTxt.UseSystemPasswordChar = true;
            // 
            // CompanyTypeLbl
            // 
            this.CompanyTypeLbl.AutoSize = true;
            this.CompanyTypeLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CompanyTypeLbl.ForeColor = System.Drawing.Color.Black;
            this.CompanyTypeLbl.Location = new System.Drawing.Point(311, 270);
            this.CompanyTypeLbl.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyTypeLbl.Name = "CompanyTypeLbl";
            this.CompanyTypeLbl.Size = new System.Drawing.Size(162, 26);
            this.CompanyTypeLbl.TabIndex = 13;
            this.CompanyTypeLbl.Text = "קטגוריית החברה";
            // 
            // NumOfEmployeesLbl
            // 
            this.NumOfEmployeesLbl.AutoSize = true;
            this.NumOfEmployeesLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NumOfEmployeesLbl.ForeColor = System.Drawing.Color.Black;
            this.NumOfEmployeesLbl.Location = new System.Drawing.Point(328, 220);
            this.NumOfEmployeesLbl.Margin = new System.Windows.Forms.Padding(0);
            this.NumOfEmployeesLbl.Name = "NumOfEmployeesLbl";
            this.NumOfEmployeesLbl.Size = new System.Drawing.Size(144, 26);
            this.NumOfEmployeesLbl.TabIndex = 11;
            this.NumOfEmployeesLbl.Text = "מספר העובדים";
            // 
            // NumOfEmployeesTxt
            // 
            this.NumOfEmployeesTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.NumOfEmployeesTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.NumOfEmployeesTxt.ForeColor = System.Drawing.Color.Black;
            this.NumOfEmployeesTxt.Location = new System.Drawing.Point(25, 223);
            this.NumOfEmployeesTxt.Name = "NumOfEmployeesTxt";
            this.NumOfEmployeesTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NumOfEmployeesTxt.Size = new System.Drawing.Size(259, 23);
            this.NumOfEmployeesTxt.TabIndex = 10;
            // 
            // EmployerNameLbl
            // 
            this.EmployerNameLbl.AutoSize = true;
            this.EmployerNameLbl.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmployerNameLbl.ForeColor = System.Drawing.Color.Black;
            this.EmployerNameLbl.Location = new System.Drawing.Point(354, 169);
            this.EmployerNameLbl.Margin = new System.Windows.Forms.Padding(0);
            this.EmployerNameLbl.Name = "EmployerNameLbl";
            this.EmployerNameLbl.Size = new System.Drawing.Size(118, 26);
            this.EmployerNameLbl.TabIndex = 9;
            this.EmployerNameLbl.Text = "שם המעסיק";
            // 
            // EmployerNameTxt
            // 
            this.EmployerNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.EmployerNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EmployerNameTxt.ForeColor = System.Drawing.Color.Black;
            this.EmployerNameTxt.Location = new System.Drawing.Point(25, 172);
            this.EmployerNameTxt.Name = "EmployerNameTxt";
            this.EmployerNameTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EmployerNameTxt.Size = new System.Drawing.Size(259, 23);
            this.EmployerNameTxt.TabIndex = 8;
            // 
            // SignUpLbl
            // 
            this.SignUpLbl.AutoSize = true;
            this.SignUpLbl.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SignUpLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(120)))), ((int)(((byte)(97)))));
            this.SignUpLbl.Location = new System.Drawing.Point(176, 82);
            this.SignUpLbl.Margin = new System.Windows.Forms.Padding(0);
            this.SignUpLbl.Name = "SignUpLbl";
            this.SignUpLbl.Size = new System.Drawing.Size(146, 46);
            this.SignUpLbl.TabIndex = 7;
            this.SignUpLbl.Text = "הרשמה";
            // 
            // ProjectTitleLbl
            // 
            this.ProjectTitleLbl.AutoSize = true;
            this.ProjectTitleLbl.Font = new System.Drawing.Font("Arial", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProjectTitleLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.ProjectTitleLbl.Location = new System.Drawing.Point(124, 21);
            this.ProjectTitleLbl.Margin = new System.Windows.Forms.Padding(0);
            this.ProjectTitleLbl.Name = "ProjectTitleLbl";
            this.ProjectTitleLbl.Size = new System.Drawing.Size(246, 61);
            this.ProjectTitleLbl.TabIndex = 6;
            this.ProjectTitleLbl.Text = "NoarJob";
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LoginBtn.ForeColor = System.Drawing.Color.GhostWhite;
            this.LoginBtn.Location = new System.Drawing.Point(371, 645);
            this.LoginBtn.Margin = new System.Windows.Forms.Padding(0);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(210, 39);
            this.LoginBtn.TabIndex = 24;
            this.LoginBtn.Text = "התחברות";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Visible = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // SignUpBtn
            // 
            this.SignUpBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.SignUpBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.SignUpBtn.ForeColor = System.Drawing.Color.GhostWhite;
            this.SignUpBtn.Location = new System.Drawing.Point(720, 645);
            this.SignUpBtn.Margin = new System.Windows.Forms.Padding(0);
            this.SignUpBtn.Name = "SignUpBtn";
            this.SignUpBtn.Size = new System.Drawing.Size(76, 26);
            this.SignUpBtn.TabIndex = 25;
            this.SignUpBtn.Text = "הירשם";
            this.SignUpBtn.UseVisualStyleBackColor = false;
            this.SignUpBtn.Visible = false;
            this.SignUpBtn.Click += new System.EventHandler(this.SignUpBtn_Click);
            // 
            // EmployerLoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1213, 820);
            this.Controls.Add(this.SignUpBtn);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.SignUpPanel);
            this.Name = "EmployerLoginPage";
            this.Text = "EmployerLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EmployerLogin_Load);
            this.SignUpPanel.ResumeLayout(false);
            this.SignUpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel SignUpPanel;
        public System.Windows.Forms.Label EmployerPasswordLbl;
        private System.Windows.Forms.TextBox EmployerPasswordTxt;
        public System.Windows.Forms.Label CompanyTypeLbl;
        public System.Windows.Forms.Label NumOfEmployeesLbl;
        private System.Windows.Forms.TextBox NumOfEmployeesTxt;
        public System.Windows.Forms.Label EmployerNameLbl;
        private System.Windows.Forms.TextBox EmployerNameTxt;
        public System.Windows.Forms.Label SignUpLbl;
        public System.Windows.Forms.Label ProjectTitleLbl;
        public System.Windows.Forms.Label CompanyNameLbl;
        private System.Windows.Forms.TextBox CompanyNameTxt;
        private System.Windows.Forms.ComboBox CompanyTypeDropDown;
        public System.Windows.Forms.Button AccountBtn;
        public System.Windows.Forms.Button LoginBtn;
        public System.Windows.Forms.Label CompanyEmailLbl;
        private System.Windows.Forms.TextBox CompanyEmailTxt;
        public System.Windows.Forms.Button SigninBtn;
        private System.Windows.Forms.Label AccountLbl;
        public System.Windows.Forms.Button SignUpBtn;
    }
}