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

namespace ExamSystem
{
    public partial class Subjects : Form
    {
        private string username;
        private string name;

        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public Subjects(string Name, string Username)
        {
            InitializeComponent();

            name = Name;

            username = Username;

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            goBackToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlB;
            teachersToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlT;
            studentsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlD;
            resultsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlR;
            reportsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlE;

            searchTxtBox.Text = "Search Here";

            UpdateSubject_Button.Enabled = false;
            DeleteSubject_Button.Enabled = false;
            EditSubjects_Button.Enabled = false;
            RemoveSubjects_Button.Enabled = false;

            Fillcombo();
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

        private void ViewButton_ClickFucn()
        {
            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from subject_table order by S_id ASC", con);  // SELECT DISTINCT S.S_id , S.S_name , T.T_id , T.T_name , T.T_degree FROM subject_table S , teacher_table T where S.T_id = T.T_id
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

            EditSubjects_Button.Enabled = true;
            RemoveSubjects_Button.Enabled = true;
        }

        private void ViewSubjects_Button_Click(object sender, EventArgs e)
        {
            ViewButton_ClickFucn();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to LogOut?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
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

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to LogOut?", "LogOut", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                LogOut();
            }
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminArea aa = new AdminArea(name, username);
            aa.Show();
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminArea aa = new AdminArea(name, username);
            aa.Show();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers ta = new Teachers(name, username);
            ta.Show();
        }

        private void EditSubjects_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string check = dt.Rows[0][0].ToString();

                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sda.Update(dt);
                    MessageBox.Show("Subject Edited Successfull!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RemoveSubjects_Button_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Subjects Removed Successfull!", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

            catch
            {
                MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Fillcombo()
        {
            MySqlCommand cmd = new MySqlCommand("select S_id , S_name from subject_table order by S_id ASC", con);

            MySqlCommand cmd1 = new MySqlCommand("select T_id from teacher_table order by T_id ASC", con);

            MySqlDataReader myReader;

            MySqlDataReader myReader1;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();
                
                while (myReader.Read())
                {
                    string SubjectID = myReader.GetString("S_id");
                    string SubjectName = myReader.GetString("S_name");

                    comboBox1.Items.Add(SubjectID);
                    nameBox.Items.Add(SubjectName);
                }

                myReader.Close();

                myReader1 = cmd1.ExecuteReader();

                while (myReader1.Read())
                {
                    string TeacherID = myReader1.GetString("T_id");
                    
                    teacherBox.Items.Add(TeacherID);
                }

                myReader1.Close();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSubject_Button.Enabled = true;
            DeleteSubject_Button.Enabled = true;

            string Teacher_id = "";
            string Name = "";

            MySqlCommand cmd = new MySqlCommand("select * from subject_table where S_id = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    Name = myReader.GetString("S_name").ToString();
                    string CreditHours = myReader.GetInt32("S_credithours").ToString();
                    Teacher_id = myReader.GetString("T_id").ToString();
                    string Semester_id = myReader.GetString("Se_id").ToString();

                    comboBox2.Text = CreditHours;
                    semesterBox.Text = Semester_id; 
                }

                myReader.Close();

                con.Close();

                nameBox.Text = Name;
                teacherBox.Text = Teacher_id;
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSubject_Button.Enabled = true;
            DeleteSubject_Button.Enabled = true;

            string Teacher_id = "";
            string Id = ""; 

            MySqlCommand cmd = new MySqlCommand("select * from subject_table where S_name = '" + nameBox.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    Id = myReader.GetString("S_id").ToString();
                    string CreditHours = myReader.GetInt32("S_credithours").ToString();
                    Teacher_id = myReader.GetString("T_id").ToString();
                    string Semester_id = myReader.GetString("Se_id").ToString();

                    comboBox2.Text = CreditHours;
                    semesterBox.Text = Semester_id;
                }

                myReader.Close();

                con.Close();

                comboBox1.Text = Id;
                teacherBox.Text = Teacher_id;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void teacherBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MySqlDataAdapter sda1 = new MySqlDataAdapter("select T_name , T_degree from teacher_table where T_id = '" + teacherBox.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);

                nameLabel.Text = "Name    :  " + dt1.Rows[0][0].ToString();
                degreeLabel.Text = "Degree  :  " + dt1.Rows[0][1].ToString();

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Connection Problem!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void AddSubject_Button_Click(object sender, EventArgs e)
        {
            string SId = "CS00";
            string Count;
            string S_id = "";
            int count = 0;

            if (nameBox.Text == "" || comboBox2.Text == "" || teacherBox.Text == "" || semesterBox.Text == "")
            {
                MessageBox.Show("Required Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    MySqlDataAdapter sda;
                    DataTable dt;

                    sda = new MySqlDataAdapter("select S_count from counter", con);
                    dt = new DataTable();
                    sda.Fill(dt);

                    string c = dt.Rows[0][0].ToString();

                    count = Int32.Parse(c);
                    count++;

                    Count = count.ToString();
                    S_id = SId + Count;
     
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into subject_table (S_id , S_name , S_credithours , T_id , Se_id ) values('" + S_id + "' , '" + nameBox.Text + "' , '" + comboBox2.Text + "' , '" + teacherBox.Text + "' , '" + semesterBox.Text + "')";

                    try
                    {
                        if (MessageBox.Show("Do you want to Add Subject ?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Subject Added Successfully! \n Subject" + nameBox.Text + " ID is " + S_id, "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            MySqlCommand comd = new MySqlCommand(@"Update counter set S_count = '" + count + "' ", con);
                            comd.ExecuteNonQuery();

                            con.Close();

                            Clear();
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Subject Name is Duplicated change it with addition 1,2,3 like OOP2 , OOP3 , OOP4 etc \n OR \n" + "You Enter Wrong Teacher Id which does not exist!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void UpdateSubject_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || nameBox.Text == "" || comboBox2.Text == "" || teacherBox.Text == "" || semesterBox.Text == "")
            {
                MessageBox.Show("Required Field is Empty Or ID Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(@"Update subject_table set S_name = '" + nameBox.Text + "' , S_credithours = '" + comboBox2.Text + "' , T_id = '" + teacherBox.Text + "' , Se_id = '" + semesterBox.Text + "' where (S_id = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Update Subject ?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Subject Updated Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            con.Close();

                            Clear();
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Subject Name is Duplicated change it with addition 1,2,3 like OOP2 , OOP3 , OOP4 etc \n + OR \n" + "You Enter Wrong Teacher Id which does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void Clear()
        {
            comboBox1.Text = "";
            nameBox.Text = "";
            comboBox2.Text = null;
            teacherBox.Text = "";
            nameLabel.Text = "Name  :";
            degreeLabel.Text = "Degree  :";
            semesterBox.Text = null;

            comboBox1.Items.Clear();
            nameBox.Items.Clear();
            teacherBox.Items.Clear();

            Fillcombo();
            ViewButton_ClickFucn();
        }

        private void DeleteSubject_Button_Click(object sender, EventArgs e)
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
                    MySqlCommand cmd = new MySqlCommand(@"Delete from subject_table Where (S_id = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Delete Subject ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Subject Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        sda = new MySqlDataAdapter("SELECT * FROM subject_table WHERE S_name Like '%" + searchTxtBox.Text + "%' or S_id Like '%" + searchTxtBox.Text + "%' or T_id Like '%" + searchTxtBox.Text + "%'", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AllowUserToAddRows = false;

                        try
                        {
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                EditSubjects_Button.Enabled = true;
                                RemoveSubjects_Button.Enabled = true;
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

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports rr = new Reports(name, username);
            rr.Show();
        }
    }
}
