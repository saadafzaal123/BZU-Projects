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
    public partial class Expense : Form
    {
        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        string Name;

        public Expense(string name)
        {
            InitializeComponent();
            Fillcombo();
            Name = name;

            Update_Button.Enabled = false;
            Remove_Button.Enabled = false;

            Add_Expense_Button.Enabled = false;
            Edit_button.Enabled = false;
            Delete_Button.Enabled = false;
        }

        private void Expense_Load(object sender, EventArgs e)
        {

        }

        private void Go_Back_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage ad = new AdminPage(Name);
            ad.Show();
        }

        private void LogOut_button_Click(object sender, EventArgs e)
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
                    sda = new MySqlDataAdapter(@"Select * from expense", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

                catch (Exception)
                {
                    MessageBox.Show("Query Error!");
                }

                Update_Button.Enabled = true;
                Remove_Button.Enabled = true;
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);

                scb.ConflictOption = ConflictOption.OverwriteChanges;

                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    sda.Update(dt);
                    MessageBox.Show("Expense Updated Successfull!");

                    this.Hide();
                    Expense ex = new Expense(Name);
                    ex.Show();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Remove_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);

                scb.ConflictOption = ConflictOption.OverwriteChanges;

                if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    sda.Update(dt);
                    MessageBox.Show("Expense Deleted Successfull!");

                    this.Hide();
                    Expense ex = new Expense(Name);
                    ex.Show();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Fillcombo()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select Expense from expense order by Expense ASC", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Expense = myReader.GetString("Expense");
                    comboBox1.Items.Add(Expense);
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
            Edit_button.Enabled = true;
            Delete_Button.Enabled = true;

            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select * from expense where Expense = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Price = myReader.GetDouble("Price").ToString();
                    string Date = myReader.GetDateTime("Date").ToString();

                    PriceTxtBox.Text = Price;
                    dateTimePicker1.Text = Date;
                }

                myReader.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Add_Expense_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                if (comboBox1.Text == "" || PriceTxtBox.Text == "")
                {
                    MessageBox.Show("Require Fields Empty!");
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into expense (Expense , Price , Date) values('" + comboBox1.Text + "' , '" + PriceTxtBox.Text + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                    try
                    {
                        if (MessageBox.Show("Do you want to Add Expense ?", "Add", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Expense Inserted Successfully!");

                            this.Hide();
                            Expense ex = new Expense(Name);
                            ex.Show();
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Expense is InValid!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void Edit_button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Update expense set Price = '" + PriceTxtBox.Text + "' , Date = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' Where (Expense = '" + comboBox1.Text + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Edit Expense ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense Edit Successfully!");

                        this.Hide();
                        Expense ex = new Expense(Name);
                        ex.Show();
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

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Delete from expense Where (Expense = '" + comboBox1.Text + "')", con);

                try
                {
                    if (MessageBox.Show("Do you want to Delete Expense ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Expense Deleted Successfully!");

                        this.Hide();
                        Expense ex = new Expense(Name);
                        ex.Show();
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

        private void PriceTxtBox_TextChanged(object sender, EventArgs e)
        {
            Add_Expense_Button.Enabled = true;
        }
    }
}
