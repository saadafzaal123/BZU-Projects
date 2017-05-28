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
    public partial class Purchase : Form
    {
        string Name;

        public Purchase(string name)
        {
            InitializeComponent();
            Fillcombo();
            Name = name;
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage ad = new AdminPage(Name);
            ad.Show();
        }

        private void GotoStock_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock st = new Stock(Name);
            st.Show();
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

        private void AddtoStock_Button_Click(object sender, EventArgs e)
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
                        MySqlDataAdapter sda = new MySqlDataAdapter("Select Name , PurUntPrice , Stock , SldUntPrice , NewStock , NewPurUntPrice from medicine where Name = '" + comboBox1.Text + "'", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        string NAME = dt.Rows[0][0].ToString();
                        string purUntPrice = dt.Rows[0][1].ToString();
                        string stock = dt.Rows[0][2].ToString();
                        string sldUntPrice = dt.Rows[0][3].ToString();
                        string newstock = dt.Rows[0][4].ToString();
                        string newPurUntPrice = dt.Rows[0][5].ToString();

                        int Stock = Int32.Parse(stock);
                        int Quantity = Int32.Parse(QtyTxtBox.Text);
                        Double PurUntPrice = Double.Parse(purUntPrice);
                        Double SldUntPrice = Double.Parse(sldUntPrice);
                        Double NewPurUntPrice = Double.Parse(newPurUntPrice);
                        int NewStock = Int32.Parse(newstock);

                        Double TotalPrice;

                        MySqlCommand cmd = con.CreateCommand();

                        if (checkBox1.Checked)
                        {
                            if (checkBox2.Checked)
                            {
                                if (Quantity <= NewStock)
                                {
                                    TotalPrice = NewPurUntPrice * Quantity;
                                    cmd.CommandText = "Insert into stock (Name , Quantity , Individual_Price , Total_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + NewPurUntPrice + "' , '" + TotalPrice + "' , '" + "New" + "' , '" + "Yes" + "')";

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Add to the Stock Successfully!");

                                        QtyTxtBox.Text = null;
                                        comboBox1.Text = null;
                                        checkBox1.Checked = false;
                                        StockTxtBox.Text = null;
                                        NewStockTxtBox.Text = null;
                                        checkBox2.Checked = false;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Already Added to the Stock!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity Exceed the NewStock Limits");
                                }
                            }
                            else
                            {
                                if (Quantity <= Stock)
                                {
                                    TotalPrice = PurUntPrice * Quantity;
                                    cmd.CommandText = "Insert into stock (Name , Quantity , Individual_Price , Total_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + PurUntPrice + "' , '" + TotalPrice + "' , '" + "Old" +"' , '" + "Yes" + "')";

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Add to the Stock Successfully!");

                                        QtyTxtBox.Text = null;
                                        comboBox1.Text = null;
                                        checkBox1.Checked = false;
                                        StockTxtBox.Text = null;
                                        NewStockTxtBox.Text = null;
                                        checkBox2.Checked = false;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Already Added to the Stock!");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Quantity Exceed the Stock Limits");
                                }
                            }
                        }
                        else
                        {
                            if (checkBox2.Checked)
                            {
                                TotalPrice = NewPurUntPrice * Quantity;

                                cmd.CommandText = "Insert into stock (Name , Quantity , Individual_Price , Total_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + NewPurUntPrice + "' , '" + TotalPrice + "' , '" + "New" + "' , '" + "No" + "')";
                            }
                            else
                            {
                                TotalPrice = PurUntPrice * Quantity;

                                cmd.CommandText = "Insert into stock (Name , Quantity , Individual_Price , Total_Price , Stock_Type , IsReturn) values('" + NAME + "' , '" + QtyTxtBox.Text + "' , '" + PurUntPrice + "' , '" + TotalPrice + "' , '" + "Old" +"' , '" + "No" + "')";
                            }
                             try
                             {
                                 cmd.ExecuteNonQuery();
                                 MessageBox.Show("Add to the Stock Successfully!");

                                 QtyTxtBox.Text = null;
                                 comboBox1.Text = null;
                                 checkBox1.Checked = false;
                                 StockTxtBox.Text = null;
                                 NewStockTxtBox.Text = null;
                                 checkBox2.Checked = false;
                             }

                             catch (Exception)
                             {
                                 MessageBox.Show("Already Added to the Stock!");
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
