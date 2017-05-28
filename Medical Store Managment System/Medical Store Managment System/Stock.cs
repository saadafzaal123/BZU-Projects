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
    public partial class Stock : Form
    {
        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        string Name;

        public Stock(string name)
        {
            InitializeComponent();
            Name = name;

            UpdateStock_Button.Enabled = false;
            Delete_Button.Enabled = false;
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase p = new Purchase(Name);
            p.Show();
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void SeeStock_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select Name , Quantity , Individual_Price , Total_Price from stock", con);
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

            UpdateStock_Button.Enabled = true;
            Delete_Button.Enabled = true;
        }

        private void UpdateStock_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to Edit this row ?", "Edit", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        sda.Update(dt);

                        MySqlDataAdapter ssd = new MySqlDataAdapter("select * from stock", con);
                        DataTable dtss = new DataTable();
                        ssd.Fill(dtss);

                        for (int i = 0; i < dtss.Rows.Count; i++)
                        {
                            string NAME = dtss.Rows[i]["Name"].ToString();
                            string quantity = dtss.Rows[i]["Quantity"].ToString();
                            string individual_price = dtss.Rows[i]["Individual_Price"].ToString();
                            string Stock_Type = dtss.Rows[i]["Stock_Type"].ToString();
                            string IsReturn = dtss.Rows[i]["IsReturn"].ToString();

                            int Quantity = Int32.Parse(quantity);
                            Double Individual_Price = Double.Parse(individual_price);

                            try
                            {
                                MySqlDataAdapter sd = new MySqlDataAdapter("Select Stock , PurUntPrice , NewStock , NewPurUntPrice from medicine where Name = '" + NAME + "' ", con);
                                DataTable dts = new DataTable();
                                sd.Fill(dts);

                                string stock = dts.Rows[0][0].ToString();
                                string purUntPrice = dts.Rows[0][1].ToString();
                                string newstock = dts.Rows[0][2].ToString();
                                string newPurUntPrice = dts.Rows[0][3].ToString();

                                int Stock = Int32.Parse(stock);
                                Double PurUntPrice = Double.Parse(purUntPrice);
                                int NewStock = Int32.Parse(newstock);
                                Double NewPurUntPrice = Double.Parse(newPurUntPrice);

                                if (IsReturn == "Yes" && Stock_Type == "Old")
                                {
                                    if (Quantity > Stock)
                                    {
                                        MySqlCommand cm = new MySqlCommand(@"Update stock set Quantity = '" + Stock + "' Where (Name = '" + NAME + "')", con);

                                        try
                                        {
                                            cm.ExecuteNonQuery();

                                            MessageBox.Show("You exceed the Stock value so last the value of stock is adjusted which is return able!");

                                            Quantity = Stock;
                                        }

                                        catch (Exception)
                                        {
                                            MessageBox.Show("Query Inncorrect!");
                                        }
                                    }
                                }

                                if (IsReturn == "Yes" && Stock_Type == "New")
                                {
                                    if (Quantity > NewStock)
                                    {
                                        MySqlCommand cm = new MySqlCommand(@"Update stock set Quantity = '" + NewStock + "' Where (Name = '" + NAME + "')", con);

                                        try
                                        {
                                            cm.ExecuteNonQuery();

                                            MessageBox.Show("You exceed the NewStock value so last the value of Newstock is adjusted which is return able!");

                                            Quantity = NewStock;
                                        }

                                        catch (Exception)
                                        {
                                            MessageBox.Show("Query Inncorrect!");
                                        }
                                    }
                                }

                                if (Individual_Price != PurUntPrice && Stock_Type == "Old")
                                {
                                    MySqlCommand cm = new MySqlCommand(@"Update stock set Individual_Price = '" + PurUntPrice + "' Where (Name = '" + NAME + "')", con);

                                    try
                                    {
                                        cm.ExecuteNonQuery();

                                        MessageBox.Show("You changed the Individual Price so its not Updated!");

                                        Individual_Price = PurUntPrice;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Inncorrect!");
                                    }     
                                }

                                if (Individual_Price != NewPurUntPrice && Stock_Type == "New")
                                {
                                    MySqlCommand cm = new MySqlCommand(@"Update stock set Individual_Price = '" + NewPurUntPrice + "' Where (Name = '" + NAME + "')", con);

                                    try
                                    {
                                        cm.ExecuteNonQuery();

                                        MessageBox.Show("You changed the Individual Price so its not Changed!");

                                        Individual_Price = NewPurUntPrice;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Inncorrect!");
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Query Inncorrect!");
                            }

                            Double Total_Price = Quantity * Individual_Price;

                            MySqlCommand cmd = new MySqlCommand(@"Update stock set Total_Price = '" + Total_Price + "' Where (Name = '" + NAME + "')", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Inncorrect!");
                            }
                        }
                        MessageBox.Show("Stock Updated Successfully");

                        this.Hide();
                        Stock st = new Stock(Name);
                        st.Show();
                    }

                    catch (Exception)
                    {
                        MessageBox.Show("Data Read Problem!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Query Error!");
            }
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                scb = new MySqlCommandBuilder(sda);
                if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    sda.Update(dt);
                    MessageBox.Show("Deleted Successfull!");
                }
            }

            catch
            {
                MessageBox.Show("Query Error!");
            }
        }

        private void ResetStock_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Delete from Stock", con);

                try
                {
                    if (MessageBox.Show("Do you want to Reset Stock ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Stock Reset Successfully!");

                        this.Hide();
                        Stock st = new Stock(Name);
                        st.Show();
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

        private void ProcessStock_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            string UsrId = "";

            try
            {
                MySqlDataAdapter sd = new MySqlDataAdapter("Select UsrId from accounts where Name = '" + Name + "' ", con);
                DataTable dts = new DataTable();
                sd.Fill(dts);
                UsrId = dts.Rows[0][0].ToString();
            }

            catch (Exception)
            {
                MessageBox.Show("UsrId not found!");
            }

            try
            {
                con.Open();

                try
                {
                    MySqlDataAdapter ssd = new MySqlDataAdapter("select * from stock", con);
                    DataTable dtss = new DataTable();
                    ssd.Fill(dtss);

                    for (int i = 0; i < dtss.Rows.Count; i++)
                    {
                        string NAME = dtss.Rows[i]["Name"].ToString();
                        string quantity = dtss.Rows[i]["Quantity"].ToString();
                        string IsReturn = dtss.Rows[i]["IsReturn"].ToString();
                        string Stock_Type = dtss.Rows[i]["Stock_Type"].ToString();

                        int Quantity = Int32.Parse(quantity);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select Stock , ThhVal , MedCde , PurUntPrice , SldUntPrice , Sold , Type , Name , NewStock , NewPurUntPrice from medicine where Name = '" + NAME + "' ", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            string stock = dts.Rows[0][0].ToString();
                            string thhval = dts.Rows[0][1].ToString();
                            string MedCde = dts.Rows[0][2].ToString();
                            string purUntPrice = dts.Rows[0][3].ToString();
                            string sldUntPrice = dts.Rows[0][4].ToString();
                            string sold = dts.Rows[0][5].ToString();
                            string MType = dts.Rows[0][6].ToString();
                            string MName = dts.Rows[0][7].ToString();
                            string newStock = dts.Rows[0][8].ToString();
                            string newPurUntPrice = dts.Rows[0][9].ToString();

                            int Stock = Int32.Parse(stock);
                            int Thhval = Int32.Parse(thhval);
                            Double PurUntPrice = Double.Parse(purUntPrice);
                            Double SldUntPrice = Double.Parse(sldUntPrice);
                            int Sold = Int32.Parse(sold);
                            int NewStock = Int32.Parse(newStock);
                            Double NewPurUntPrice = Double.Parse(newPurUntPrice);

                            int New_Stock = Stock + Quantity;

                            MySqlCommand cmd;

                            if (IsReturn == "Yes" && Stock_Type == "Old")
                            {
                                New_Stock = Stock - Quantity;

                                cmd = new MySqlCommand(@"Update medicine set Stock = '" + New_Stock + "' , LastSldDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' Where (Name = '" + NAME + "')", con);         

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "No" + "' , '" + "Yes" + "' , '" + Quantity + "' , '" + PurUntPrice + "' , '" + PurUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                    try
                                    {
                                        c_m_d.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Data not inserted in AudTrl Table!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("New Stock is not Updated!");
                                }
                            }

                            if (IsReturn == "Yes" && Stock_Type == "New")
                            {
                                New_Stock = NewStock - Quantity;

                                cmd = new MySqlCommand(@"Update medicine set NewStock = '" + New_Stock + "' , LastSldDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' Where (Name = '" + NAME + "')", con);

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "No" + "' , '" + "Yes" + "' , '" + Quantity + "' , '" + NewPurUntPrice + "' , '" + NewPurUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                    try
                                    {
                                        c_m_d.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Data not inserted in AudTrl Table!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("New Stock is not Updated!");
                                }
                            }

                            if (IsReturn == "No" && Stock_Type == "New")
                            {
                                New_Stock = NewStock + Quantity;

                                cmd = new MySqlCommand(@"Update medicine set NewStock = '" + New_Stock + "' , LastSldDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' Where (Name = '" + NAME + "')", con);

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "Yes" + "' , '" + "No" + "' , '" + Quantity + "' , '" + NewPurUntPrice + "' , '" + NewPurUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                    try
                                    {
                                        c_m_d.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Data not inserted in AudTrl Table!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("New Stock is not Updated!");
                                }
                            }

                            if (IsReturn == "No" && Stock_Type == "Old")
                            {
                                cmd = new MySqlCommand(@"Update medicine set Stock = '" + New_Stock + "' , LastPurDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' Where (Name = '" + NAME + "')", con);

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "Yes" + "' , '" + "No" + "' , '" + Quantity + "' , '" + PurUntPrice + "' , '" + SldUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                    try
                                    {
                                        c_m_d.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Data not inserted in AudTrl Table!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("New Stock is not Updated!");
                                }
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Query Error!");
                        }
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Data Read Problem!");
                }

                try
                {
                    MySqlDataAdapter sd = new MySqlDataAdapter("Select SUM(Individual_Price*Quantity) from stock where IsReturn = '" + "No" + "' ", con);
                    DataTable dts = new DataTable();
                    sd.Fill(dts);
                    BillTxtBox.Text = dts.Rows[0][0].ToString();

                    string bill = BillTxtBox.Text;
                    Double Bill = Double.Parse(bill);

                    BillTxtBox.Text = Convert.ToInt32(Bill).ToString();

                    int B = Convert.ToInt32(Bill);

                    if (Bill == 0)
                    {
                        MessageBox.Show("Bill not created Stock Table is Empty!");
                    }
                    else
                    {
                        try
                        {
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "Insert into Purchase_Bill (Bill , Date) values('" + B + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                            try
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Bill Created Successfully!");

                                MySqlCommand comd = new MySqlCommand(@"Delete from Stock", con);

                                try
                                {
                                    comd.ExecuteNonQuery();
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Query Inncorrect!");
                                }
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Bill not Created Successfully!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("No Entry in Bill Tabel!");
                        }
                    }

                }

                catch (Exception)
                {
                    try
                    {
                        MySqlDataAdapter sd = new MySqlDataAdapter("Select SUM(Individual_Price*Quantity) from stock where IsReturn = '" + "Yes" + "' ", con);
                        DataTable dts = new DataTable();
                        sd.Fill(dts);
                        BillTxtBox.Text = dts.Rows[0][0].ToString();

                        string bill = BillTxtBox.Text;
                        Double Bill = Double.Parse(bill);

                        BillTxtBox.Text = Convert.ToInt32(Bill).ToString();

                        int B = Convert.ToInt32(Bill);

                        if (Bill == 0)
                        {
                            MessageBox.Show("Bill not created Stock Table is Empty!");
                        }
                        else
                        {
                            try
                            {
                                MySqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "Insert into Sold_Bill (Bill , Date) values('" + B + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Bill Created Successfully!");

                                    MySqlCommand comd = new MySqlCommand(@"Delete from Stock", con);

                                    try
                                    {
                                        comd.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Inncorrect!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Bill not Created Successfully!");
                                }
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("No Entry in Bill Tabel!");
                            }
                        }

                    }

                    catch (Exception)
                    {
                        BillTxtBox.Text = null;
                        MessageBox.Show("Bill not created Stock is Empty!");
                    }
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
