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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Activated(object sender, EventArgs e)
        {
            usernameTxtBox.Focus();
        }

        private void CloseMe_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to exit application?", "Exit", MessageBoxButtons.YesNo , MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=exam_system;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("Select Count(*) , IsAdmin , IsBlocked , IsLogin , T_name from teacher_table where T_username = '" + usernameTxtBox.Text + "' and T_password = '" + passwordTxtBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    if (dt.Rows[0][2].ToString() == "No")
                    {
                        if (dt.Rows[0][3].ToString() == "Yes")
                        {
                            MessageBox.Show("You are Already Login!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (RememeberMe.Checked == true)
                            {
                                MySqlCommand sc = new MySqlCommand(@"Update teacher_table set IsLogin = '" + "Yes" + "' where T_username = '" + usernameTxtBox.Text + "'", con);

                                if (dt.Rows[0][1].ToString() == "Yes")
                                {
                                    try
                                    {
                                        sc.ExecuteNonQuery();

                                        this.Hide();
                                        AdminArea aa = new AdminArea(dt.Rows[0][4].ToString() , usernameTxtBox.Text);
                                        aa.Show();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Some Error Occur During Login Please try Later!", "Error" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        sc.ExecuteNonQuery();

                                        this.Hide();
                                        TeacherArea ta = new TeacherArea(dt.Rows[0][4].ToString() , usernameTxtBox.Text);
                                        ta.Show();
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Some Error Occur During Login Please try Later!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please Check Remember Me!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Account has been Blocked Contact Admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Passward!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Problem!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
