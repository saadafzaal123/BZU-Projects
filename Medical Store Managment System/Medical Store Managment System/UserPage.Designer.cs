namespace Medical_Store_Managment_System
{
    partial class UserPage
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
            this.USER = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Sales_button = new System.Windows.Forms.Button();
            this.LogOut_Button = new System.Windows.Forms.Button();
            this.Reset_Password_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // USER
            // 
            this.USER.AutoSize = true;
            this.USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USER.ForeColor = System.Drawing.Color.White;
            this.USER.Location = new System.Drawing.Point(56, 78);
            this.USER.Name = "USER";
            this.USER.Size = new System.Drawing.Size(71, 24);
            this.USER.TabIndex = 0;
            this.USER.Text = "User  :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(147, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Page";
            // 
            // Sales_button
            // 
            this.Sales_button.BackColor = System.Drawing.Color.White;
            this.Sales_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Sales_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sales_button.Location = new System.Drawing.Point(126, 148);
            this.Sales_button.Name = "Sales_button";
            this.Sales_button.Size = new System.Drawing.Size(173, 37);
            this.Sales_button.TabIndex = 2;
            this.Sales_button.Text = "Sales";
            this.Sales_button.UseVisualStyleBackColor = false;
            this.Sales_button.Click += new System.EventHandler(this.Sales_button_Click);
            // 
            // LogOut_Button
            // 
            this.LogOut_Button.BackColor = System.Drawing.Color.White;
            this.LogOut_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_Button.Location = new System.Drawing.Point(126, 301);
            this.LogOut_Button.Name = "LogOut_Button";
            this.LogOut_Button.Size = new System.Drawing.Size(173, 37);
            this.LogOut_Button.TabIndex = 4;
            this.LogOut_Button.Text = "LogOut";
            this.LogOut_Button.UseVisualStyleBackColor = false;
            this.LogOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // Reset_Password_button
            // 
            this.Reset_Password_button.BackColor = System.Drawing.Color.White;
            this.Reset_Password_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset_Password_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Password_button.Location = new System.Drawing.Point(126, 225);
            this.Reset_Password_button.Name = "Reset_Password_button";
            this.Reset_Password_button.Size = new System.Drawing.Size(173, 37);
            this.Reset_Password_button.TabIndex = 5;
            this.Reset_Password_button.Text = "Reset Password";
            this.Reset_Password_button.UseVisualStyleBackColor = false;
            this.Reset_Password_button.Click += new System.EventHandler(this.Reset_Password_button_Click);
            // 
            // UserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(426, 406);
            this.Controls.Add(this.Reset_Password_button);
            this.Controls.Add(this.LogOut_Button);
            this.Controls.Add(this.Sales_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.USER);
            this.Name = "UserPage";
            this.Text = "Al-Saad-Medical-Store";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label USER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Sales_button;
        private System.Windows.Forms.Button LogOut_Button;
        private System.Windows.Forms.Button Reset_Password_button;
    }
}