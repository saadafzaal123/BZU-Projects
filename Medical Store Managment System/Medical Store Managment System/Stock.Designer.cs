namespace Medical_Store_Managment_System
{
    partial class Stock
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SeeStock_Button = new System.Windows.Forms.Button();
            this.UpdateStock_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.ProcessStock_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BillTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.GoBack_Button = new System.Windows.Forms.Button();
            this.ResetStock_Button = new System.Windows.Forms.Button();
            this.LogOut_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(258, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock Page";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(534, 334);
            this.dataGridView1.TabIndex = 1;
            // 
            // SeeStock_Button
            // 
            this.SeeStock_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeStock_Button.Location = new System.Drawing.Point(106, 428);
            this.SeeStock_Button.Name = "SeeStock_Button";
            this.SeeStock_Button.Size = new System.Drawing.Size(124, 41);
            this.SeeStock_Button.TabIndex = 2;
            this.SeeStock_Button.Text = "See Stock";
            this.SeeStock_Button.UseVisualStyleBackColor = true;
            this.SeeStock_Button.Click += new System.EventHandler(this.SeeStock_Button_Click);
            // 
            // UpdateStock_Button
            // 
            this.UpdateStock_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateStock_Button.Location = new System.Drawing.Point(269, 428);
            this.UpdateStock_Button.Name = "UpdateStock_Button";
            this.UpdateStock_Button.Size = new System.Drawing.Size(124, 41);
            this.UpdateStock_Button.TabIndex = 3;
            this.UpdateStock_Button.Text = "Update Stock";
            this.UpdateStock_Button.UseVisualStyleBackColor = true;
            this.UpdateStock_Button.Click += new System.EventHandler(this.UpdateStock_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.Location = new System.Drawing.Point(433, 428);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(124, 41);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ProcessStock_Button
            // 
            this.ProcessStock_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessStock_Button.Location = new System.Drawing.Point(145, 503);
            this.ProcessStock_Button.Name = "ProcessStock_Button";
            this.ProcessStock_Button.Size = new System.Drawing.Size(124, 41);
            this.ProcessStock_Button.TabIndex = 5;
            this.ProcessStock_Button.Text = "Process Stock";
            this.ProcessStock_Button.UseVisualStyleBackColor = true;
            this.ProcessStock_Button.Click += new System.EventHandler(this.ProcessStock_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(302, 509);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Bill  :";
            // 
            // BillTxtBox
            // 
            this.BillTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillTxtBox.Location = new System.Drawing.Point(421, 512);
            this.BillTxtBox.Name = "BillTxtBox";
            this.BillTxtBox.Size = new System.Drawing.Size(180, 26);
            this.BillTxtBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(302, 570);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date        :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(419, 570);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(180, 26);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // GoBack_Button
            // 
            this.GoBack_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBack_Button.Location = new System.Drawing.Point(106, 631);
            this.GoBack_Button.Name = "GoBack_Button";
            this.GoBack_Button.Size = new System.Drawing.Size(124, 41);
            this.GoBack_Button.TabIndex = 10;
            this.GoBack_Button.Text = "Go Back";
            this.GoBack_Button.UseVisualStyleBackColor = true;
            this.GoBack_Button.Click += new System.EventHandler(this.GoBack_Button_Click);
            // 
            // ResetStock_Button
            // 
            this.ResetStock_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetStock_Button.Location = new System.Drawing.Point(272, 631);
            this.ResetStock_Button.Name = "ResetStock_Button";
            this.ResetStock_Button.Size = new System.Drawing.Size(124, 41);
            this.ResetStock_Button.TabIndex = 11;
            this.ResetStock_Button.Text = "Reset Stock";
            this.ResetStock_Button.UseVisualStyleBackColor = true;
            this.ResetStock_Button.Click += new System.EventHandler(this.ResetStock_Button_Click);
            // 
            // LogOut_Button
            // 
            this.LogOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_Button.Location = new System.Drawing.Point(433, 631);
            this.LogOut_Button.Name = "LogOut_Button";
            this.LogOut_Button.Size = new System.Drawing.Size(124, 41);
            this.LogOut_Button.TabIndex = 12;
            this.LogOut_Button.Text = "LogOut";
            this.LogOut_Button.UseVisualStyleBackColor = true;
            this.LogOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(668, 697);
            this.Controls.Add(this.LogOut_Button);
            this.Controls.Add(this.ResetStock_Button);
            this.Controls.Add(this.GoBack_Button);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BillTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProcessStock_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.UpdateStock_Button);
            this.Controls.Add(this.SeeStock_Button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Stock";
            this.Text = "Al-Saad-Medical-Store";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SeeStock_Button;
        private System.Windows.Forms.Button UpdateStock_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button ProcessStock_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BillTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button GoBack_Button;
        private System.Windows.Forms.Button ResetStock_Button;
        private System.Windows.Forms.Button LogOut_Button;
    }
}