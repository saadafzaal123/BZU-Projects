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
    public partial class Sales : Form
    {
        string Name;

        public Sales(string name)
        {
            InitializeComponent();
            Fillcombo();
            Name = name;
        }

        private void GotoCart_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cart c = new Cart(Name);
            c.Show();
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlDataAdapter sda = new MySqlDataAdapter("Select IsAdmin from accounts where Name = '" + Name + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "No")
                {
                    this.Hide();
                    UserPage us = new UserPage(Name);
                    us.Show();
                }

                if (dt.Rows[0][0].ToString() == "Yes")
                {
                    this.Hide();
                    AdminPage ad = new AdminPage(Name);
                    ad.Show();
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

            MySqlCommand cmd = new MySqlCommand("select Name from medicine where Stock > '" + 0 + "' OR NewStock > '" + 0 + "' order by Name ASC", con);

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

        private void AddtoCart_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();
                try
                {
                    string qty = QtyTxtBox.Text;
                    int Qty = Int32.Parse(qty);

                    if (Qty < 0)
                    {
                        MessageBox.Show("Quantity must be Positive!");
                    }
                    else
                    {

                        MySqlDataAdapter sda = new MySqlDataAdapter("Select Name , SldUntPrice , Stock , PurUntPrice , Discount , NewStock from medicine where Name = '" + comboBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        string NAME = dt.Rows[0][0].ToString();
                        string sldUntPrice = dt.Rows[0][1].ToString();
                        string stock = dt.Rows[0][2].ToString();
                        string purUntPrice = dt.Rows[0][3].ToString();
                        string discount = dt.Rows[0][4].ToString();
                        string newStock = dt.Rows[0][5].ToString();

                        int Stock = Int32.Parse(stock);
                        int Quantity = Int32.Parse(QtyTxtBox.Text);
                        Double SldUntPrice = Double.Parse(sldUntPrice);
                        Double PurUntPrice = Double.Parse(purUntPrice);
                        Double Discount = Double.Parse(discount);
                        int NewStock = Int32.Parse(newStock);

                        Double TotalPrice;

                        MySqlCommand cmd = con.CreateCommand();

                        if (checkBox1.Checked)
                        {
                            if (checkBox2.Checked)
                            {
                                TotalPrice = SldUntPrice * Quantity;

                                Double DiscountPrice = (TotalPrice * Discount) / 100;

                                Double NetPrice = TotalPrice - DiscountPrice;

                                cmd.CommandText = "Insert into cart (Name , Quantity , Individual_Price , Total_Price , Discount , Net_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + SldUntPrice + "' , '" + TotalPrice + "' , '" + Discount + "%" + "' , '" + NetPrice + "' , '" + "New" + "'  , '" + "Yes" + "')";

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Add to the Cart Successfully!");

                                    QtyTxtBox.Text = null;
                                    comboBox1.Text = null;
                                    checkBox1.Checked = false;
                                    StockTxtBox.Text = null;
                                    NewStockTxtBox.Text = null;
                                    checkBox2.Checked = false;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Already Added to the Cart!");
                                }
                            }
                            else
                            {
                                TotalPrice = SldUntPrice * Quantity;

                                Double DiscountPrice = (TotalPrice * Discount) / 100;

                                Double NetPrice = TotalPrice - DiscountPrice;

                                cmd.CommandText = "Insert into cart (Name , Quantity , Individual_Price , Total_Price , Discount , Net_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + SldUntPrice + "' , '" + TotalPrice + "' , '" + Discount + "%" + "' , '" + NetPrice + "' , '" + "Old" +"' , '" + "Yes" + "')";

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Add to the Cart Successfully!");

                                    QtyTxtBox.Text = null;
                                    comboBox1.Text = null;
                                    checkBox1.Checked = false;
                                    StockTxtBox.Text = null;
                                    NewStockTxtBox.Text = null;
                                    checkBox2.Checked = false;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Already Added to the Cart!");
                                }
                            }
                        }
                        else
                        {
                            if (checkBox2.Checked)
                            {
                                if (NewStock >= Quantity)
                                {

                                    TotalPrice = SldUntPrice * Quantity;

                                    Double DiscountPrice = (TotalPrice * Discount) / 100;

                                    Double NetPrice = TotalPrice - DiscountPrice;

                                    cmd.CommandText = "Insert into cart (Name , Quantity , Individual_Price , Total_Price , Discount , Net_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + SldUntPrice + "' , '" + TotalPrice + "' , '" + Discount + "%" + "' , '" + NetPrice + "' , '" + "New" +"' , '" + "No" + "')";


                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Add to the Cart Successfully!");

                                        QtyTxtBox.Text = null;
                                        comboBox1.Text = null;
                                        checkBox1.Checked = false;
                                        StockTxtBox.Text = null;
                                        NewStockTxtBox.Text = null;
                                        checkBox2.Checked = false;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Already Added to the Cart!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity Exceed the NewStock Limits");
                                }
                            }
                            else
                            {
                                if (Stock >= Quantity)
                                {

                                    TotalPrice = SldUntPrice * Quantity;

                                    Double DiscountPrice = (TotalPrice * Discount) / 100;

                                    Double NetPrice = TotalPrice - DiscountPrice;

                                    cmd.CommandText = "Insert into cart (Name , Quantity , Individual_Price , Total_Price , Discount , Net_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + SldUntPrice + "' , '" + TotalPrice + "' , '" + Discount + "%" + "' , '" + NetPrice + "' , '" + "Old" +"' , '" + "No" + "')";


                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Add to the Cart Successfully!");

                                        QtyTxtBox.Text = null;
                                        comboBox1.Text = null;
                                        checkBox1.Checked = false;
                                        StockTxtBox.Text = null;
                                        NewStockTxtBox.Text = null;
                                        checkBox2.Checked = false;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Already Added to the Cart!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity Exceed the Stock Limits");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Medicine and Quantity Field Required!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            MySqlCommand cmd = new MySqlCommand("select * from medicine where Name = '" + comboBox1.Text + "'", con);

            MySqlDataReader myReader;

            try
            {
                con.Open();

                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string Stock = myReader.GetInt32("Stock").ToString();
                    string NewStock = myReader.GetInt32("NewStock").ToString();

                    StockTxtBox.Text = Stock;
                    NewStockTxtBox.Text = NewStock;
                }

                myReader.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
