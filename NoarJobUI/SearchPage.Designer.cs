using System.Drawing;

namespace NoarJobUI
{
    partial class SearchPage
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
            this.DisconnectionBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DisconnectionBtn
            // 
            this.DisconnectionBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(179)))), ((int)(((byte)(144)))));
            this.DisconnectionBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DisconnectionBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.DisconnectionBtn.Location = new System.Drawing.Point(1086, 91);
            this.DisconnectionBtn.Margin = new System.Windows.Forms.Padding(0);
            this.DisconnectionBtn.Name = "DisconnectionBtn";
            this.DisconnectionBtn.Size = new System.Drawing.Size(184, 39);
            this.DisconnectionBtn.TabIndex = 8;
            this.DisconnectionBtn.Text = "התנתק מהמשתמש";
            this.DisconnectionBtn.UseVisualStyleBackColor = false;
            this.DisconnectionBtn.Click += new System.EventHandler(this.DisconnectionBtn_Click);
            // 
            // SearchPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(248)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(1430, 837);
            this.Controls.Add(this.DisconnectionBtn);
            this.ForeColor = System.Drawing.Color.Cornsilk;
            this.Name = "SearchPage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "SearchPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button DisconnectionBtn;
    }
}