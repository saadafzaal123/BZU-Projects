namespace Medical_Store_Managment_System
{
    partial class Cart
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
            this.SeeCart_Button = new System.Windows.Forms.Button();
            this.UpadateCart_Button = new System.Windows.Forms.Button();
            this.Delete_Button = new System.Windows.Forms.Button();
            this.ProcessCart_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BillTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.GoBack_Button = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.LogOut_Button = new System.Windows.Forms.Button();
            this.DiscountTxtBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.NetBillTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(327, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cart Page";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(70, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 271);
            this.dataGridView1.TabIndex = 1;
            // 
            // SeeCart_Button
            // 
            this.SeeCart_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeeCart_Button.Location = new System.Drawing.Point(70, 367);
            this.SeeCart_Button.Name = "SeeCart_Button";
            this.SeeCart_Button.Size = new System.Drawing.Size(200, 41);
            this.SeeCart_Button.TabIndex = 2;
            this.SeeCart_Button.Text = "See Cart";
            this.SeeCart_Button.UseVisualStyleBackColor = true;
            this.SeeCart_Button.Click += new System.EventHandler(this.SeeCart_Button_Click);
            // 
            // UpadateCart_Button
            // 
            this.UpadateCart_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpadateCart_Button.Location = new System.Drawing.Point(292, 367);
            this.UpadateCart_Button.Name = "UpadateCart_Button";
            this.UpadateCart_Button.Size = new System.Drawing.Size(200, 41);
            this.UpadateCart_Button.TabIndex = 3;
            this.UpadateCart_Button.Text = "UpdateCart";
            this.UpadateCart_Button.UseVisualStyleBackColor = true;
            this.UpadateCart_Button.Click += new System.EventHandler(this.UpadateCart_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete_Button.Location = new System.Drawing.Point(513, 367);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(200, 41);
            this.Delete_Button.TabIndex = 4;
            this.Delete_Button.Text = "Delete";
            this.Delete_Button.UseVisualStyleBackColor = true;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // ProcessCart_Button
            // 
            this.ProcessCart_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessCart_Button.Location = new System.Drawing.Point(159, 490);
            this.ProcessCart_Button.Name = "ProcessCart_Button";
            this.ProcessCart_Button.Size = new System.Drawing.Size(212, 74);
            this.ProcessCart_Button.TabIndex = 5;
            this.ProcessCart_Button.Text = "Process Cart";
            this.ProcessCart_Button.UseVisualStyleBackColor = true;
            this.ProcessCart_Button.Click += new System.EventHandler(this.ProcessCart_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(419, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Bill  :";
            // 
            // BillTxtBox
            // 
            this.BillTxtBox.Enabled = false;
            this.BillTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillTxtBox.Location = new System.Drawing.Point(538, 441);
            this.BillTxtBox.Name = "BillTxtBox";
            this.BillTxtBox.Size = new System.Drawing.Size(180, 26);
            this.BillTxtBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(418, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date        :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(537, 588);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(181, 26);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // GoBack_Button
            // 
            this.GoBack_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBack_Button.Location = new System.Drawing.Point(70, 637);
            this.GoBack_Button.Name = "GoBack_Button";
            this.GoBack_Button.Size = new System.Drawing.Size(200, 41);
            this.GoBack_Button.TabIndex = 10;
            this.GoBack_Button.Text = "Go Back";
            this.GoBack_Button.UseVisualStyleBackColor = true;
            this.GoBack_Button.Click += new System.EventHandler(this.GoBack_Button_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Button.Location = new System.Drawing.Point(292, 637);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(200, 41);
            this.Reset_Button.TabIndex = 11;
            this.Reset_Button.Text = "Reset Cart";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // LogOut_Button
            // 
            this.LogOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_Button.Location = new System.Drawing.Point(518, 637);
            this.LogOut_Button.Name = "LogOut_Button";
            this.LogOut_Button.Size = new System.Drawing.Size(200, 41);
            this.LogOut_Button.TabIndex = 12;
            this.LogOut_Button.Text = "LogOut";
            this.LogOut_Button.UseVisualStyleBackColor = true;
            this.LogOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // DiscountTxtBox
            // 
            this.DiscountTxtBox.Enabled = false;
            this.DiscountTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiscountTxtBox.Location = new System.Drawing.Point(538, 490);
            this.DiscountTxtBox.Name = "DiscountTxtBox";
            this.DiscountTxtBox.Size = new System.Drawing.Size(180, 26);
            this.DiscountTxtBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(418, 491);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Discount  :";
            // 
            // NetBillTxtBox
            // 
            this.NetBillTxtBox.Enabled = false;
            this.NetBillTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NetBillTxtBox.Location = new System.Drawing.Point(538, 539);
            this.NetBillTxtBox.Name = "NetBillTxtBox";
            this.NetBillTxtBox.Size = new System.Drawing.Size(180, 26);
            this.NetBillTxtBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(419, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Net Bill    :";
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(779, 693);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NetBillTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DiscountTxtBox);
            this.Controls.Add(this.LogOut_Button);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.GoBack_Button);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BillTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProcessCart_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.UpadateCart_Button);
            this.Controls.Add(this.SeeCart_Button);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "Cart";
            this.Text = "Al-Saad-Medical-Store";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button SeeCart_Button;
        private System.Windows.Forms.Button UpadateCart_Button;
        private System.Windows.Forms.Button Delete_Button;
        private System.Windows.Forms.Button ProcessCart_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BillTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button GoBack_Button;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button LogOut_Button;
        private System.Windows.Forms.TextBox DiscountTxtBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NetBillTxtBox;
        private System.Windows.Forms.Label label5;
    }
}