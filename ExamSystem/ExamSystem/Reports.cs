using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace ExamSystem
{
    public partial class Reports : Form
    {
        private string username;
        private string name;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public Reports(string Name, string Username)
        {
            InitializeComponent();

            name = Name;

            username = Username;

            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            teachersToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlT;
            subjectsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlS;
            studentsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlD;
            resultsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlR;
            goBackToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlB;

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            if (GoBack() == "User")
            {
                subjectsToolStripMenuItem.Enabled = false;
                teachersToolStripMenuItem.Enabled = false;
                AdminSearchCheck.Enabled = false;
                searchTxtBox.Enabled = false;
            }

            searchTxtBox.Text = "Type Here";

            Fillcombo();

            searchTxtBox.Enabled = false;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to LogOut?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                LogOut();
            }
        }

        private void LogOut()
        {
            MySqlCommand sc = new MySqlCommand(@"Update teacher_table set IsLogin = '" + "No" + "' where T_username = '" + username + "'", con);

            try
            {
                sc.ExecuteNonQuery();

                con.Close();

                this.Hide();
                Login lg = new Login();
                lg.Show();

            }
            catch (Exception)
            {
                MessageBox.Show("Some Error Occurr During LogOut!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GoBack()
        {
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter("select IsAdmin from teacher_table where T_username = '" + username + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string IsAdmin = dt.Rows[0][0].ToString();

                if (IsAdmin == "Yes")
                {
                    return "Admin";
                }
                else
                {
                    return "User";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null;
            }
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GoBack() == "Admin")
            {
                this.Hide();
                AdminArea aa = new AdminArea(name, username);
                aa.Show();
            }
            else if (GoBack() == "User")
            {
                this.Hide();
                TeacherArea ta = new TeacherArea(name, username);
                ta.Show();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to LogOut?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                LogOut();
            }
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects sb = new Subjects(name, username);
            sb.Show();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers t = new Teachers(name, username);
            t.Show();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students st = new Students(name, username);
            st.Show();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Results rr = new Results(name, username);
            rr.Show();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            string Fall = "Fall";

            for (int i = 2001; i <= 2099; i++)
            {
                string Session = Fall + " " + i;

                sessionBox1.Items.Add(Session);
                sessionBox.Items.Add(Session);
            }

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void Report_Button_Click(object sender, EventArgs e)
        {
            if (AdminSearchCheck.Checked == true)
            {
                if (searchTxtBox.Text == "")
                {
                    MessageBox.Show("Enter something in Search Box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter("SELECT No , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade FROM scoring_table WHERE Name Like '%" + searchTxtBox.Text + "%' or RollNo Like '%" + searchTxtBox.Text + "%'", con);
                        MyData md = new MyData();
                        sda.Fill(md.Tables[0]);

                        reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                        reportViewer1.LocalReport.ReportPath = "Report1.rdlc";

                        reportViewer1.LocalReport.DataSources.Clear();

                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", md.Tables[0]));

                        reportViewer1.DocumentMapCollapsed = true;

                        reportViewer1.RefreshReport();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Error!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (subjectBox1.Text == "" || sectionBox1.Text == "" || sessionBox1.Text == "")
                {
                    MessageBox.Show("Subject , Section and Session Field is must Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox1.Text + "' ", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);

                        string SubjectID = dt2.Rows[0][0].ToString();

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select St_rollno from student_table where St_section = '" + sectionBox1.Text + "' and St_session = '" + sessionBox1.Text + "' ", con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);

                        MyData md = new MyData();

                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            string StudentRollno = dt1.Rows[i]["St_rollno"].ToString();

                            MySqlDataAdapter sda = new MySqlDataAdapter(@"Select No , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade from scoring_table where S_id = '" + SubjectID + "' and RollNo = '" + StudentRollno + "'", con);

                            sda.Fill(md.Tables[0]);
                        }

                        reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                        reportViewer1.LocalReport.ReportPath = "Report1.rdlc";

                        reportViewer1.LocalReport.DataSources.Clear();

                        reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", md.Tables[0]));

                        reportViewer1.DocumentMapCollapsed = true;

                        reportViewer1.RefreshReport();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Error! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AdminSearchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AdminSearchCheck.Checked == true)
            {
                subjectBox1.Enabled = false;
                subjectBox1.Text = null;
                searchTxtBox.Enabled = true;
            }
            else if (AdminSearchCheck.Checked == false)
            {
                subjectBox1.Enabled = true;
                searchTxtBox.Text = "Type Here";
                searchTxtBox.Enabled = false;
            }
        }

        private void Fillcombo()
        {
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            string T_id = dt1.Rows[0][0].ToString();

            MySqlCommand cmd = new MySqlCommand("select S_name from subject_table where T_id = '" + T_id + "'", con);

            MySqlDataReader myReader;

            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                string SubjectName = myReader.GetString("S_name");

                subjectBox1.Items.Add(SubjectName);
            }

            myReader.Close();
        }

        private void IgnoreSectionCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreSectionCheck.Checked == true)
            {
                sectionBox.Enabled = false;
                sectionBox.Text = null;
            }
            else if (ignoreSectionCheck.Checked == false)
            {
                sectionBox.Enabled = true;
            }
        }

        private void Student_Report_Button_Click(object sender, EventArgs e)
        {
            if (ignoreSectionCheck.Checked == true)
            {
                if (sessionBox.Text == "")
                {
                    MessageBox.Show("Session Field is must Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from student_table where St_session = '" + sessionBox.Text + "'", con);
                        MyData md = new MyData();
                        sda.Fill(md.Tables[1]);

                        reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                        reportViewer2.LocalReport.ReportPath = "Report2.rdlc";

                        reportViewer2.LocalReport.DataSources.Clear();

                        reportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", md.Tables[1]));

                        reportViewer2.DocumentMapCollapsed = true;

                        reportViewer2.RefreshReport();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Error! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (sectionBox.Text == "" || sessionBox.Text == "")
                {
                    MessageBox.Show("Session and Section Field is must Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from student_table where St_session = '" + sessionBox.Text + "' and St_section = '" + sectionBox.Text + "'", con);
                        MyData md = new MyData();
                        sda.Fill(md.Tables[1]);

                        reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                        reportViewer2.LocalReport.ReportPath = "Report2.rdlc";

                        reportViewer2.LocalReport.DataSources.Clear();

                        reportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", md.Tables[1]));

                        reportViewer2.DocumentMapCollapsed = true;

                        reportViewer2.RefreshReport();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Error! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Report_Button_MouseEnter(object sender, EventArgs e)
        {
            Report_Button.Size = new Size(Report_Button.Size.Width + 3, Report_Button.Size.Height + 3);
            Report_Button.Location = new Point(Report_Button.Left, Report_Button.Top - 2);
        }

        private void Report_Button_MouseLeave(object sender, EventArgs e)
        {
            Report_Button.Size = new Size(Report_Button.Size.Width - 3, Report_Button.Size.Height - 3);
            Report_Button.Location = new Point(Report_Button.Left, Report_Button.Top + 2);
        }

        private void Student_Report_Button_MouseEnter(object sender, EventArgs e)
        {
            Student_Report_Button.Size = new Size(Student_Report_Button.Size.Width + 3, Student_Report_Button.Size.Height + 3);
            Student_Report_Button.Location = new Point(Student_Report_Button.Left, Student_Report_Button.Top - 2);
        }

        private void Student_Report_Button_MouseLeave(object sender, EventArgs e)
        {
            Student_Report_Button.Size = new Size(Student_Report_Button.Size.Width - 3, Student_Report_Button.Size.Height - 3);
            Student_Report_Button.Location = new Point(Student_Report_Button.Left, Student_Report_Button.Top + 2);
        }
    }
}
