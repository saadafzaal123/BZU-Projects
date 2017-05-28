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
    public partial class ResetPassword : Form
    {
        string NAME;

        public ResetPassword(string name)
        {
            InitializeComponent();
            NAME = name;
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
             MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

             try
             {
                 con.Open();

                 MySqlDataAdapter sda = new MySqlDataAdapter("Select IsAdmin from accounts where Name = '"+NAME+"'", con);
                 DataTable dt = new DataTable();
                 sda.Fill(dt);

                 if (dt.Rows[0][0].ToString() == "No")
                 {
                     this.Hide();
                     UserPage us = new UserPage(NAME);
                     us.Show();
                 }

                 if (dt.Rows[0][0].ToString() == "Yes")
                 {
                     this.Hide();
                     AdminPage ad = new AdminPage(NAME);
                     ad.Show();
                 }
            
             }

             catch (Exception)
             {
                 MessageBox.Show("Connection Problem!");
             }         
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("Select Count(*) from accounts where Name = '" + NAME + "' and Password = '" + CpasswordTxtBox.Text + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    string Npass =  NpasswordTxtBox.Text;
                    string CNPass = CNpasswordTxtBox.Text;

                    if (Npass == CNPass)
                    {
                        MySqlCommand cm = new MySqlCommand(@"Update accounts Set Password = '" + NpasswordTxtBox.Text + "'  where (Password = '" + CpasswordTxtBox.Text + "' and Name = '" + NAME + "')", con);

                        try
                        {
                            cm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Password reset Successfully!");

                            CpasswordTxtBox.Text = "";
                            NpasswordTxtBox.Text = "";
                            CNpasswordTxtBox.Text = "";
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Password does not reset!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("New-Password and Confirm-New-Password does not match!");
                    }
                 }
                 else
                 {
                    MessageBox.Show("Wrong Current Password!");
                 }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
