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
using System.IO;

namespace ExamSystem
{
    public partial class Results : Form
    {
        private string username;
        private string name;

        private string Btn;

        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public Results(string Name, string Username)
        {
            InitializeComponent();

            username = Username;

            name = Name;

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            gobackToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlB;
            subjectsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlS;
            studentsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlD;
            teachersToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlT;
            reportsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlE;

            if (GoBack() == "User")
            {
                subjectsToolStripMenuItem.Enabled = false;
                teachersToolStripMenuItem.Enabled = false;
                AdminSearchCheck.Enabled = false;
            }

            Fillcombo();

            sectionBox.Enabled = false;
            rollnoBox.Enabled = false;
            Update_Button.Enabled = false;
            Delete_Button.Enabled = false;
            Edit_Button.Enabled = false;
            Remove_Button.Enabled = false;

            searchTxtBox.Text = "Search Here";
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
            con.Open();

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
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("select IsAdmin from teacher_table where T_username = '" + username + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string IsAdmin = dt.Rows[0][0].ToString();

                if (IsAdmin == "Yes")
                {
                    con.Close();

                    return "Admin";
                }
                else
                {
                    con.Close();

                    return "User";
                }
            }
            catch (Exception)
            {
                con.Close();

                MessageBox.Show("Connection Problem!");

                return null;
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

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to LogOut?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                LogOut();
            }
        }

        private void gobackToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void GoBack_Button_Click(object sender, EventArgs e)
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

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects ss = new Subjects(name, username);
            ss.Show();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students st = new Students(name, username);
            st.Show();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers tt = new Teachers(name, username);
            tt.Show();
        }

        private void Fillcombo()
        {
            MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);

            string T_id = dt1.Rows[0][0].ToString();

            MySqlCommand cmd = new MySqlCommand("select S_name from subject_table where T_id = '" + T_id + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string SubjectName = myReader.GetString("S_name");
                    
                    subjectBox.Items.Add(SubjectName);
                    subjectBox1.Items.Add(SubjectName);
                }

                myReader.Close();

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void sectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rollnoBox.Items.Clear();

            midTxtBox.Text = "";
            finalTxtBox.Text = "";
            sessionalTxtBox.Text = "";
            totalTxtBox.Text = "";
            gpaTxtBox.Text = "";
            gradeTxtBox.Text = "";

            MySqlCommand cmd = new MySqlCommand("select St_rollno from student_table where St_section = '" + sectionBox.Text + "' and St_session = '" + sessionBox.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string StudentRollNo = myReader.GetString("St_rollno").ToString();

                    rollnoBox.Items.Add(StudentRollNo);
                }

                if (rollnoBox.Items.Count != 0)
                {
                    rollnoBox.Enabled = true;

                    rollnoBox.Text = null;
                }
                else
                {
                    rollnoBox.Enabled = false;
                    Update_Button.Enabled = false;
                    Delete_Button.Enabled = false;

                    rollnoBox.Text = null;
                }

                myReader.Close();

                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void View_Button_Click(object sender, EventArgs e)
        {
            ViewButton_ClickFucn();
        }

