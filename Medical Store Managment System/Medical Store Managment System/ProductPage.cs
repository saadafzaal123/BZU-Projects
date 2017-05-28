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
    public partial class ProductPage : Form
    {
        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        string Name;

        public ProductPage(string name)
        {
            InitializeComponent();
            Fillcombo();
            Name = name;

            Update_Button.Enabled = false;
            Remove_Button.Enabled = false;

            Add_Button.Enabled = false;
            Edit_Button.Enabled = false;
            Delete_Button.Enabled = false;  
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
                    sda = new MySqlDataAdapter(@"Select * from medicine order by MedCde ASC", con);
                    dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
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
                    MessageBox.Show("Medicine Updated Successfull!");

                    this.Hide();
                    ProductPage pp = new ProductPage(Name);
                    pp.Show();
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
                    MessageBox.Show("Medicine Deleted Successfull!");

                    this.Hide();
                    ProductPage pp = new ProductPage(Name);
                    pp.Show();
                }
            }

            catch
            {
                MessageBox.Show("Query Error!");
            }
        }

        private void Fillcombo()
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select Name from medicine order by Name ASC", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Name = myReader.GetString("Name");
                    comboBox1.Items.Add(Name);
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
            Delete_Button.Enabled = true;

            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select * from medicine where Name = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Type = myReader.GetString("Type");
                    string Stock = myReader.GetInt32("Stock").ToString();
                    string Sold = myReader.GetInt32("Sold").ToString();
                    string PurUntPrice = myReader.GetDouble("PurUntPrice").ToString();
                    string SldUntPrice = myReader.GetDouble("SldUntPrice").ToString();
                    string ThhVal = myReader.GetInt32("ThhVal").ToString();
                    string Discount = myReader.GetDouble("Discount").ToString();
                    string NewStock = myReader.GetDouble("NewStock").ToString();
                    string NewPurUntPrice = myReader.GetDouble("NewPurUntPrice").ToString();

                    TypeTxtBox.Text = Type;
                    StockTxtBox.Text = Stock;
                    SoldTxtBox.Text = Sold;
                    PurUntPriceTxtBox.Text = PurUntPrice;
                    SldUntPriceTxtBox.Text = SldUntPrice;
                    ThhValTxtBox.Text = ThhVal;
                    DiscountTxtBox.Text = Discount;
                    NewStockTxtBox.Text = NewStock;
                    NewPurUntPriceTxtBox.Text = NewPurUntPrice;
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

            string MedCde;
            string Count;
            string RNo = "IFN000"; 

            try
            {
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("select count from counter", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                string c = dt.Rows[0][0].ToString();
         
                int count = Int32.Parse(c);
                count++;

                Count = count.ToString();
                MedCde = RNo + Count;

                if (comboBox1.Text == "" || TypeTxtBox.Text == "" || PurUntPriceTxtBox.Text == "" || SldUntPriceTxtBox.Text == "" || ThhValTxtBox.Text == "" || DiscountTxtBox.Text == "")
                {
                    MessageBox.Show("Require Fields Empty!");
                }
                else
                {
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "Insert into medicine (MedCde , Type , Name , PurUntPrice , SldUntPrice , ThhVal , Discount , NewPurUntPrice) values('" + MedCde + "' , '" + TypeTxtBox.Text + "' , '" + comboBox1.Text + "' , '" + PurUntPriceTxtBox.Text + "' , '" + SldUntPriceTxtBox.Text + "' , '" + ThhValTxtBox.Text + "' , '" + DiscountTxtBox.Text + "' , '" + NewPurUntPriceTxtBox.Text + "')";

                    try
                    {
                        if (MessageBox.Show("Do you want to Add Medicine ?", "Add", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Medicine Inserted Successfully!");

                            MySqlCommand comd = new MySqlCommand(@"Update counter set count = '" + count + "' ", con);
                            comd.ExecuteNonQuery();

                            this.Hide();
                            ProductPage pp = new ProductPage(Name);
                            pp.Show();
                        }
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Name is InValid or Already Exist!");
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

                if (comboBox1.Text == "" || TypeTxtBox.Text == "" || PurUntPriceTxtBox.Text == "" || SldUntPriceTxtBox.Text == "" || ThhValTxtBox.Text == "" || DiscountTxtBox.Text == "")
                {
                    MessageBox.Show("Require Fields Empty!");
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(@"Update medicine set Type = '" + TypeTxtBox.Text + "' , PurUntPrice = '" + PurUntPriceTxtBox.Text + "' , SldUntPrice = '" + SldUntPriceTxtBox.Text + "' , ThhVal = '" + ThhValTxtBox.Text + "' , Discount = '" + DiscountTxtBox.Text + "' , NewPurUntPrice =  '" + NewPurUntPriceTxtBox.Text + "' Where (Name = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Edit Medicine ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Medicine Edit Successfully!");

                            this.Hide();
                            ProductPage pp = new ProductPage(Name);
                            pp.Show();
                        }
                        con.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Require Fields Empty!");
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand(@"Delete from medicine Where (Name = '" + comboBox1.Text + "')", con);

                    try
                    {
                        if (MessageBox.Show("Do you want to Delete Medicine ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Medicine Deleted Successfully!");

                            this.Hide();
                            ProductPage pp = new ProductPage(Name);
                            pp.Show();
                        }
                        con.Close();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Query Inncorrect!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void TypeTxtBox_TextChanged(object sender, EventArgs e)
        {
            Add_Button.Enabled = true;
        }
    }
}
