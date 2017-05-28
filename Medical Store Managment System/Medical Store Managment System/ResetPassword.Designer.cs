namespace Medical_Store_Managment_System
{
    partial class ResetPassword
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CpasswordTxtBox = new System.Windows.Forms.TextBox();
            this.NpasswordTxtBox = new System.Windows.Forms.TextBox();
            this.CNpasswordTxtBox = new System.Windows.Forms.TextBox();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.GoBack_Button = new System.Windows.Forms.Button();
            this.LogOut_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(169, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reset Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(62, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Password          :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(62, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Password               :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(62, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm New Password  :";
            // 
            // CpasswordTxtBox
            // 
            this.CpasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CpasswordTxtBox.Location = new System.Drawing.Point(282, 102);
            this.CpasswordTxtBox.Name = "CpasswordTxtBox";
            this.CpasswordTxtBox.Size = new System.Drawing.Size(197, 23);
            this.CpasswordTxtBox.TabIndex = 4;
            this.CpasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // NpasswordTxtBox
            // 
            this.NpasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NpasswordTxtBox.Location = new System.Drawing.Point(282, 164);
            this.NpasswordTxtBox.Name = "NpasswordTxtBox";
            this.NpasswordTxtBox.Size = new System.Drawing.Size(197, 23);
            this.NpasswordTxtBox.TabIndex = 5;
            this.NpasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // CNpasswordTxtBox
            // 
            this.CNpasswordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CNpasswordTxtBox.Location = new System.Drawing.Point(282, 223);
            this.CNpasswordTxtBox.Name = "CNpasswordTxtBox";
            this.CNpasswordTxtBox.Size = new System.Drawing.Size(197, 23);
            this.CNpasswordTxtBox.TabIndex = 6;
            this.CNpasswordTxtBox.UseSystemPasswordChar = true;
            // 
            // Reset_Button
            // 
            this.Reset_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Button.Location = new System.Drawing.Point(66, 294);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(119, 41);
            this.Reset_Button.TabIndex = 7;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // GoBack_Button
            // 
            this.GoBack_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBack_Button.Location = new System.Drawing.Point(213, 294);
            this.GoBack_Button.Name = "GoBack_Button";
            this.GoBack_Button.Size = new System.Drawing.Size(119, 41);
            this.GoBack_Button.TabIndex = 8;
            this.GoBack_Button.Text = "GoBack";
            this.GoBack_Button.UseVisualStyleBackColor = true;
            this.GoBack_Button.Click += new System.EventHandler(this.GoBack_Button_Click);
            // 
            // LogOut_Button
            // 
            this.LogOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_Button.Location = new System.Drawing.Point(360, 294);
            this.LogOut_Button.Name = "LogOut_Button";
            this.LogOut_Button.Size = new System.Drawing.Size(119, 41);
            this.LogOut_Button.TabIndex = 9;
            this.LogOut_Button.Text = "LogOut";
            this.LogOut_Button.UseVisualStyleBackColor = true;
            this.LogOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(549, 398);
            this.Controls.Add(this.LogOut_Button);
            this.Controls.Add(this.GoBack_Button);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.CNpasswordTxtBox);
            this.Controls.Add(this.NpasswordTxtBox);
            this.Controls.Add(this.CpasswordTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ResetPassword";
            this.Text = "Al-Saad-Medical-Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CpasswordTxtBox;
        private System.Windows.Forms.TextBox NpasswordTxtBox;
        private System.Windows.Forms.TextBox CNpasswordTxtBox;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button GoBack_Button;
        private System.Windows.Forms.Button LogOut_Button;
    }
}