        private void ViewButton_ClickFucn()
        {
            if (subjectBox1.Text == "" || sectionBox1.Text == "" || sessionBox1.Text == "")
            {
                MessageBox.Show("Subject , Section and Session Field is must Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    try
                    {
                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox1.Text + "' ", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);

                        string SubjectID = dt2.Rows[0][0].ToString();

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select St_rollno from student_table where St_section = '" + sectionBox1.Text + "' and St_session = '" + sessionBox1.Text + "' ",con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);

                        dt = new DataTable();

                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            string StudentRollno = dt1.Rows[i]["St_rollno"].ToString();

                            sda = new MySqlDataAdapter(@"Select No , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade from scoring_table where S_id = '" + SubjectID + "' and RollNo = '" + StudentRollno + "'", con);  // SELECT DISTINCT S.S_id , S.S_name , T.T_id , T.T_name , T.T_degree FROM subject_table S , teacher_table T where S.T_id = T.T_id
                           
                            sda.Fill(dt);
                        }

                        dataGridView1.DataSource = dt;
                        dataGridView1.AllowUserToAddRows = false;
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Query Error! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    con.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }

                Edit_Button.Enabled = true;
                Remove_Button.Enabled = true;
            }
        }

        private void Results_Load(object sender, EventArgs e)
        {
            string Fall = "Fall";

            for (int i = 2001; i <= 2099; i++)
            {
                string Session = Fall + " " + i;

                sessionBox.Items.Add(Session);
                sessionBox1.Items.Add(Session);
            }
        }

        private void sessionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionBox.Enabled = true;

            sectionBox.Text = null;

            nameTxtBox.Text = "";
            midTxtBox.Text = "";
            finalTxtBox.Text = "";
            sessionalTxtBox.Text = "";
            totalTxtBox.Text = "";
            gpaTxtBox.Text = "";
            gradeTxtBox.Text = "";
        }

        private void rollnoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subjectBox.Text == "")
            {
                MessageBox.Show("Please Select Subject!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Update_Button.Enabled = true;
                Delete_Button.Enabled = true;

                MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox.Text + "' ", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);

                string SubjectID = dt2.Rows[0][0].ToString();

                if (rollnoBox.Text != "")
                {
                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select St_name from student_table where St_rollno = '" + rollnoBox.Text + "' ", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    string StudentName = dt1.Rows[0][0].ToString();

                    nameTxtBox.Text = StudentName;
                }

                MySqlCommand cmd = new MySqlCommand("Select Mid , Final , Sessional , Total , GPA , Grade from scoring_table where S_id = '" + SubjectID + "' and RollNo = '" + rollnoBox.Text + "'", con);

                MySqlDataReader myReader;

                try
                {
                    con.Open();

                    myReader = cmd.ExecuteReader();

                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            string StudentMid = myReader.GetDouble("Mid").ToString();
                            string StudentFinal = myReader.GetDouble("Final").ToString();
                            string StudentSessional = myReader.GetDouble("Sessional").ToString();
                            string StudentTotal = myReader.GetDouble("Total").ToString();
                            string StudentGPA = myReader.GetDouble("GPA").ToString();
                            string StudentGrade = myReader.GetString("Grade").ToString();

                            midTxtBox.Text = StudentMid;
                            finalTxtBox.Text = StudentFinal;
                            sessionalTxtBox.Text = StudentSessional;
                            totalTxtBox.Text = StudentTotal;
                            gpaTxtBox.Text = StudentGPA;
                            gradeTxtBox.Text = StudentGrade;
                        }

                        myReader.Close();

                        con.Close();
                    }
                    else
                    {
                        midTxtBox.Text = "";
                        finalTxtBox.Text = "";
                        sessionalTxtBox.Text = "";
                        totalTxtBox.Text = "";
                        gpaTxtBox.Text = "";
                        gradeTxtBox.Text = "";

                        myReader.Close();

                        con.Close();
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }
            }
        }

        private void subjectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            rollnoBox.Text = null;
            nameTxtBox.Text = null;
            midTxtBox.Text = "";
            finalTxtBox.Text = "";
            sessionalTxtBox.Text = "";
            totalTxtBox.Text = "";
            gpaTxtBox.Text = "";
            gradeTxtBox.Text = "";
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            Btn = "A";

            Add_Update_Btn_Func();
        }

        private void Add_Update_Btn_Func()
        {
            Double mid = -1;
            Double sessional = -1;
            Double final = -1;
            Double total;
            Double gpa = 0.0;
            string grade = "";

            if (subjectBox.Text == "" || rollnoBox.Text == "" || nameTxtBox.Text == "" || midTxtBox.Text == "")
            {
                MessageBox.Show("Required Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (sessionalTxtBox.Text != "" && finalTxtBox.Text == "")
                {
                    try
                    {
                        sessional = Double.Parse(sessionalTxtBox.Text);
                        mid = Double.Parse(midTxtBox.Text);

                        if (mid > 30 || mid < 0)
                        {
                            MessageBox.Show("Mid must be positve or less then 31!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (sessional > 20 || sessional < 0)
                        {
                            MessageBox.Show("Sessional must be positve or less then 21!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Btn == "A")
                            {
                                Add_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                            else if (Btn == "U")
                            {
                                Update_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mid and Sessional fields must be in Digit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (finalTxtBox.Text != "" && sessionalTxtBox.Text == "")
                {
                    try
                    {
                        mid = Double.Parse(midTxtBox.Text);
                        final = Double.Parse(finalTxtBox.Text);

                        if (mid > 30 || mid < 0)
                        {
                            MessageBox.Show("Mid must be positve or less then 31!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (final > 50 || final < 0)
                        {
                            MessageBox.Show("Final must be positve or less then 51!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Btn == "A")
                            {
                                Add_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                            else if (Btn == "U")
                            {
                                Update_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mid and Final fields must be in Digit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (finalTxtBox.Text == "" && sessionalTxtBox.Text == "")
                {
                    try
                    {
                        mid = Double.Parse(midTxtBox.Text);

                        if (mid > 30 || mid < 0)
                        {
                            MessageBox.Show("Mid must be positve or less then 31!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (Btn == "A")
                            {
                                Add_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                            else if (Btn == "U")
                            {
                                Update_Fucn(mid, sessional, final, 0.0, 0.0, "");
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mid fields must be in Digit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    try
                    {
                        mid = Double.Parse(midTxtBox.Text);
                        sessional = Double.Parse(sessionalTxtBox.Text);
                        final = Double.Parse(finalTxtBox.Text);

                        if (mid > 30 || mid < 0)
                        {
                            MessageBox.Show("Mid must be positve or less then 31!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (sessional > 20 || sessional < 0)
                        {
                            MessageBox.Show("Sessional must be positve or less then 21!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (final > 50 || final < 0)
                        {
                            MessageBox.Show("Final must be positve or less then 51!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            total = mid + sessional + final;

                            gpa = getGPA(total);

                            grade = getGrade(total);

                            if (Btn == "A")
                            {
                                Add_Fucn(mid, sessional, final, total, gpa, grade);
                            }
                            else if (Btn == "U")
                            {
                                Update_Fucn(mid, sessional, final, total, gpa, grade);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Mid , Sessional and Final fields must be in Digit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Add_Fucn(Double Mid , Double Sessional , Double Final , Double Total , Double GPA , string Grade)
        {
            try
            {
                con.Open();

                MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id , Se_id , S_name from subject_table where S_name = '" + subjectBox.Text + "' ", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);

                string SubjectID = dt2.Rows[0][0].ToString();
                string SemesterID = dt2.Rows[0][1].ToString();
                string SubjectName = dt2.Rows[0][2].ToString();

                MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                string T_id = dt1.Rows[0][0].ToString();

                MySqlDataAdapter sda3 = new MySqlDataAdapter("select count(*) from scoring_table where T_id = '" + T_id + "' and S_id = '" + SubjectID + "' and RollNo = '" + rollnoBox.Text + "'", con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);

                string StudentCount = dt3.Rows[0][0].ToString();

                if (StudentCount != "0")
                {
                    con.Close();

                    MessageBox.Show("Student " + rollnoBox.Text + " Result of " + subjectBox.Text + " Subject is Already Inserted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into scoring_table (T_id , S_id , Se_id , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade) values('" + T_id + "' , '" + SubjectID + "' , '" + SemesterID + "' , '" + SubjectName + "' , '" + rollnoBox.Text + "' , '" + nameTxtBox.Text + "' , '" + Mid + "' , '" + Final + "' , '" + Sessional + "' , '" + Total + "' , '" + GPA + "' , '" + Grade + "')";

                    try
                    {
                        if (MessageBox.Show("Do you want to Add Result ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Result Added Successfully!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            rollnoBox.Text = null;
                            nameTxtBox.Text = "";
                            midTxtBox.Text = "";
                            finalTxtBox.Text = "";
                            sessionalTxtBox.Text = "";
                            totalTxtBox.Text = "";
                            gpaTxtBox.Text = "";
                            gradeTxtBox.Text = "";
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            Btn = "U";

            Add_Update_Btn_Func();
        }

        private void Update_Fucn(Double Mid, Double Sessional, Double Final, Double Total, Double GPA, string Grade)
        {
            try
            {
                con.Open();

                MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox.Text + "' ", con);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);

                string SubjectID = dt2.Rows[0][0].ToString();

                MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                string T_id = dt1.Rows[0][0].ToString();

                MySqlCommand cmd = new MySqlCommand(@"Update scoring_table set Mid = '" + Mid + "' , Final = '" + Final + "' , Sessional = '" + Sessional + "' , Total = '" + Total + "' , GPA = '" + GPA + "' , Grade = '" + Grade + "' where (T_id = '" + T_id + "' and S_id = '" + SubjectID + "' and RollNo = '" + rollnoBox.Text + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Update Result ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Result Updated Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        con.Close();

                        rollnoBox.Text = null;
                        nameTxtBox.Text = "";
                        midTxtBox.Text = "";
                        finalTxtBox.Text = "";
                        sessionalTxtBox.Text = "";
                        totalTxtBox.Text = "";
                        gpaTxtBox.Text = "";
                        gradeTxtBox.Text = "";
                    }

                    con.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (subjectBox.Text == "" || rollnoBox.Text == "")
                {
                    MessageBox.Show("Subject or RollNo Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }
                else
                {
                    MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox.Text + "' ", con);
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);

                    string SubjectID = dt2.Rows[0][0].ToString();

                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    string T_id = dt1.Rows[0][0].ToString();

                    MySqlCommand cmd = new MySqlCommand(@"Delete from scoring_table Where (T_id = '" + T_id + "' and S_id = '" + SubjectID + "' and RollNo = '" + rollnoBox.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Delete Result ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Result Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            rollnoBox.Text = null;
                            nameTxtBox.Text = "";
                            midTxtBox.Text = "";
                            finalTxtBox.Text = "";
                            sessionalTxtBox.Text = "";
                            totalTxtBox.Text = "";
                            gpaTxtBox.Text = "";
                            gradeTxtBox.Text = "";
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Query Inncorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
                    }
                }

                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void Remove_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);

                if (MessageBox.Show("Do you want to remove this row ?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }

                    sda.Update(dt);
                    MessageBox.Show("Result Removed Successfull!", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rollnoBox.Text = null;
                    nameTxtBox.Text = "";
                    midTxtBox.Text = "";
                    finalTxtBox.Text = "";
                    sessionalTxtBox.Text = "";
                    totalTxtBox.Text = "";
                    gpaTxtBox.Text = "";
                    gradeTxtBox.Text = "";
                }
            }

            catch
            {
                MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
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
                        con.Open();

                        try
                        {
                            sda = new MySqlDataAdapter("SELECT No , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade FROM scoring_table WHERE Name Like '%" + searchTxtBox.Text + "%' or RollNo Like '%" + searchTxtBox.Text + "%'", con);
                            dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView1.DataSource = dt;
                            dataGridView1.AllowUserToAddRows = false;

                            try
                            {
                                if (dt.Rows[0][0].ToString() != "")
                                {
                                    Edit_Button.Enabled = true;
                                    Remove_Button.Enabled = true;
                                }
                            }
                            catch (Exception)
                            {
                                // do nothing
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Query Error!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        con.Close();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
                    }
                }
            }
            else
            {
                if (subjectBox1.Text == "")
                {
                    MessageBox.Show("Please Select Subject First!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (searchTxtBox.Text == "")
                    {
                        MessageBox.Show("Enter something in Search Box!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        try
                        {
                            con.Open();

                            try
                            {
                                MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox1.Text + "' ", con);
                                DataTable dt2 = new DataTable();
                                sda2.Fill(dt2);

                                string SubjectID = dt2.Rows[0][0].ToString();

                                sda = new MySqlDataAdapter("SELECT No , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade FROM scoring_table WHERE S_id = '" + SubjectID + "' and (Name Like '%" + searchTxtBox.Text + "%' or RollNo Like '%" + searchTxtBox.Text + "%')", con);
                                dt = new DataTable();
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.AllowUserToAddRows = false;

                                try
                                {
                                    if (dt.Rows[0][0].ToString() != "")
                                    {
                                        Edit_Button.Enabled = true;
                                        Remove_Button.Enabled = true;
                                    }
                                }
                                catch (Exception)
                                {
                                    // do nothing
                                }
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("Query Error!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            con.Close();
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            con.Close();
                        }
                    }
                }
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            string[] SubjectID = new string[subjectBox1.Items.Count];

            List<string> Subjects = new List<string>();

            Double mid = 0;
            Double sessional = 0;
            Double final = 0;
            Double total = 0;
            Double gpa = 0.0;
            string grade = "";

            try
            {
                con.Open();

                string check = dt.Rows[0][0].ToString();

                scb = new MySqlCommandBuilder(sda);

                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sda.Update(dt);

                    MySqlDataAdapter sda4 = new MySqlDataAdapter("select S_id from subject_table", con);
                    DataTable dt4 = new DataTable();
                    sda4.Fill(dt4);

                    for (int j = 0; j < dt4.Rows.Count; j++)
                    {
                        string Subject_ID = dt4.Rows[j]["S_id"].ToString();

                        Subjects.Add(Subject_ID);
                    }

                    for (int i = 0; i < subjectBox1.Items.Count; i++)
                    {
                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id from subject_table where S_name = '" + subjectBox1.Items[i].ToString() + "' ", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);

                        SubjectID[i] = dt2.Rows[0][0].ToString();
                    }

                    MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    string T_id = dt1.Rows[0][0].ToString();

                    if (AdminSearchCheck.Enabled == true)
                    {
                        foreach (var Subject_id in Subjects)
                        {
                            MySqlDataAdapter sda3 = new MySqlDataAdapter("SELECT No , RollNo , Mid , Final , Sessional FROM scoring_table WHERE S_id = '" + Subject_id + "'", con);
                            DataTable dt3 = new DataTable();
                            sda3.Fill(dt3);

                            EditButtonFunc(dt3, mid, final, sessional, total, gpa, grade, Subject_id, null);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < SubjectID.Length; i++)
                        {
                            MySqlDataAdapter sda3 = new MySqlDataAdapter("SELECT No , RollNo , Mid , Final , Sessional FROM scoring_table WHERE S_id = '" + SubjectID[i] + "' and T_id = '" + T_id + "'", con);
                            DataTable dt3 = new DataTable();
                            sda3.Fill(dt3);

                            EditButtonFunc(dt3, mid, final, sessional, total, gpa, grade , SubjectID[i] , T_id);
                        }
                    }

                    con.Close(); 

                    MessageBox.Show("Result Edited Successfull!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    rollnoBox.Text = null;
                    nameTxtBox.Text = "";
                    midTxtBox.Text = "";
                    finalTxtBox.Text = "";
                    sessionalTxtBox.Text = "";
                    totalTxtBox.Text = "";
                    gpaTxtBox.Text = "";
                    gradeTxtBox.Text = "";
                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close(); 
            }
        }

        public void EditButtonFunc(DataTable dt3 , Double mid , Double final , Double sessional , Double total , Double gpa , string grade , string SubjectID , string T_id)
        {
            for (int j = 0; j < dt3.Rows.Count; j++)
            {
                string StudentRollno = dt3.Rows[j]["RollNo"].ToString();

                try
                {
                    mid = Double.Parse(dt3.Rows[j]["Mid"].ToString());
                }
                catch (Exception)
                {
                    mid = -1;
                }

                try
                {
                    final = Double.Parse(dt3.Rows[j]["Final"].ToString());
                }
                catch (Exception)
                {
                    final = -1;
                }

                try
                {
                    sessional = Double.Parse(dt3.Rows[j]["Sessional"].ToString());
                }
                catch (Exception)
                {
                    sessional = -1;
                }

                mid = checkMid(mid);

                final = checkFinal(final);

                sessional = checkSessional(sessional);

                if (sessional != -1 && final != -1 && mid != -1)
                {
                    total = mid + sessional + final;

                    gpa = getGPA(total);

                    grade = getGrade(total);
                }
                else
                {
                    total = 0;
                    gpa = 0;
                    grade = "";
                }

                if (AdminSearchCheck.Enabled == true)
                {
                    MySqlCommand cmd = new MySqlCommand(@"Update scoring_table set Mid = '" + mid + "' , Final = '" + final + "' , Sessional = '" + sessional + "' , Total = '" + total + "' , GPA = '" + gpa + "' , Grade = '" + grade + "' where (S_id = '" + SubjectID + "' and RollNo = '" + StudentRollno + "')", con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(@"Update scoring_table set Mid = '" + mid + "' , Final = '" + final + "' , Sessional = '" + sessional + "' , Total = '" + total + "' , GPA = '" + gpa + "' , Grade = '" + grade + "' where (T_id = '" + T_id + "' and S_id = '" + SubjectID + "' and RollNo = '" + StudentRollno + "')", con);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports rr = new Reports(name, username);
            rr.Show();
        }

        private void AdminSearchCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (AdminSearchCheck.Checked == true)
            {
                subjectBox1.Enabled = false;
                subjectBox1.Text = null;
            }
            else if(AdminSearchCheck.Checked == false)
            {
                subjectBox1.Enabled = true;
            }
        }

        private Double checkMid(Double mid)
        {
            if (mid > 30 || mid < 0)
            {
                mid = -1;

                return mid;
            }
            else
            {
                return mid;
            }
        }

        private Double checkFinal(Double final)
        {
            if (final > 50 || final < 0)
            {
                final = -1;

                return final;
            }
            else
            {
                return final;
            }
        }

        private Double checkSessional(Double sessional)
        {
            if (sessional > 20 || sessional < 0)
            {
                sessional = -1;

                return sessional;
            }
            else
            {
                return sessional;
            }
        }

        private Double getGPA(Double total)
        {
            if (total >= 80 && total <= 100)   // A+
            {
                return 4.00;
            }

            else if (total >= 75 && total <= 79)   // A
            {
                return 3.8;
            }

            else if (total >= 70 && total <= 74)   // B
            {
                return 3.5;
            }

            else if (total >= 65 && total <= 69)   // C
            {
                return 3.00;
            }

            else if (total >= 60 && total <= 64)   // D
            {
                return 2.8;
            }

            else if (total >= 55 && total <= 59)   // E
            {
                return 2.5;
            }

            else if (total >= 50 && total <= 54)   // E
            {
                return 2;
            }

            else if (total < 50)    // F
            {
                return 1.5;
            }
            else
            {
                return 0.0;
            }
        }

        private string getGrade(Double total)
        {
            if (total >= 80 && total <= 100)   // A+
            {
                return "A+";
            }
            else if (total >= 75 && total <= 79)   // A
            {
                return "A";
            }
            else if (total >= 70 && total <= 74)   // B
            {
                return "B";
            }
            else if (total >= 65 && total <= 69)   // C
            {
                return "C";
            }
            else if (total >= 60 && total <= 64)   // D
            {
                return "D";
            }
            else if (total >= 50 && total <= 59)   // E
            {
                return "E";
            }
            else if (total < 50)    // F
            {
                return "F";
            }
            else
            {
                return null;
            }
        }
        
        private bool Mid_Final_Sessional_Marks(string mid , string final , string sessional , string rollNo , string T_id , string SemesterID , string SubjectID , bool check , string checkMsg , int i)
        {
            Double Mid = -1;
            Double Sessional = -1;
            Double Final = -1;
            Double Total;
            Double GPA = 0.0;
            string Grade = "";

            MySqlDataAdapter sda3 = new MySqlDataAdapter("select St_name from student_table where St_session = '" + sessionBox1.Text + "' and St_section = '" + sectionBox1.Text + "' and St_rollNo = '" + rollNo + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);

            try
            {
                string StudentName = dt3.Rows[0][0].ToString();

                MySqlDataAdapter sda4 = new MySqlDataAdapter("select No , Mid , Final , Sessional from scoring_table where S_id = '" + SubjectID + "' and RollNo = '" + rollNo + "'", con);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);

                try
                {
                    string No = dt4.Rows[0][0].ToString();

                    if (checkMsg == "MF")
                    {
                        try
                        {
                            Mid = Double.Parse(mid);
                        }
                        catch (Exception)
                        {
                            Mid = -1;
                        }

                        try
                        {
                            Final = Double.Parse(final);
                        }
                        catch (Exception)
                        {
                            Final = -1;
                        }

                        Sessional = Double.Parse(dt4.Rows[0][3].ToString());
                    }

                    else if (checkMsg == "FS")
                    {
                        try
                        {
                            Final = Double.Parse(final);
                        }
                        catch (Exception)
                        {
                            Final = -1;
                        }

                        try
                        {
                            Sessional = Double.Parse(sessional);
                        }
                        catch (Exception)
                        {
                            Sessional = -1;
                        }

                        Mid = Double.Parse(dt4.Rows[0][1].ToString());
                    }

                    else if (checkMsg == "MS")
                    {
                        try
                        {
                            Mid = Double.Parse(mid);
                        }
                        catch (Exception)
                        {
                            Mid = -1;
                        }

                        try
                        {
                            Sessional = Double.Parse(sessional);
                        }
                        catch (Exception)
                        {
                            Sessional = -1;
                        }

                        Final = Double.Parse(dt4.Rows[0][2].ToString());
                    }

                    else if (checkMsg == "M")
                    {
                        try
                        {
                            Mid = Double.Parse(mid);
                        }
                        catch (Exception)
                        {
                            Mid = -1;
                        }

                        Final = Double.Parse(dt4.Rows[0][2].ToString());
                        Sessional = Double.Parse(dt4.Rows[0][3].ToString());
                    }

                    else if (checkMsg == "F")
                    {
                        try
                        {
                            Final = Double.Parse(final);
                        }
                        catch (Exception)
                        {
                            Final = -1;
                        }

                        Mid = Double.Parse(dt4.Rows[0][1].ToString());
                        Sessional = Double.Parse(dt4.Rows[0][3].ToString());
                    }

                    else if (checkMsg == "S")
                    {
                        try
                        {
                            Sessional = Double.Parse(sessional);
                        }
                        catch (Exception)
                        {
                            Sessional = -1;
                        }

                        Mid = Double.Parse(dt4.Rows[0][1].ToString());
                        Final = Double.Parse(dt4.Rows[0][2].ToString());
                    }

                    else
                    {
                        try
                        {
                            Mid = Double.Parse(mid);
                        }
                        catch (Exception)
                        {
                            Mid = -1;
                        }

                        try
                        {
                            Final = Double.Parse(final);
                        }
                        catch (Exception)
                        {
                            Final = -1;
                        }

                        try
                        {
                            Sessional = Double.Parse(sessional);
                        }
                        catch (Exception)
                        {
                            Sessional = -1;
                        }
                    }

                    Mid = checkMid(Mid);

                    Final = checkFinal(Final);

                    Sessional = checkSessional(Sessional);

                    if (Sessional != -1 && Final != -1 && Mid != -1)
                    {
                        Total = Mid + Sessional + Final;

                        GPA = getGPA(Total);

                        Grade = getGrade(Total);
                    }
                    else
                    {
                        Total = 0;
                        GPA = 0;
                        Grade = "";
                    }

                    MySqlCommand cmd = new MySqlCommand(@"Update scoring_table set Mid = '" + Mid + "' , Final = '" + Final + "' , Sessional = '" + Sessional + "' , Total = '" + Total + "' , GPA = '" + GPA + "' , Grade = '" + Grade + "' where (T_id = '" + T_id + "' and S_id = '" + SubjectID + "' and RollNo = '" + rollNo + "')", con);

                    try
                    {
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        int j = i;
                        j++;

                        MessageBox.Show("Error in file at line " + j + " Data not Enter of Specific Line! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (check == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception)
                {
                    try
                    {
                        Mid = Double.Parse(mid);
                    }
                    catch (Exception)
                    {
                        Mid = -1;
                    }

                    try
                    {
                        Final = Double.Parse(final);
                    }
                    catch (Exception)
                    {
                        Final = -1;
                    }

                    try
                    {
                        Sessional = Double.Parse(sessional);
                    }
                    catch (Exception)
                    {
                        Sessional = -1;
                    }

                    Mid = checkMid(Mid);

                    Final = checkFinal(Final);

                    Sessional = checkSessional(Sessional);

                    if (Sessional != -1 && Final != -1 && Mid != -1)
                    {
                        Total = Mid + Sessional + Final;

                        GPA = getGPA(Total);

                        Grade = getGrade(Total);
                    }
                    else
                    {
                        Total = 0;
                        GPA = 0;
                        Grade = "";
                    }

                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into scoring_table (T_id , S_id , Se_id , Subject , RollNo , Name , Mid , Final , Sessional , Total , GPA , Grade) values('" + T_id + "' , '" + SubjectID + "' , '" + SemesterID + "' , '" + subjectBox1.Text + "' , '" + rollNo + "' , '" + StudentName + "' , '" + Mid + "' , '" + Final + "' , '" + Sessional + "' , '" + Total + "' , '" + GPA + "' , '" + Grade + "')";

                    try
                    {
                        cmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (Exception ex)
                    {
                        int j = i;
                        j++;

                        MessageBox.Show("Error in file at line " + j + " Data not Enter of Specific Line! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        if (check == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                int j = i;
                j++;

                MessageBox.Show("Error in file at line " + j + " Data not Enter of Specific Line! \n" + "Student " + rollNo + " is not in section " + sectionBox1.Text + " of session " + sessionBox1.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (check == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void ImportResults_Button_Click(object sender, EventArgs e)
        {
            if (subjectBox1.Text == "" || sectionBox1.Text == "" || sessionBox1.Text == "")
            {
                MessageBox.Show("Subject , Section and Session Field is must Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MidsCheck.Checked == false && FinalsCheck.Checked == false && SessionalsCheck.Checked == false)
                {
                    MessageBox.Show("Mids , Finals or Sessional Checkboxes must Checked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        con.Open();

                        MySqlDataAdapter sda2 = new MySqlDataAdapter("select S_id , Se_id from subject_table where S_name = '" + subjectBox1.Text + "' ", con);
                        DataTable dt2 = new DataTable();
                        sda2.Fill(dt2);

                        string SubjectID = dt2.Rows[0][0].ToString();
                        string SemesterID = dt2.Rows[0][1].ToString();

                        MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_id from teacher_table where T_username = '" + username + "'", con);
                        DataTable dt1 = new DataTable();
                        sda1.Fill(dt1);

                        string T_id = dt1.Rows[0][0].ToString();

                        string checkMsg = "";

                        if (MidsCheck.Checked == true && FinalsCheck.Checked == true && SessionalsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Mids,Finals,Sessionals \n" + "BSCS-13-F-187,30,50,20 \n" + "BSCS-13-F-192,30,50,20", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "MFS";
                        }
                        else if (MidsCheck.Checked == true && FinalsCheck.Checked)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Mids,Finals \n" + "BSCS-13-F-187,30,50 \n" + "BSCS-13-F-192,30,50", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "MF";
                        }
                        else if (FinalsCheck.Checked == true && SessionalsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Finals,Sessionals \n" + "BSCS-13-F-187,50,20 \n" + "BSCS-13-F-192,50,20", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "FS";
                        }
                        else if (MidsCheck.Checked == true && SessionalsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Mids,Sessionals \n" + "BSCS-13-F-187,30,20 \n" + "BSCS-13-F-192,30,20", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "MS";
                        }
                        else if (MidsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Mids \n" + "BSCS-13-F-187,30 \n" + "BSCS-13-F-192,30", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "M";
                        }
                        else if (FinalsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Finals \n" + "BSCS-13-F-187,50 \n" + "BSCS-13-F-192,50", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "F";
                        }
                        else if (SessionalsCheck.Checked == true)
                        {
                            MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Sessionals \n" + "BSCS-13-F-187,20 \n" + "BSCS-13-F-192,20", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            checkMsg = "S";
                        }

                        Stream myStream = null;

                        char[] delimiterChars = { ',', '.', ':', '\t' };     // ' '

                        bool check = false;
                        int count = 0;
                        string rollNo = "";
                        string mid = "";
                        string final = "";
                        string sessional = "";

                        OpenFileDialog theDialog = new OpenFileDialog();
                        theDialog.Title = "Open File";
                        theDialog.Filter = "Chose File(*.txt; *.csv)|*.txt; *.csv";
                        theDialog.InitialDirectory = @"C:\Users\Saad Afzaal\Desktop";

                        if (theDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                if ((myStream = theDialog.OpenFile()) != null)
                                {
                                    using (myStream)
                                    {
                                        // Insert code to read the stream here.

                                        string ext = Path.GetExtension(theDialog.FileName);

                                        if (ext == ".txt" || ext == ".csv")
                                        {
                                            if (MessageBox.Show("Do you want to Import Results ?", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                            {
                                                string filename = theDialog.FileName;

                                                string[] filelines = File.ReadAllLines(filename);

                                                for (int i = 0; i < filelines.Length; i++)
                                                {
                                                    string[] StudentsInfo = filelines[i].Split(delimiterChars);

                                                    foreach (string R in StudentsInfo)
                                                    {
                                                        count++;

                                                        if (checkMsg == "MFS")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                mid = R;
                                                            }

                                                            else if (count == 3)
                                                            {
                                                                final = R;
                                                            }

                                                            else if (count == 4)
                                                            {
                                                                sessional = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "MF")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                mid = R;
                                                            }

                                                            else if (count == 3)
                                                            {
                                                                final = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "FS")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                final = R;
                                                            }

                                                            else if (count == 3)
                                                            {
                                                                sessional = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "MS")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                mid = R;
                                                            }

                                                            else if (count == 3)
                                                            {
                                                                sessional = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "M")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                mid = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "F")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                final = R;
                                                            }
                                                        }

                                                        else if (checkMsg == "S")
                                                        {
                                                            if (count == 1)
                                                            {
                                                                rollNo = R;
                                                            }

                                                            else if (count == 2)
                                                            {
                                                                sessional = R;
                                                            }
                                                        }
                                                    }

                                                    if ((checkMsg == "MFS" && (mid == "" || final == "" || sessional == "")) || (checkMsg == "MF" && (mid == "" || final == "")) || (checkMsg == "FS" && (final == "" || sessional == "")) || (checkMsg == "MS" && (mid == "" || sessional == "")) || (checkMsg == "M" && mid == "") || (checkMsg == "F" && final == "") || (checkMsg == "S" && sessional == ""))
                                                    {
                                                        int j = i;
                                                        j++;

                                                        MessageBox.Show("Error in file at line " + j + " Data not Enter of Specific Line", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                        if (check == true)
                                                        {
                                                            check = true;
                                                        }
                                                        else
                                                        {
                                                            check = false;
                                                        }
                                                    }

                                                    else
                                                    {
                                                        if (checkMsg == "MFS")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "MF")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "FS")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "MS")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "M")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "F")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }

                                                        else if (checkMsg == "S")
                                                        {
                                                            check = Mid_Final_Sessional_Marks(mid, final, sessional, rollNo, T_id, SemesterID, SubjectID, check, checkMsg, i);
                                                        }
                                                    }

                                                    count = 0;
                                                }

                                                con.Close();

                                                if (check == true)
                                                {
                                                    MessageBox.Show("Results Imported Successfully!", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    rollnoBox.Text = null;
                                                    nameTxtBox.Text = "";
                                                    midTxtBox.Text = "";
                                                    finalTxtBox.Text = "";
                                                    sessionalTxtBox.Text = "";
                                                    totalTxtBox.Text = "";
                                                    gpaTxtBox.Text = "";
                                                    gradeTxtBox.Text = "";
                                                }
                                            }
                                            else
                                            {
                                                con.Close();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("File must be in '.txt' & '.csv' format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                            con.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    con.Close();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                con.Close();
                            }
                        }
                        else
                        {
                            con.Close();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
                    }
                }
            }
        }
    }
}
