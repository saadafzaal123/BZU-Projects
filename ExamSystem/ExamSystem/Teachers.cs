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
    public partial class Teachers : Form
    {
        private string username;
        private string name;

        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public Teachers(string Name, string Username)
        {
            InitializeComponent();

            username = Username;

            name = Name;

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            goBackToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlB;
            SubjectsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlS;
            studentsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlD;
            resultsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlR;
            reportsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlE;
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            searchTxtBox.Text = "Search Here";

            UpdateTeacher_Button.Enabled = false;
            DeleteTeacher_Button.Enabled = false;
            EditTeachers_Button.Enabled = false;
            RemoveTeachers_Button.Enabled = false;

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

        private void Fillcombo()
        {
            MySqlCommand cmd = new MySqlCommand("select T_id from teacher_table order by T_id ASC", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string TeacherName = myReader.GetString("T_id");
                    comboBox1.Items.Add(TeacherName);
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

        private void ViewTeachers_Button_Click(object sender, EventArgs e)
        {
            ViewButton_ClickFucn();
        }

        private void ViewButton_ClickFucn()
        {
            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from teacher_table order by T_id ASC", con);
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

            EditTeachers_Button.Enabled = true;
            RemoveTeachers_Button.Enabled = true;
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminArea aa = new AdminArea(name, username);
            aa.Show();
        }

        private void GoBack_Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminArea aa = new AdminArea(name, username);
            aa.Show();
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminArea aa = new AdminArea(name, username);
            aa.Show();
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

        private void LogOut_Button2_Click(object sender, EventArgs e)
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

        private void EditTeachers_Button_Click(object sender, EventArgs e)
        {
            try
            {
                string check = dt.Rows[0][0].ToString();

                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sda.Update(dt);
                    MessageBox.Show("Teacher Edited Successfull!", "Edited", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

             catch (Exception ex)
             {
                 MessageBox.Show("Query Error! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }

        private void RemoveTeachers_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);

                if (MessageBox.Show("Do you want to remove this row ?", "Remove", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        dataGridView1.Rows.Remove(row);
                    }

                    sda.Update(dt);
                    MessageBox.Show("Teacher Removed Successfull!", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Clear();
                }
            }

            catch
            {
                MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowBlockedTeachers_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from teacher_table where IsBlocked = '" + "Yes" + "'", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
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
        }

        private void BlockedAllTeachers_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update teacher_table set IsBlocked = '" + "Yes" + "' Where (IsAdmin = '" + "No" + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Blocked All Teachers ?", "Block", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("All Teachers Blocked Successfully!", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }

                con.Close();

                Clear();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void UnBlockedAllTeachers_Button_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update teacher_table set IsBlocked = '" + "No" + "' Where (IsAdmin = '" + "No" + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to UnBlock All Teachers ?", "UnBlock", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("All Teachers UnBlocked Successfully!", "UnBlocked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con.Close();
                }

                con.Close();

                Clear();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
            }
        }

        private void AddTeacher_Button_Click(object sender, EventArgs e)
        {
            string UId = "UTCH000";
            string AId = "ATCH000";
            string Count;
            string T_id = "";
            int count = 0;

            if (nameTxtBox.Text == "" || usernameTxtBox.Text == "" || passwordTxtBox.Text == "" || degreeTxtBox.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Required Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    try
                    {
                        con.Open();

                        MySqlDataAdapter sda;
                        DataTable dt;

                        if (comboBox2.Text == "Yes")
                        {
                            sda = new MySqlDataAdapter("select AT_count from counter", con);
                            dt = new DataTable();
                            sda.Fill(dt);

                            string c = dt.Rows[0][0].ToString();

                            count = Int32.Parse(c);
                            count++;

                            Count = count.ToString();
                            T_id = AId + Count;
                        }
                        else
                        {
                            sda = new MySqlDataAdapter("select UT_count from counter", con);
                            dt = new DataTable();
                            sda.Fill(dt);

                            string c = dt.Rows[0][0].ToString();

                            count = Int32.Parse(c);
                            count++;

                            Count = count.ToString();
                            T_id = UId + Count;
                        }

                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "Insert into teacher_table (T_id , T_name , T_username , T_password , T_degree , T_image , Date , IsAdmin , IsBlocked , IsLogin) values('" + T_id + "' , '" + nameTxtBox.Text + "' , '" + usernameTxtBox.Text + "' , '" + passwordTxtBox.Text + "' , '" + degreeTxtBox.Text + "' ,  @img  , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm") + "' , '" + comboBox2.Text + "' , '" + comboBox3.Text + "' , '" + "No" + "')";

                        try
                        {
                            if (MessageBox.Show("Do you want to Add Teacher ?", "Add", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                cmd.Parameters.Add("@img", MySqlDbType.LongBlob).Value = img;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Teacher Added Successfully! \n Teacher " + nameTxtBox.Text + " ID is " + T_id, "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (comboBox2.Text == "Yes")
                                {
                                    MySqlCommand comd = new MySqlCommand(@"Update counter set AT_count = '" + count + "' ", con);
                                    comd.ExecuteNonQuery();
                                }
                                else
                                {
                                    MySqlCommand comd = new MySqlCommand(@"Update counter set UT_count = '" + count + "' ", con);
                                    comd.ExecuteNonQuery();
                                }

                                con.Close();

                                Clear();
                            }
                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Username is already use change it with diffrent Name! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                catch (Exception)
                {
                    MessageBox.Show("Please Chose Image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChoseImage_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Chose Image(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void UpdateTeacher_Button_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || nameTxtBox.Text == "" || usernameTxtBox.Text == "" || passwordTxtBox.Text == "" || degreeTxtBox.Text == "" || comboBox2.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Required Field is Empty Or ID Field is Empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    try
                    {
                        con.Open();

                        MySqlCommand cmd = new MySqlCommand(@"Update teacher_table set T_name = '" + nameTxtBox.Text + "' , T_username = '" + usernameTxtBox.Text + "' , T_password = '" + passwordTxtBox.Text + "' , T_degree = '" + degreeTxtBox.Text + "' , T_image = @img , IsAdmin = '" + comboBox2.Text + "' , IsBlocked = '" + comboBox3.Text + "' , date = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd HH:mm") + "' Where (T_id = '" + comboBox1.Text + "')", con);

                        try
                        {
                            if (MessageBox.Show("Do you want to Update Teacher ?", "Update", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                cmd.Parameters.Add("@img", MySqlDbType.LongBlob).Value = img;
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Teacher Updated Successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                con.Close();

                                Clear();
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Username is already use change it with diffrent Name!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            con.Close();
                        }

                        con.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Connection Problem!/n" + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        con.Close();
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Please Chose Image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteTeacher_Button_Click(object sender, EventArgs e)
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
                    MySqlCommand cmd = new MySqlCommand(@"Delete from teacher_table Where (T_id = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Delete Teacher ?", "Delete", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Teacher Deleted Successfully!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                        sda = new MySqlDataAdapter("SELECT * FROM teacher_table WHERE T_name Like '%"+searchTxtBox.Text+"%' or T_id Like '%"+searchTxtBox.Text+"%'", con);
                        dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = dt;
                        dataGridView1.AllowUserToAddRows = false;

                        try
                        {
                            if (dt.Rows[0][0].ToString() != "")
                            {
                                EditTeachers_Button.Enabled = true;
                                RemoveTeachers_Button.Enabled = true;
                            }
                        }
                        catch(Exception)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTeacher_Button.Enabled = true;
            DeleteTeacher_Button.Enabled = true;

            MySqlCommand cmd = new MySqlCommand("select * from teacher_table where T_id = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Name = myReader.GetString("T_name").ToString();
                    string Uname = myReader.GetString("T_username").ToString();
                    string Password = myReader.GetString("T_password").ToString();
                    string Degree = myReader.GetString("T_degree").ToString();
                    string Date = myReader.GetDateTime("Date").ToString();
                    string IsAdmin = myReader.GetString("IsAdmin").ToString();
                    string IsBlocked = myReader.GetString("IsBlocked").ToString();
                    byte[] img = (byte[])myReader["T_image"];

                    nameTxtBox.Text = Name;
                    usernameTxtBox.Text = Uname;
                    passwordTxtBox.Text = Password;
                    degreeTxtBox.Text = Degree;
                    dateTimePicker1.Text = Date;
                    comboBox2.Text = IsAdmin;
                    comboBox3.Text = IsBlocked;

                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
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

        private void SubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects sb = new Subjects(name,username);
            sb.Show();
        }

        private void Clear()
        {
            comboBox1.Text = "";
            nameTxtBox.Text = "";
            usernameTxtBox.Text = "";
            passwordTxtBox.Text = "";
            degreeTxtBox.Text = "";
            comboBox2.Text = null;
            comboBox3.Text = null;
            pictureBox1.Image = null;

            DateTime thisDay = DateTime.Today;
            dateTimePicker1.Text = thisDay.ToString();

            comboBox1.Items.Clear();
            Fillcombo();
            ViewButton_ClickFucn();
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
