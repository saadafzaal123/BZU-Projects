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
    public partial class ManageUserAccounts : Form
    {
        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        string Name;

        public ManageUserAccounts(string name)
        {
            InitializeComponent();
            Fillcombo();
            Name = name;

            Update_Button.Enabled = false;
            Remove_Button.Enabled = false;

            Add_Button.Enabled = false;
            Edit_Button.Enabled = false;
            Delete_User_Button.Enabled = false;
        }

        private void ManageUserAccounts_Load(object sender, EventArgs e)
        {

        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage ad = new AdminPage(Name);
            ad.Show();
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void Show_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from accounts", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Error!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }

            Update_Button.Enabled = true;
            Remove_Button.Enabled = true;
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sda.Update(dt);
                    MessageBox.Show("User Updated Successfull!");

                    this.Hide();
                    ManageUserAccounts mua = new ManageUserAccounts(Name);
                    mua.Show();
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Query Error!");
            }
        }

        private void Remove_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    sda.Update(dt);
                    MessageBox.Show("User Deleted Successfull!");

                    this.Hide();
                    ManageUserAccounts mua = new ManageUserAccounts(Name);
                    mua.Show();
                }
            }

            catch
            {
                MessageBox.Show("Query Error!");
            }
        }

        private void Show_Blocked_User_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select * from accounts where IsBlocked = '"+ "Yes" +"'", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Error!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Fillcombo()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select Name from accounts order by Name ASC", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Uname = myReader.GetString("Name");
                    comboBox1.Items.Add(Uname);
                }
                myReader.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Edit_Button.Enabled = true;
            Delete_User_Button.Enabled = true;

            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");
            
            MySqlCommand cmd = new MySqlCommand("select * from accounts where Name = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;
            
            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string UsrId = myReader.GetString("UsrId");
                    string Address = myReader.GetString("Address");
                    string CellPhone = myReader.GetString("CellPhone");
                    string Password = myReader.GetString("Password");
                    string IsAdmin = myReader.GetString("IsAdmin");
                    string MedStrName = myReader.GetString("MedStrName");
                    string IsBlocked = myReader.GetString("IsBlocked");

                    UsrIdTxtBox.Text = UsrId;
                    AddressTxtBox.Text = Address;
                    CellPhoneTxtBox.Text = CellPhone;
                    PasswordTxtBox.Text = Password;
                    IsAdminComboBox.Text = IsAdmin;
                    MedStrNameTxtBox.Text = MedStrName;
                    IsBlockedComboBox.Text = IsBlocked;
                 }
                 
                myReader.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                if (comboBox1.Text == "" || UsrIdTxtBox.Text == "" || AddressTxtBox.Text == "" || CellPhoneTxtBox.Text == "" || PasswordTxtBox.Text == "" || IsAdminComboBox.Text == "" || IsBlockedComboBox.Text == "")
                {
                    MessageBox.Show("Require Fields Empty!");
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into accounts (UsrId , Name , Address , CellPhone , Password , IsAdmin , MedStrName , IsBlocked) values('" + UsrIdTxtBox.Text + "' , '" + comboBox1.Text + "' , '" + AddressTxtBox.Text + "' , '" + CellPhoneTxtBox.Text + "' , '" + PasswordTxtBox.Text + "' , '" + IsAdminComboBox.Text + "' , '" + MedStrNameTxtBox.Text + "' , '" + IsBlockedComboBox.Text + "')";

                    try
                    {
                        if ((IsAdminComboBox.Text == "Yes" || IsAdminComboBox.Text == "No") && (IsBlockedComboBox.Text == "Yes" || IsBlockedComboBox.Text == "No"))
                        {
                            if (MessageBox.Show("Do you want to Add Data ?", "Add", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("User Inserted Successfully!");

                                this.Hide();
                                ManageUserAccounts mua = new ManageUserAccounts(Name);
                                mua.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Isblocked and IsAdmin must be in form (Yes/No)!");
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("UsrId is not Valid!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update accounts Set Name = '" + comboBox1.Text + "' , Address = '" + AddressTxtBox.Text + "' , CellPhone = '" + CellPhoneTxtBox.Text + "' , Password = '" + PasswordTxtBox.Text + "' , IsAdmin = '" + IsAdminComboBox.Text + "' , IsBlocked = '" + IsBlockedComboBox.Text + "' , MedStrName = '" + MedStrNameTxtBox.Text + "' Where (UsrId = '" + UsrIdTxtBox.Text + "')", con);

                try
                {
                    if ((IsAdminComboBox.Text == "Yes" || IsAdminComboBox.Text == "No") && (IsBlockedComboBox.Text == "Yes" || IsBlockedComboBox.Text == "No"))
                    {
                        if (MessageBox.Show("Do you want to Update Data ?", "Update", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User Edit Successfully!");

                            this.Hide();
                            ManageUserAccounts mua = new ManageUserAccounts(Name);
                            mua.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Isblocked and IsAdmin must be in form (Yes/No)!");
                    }

                    con.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Delete_User_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Delete from accounts Where (UsrId = '" + UsrIdTxtBox.Text + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Delete Data ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User Deleted Successfully!");

                        this.Hide();
                        ManageUserAccounts mua = new ManageUserAccounts(Name);
                        mua.Show();
                    }
                    con.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Blocked_All_Users_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update accounts set IsBlocked = '" + "Yes" + "' Where (IsAdmin = '" + "No" + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Blocked All Users ?", "Blocked", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("All Users Blocked Successfully!");
                    }
                    con.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void UsrIdTxtBox_TextChanged(object sender, EventArgs e)
        {
            Add_Button.Enabled = true;
        }

        private void UnBlocked_All_Users_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update accounts set IsBlocked = '" + "No" + "' Where (IsAdmin = '" + "No" + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to UnBlock All Users ?", "UnBlocked", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("All Users UnBlock Successfully!");
                    }
                    con.Close();
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Inncorrect!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
