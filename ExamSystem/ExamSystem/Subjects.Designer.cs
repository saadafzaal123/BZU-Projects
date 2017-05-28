namespace ExamSystem
{
    partial class Subjects
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lable9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teacherBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.semesterBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.DeleteSubject_Button = new System.Windows.Forms.Button();
            this.UpdateSubject_Button = new System.Windows.Forms.Button();
            this.AddSubject_Button = new System.Windows.Forms.Button();
            this.RemoveSubjects_Button = new System.Windows.Forms.Button();
            this.EditSubjects_Button = new System.Windows.Forms.Button();
            this.GoBack_Button = new System.Windows.Forms.Button();
            this.LogOut_Button = new System.Windows.Forms.Button();
            this.Search_Button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ViewSubjects_Button = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.goBackToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1178, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teachersToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.reportsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // teachersToolStripMenuItem
            // 
            this.teachersToolStripMenuItem.Name = "teachersToolStripMenuItem";
            this.teachersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.teachersToolStripMenuItem.Text = "Teachers";
            this.teachersToolStripMenuItem.Click += new System.EventHandler(this.teachersToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resultsToolStripMenuItem.Text = "Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reportsToolStripMenuItem.Text = "Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // goBackToolStripMenuItem
            // 
            this.goBackToolStripMenuItem.Name = "goBackToolStripMenuItem";
            this.goBackToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.goBackToolStripMenuItem.Text = "GoBack";
            this.goBackToolStripMenuItem.Click += new System.EventHandler(this.goBackToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 63);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1178, 63);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam System of CS Department";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.welcomeLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 596);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 63);
            this.panel2.TabIndex = 4;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.Black;
            this.welcomeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(0, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(1178, 63);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Subjects";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(242, 126);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 25);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lable9
            // 
            this.lable9.AutoSize = true;
            this.lable9.BackColor = System.Drawing.Color.Transparent;
            this.lable9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable9.ForeColor = System.Drawing.Color.White;
            this.lable9.Location = new System.Drawing.Point(49, 128);
            this.lable9.Name = "lable9";
            this.lable9.Size = new System.Drawing.Size(171, 18);
            this.lable9.TabIndex = 71;
            this.lable9.Text = "Subject ID                     :  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 18);
            this.label2.TabIndex = 73;
            this.label2.Text = "Subject Name               :  ";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "3"});
            this.comboBox2.Location = new System.Drawing.Point(242, 212);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(234, 25);
            this.comboBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 18);
            this.label3.TabIndex = 75;
            this.label3.Text = "Subject CreditHours     :  ";
            // 
            // teacherBox
            // 
            this.teacherBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.teacherBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.teacherBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherBox.FormattingEnabled = true;
            this.teacherBox.IntegralHeight = false;
            this.teacherBox.Location = new System.Drawing.Point(242, 257);
            this.teacherBox.Name = "teacherBox";
            this.teacherBox.Size = new System.Drawing.Size(234, 25);
            this.teacherBox.TabIndex = 4;
            this.teacherBox.SelectedIndexChanged += new System.EventHandler(this.teacherBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 18);
            this.label4.TabIndex = 77;
            this.label4.Text = "Teacher ID                    :  ";
            // 
            // semesterBox
            // 
            this.semesterBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.semesterBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.semesterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semesterBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.semesterBox.FormattingEnabled = true;
            this.semesterBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.semesterBox.Location = new System.Drawing.Point(241, 430);
            this.semesterBox.Name = "semesterBox";
            this.semesterBox.Size = new System.Drawing.Size(234, 25);
            this.semesterBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(48, 433);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 18);
            this.label5.TabIndex = 79;
            this.label5.Text = "Semester                      :  ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(545, 280);
            this.dataGridView1.TabIndex = 81;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.degreeLabel);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(242, 302);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 105);
            this.groupBox1.TabIndex = 82;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teacher Info";
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Location = new System.Drawing.Point(6, 67);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(72, 18);
            this.degreeLabel.TabIndex = 1;
            this.degreeLabel.Text = "Degree  : ";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(6, 31);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(72, 18);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name    : ";
            // 
            // DeleteSubject_Button
            // 
            this.DeleteSubject_Button.BackColor = System.Drawing.SystemColors.Control;
            this.DeleteSubject_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteSubject_Button.Location = new System.Drawing.Point(345, 476);
            this.DeleteSubject_Button.Name = "DeleteSubject_Button";
            this.DeleteSubject_Button.Size = new System.Drawing.Size(131, 33);
            this.DeleteSubject_Button.TabIndex = 85;
            this.DeleteSubject_Button.Text = "Delete Subject";
            this.DeleteSubject_Button.UseVisualStyleBackColor = false;
            this.DeleteSubject_Button.Click += new System.EventHandler(this.DeleteSubject_Button_Click);
            // 
            // UpdateSubject_Button
            // 
            this.UpdateSubject_Button.BackColor = System.Drawing.SystemColors.Control;
            this.UpdateSubject_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateSubject_Button.Location = new System.Drawing.Point(198, 476);
            this.UpdateSubject_Button.Name = "UpdateSubject_Button";
            this.UpdateSubject_Button.Size = new System.Drawing.Size(131, 33);
            this.UpdateSubject_Button.TabIndex = 84;
            this.UpdateSubject_Button.Text = "Update Subject";
            this.UpdateSubject_Button.UseVisualStyleBackColor = false;
            this.UpdateSubject_Button.Click += new System.EventHandler(this.UpdateSubject_Button_Click);
            // 
            // AddSubject_Button
            // 
            this.AddSubject_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddSubject_Button.Location = new System.Drawing.Point(52, 476);
            this.AddSubject_Button.Name = "AddSubject_Button";
            this.AddSubject_Button.Size = new System.Drawing.Size(130, 33);
            this.AddSubject_Button.TabIndex = 83;
            this.AddSubject_Button.Text = "Add Subject";
            this.AddSubject_Button.UseVisualStyleBackColor = true;
            this.AddSubject_Button.Click += new System.EventHandler(this.AddSubject_Button_Click);
            // 
            // RemoveSubjects_Button
            // 
            this.RemoveSubjects_Button.BackColor = System.Drawing.SystemColors.Control;
            this.RemoveSubjects_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSubjects_Button.Location = new System.Drawing.Point(982, 476);
            this.RemoveSubjects_Button.Name = "RemoveSubjects_Button";
            this.RemoveSubjects_Button.Size = new System.Drawing.Size(148, 33);
            this.RemoveSubjects_Button.TabIndex = 88;
            this.RemoveSubjects_Button.Text = "Remove Subjects";
            this.RemoveSubjects_Button.UseVisualStyleBackColor = false;
            this.RemoveSubjects_Button.Click += new System.EventHandler(this.RemoveSubjects_Button_Click);
            // 
            // EditSubjects_Button
            // 
            this.EditSubjects_Button.BackColor = System.Drawing.SystemColors.Control;
            this.EditSubjects_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSubjects_Button.Location = new System.Drawing.Point(781, 476);
            this.EditSubjects_Button.Name = "EditSubjects_Button";
            this.EditSubjects_Button.Size = new System.Drawing.Size(148, 33);
            this.EditSubjects_Button.TabIndex = 87;
            this.EditSubjects_Button.Text = "Edit Subjects";
            this.EditSubjects_Button.UseVisualStyleBackColor = false;
            this.EditSubjects_Button.Click += new System.EventHandler(this.EditSubjects_Button_Click);
            // 
            // GoBack_Button
            // 
            this.GoBack_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GoBack_Button.Location = new System.Drawing.Point(198, 527);
            this.GoBack_Button.Name = "GoBack_Button";
            this.GoBack_Button.Size = new System.Drawing.Size(131, 33);
            this.GoBack_Button.TabIndex = 89;
            this.GoBack_Button.Text = "GoBack";
            this.GoBack_Button.UseVisualStyleBackColor = true;
            this.GoBack_Button.Click += new System.EventHandler(this.GoBack_Button_Click);
            // 
            // LogOut_Button
            // 
            this.LogOut_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogOut_Button.Location = new System.Drawing.Point(781, 527);
            this.LogOut_Button.Name = "LogOut_Button";
            this.LogOut_Button.Size = new System.Drawing.Size(148, 33);
            this.LogOut_Button.TabIndex = 90;
            this.LogOut_Button.Text = "LogOut";
            this.LogOut_Button.UseVisualStyleBackColor = true;
            this.LogOut_Button.Click += new System.EventHandler(this.LogOut_Button_Click);
            // 
            // Search_Button
            // 
            this.Search_Button.BackgroundImage = global::ExamSystem.Properties.Resources.search;
            this.Search_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Search_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Search_Button.Location = new System.Drawing.Point(1070, 126);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(38, 27);
            this.Search_Button.TabIndex = 92;
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(580, 168);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(550, 287);
            this.panel3.TabIndex = 93;
            // 
            // ViewSubjects_Button
            // 
            this.ViewSubjects_Button.BackColor = System.Drawing.SystemColors.Control;
            this.ViewSubjects_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewSubjects_Button.Location = new System.Drawing.Point(580, 476);
            this.ViewSubjects_Button.Name = "ViewSubjects_Button";
            this.ViewSubjects_Button.Size = new System.Drawing.Size(148, 33);
            this.ViewSubjects_Button.TabIndex = 88;
            this.ViewSubjects_Button.Text = "View Subjects";
            this.ViewSubjects_Button.UseVisualStyleBackColor = false;
            this.ViewSubjects_Button.Click += new System.EventHandler(this.ViewSubjects_Button_Click);
            // 
            // nameBox
            // 
            this.nameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.nameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameBox.FormattingEnabled = true;
            this.nameBox.IntegralHeight = false;
            this.nameBox.Location = new System.Drawing.Point(241, 169);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(234, 25);
            this.nameBox.TabIndex = 2;
            this.nameBox.SelectedIndexChanged += new System.EventHandler(this.nameBox_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Location = new System.Drawing.Point(523, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 509);
            this.panel4.TabIndex = 94;
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.searchTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxtBox.Location = new System.Drawing.Point(810, 126);
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(254, 27);
            this.searchTxtBox.TabIndex = 95;
            // 
            // Subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ExamSystem.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1178, 659);
            this.Controls.Add(this.searchTxtBox);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.ViewSubjects_Button);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.Search_Button);
            this.Controls.Add(this.LogOut_Button);
            this.Controls.Add(this.GoBack_Button);
            this.Controls.Add(this.RemoveSubjects_Button);
            this.Controls.Add(this.EditSubjects_Button);
            this.Controls.Add(this.DeleteSubject_Button);
            this.Controls.Add(this.UpdateSubject_Button);
            this.Controls.Add(this.AddSubject_Button);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.semesterBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.teacherBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lable9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Subjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subjects";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lable9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teacherBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox semesterBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.Button DeleteSubject_Button;
        private System.Windows.Forms.Button UpdateSubject_Button;
        private System.Windows.Forms.Button AddSubject_Button;
        private System.Windows.Forms.Button RemoveSubjects_Button;
        private System.Windows.Forms.Button EditSubjects_Button;
        private System.Windows.Forms.Button GoBack_Button;
        private System.Windows.Forms.Button LogOut_Button;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ViewSubjects_Button;
        private System.Windows.Forms.ToolStripMenuItem teachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ComboBox nameBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox searchTxtBox;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;

    }
}