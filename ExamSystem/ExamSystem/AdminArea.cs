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
    public partial class AdminArea : Form
    {
        private string username;
        private string name;

        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

        public AdminArea(string Name , string Username)
        {
            InitializeComponent();

            name = Name;

            welcomeLabel.Text = "Welcome : " + Name;

            usernameLabel.Text = "Username : " + Username;

            username = Username;

            DisplayImage();

            this.FormClosing += new FormClosingEventHandler(frmLogin_FormClosing);

            logOutToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.AltF4;
            teachersToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlT;
            subjectsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlS;
            studentsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlD;
            resultsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlR;
            reportsToolStripMenuItem.ShortcutKeys = (Keys)Shortcut.CtrlE;
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

        private void DisplayImage()
        {
            MySqlCommand cmd = new MySqlCommand("select * from teacher_table where T_username = '" + username + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    byte[] img = (byte[])myReader["T_image"];

                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }

                myReader.Close();

                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!" , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                con.Close();
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

                con.Close();
            }
        }

        private void Teachers_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers t = new Teachers(name, username);
            t.Show();
        }

        private void teachersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Teachers t = new Teachers(name, username);
            t.Show();
        }

        private void Subjects_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects sb = new Subjects(name, username);
            sb.Show();
        }

        private void subjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Subjects sb = new Subjects(name, username);
            sb.Show();
        }

        private void Students_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students st = new Students(name, username);
            st.Show();
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Students st = new Students(name, username);
            st.Show();
        }

        private void Results_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Results rr = new Results(name, username);
            rr.Show();
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Results rr = new Results(name, username);
            rr.Show();
        }

        private void Reports_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reports rr = new Reports(name , username);
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
