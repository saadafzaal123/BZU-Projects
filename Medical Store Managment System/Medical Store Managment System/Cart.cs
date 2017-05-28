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
    public partial class Cart : Form
    {
        MySqlDataAdapter sda;
        MySqlCommandBuilder scb;
        DataTable dt;

        string Name;

        public Cart(string name)
        {
            InitializeComponent();
            Name = name;

            UpadateCart_Button.Enabled = false;
            Delete_Button.Enabled = false;
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales s = new Sales(Name);
            s.Show();         
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void SeeCart_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                try
                {
                    sda = new MySqlDataAdapter(@"Select Name , Quantity , Individual_Price , Total_Price , Discount , Net_Price from cart", con);
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

            UpadateCart_Button.Enabled = true;
            Delete_Button.Enabled = true;
        }

        private void UpadateCart_Button_Click(object sender, EventArgs e)
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

                        MySqlDataAdapter ssd = new MySqlDataAdapter("select * from cart", con);
                        DataTable dtss = new DataTable();
                        ssd.Fill(dtss);

                        int Discount = 0;

                        for (int i = 0; i < dtss.Rows.Count; i++)
                        {
                            string NAME = dtss.Rows[i]["Name"].ToString();
                            string quantity = dtss.Rows[i]["Quantity"].ToString();
                            string individual_price = dtss.Rows[i]["Individual_Price"].ToString();
                            string IsReturn = dtss.Rows[i]["IsReturn"].ToString();
                            string Stock_Type = dtss.Rows[i]["Stock_Type"].ToString();

                            int Quantity = Int32.Parse(quantity);
                            Double Individual_Price = Double.Parse(individual_price);

                            try
                            {
                                MySqlDataAdapter sd = new MySqlDataAdapter("Select Stock , Discount , SldUntPrice , NewStock from medicine where Name = '" + NAME + "' ", con);
                                DataTable dts = new DataTable();
                                sd.Fill(dts);

                                string stock = dts.Rows[0][0].ToString();

                                string discount = dts.Rows[0][1].ToString();

                                string sldUntPrice = dts.Rows[0][2].ToString();

                                string newStock = dts.Rows[0][3].ToString();

                                int Stock = Int32.Parse(stock);

                                Discount = Int32.Parse(discount);

                                Double SldUntPrice = Double.Parse(sldUntPrice);

                                int NewStock = Int32.Parse(newStock);

                                if (Quantity > Stock && IsReturn == "No" && Stock_Type == "Old")
                                {
                                    MySqlCommand cm = new MySqlCommand(@"Update cart set Quantity = '" + Stock + "' Where (Name = '" + NAME + "')", con);

                                    try
                                    {
                                        cm.ExecuteNonQuery();

                                        MessageBox.Show("Quantity exceed Stock value so Quantity adjusted with Stock value!");

                                        Quantity = Stock;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Inncorrect!");
                                    }
                                }

                                if (Quantity > NewStock && IsReturn == "No" && Stock_Type == "New")
                                {
                                    MySqlCommand cm = new MySqlCommand(@"Update cart set Quantity = '" + NewStock + "' Where (Name = '" + NAME + "')", con);

                                    try
                                    {
                                        cm.ExecuteNonQuery();

                                        MessageBox.Show("Quantity exceed NewStock value so Quantity adjusted with NewStock value!");

                                        Quantity = NewStock;
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Inncorrect!");
                                    }
                                }

                                if (SldUntPrice != Individual_Price)
                                {
                                    MySqlCommand cm = new MySqlCommand(@"Update cart set Individual_Price = '" + SldUntPrice + "' Where (Name = '" + NAME + "')", con);

                                    try
                                    {
                                        cm.ExecuteNonQuery();

                                        MessageBox.Show("You changed the Individual Price so its not Changed!");

                                        Individual_Price = SldUntPrice;
                                    }

                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                            Double Total_Price = Quantity * Individual_Price;

                            Double DiscountPrice = (Total_Price * Discount) / 100;

                            Double NetPrice = Total_Price - DiscountPrice;

                            MySqlCommand cmd = new MySqlCommand(@"Update cart set Total_Price = '" + Total_Price + "' , Net_Price = '" + NetPrice + "' , Discount = '" + Discount + "%" + "' Where (Name = '" + NAME + "')", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Inncorrect!");
                            }  
                        }
                        MessageBox.Show("Cart Updated Successfully");

                        this.Hide();
                        Cart c = new Cart(Name);
                        c.Show();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                MySqlCommand cmd = new MySqlCommand(@"Delete from Cart", con);

                try
                {
                    if (MessageBox.Show("Do you want to Reset Cart ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cart Reset Successfully!");

                        this.Hide();
                        Cart c = new Cart(Name);
                        c.Show();
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

        private void ProcessCart_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            string OverCross_Stock = "";
            string UsrId = "";
            string OverCross_NewStock = "";

            try
            {
                MySqlDataAdapter sd = new MySqlDataAdapter("Select UsrId from accounts where Name = '" + Name +"' ", con);
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
                    MySqlDataAdapter ssd = new MySqlDataAdapter("select * from cart", con);
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

                            int New_Stock;

                            if (IsReturn == "Yes" && Stock_Type == "Old")
                            {
                                New_Stock = Stock + Quantity;
                                int New_Sold = Sold - Quantity;

                                MySqlCommand cmd;

                                if (New_Sold >= 0)
                                {
                                    cmd = new MySqlCommand(@"Update medicine set Stock = '" + New_Stock + "' , LastPurDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + New_Sold + "' Where (Name = '" + NAME + "')", con);
                                }
                                else
                                {
                                    cmd = new MySqlCommand(@"Update medicine set Stock = '" + New_Stock + "' , LastPurDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + 0 + "' Where (Name = '" + NAME + "')", con);
                                }
                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "Yes" + "' , '" + "No" + "' , '" + Quantity + "' , '" + SldUntPrice + "' , '" + SldUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

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
                                New_Stock = NewStock + Quantity;
                                int New_Sold = Sold - Quantity;

                                MySqlCommand cmd;

                                if (New_Sold >= 0)
                                {
                                    cmd = new MySqlCommand(@"Update medicine set NewStock = '" + New_Stock + "' , LastPurDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + New_Sold + "' Where (Name = '" + NAME + "')", con);
                                }
                                else
                                {
                                    cmd = new MySqlCommand(@"Update medicine set NewStock = '" + New_Stock + "' , LastPurDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + 0 + "' Where (Name = '" + NAME + "')", con);
                                }
                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "Yes" + "' , '" + "No" + "' , '" + Quantity + "' , '" + SldUntPrice + "' , '" + SldUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

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
                                Sold += Quantity;
                                New_Stock = NewStock - Quantity;

                                MySqlCommand cmd = new MySqlCommand(@"Update medicine set NewStock = '" + New_Stock + "' , LastSldDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + Sold + "' Where (Name = '" + NAME + "')", con);

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    if (New_Stock < Thhval)
                                    {
                                        OverCross_NewStock += " - " + NAME + " - ";
                                    }

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "No" + "' , '" + "Yes" + "' , '" + Quantity + "' , '" + NewPurUntPrice + "' , '" + SldUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

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

                            if(IsReturn == "No" && Stock_Type == "Old")
                            {
                                Sold += Quantity;
                                New_Stock = Stock - Quantity;

                                MySqlCommand cmd = new MySqlCommand(@"Update medicine set Stock = '" + New_Stock + "' , LastSldDate = '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "' , Sold = '" + Sold + "' Where (Name = '" + NAME + "')", con);

                                try
                                {
                                    cmd.ExecuteNonQuery();

                                    if (New_Stock < Thhval)
                                    {
                                        OverCross_Stock += " - " + NAME + " - ";
                                    }

                                    MySqlCommand c_m_d = con.CreateCommand();
                                    c_m_d.CommandText = "Insert into audittrail (MedCde , Type , Name , UsrId , IsPur , IsSld , Qty , PurUntPrice , SldUntPrice , Date) values('" + MedCde + "' , '" + MType + "' , '" + MName + "' , '" + UsrId + "' , '" + "No" + "' , '" + "Yes" + "' , '" + Quantity + "' , '" + PurUntPrice + "' , '" + SldUntPrice + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

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
                    MySqlDataAdapter sd = new MySqlDataAdapter("Select SUM(Individual_Price*Quantity) , SUM(Net_Price) from Cart where IsReturn = '" + "No" + "'", con);
                    DataTable dts = new DataTable();
                    sd.Fill(dts);

                    BillTxtBox.Text = dts.Rows[0][0].ToString();
                    NetBillTxtBox.Text = dts.Rows[0][1].ToString();



                    string bill = BillTxtBox.Text;
                    Double Bill = Double.Parse(bill);

                    BillTxtBox.Text = Convert.ToInt32(Bill).ToString();

                    string netbill = NetBillTxtBox.Text;
                    Double NetBill = Double.Parse(netbill);

                    NetBillTxtBox.Text = Convert.ToInt32(NetBill).ToString();

                    Double Discount = Bill - NetBill;

                    DiscountTxtBox.Text = Convert.ToInt32(Discount).ToString();

                    int N = Convert.ToInt32(NetBill);

                    if (Bill != 0 && NetBill != 0)
                    {
                        try
                        {
                            MySqlCommand cmd = con.CreateCommand();
                            cmd.CommandText = "Insert into Sold_Bill (Bill , Date) values('" + N + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                            try
                            {
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Bill Created Successfully!");

                                if (OverCross_Stock != null && OverCross_Stock != "")
                                {
                                    MessageBox.Show("Medicine " + OverCross_Stock + " has crossed threshold value in Stock!");
                                }

                                if (OverCross_NewStock != null && OverCross_NewStock != "")
                                {
                                    MessageBox.Show("Medicine " + OverCross_NewStock + " has crossed threshold value in NewStock!");
                                }

                                MySqlCommand comd = new MySqlCommand(@"Delete from Cart", con);

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
                    else
                    {
                        BillTxtBox.Text = null;
                        NetBillTxtBox.Text = null;
                        DiscountTxtBox.Text = null;

                        MessageBox.Show("Bill not created Cart is Empty!");
                    }
                }

                catch (Exception)
                {
                    try
                    {
                        MySqlDataAdapter sd = new MySqlDataAdapter("Select SUM(Individual_Price*Quantity) , SUM(Net_Price) from Cart where IsReturn = '" + "Yes" + "' ", con);
                        DataTable dts = new DataTable();
                        sd.Fill(dts);

                        BillTxtBox.Text = dts.Rows[0][0].ToString();
                        NetBillTxtBox.Text = dts.Rows[0][1].ToString();

                        string bill = BillTxtBox.Text;
                        Double Bill = Double.Parse(bill);

                        BillTxtBox.Text = Convert.ToInt32(Bill).ToString();

                        string netbill = NetBillTxtBox.Text;
                        Double NetBill = Double.Parse(netbill);

                        NetBillTxtBox.Text = Convert.ToInt32(NetBill).ToString();

                        Double Discount = Bill - NetBill;

                        DiscountTxtBox.Text = Convert.ToInt32(Discount).ToString();

                        int N = Convert.ToInt32(NetBill);

                        if (Bill != 0 && NetBill != 0)
                        {
                            try
                            {
                                MySqlCommand cmd = con.CreateCommand();
                                cmd.CommandText = "Insert into Purchase_Bill (Bill , Date) values('" + N + "' , '" + dateTimePicker1.Value.ToString("yyyy/MM/dd") + "')";

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Bill Created Successfully!");

                                    if (OverCross_Stock != null && OverCross_Stock != "")
                                    {
                                        MessageBox.Show("Medicine " + OverCross_Stock + " has crossed threshold value in Stock!");
                                    }

                                    if (OverCross_NewStock != null && OverCross_NewStock != "")
                                    {
                                        MessageBox.Show("Medicine " + OverCross_NewStock + " has crossed threshold value in NewStock!");
                                    }

                                    MySqlCommand comd = new MySqlCommand(@"Delete from Cart", con);

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
                        else
                        {
                            MessageBox.Show("Bill not created Cart is Empty!");
                        }
                    }

                    catch (Exception)
                    {
                        BillTxtBox.Text = null;
                        NetBillTxtBox.Text = null;
                        DiscountTxtBox.Text = null;

                        MessageBox.Show("Bill not created Cart is Empty!");
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
