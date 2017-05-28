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
    public partial class Students : Form
    {
        private string username;
        private string name;

        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public Students(string Name, string Username)
        {
            InitializeComponent();

            name = Name;

            username = Username;

            gobackToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlB;
            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            subjectsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlS;
            teachersToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlT;
            resultsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlR;
            reportsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlE;

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            if (GoBack() == "User")
            {
                subjectsToolStripMenuItem.Enabled = false;
                teachersToolStripMenuItem.Enabled = false;
            }

            Fillcombo();

            UpdateStudent_Button.Enabled = false;
            DeleteStudent_Button.Enabled = false;
            EditStudents_Button.Enabled = false;
            RemoveStudents_Button.Enabled = false;

            searchTxtBox.Text = "Search Here";

            string Fall = "Fall";

            for (int i = 2001; i <= 2099; i++)
            {
                string Session = Fall + " " + i;

                sessionBox.Items.Add(Session);
            }
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

        private void ViewButton_ClickFucn()
        {
            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from student_table order by St_rollno ASC", con);  // SELECT DISTINCT S.S_id , S.S_name , T.T_id , T.T_name , T.T_degree FROM subject_table S , teacher_table T where S.T_id = T.T_id
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }

            EditStudents_Button.Enabled = true;
            RemoveStudents_Button.Enabled = true;
        }

        private void ViewStudents_Button_Click(object sender, EventArgs e)
        {
            ViewButton_ClickFucn();
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

        private void gobackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GoBack() == "Admin")
            {
                this.Hide();
                AdminArea aa = new AdminArea(name, username);
                aa.Show();
            }
            else if(GoBack() == "User")
            {
                this.Hide();
                TeacherArea ta = new TeacherArea(name, username);
                ta.Show();
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

        private void Fillcombo()
        {
            MySqlCommand cmd = new MySqlCommand("select St_rollno from student_table order by St_rollno ASC", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string StudentRollNo = myReader.GetString("St_rollno");
                    comboBox1.Items.Add(StudentRollNo);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStudent_Button.Enabled = true;
            DeleteStudent_Button.Enabled = true;

            MySqlCommand cmd = new MySqlCommand("select * from student_table where St_rollno = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string StudentName = myReader.GetString("St_name").ToString();
                    string StudentSection = myReader.GetChar("St_section").ToString();
                    string StudentDepartment = myReader.GetString("St_department").ToString();
                    string StudentGender = myReader.GetString("St_gender").ToString();
                    string StudentSession = myReader.GetString("St_session").ToString();
                    string Date = myReader.GetDateTime("Date").ToString();

                    nameTxtBox.Text = StudentName;
                    comboBox2.Text = StudentSection;
                    comboBox3.Text = StudentDepartment;
                    
                    if(StudentGender == "Male")
                    {
                        maleRadio.Checked = true;
                    }
                    else
                    {
                        femaleRadio.Checked = true;
                    }

                    sessionBox.Text = StudentSession;

                    dateTimePicker1.Text = Date;
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

        private void EditStudents_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string check = dt.Rows[0][0].ToString();

                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sda.Update(dt);
                    MessageBox.Show("Student Edited Successfull!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Query Error! \n" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RemoveStudents_Button_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Student Removed Successfull!", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

            catch
            {
                MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            comboBox1.Text = "";
            nameTxtBox.Text = "";
            comboBox2.Text = null;
            comboBox3.Text = null;
            maleRadio.Checked = false;
            femaleRadio.Checked = false;

            DateTime thisDay = DateTime.Today;
            dateTimePicker1.Text = thisDay.ToString(); 

            comboBox1.Items.Clear();
            Fillcombo();
            ViewButton_ClickFucn();
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
            Teachers tt = new Teachers(name, username);
            tt.Show();
        }

        private void UpdateStudent_Button_Click(object sender, EventArgs e)
        {
            string gender = "";

            if ((comboBox1.Text == "" || nameTxtBox.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || sessionBox.Text == "") || (maleRadio.Checked == false && femaleRadio.Checked == false))
            {
                MessageBox.Show("Required Field is Empty Or RollNo Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (maleRadio.Checked == true)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(@"Update student_table set St_name = '" + nameTxtBox.Text + "' , St_section = '" + comboBox2.Text + "' , St_department = '" + comboBox3.Text + "' , St_session = '" + sessionBox.Text + "' , St_gender = '" + gender + "' , Date = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm") + "' where (St_rollno = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Update Student ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Student Updated Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            Clear();
                        }
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
                    MessageBox.Show("Connection Problem!/n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }
            }
        }

        private void DeleteStudent_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("ID Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(@"Delete from student_table Where (St_rollno = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Delete Student ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Student Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            Clear();
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = e.RowIndex;

                DataGridViewRow Row = dataGridView1.Rows[index]; 

                comboBox1.Text = Row.Cells[0].Value.ToString();

                //comboBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
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
                        sda = new MySqlDataAdapter("SELECT * FROM student_table WHERE St_name Like '%" + searchTxtBox.Text + "%' or St_rollno Like '%" + searchTxtBox.Text + "%' or St_session Like '%" + searchTxtBox.Text + "%'", con);
                        dt = new DataTable(); 
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AllowUserToAddRows = false;

                        try
                        {
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                EditStudents_Button.Enabled = true;
                                RemoveStudents_Button.Enabled = true;
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

        private void AddStudent_Button_Click(object sender, EventArgs e)
        {
            string gender = "";

            if ((comboBox1.Text == "" || nameTxtBox.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || sessionBox.Text == "") || (maleRadio.Checked == false && femaleRadio.Checked == false))
            {
                MessageBox.Show("Required Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (maleRadio.Checked == true)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Female";
                    }

                    con.Open();

                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into student_table (St_rollno , St_name , St_section , St_department , St_gender , St_session, Date ) values('" + comboBox1.Text + "' , '" + nameTxtBox.Text + "' , '" + comboBox2.Text + "' , '" + comboBox3.Text + "' , '" + gender + "' , '" + sessionBox.Text + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm") + "')";

                    try
                    {
                        if (MessageBox.Show("Do you want to Add Student ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Student Added Successfully!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            Clear();
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
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

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Results rr = new Results(name, username);
            rr.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports rr = new Reports(name, username);
            rr.Show();
        }

        private void AddStudentsFromFile_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MessageBox.Show("Extention in '.txt' & '.csv' format and File in form : \n" + "RollNo,Name,Section,Department,Gender,Session \n" + "BSCS-13-F-187,Janisar Hussain,C,BSCS,Male,Fall 2013 \n" + "BSCS-13-F-192,Saad Afzaal,C,BSCS,Male,Fall 2013", "File Format", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Stream myStream = null;

                char[] delimiterChars = { ',', '.', ':', '\t' };     // ' '

                bool check = false;
                int count = 0;
                string rollNo = "";
                string name = "";
                string section = "";
                string department = "";
                string gender = "";
                string session = "";

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
                                    if (MessageBox.Show("Do you want to Import Students ?", "Import", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        string filename = theDialog.FileName;

                                        string[] filelines = File.ReadAllLines(filename);

                                        for (int i = 0; i < filelines.Length; i++)
                                        {
                                            string[] StudentsInfo = filelines[i].Split(delimiterChars);

                                            foreach (string S in StudentsInfo)
                                            {
                                                count++;

                                                if (count == 1)
                                                {
                                                    rollNo = S;
                                                }

                                                else if (count == 2)
                                                {
                                                    name = S;
                                                }

                                                else if (count == 3)
                                                {
                                                    section = S;
                                                }

                                                else if (count == 4)
                                                {
                                                    department = S;
                                                }

                                                else if (count == 5)
                                                {
                                                    gender = S;
                                                }

                                                else if (count == 6)
                                                {
                                                    session = S;
                                                }
                                            }

                                            if (count < 6 || rollNo == "" || name == "" || section == "" || department == "" || gender == "" || session == "")
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
                                                MySqlCommand cmd = con.CreateCommand();
                                                cmd.CommandText = "Insert into student_table (St_rollno , St_name , St_section , St_department , St_gender , St_session, Date ) values('" + rollNo + "' , '" + name + "' , '" + section + "' , '" + department + "' , '" + gender + "' , '" + session + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm") + "')";

                                                try
                                                {
                                                    cmd.ExecuteNonQuery();

                                                    check = true;
                                                }
                                                catch (Exception ex)
                                                {
                                                    int j = i;
                                                    j++;

                                                    MessageBox.Show("Error in file at line " + j + " Data not Enter of Specific Line! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                                    if (check == true)
                                                    {
                                                        check = true;
                                                    }
                                                    else
                                                    {
                                                        check = false;
                                                    }
                                                }
                                            }

                                            count = 0;
                                        }

                                        con.Close();

                                        if (check == true)
                                        {
                                            MessageBox.Show("Students Imported Successfully!", "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            Clear();
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
