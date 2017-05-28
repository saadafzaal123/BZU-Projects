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

namespace Medical_Store_Managment_System
{
    public partial class Login_Form : Form
    {
        int count = 0;

        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("Select Count(*) from accounts where Name = '" + usernameTxtBox.Text + "' and Password = '" + passwordTxtBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    MySqlDataAdapter sda1 = new MySqlDataAdapter("Select IsAdmin , Isblocked from accounts where Name = '" + usernameTxtBox.Text + "' and Password = '" + passwordTxtBox.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    if (dt1.Rows[0][0].ToString() == "Yes")
                    {
                        this.Hide();
                        AdminPage ad = new AdminPage(usernameTxtBox.Text);
                        ad.Show();
                    }

                    if (dt1.Rows[0][0].ToString() == "No")
                    {
                        if (dt1.Rows[0][1].ToString() == "No")
                        {
                            this.Hide();
                            UserPage us = new UserPage(usernameTxtBox.Text);
                            us.Show();
                        }
                        else
                        {
                            MessageBox.Show("Your account has been blocked!");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Wrong UserName or Passward!");
                    count++;

                    if (count == 3)
                    {
                        MySqlDataAdapter sda3 = new MySqlDataAdapter("Select IsAdmin from accounts where Name = '" + usernameTxtBox.Text + "'", con);
                        DataTable dt3 = new DataTable();
                        sda3.Fill(dt3);

                        if (dt3.Rows[0][0].ToString() == "No")
                        {
                            MySqlCommand cmd = new MySqlCommand(@"Update accounts Set IsBlocked = '" + "Yes" + "'  Where (Name = '" + usernameTxtBox.Text + "')", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Due to try more then 3 times so account has been blocked!");
                                count = 0;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Blocked Error!");
                            }
                        }
                    }
                }

                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
