namespace ExamSystem
{
    partial class Reports
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ScoringTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MyData = new ExamSystem.MyData();
            this.StudentTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teachersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Report_Button = new System.Windows.Forms.Button();
            this.searchTxtBox = new System.Windows.Forms.TextBox();
            this.AdminSearchCheck = new System.Windows.Forms.CheckBox();
            this.sessionBox1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.subjectBox1 = new System.Windows.Forms.ComboBox();
            this.sectionBox1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Student_Report_Button = new System.Windows.Forms.Button();
            this.ignoreSectionCheck = new System.Windows.Forms.CheckBox();
            this.sessionBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sectionBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ScoringTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTableBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoringTableBindingSource
            // 
            this.ScoringTableBindingSource.DataMember = "ScoringTable";
            this.ScoringTableBindingSource.DataSource = this.MyData;
            // 
            // MyData
            // 
            this.MyData.DataSetName = "MyData";
            this.MyData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // StudentTableBindingSource
            // 
            this.StudentTableBindingSource.DataMember = "StudentTable";
            this.StudentTableBindingSource.DataSource = this.MyData;
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
            this.menuStrip1.Size = new System.Drawing.Size(1248, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subjectsToolStripMenuItem,
            this.teachersToolStripMenuItem,
            this.studentsToolStripMenuItem,
            this.resultsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // subjectsToolStripMenuItem
            // 
            this.subjectsToolStripMenuItem.Name = "subjectsToolStripMenuItem";
            this.subjectsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.subjectsToolStripMenuItem.Text = "Subjects";
            this.subjectsToolStripMenuItem.Click += new System.EventHandler(this.subjectsToolStripMenuItem_Click);
            // 
            // teachersToolStripMenuItem
            // 
            this.teachersToolStripMenuItem.Name = "teachersToolStripMenuItem";
            this.teachersToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.teachersToolStripMenuItem.Text = "Teachers";
            this.teachersToolStripMenuItem.Click += new System.EventHandler(this.teachersToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.resultsToolStripMenuItem.Text = "Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
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
            this.panel1.Size = new System.Drawing.Size(1248, 63);
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
            this.label1.Size = new System.Drawing.Size(1248, 63);
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
            this.panel2.Location = new System.Drawing.Point(0, 616);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1248, 63);
            this.panel2.TabIndex = 5;
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.Black;
            this.welcomeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(0, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(1248, 63);
            this.welcomeLabel.TabIndex = 1;
            this.welcomeLabel.Text = "Reports";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 90);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1258, 528);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1250, 497);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Results Report";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackgroundImage = global::ExamSystem.Properties.Resources.background;
            this.splitContainer1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel1.Controls.Add(this.Report_Button);
            this.splitContainer1.Panel1.Controls.Add(this.searchTxtBox);
            this.splitContainer1.Panel1.Controls.Add(this.AdminSearchCheck);
            this.splitContainer1.Panel1.Controls.Add(this.sessionBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.subjectBox1);
            this.splitContainer1.Panel1.Controls.Add(this.sectionBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::ExamSystem.Properties.Resources.background;
            this.splitContainer1.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer1.Panel2.Controls.Add(this.reportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(1244, 491);
            this.splitContainer1.SplitterDistance = 79;
            this.splitContainer1.TabIndex = 0;
            // 
            // Report_Button
            // 
            this.Report_Button.BackgroundImage = global::ExamSystem.Properties.Resources.Report;
            this.Report_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Report_Button.Location = new System.Drawing.Point(1087, 22);
            this.Report_Button.Name = "Report_Button";
            this.Report_Button.Size = new System.Drawing.Size(135, 35);
            this.Report_Button.TabIndex = 115;
            this.Report_Button.UseVisualStyleBackColor = true;
            this.Report_Button.Click += new System.EventHandler(this.Report_Button_Click);
            this.Report_Button.MouseEnter += new System.EventHandler(this.Report_Button_MouseEnter);
            this.Report_Button.MouseLeave += new System.EventHandler(this.Report_Button_MouseLeave);
            // 
            // searchTxtBox
            // 
            this.searchTxtBox.BackColor = System.Drawing.SystemColors.Control;
            this.searchTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxtBox.Location = new System.Drawing.Point(805, 24);
            this.searchTxtBox.Multiline = true;
            this.searchTxtBox.Name = "searchTxtBox";
            this.searchTxtBox.Size = new System.Drawing.Size(254, 30);
            this.searchTxtBox.TabIndex = 114;
            // 
            // AdminSearchCheck
            // 
            this.AdminSearchCheck.AutoSize = true;
            this.AdminSearchCheck.BackColor = System.Drawing.Color.Transparent;
            this.AdminSearchCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminSearchCheck.ForeColor = System.Drawing.Color.White;
            this.AdminSearchCheck.Location = new System.Drawing.Point(658, 28);
            this.AdminSearchCheck.Name = "AdminSearchCheck";
            this.AdminSearchCheck.Size = new System.Drawing.Size(124, 24);
            this.AdminSearchCheck.TabIndex = 112;
            this.AdminSearchCheck.Text = "AdminSearch";
            this.AdminSearchCheck.UseVisualStyleBackColor = false;
            this.AdminSearchCheck.CheckedChanged += new System.EventHandler(this.AdminSearchCheck_CheckedChanged);
            // 
            // sessionBox1
            // 
            this.sessionBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sessionBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sessionBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionBox1.FormattingEnabled = true;
            this.sessionBox1.IntegralHeight = false;
            this.sessionBox1.Location = new System.Drawing.Point(391, 27);
            this.sessionBox1.Name = "sessionBox1";
            this.sessionBox1.Size = new System.Drawing.Size(89, 25);
            this.sessionBox1.TabIndex = 110;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(306, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 20);
            this.label11.TabIndex = 111;
            this.label11.Text = "Session :";
            // 
            // subjectBox1
            // 
            this.subjectBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subjectBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subjectBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectBox1.FormattingEnabled = true;
            this.subjectBox1.Location = new System.Drawing.Point(97, 27);
            this.subjectBox1.Name = "subjectBox1";
            this.subjectBox1.Size = new System.Drawing.Size(187, 25);
            this.subjectBox1.TabIndex = 109;
            // 
            // sectionBox1
            // 
            this.sectionBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sectionBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sectionBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionBox1.FormattingEnabled = true;
            this.sectionBox1.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.sectionBox1.Location = new System.Drawing.Point(583, 27);
            this.sectionBox1.Name = "sectionBox1";
            this.sectionBox1.Size = new System.Drawing.Size(46, 25);
            this.sectionBox1.TabIndex = 107;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(503, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 108;
            this.label9.Text = "Section :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 20);
            this.label10.TabIndex = 106;
            this.label10.Text = "Subject :";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.ScoringTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ExamSystem.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1244, 408);
            this.reportViewer1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.splitContainer2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1250, 497);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Students Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackgroundImage = global::ExamSystem.Properties.Resources.background;
            this.splitContainer2.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel1.Controls.Add(this.Student_Report_Button);
            this.splitContainer2.Panel1.Controls.Add(this.ignoreSectionCheck);
            this.splitContainer2.Panel1.Controls.Add(this.sessionBox);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.sectionBox);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer2.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.splitContainer2.Panel2.Controls.Add(this.reportViewer2);
            this.splitContainer2.Size = new System.Drawing.Size(1244, 491);
            this.splitContainer2.SplitterDistance = 78;
            this.splitContainer2.TabIndex = 1;
            // 
            // Student_Report_Button
            // 
            this.Student_Report_Button.BackgroundImage = global::ExamSystem.Properties.Resources.Report;
            this.Student_Report_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Student_Report_Button.Location = new System.Drawing.Point(785, 22);
            this.Student_Report_Button.Name = "Student_Report_Button";
            this.Student_Report_Button.Size = new System.Drawing.Size(135, 35);
            this.Student_Report_Button.TabIndex = 115;
            this.Student_Report_Button.UseVisualStyleBackColor = true;
            this.Student_Report_Button.Click += new System.EventHandler(this.Student_Report_Button_Click);
            this.Student_Report_Button.MouseEnter += new System.EventHandler(this.Student_Report_Button_MouseEnter);
            this.Student_Report_Button.MouseLeave += new System.EventHandler(this.Student_Report_Button_MouseLeave);
            // 
            // ignoreSectionCheck
            // 
            this.ignoreSectionCheck.AutoSize = true;
            this.ignoreSectionCheck.BackColor = System.Drawing.Color.Transparent;
            this.ignoreSectionCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ignoreSectionCheck.ForeColor = System.Drawing.Color.White;
            this.ignoreSectionCheck.Location = new System.Drawing.Point(638, 28);
            this.ignoreSectionCheck.Name = "ignoreSectionCheck";
            this.ignoreSectionCheck.Size = new System.Drawing.Size(128, 24);
            this.ignoreSectionCheck.TabIndex = 112;
            this.ignoreSectionCheck.Text = "IgnoreSection";
            this.ignoreSectionCheck.UseVisualStyleBackColor = false;
            this.ignoreSectionCheck.CheckedChanged += new System.EventHandler(this.IgnoreSectionCheck_CheckedChanged);
            // 
            // sessionBox
            // 
            this.sessionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sessionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sessionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sessionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionBox.FormattingEnabled = true;
            this.sessionBox.IntegralHeight = false;
            this.sessionBox.Location = new System.Drawing.Point(371, 27);
            this.sessionBox.Name = "sessionBox";
            this.sessionBox.Size = new System.Drawing.Size(89, 25);
            this.sessionBox.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(286, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "Session :";
            // 
            // sectionBox
            // 
            this.sectionBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.sectionBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.sectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sectionBox.FormattingEnabled = true;
            this.sectionBox.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E"});
            this.sectionBox.Location = new System.Drawing.Point(563, 27);
            this.sectionBox.Name = "sectionBox";
            this.sectionBox.Size = new System.Drawing.Size(46, 25);
            this.sectionBox.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(483, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 108;
            this.label3.Text = "Section :";
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reportDataSource7.Name = "DataSet2";
            reportDataSource7.Value = this.StudentTableBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "ExamSystem.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(1244, 409);
            this.reportViewer2.TabIndex = 0;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ExamSystem.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1248, 679);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "Reports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ScoringTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentTableBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teachersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label welcomeLabel;
        private MyData MyData;
        private System.Windows.Forms.BindingSource ScoringTableBindingSource;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox AdminSearchCheck;
        private System.Windows.Forms.ComboBox sessionBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox subjectBox1;
        private System.Windows.Forms.ComboBox sectionBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox searchTxtBox;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button Report_Button;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button Student_Report_Button;
        private System.Windows.Forms.CheckBox ignoreSectionCheck;
        private System.Windows.Forms.ComboBox sessionBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sectionBox;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource StudentTableBindingSource;
    }
}