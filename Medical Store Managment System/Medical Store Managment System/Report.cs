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
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel; 

namespace Medical_Store_Managment_System
{
    public partial class Report : Form
    {
        string Name;

        public Report(string user)
        {
            InitializeComponent();

            Name = user;

            DaysTxtBox.Enabled = false;
            StartDate.Enabled = false;
            EndDate.Enabled = false;
            SalesProfitTxtBox.ReadOnly = true;
            ExpensesTxtBox.ReadOnly = true;
            NProfitTxtBox.ReadOnly = true;
            DownloadReport_Button.Enabled = false;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            NProfitTxtBox.Select(0, 0);
        }

        private void GenerateReport_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();

                string Option = comboBox1.Text;

                if (Option != "")
                {
                    if (Option == "Last n days")
                    {
                        try
                        {
                            string days = DaysTxtBox.Text;
                            int Days = Int32.Parse(days);

                            DateTime thisDay = DateTime.Today;
                            DateTime dt;

                            dt = thisDay.AddDays(-Days);

                            if (Days < 0)
                            {
                                MessageBox.Show("Days must be Positive!");
                            }
                            else
                            {
                                try
                                {
                                    MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                                    DataTable dts = new DataTable();
                                    sd.Fill(dts);

                                    for (int i = 0; i < dts.Rows.Count; i++)
                                    {
                                        string MedCde = dts.Rows[i]["MedCde"].ToString();
                                        string Type = dts.Rows[i]["Type"].ToString();
                                        string MName = dts.Rows[i]["Name"].ToString();
                                        string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                        string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                        string Discount = dts.Rows[i]["Discount"].ToString();

                                        try
                                        {
                                            MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                            DataTable dtss = new DataTable();
                                            sds.Fill(dtss);

                                            string SoldQuantity = dtss.Rows[0][0].ToString();
                                            string SoldCost = dtss.Rows[0][1].ToString();
                                            string PurCost = dtss.Rows[0][2].ToString();

                                            MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                            DataTable dtsssss = new DataTable();
                                            sdssss.Fill(dtsssss);

                                            string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                            if (SoldQuantity != "" && SoldCost != "")
                                            {
                                                Double soldcost;     
                                                int soldquantity;
                                                Double purcost;
                                                int returnquantity;

                                                try
                                                {
                                                    soldcost = Double.Parse(SoldCost);
                                                }
                                                catch (Exception)
                                                {
                                                    soldcost = 0;
                                                }

                                                try
                                                {
                                                    soldquantity = Int32.Parse(SoldQuantity);
                                                }
                                                catch (Exception)
                                                {
                                                    soldquantity = 0;
                                                }

                                                try
                                                {
                                                    purcost = Double.Parse(PurCost);
                                                }
                                                catch (Exception)
                                                {
                                                    purcost = 0;
                                                }

                                                try
                                                {
                                                    returnquantity = Int32.Parse(ReturnQuantity);
                                                }
                                                catch (Exception)
                                                {
                                                    returnquantity = 0;
                                                }

                                                int NewQuatity = soldquantity - returnquantity;

                                                Double ProfitLose;

                                                if (returnquantity > 0)
                                                {
                                                    Double slduntprice = Double.Parse(SldUntPrice);
                                                    Double puruntprice = Double.Parse(PurUntPrice);
                                                    Double discount = Double.Parse(Discount);

                                                    Double SCost = NewQuatity * slduntprice;

                                                    Double DCost = (SCost * discount) / 100;

                                                    Double NCost = SCost - DCost;

                                                    SCost = NCost;

                                                    Double PCost = NewQuatity * puruntprice;

                                                    soldcost = SCost;
                                                    purcost = PCost;

                                                    ProfitLose = SCost - PCost;
                                                }
                                                else
                                                {
                                                    Double discount = Double.Parse(Discount);

                                                    Double dcost = (soldcost * discount) / 100;

                                                    Double ncost = soldcost - dcost;

                                                    soldcost = ncost;

                                                    ProfitLose = soldcost - purcost;
                                                }

                                                //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                                MySqlCommand c_m_d = con.CreateCommand();
                                                c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                                try
                                                {
                                                    c_m_d.ExecuteNonQuery();

                                                    try
                                                    {
                                                        MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                        DataTable dtssss = new DataTable();
                                                        sda.Fill(dtssss);
                                                        dataGridView1.DataSource = dtssss;
                                                        dataGridView1.AllowUserToAddRows = false;

                                                        MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                        DataTable dtsss = new DataTable();
                                                        sdss.Fill(dtsss);
                                                        dataGridView2.DataSource = dtsss;
                                                        dataGridView2.AllowUserToAddRows = false;
                                                    }

                                                    catch (Exception)
                                                    {
                                                        MessageBox.Show("Data does not Exists Between Days!");
                                                    }
                                                }

                                                catch (MySqlException)
                                                {
                                                    MessageBox.Show("Data not inserted Successfully!");
                                                }
                                            }
                                        }

                                        catch (Exception)
                                        {
                                            MessageBox.Show(MName + " Medicine doest not Found!");
                                        }
                                    }

                                    try
                                    {
                                        MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                        DataTable dtss = new DataTable();
                                        sds.Fill(dtss);

                                        string profit = dtss.Rows[0][0].ToString();

                                        MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                        DataTable dtsss = new DataTable();
                                        sdss.Fill(dtsss);

                                        string expense = dtsss.Rows[0][0].ToString();

                                        Double Profit = Double.Parse(profit);

                                        Double Expense;

                                        try
                                        {
                                            Expense = Double.Parse(expense);
                                        }

                                        catch (Exception)
                                        {
                                            Expense = 0;
                                            expense = "0";
                                        }

                                        Double NetProfit = Profit - Expense;

                                        long P = Convert.ToInt64(Profit);
                                        long E = Convert.ToInt64(Expense);
                                        long N = Convert.ToInt64(NetProfit);

                                        SalesProfitTxtBox.Text = P.ToString();
                                        ExpensesTxtBox.Text = E.ToString();

                                        if (NetProfit < 0)
                                        {
                                            NProfitTxtBox.BackColor = Color.Red;
                                            NProfitTxtBox.ForeColor = Color.White;

                                            NProfitTxtBox.Text = N.ToString();
                                        }

                                        else
                                        {
                                            NProfitTxtBox.BackColor = Color.Green;
                                            NProfitTxtBox.ForeColor = Color.White;

                                            NProfitTxtBox.Text = N.ToString();
                                        }

                                        DownloadReport_Button.Enabled = true;
                                    }
                                        
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Data does not Exists Between Days!");

                                        try
                                        {
                                            MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                            DataTable dtssss = new DataTable();
                                            sda.Fill(dtssss);
                                            dataGridView1.DataSource = dtssss;
                                            dataGridView1.AllowUserToAddRows = false;

                                            MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                            DataTable dtsss = new DataTable();
                                            sdss.Fill(dtsss);
                                            dataGridView2.DataSource = dtsss;
                                            dataGridView2.AllowUserToAddRows = false;

                                            NProfitTxtBox.BackColor = Color.White;

                                            SalesProfitTxtBox.Text = null;
                                            ExpensesTxtBox.Text = null;
                                            NProfitTxtBox.Text = null;
                                        }

                                        catch (Exception)
                                        {
                                            MessageBox.Show("Data does not Exists Between Days!");
                                        }
                                    }

                                    MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                                    try
                                    {
                                        cmd.ExecuteNonQuery();
                                    }

                                    catch (Exception)
                                    {
                                        MessageBox.Show("Query Error!");
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Data not found!");
                                }
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Days must be in Digits!");
                        }
                    }


                    if (Option == "Select Date Range")
                    {
                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + StartDate.Value.ToString("yyyy/MM/dd") + "'  and  '" + EndDate.Value.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + StartDate.Value.ToString("yyyy/MM/dd") + "'  and  '" + EndDate.Value.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price  , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + StartDate.Value.ToString("yyyy/MM/dd") + "'  and  '" + EndDate.Value.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Data does not Exists Between Dates Range!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + StartDate.Value.ToString("yyyy/MM/dd") + "'  and  '" + EndDate.Value.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Data does not Exists Between Dates Range!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + StartDate.Value.ToString("yyyy/MM/dd") + "'  and  '" + EndDate.Value.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Data does not Exists Between Dates Range!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Today")
                    {
                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddDays(0);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Today Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Today Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Today Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Yesterday")
                    {
                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddDays(-1);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("YesterDay Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Yesterday Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Yesterday Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Last Week")
                    {
                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddDays(-7);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Last Week Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Last Week Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Last Week Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Last Month")
                    {
                        string currentDay = DateTime.Now.Day.ToString();

                        int CurrentDay = Int32.Parse(currentDay);

                        int GetFirstDay = 0;

                        for (int i = 0; i <= 31; i++)
                        {
                            if (CurrentDay - i == 1)
                            {
                                GetFirstDay = i;
                                break;
                            }
                        }

                        DateTime thisDay = DateTime.Today;
                        DateTime dt;
                        DateTime dt2;

                        dt = thisDay.AddMonths(-1).AddDays(-GetFirstDay);
                        dt2 = dt.AddDays(30);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + dt2.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + dt2.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + dt2.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Last Month Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + dt2.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Last Month Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + dt2.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Last Month Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }
                     

                    if (Option == "Current Month")
                    {
                        string currentDay = DateTime.Now.Day.ToString();

                        int CurrentDay = Int32.Parse(currentDay);

                        int GetFirstDay = 0; 

                        for (int i = 0; i <= 31; i++)
                        {
                            if (CurrentDay - i == 1)
                            {
                                GetFirstDay = i;
                                break;
                            }
                        }

                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddDays(-GetFirstDay);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;
                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price ,	Discount , 	Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Current Month Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Current Month Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Current Month does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Current Year")
                    {
                        string currentDay = DateTime.Now.Day.ToString();
                        string currentMonth = DateTime.Now.Month.ToString();

                        int CurrentDay = Int32.Parse(currentDay);
                        int CurrentMonth = Int32.Parse(currentMonth);

                        int GetFirstDay = 0;
                        int GetFirstMonth = 0;

                        for (int i = 0; i <= 31; i++)
                        {
                            if (CurrentDay - i == 1)
                            {
                                GetFirstDay = i;
                                break;
                            }
                        }

                        for (int i = 0; i <= 12; i++)
                        {
                            if (CurrentMonth - i == 1)
                            {
                                GetFirstMonth = i;
                                break;
                            }
                        }

                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddMonths(-GetFirstMonth).AddDays(-GetFirstDay);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Current Year Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Current Year Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Current Year Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }


                    if (Option == "Current Week")
                    {
                        String DayName = System.DateTime.Now.DayOfWeek.ToString();

                        int FirstDayWeek = 0; 

                        if (DayName == "Tuesday")
                        {
                            FirstDayWeek = 1;
                        }

                        if (DayName == "Wednesday")
                        {
                            FirstDayWeek = 2;
                        }

                        if (DayName == "Thursday")
                        {
                            FirstDayWeek = 3;
                        }

                        if (DayName == "Friday")
                        {
                            FirstDayWeek = 4;
                        }

                        if (DayName == "Saturday")
                        {
                            FirstDayWeek = 5;
                        }

                        if (DayName == "Sunday")
                        {
                            FirstDayWeek = 6;
                        }

                        DateTime thisDay = DateTime.Today;
                        DateTime dt;

                        dt = thisDay.AddDays(-FirstDayWeek);

                        try
                        {
                            MySqlDataAdapter sd = new MySqlDataAdapter("Select * from medicine", con);
                            DataTable dts = new DataTable();
                            sd.Fill(dts);

                            for (int i = 0; i < dts.Rows.Count; i++)
                            {
                                string MedCde = dts.Rows[i]["MedCde"].ToString();
                                string Type = dts.Rows[i]["Type"].ToString();
                                string MName = dts.Rows[i]["Name"].ToString();
                                string PurUntPrice = dts.Rows[i]["PurUntPrice"].ToString();
                                string SldUntPrice = dts.Rows[i]["SldUntPrice"].ToString();
                                string Discount = dts.Rows[i]["Discount"].ToString();

                                try
                                {
                                    MySqlDataAdapter sds = new MySqlDataAdapter("select sum(qty) , sum(qty * SldUntPrice) , sum(qty * PurUntPrice) from audittrail where IsSld = 'Yes' and Name = '" + MName + "' and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtss = new DataTable();
                                    sds.Fill(dtss);

                                    string SoldQuantity = dtss.Rows[0][0].ToString();
                                    string SoldCost = dtss.Rows[0][1].ToString();
                                    string PurCost = dtss.Rows[0][2].ToString();

                                    MySqlDataAdapter sdssss = new MySqlDataAdapter("select sum(qty) from audittrail where IsPur = 'Yes' and Name = '" + MName + "' and PurUntPrice = SldUntPrice and Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsssss = new DataTable();
                                    sdssss.Fill(dtsssss);

                                    string ReturnQuantity = dtsssss.Rows[0][0].ToString();

                                    if (SoldQuantity != "" && SoldCost != "")
                                    {
                                        Double soldcost;
                                        int soldquantity;
                                        Double purcost;
                                        int returnquantity;

                                        try
                                        {
                                            soldcost = Double.Parse(SoldCost);
                                        }
                                        catch (Exception)
                                        {
                                            soldcost = 0;
                                        }

                                        try
                                        {
                                            soldquantity = Int32.Parse(SoldQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            soldquantity = 0;
                                        }

                                        try
                                        {
                                            purcost = Double.Parse(PurCost);
                                        }
                                        catch (Exception)
                                        {
                                            purcost = 0;
                                        }

                                        try
                                        {
                                            returnquantity = Int32.Parse(ReturnQuantity);
                                        }
                                        catch (Exception)
                                        {
                                            returnquantity = 0;
                                        }

                                        int NewQuatity = soldquantity - returnquantity;

                                        Double ProfitLose;

                                        if (returnquantity > 0)
                                        {
                                            Double slduntprice = Double.Parse(SldUntPrice);
                                            Double puruntprice = Double.Parse(PurUntPrice);
                                            Double discount = Double.Parse(Discount);

                                            Double SCost = NewQuatity * slduntprice;

                                            Double DCost = (SCost * discount) / 100;

                                            Double NCost = SCost - DCost;

                                            SCost = NCost;

                                            Double PCost = NewQuatity * puruntprice;

                                            soldcost = SCost;
                                            purcost = PCost;

                                            ProfitLose = SCost - PCost;
                                        }
                                        else
                                        {
                                            Double discount = Double.Parse(Discount);

                                            Double dcost = (soldcost * discount) / 100;

                                            Double ncost = soldcost - dcost;

                                            soldcost = ncost;

                                            ProfitLose = soldcost - purcost;
                                        }

                                        //MessageBox.Show(MedCde + "---" + Type + "---" + MName + "---" + soldquantity + "---" + soldcost + "---" + purchasequantity + "---" + purchasecost + "---" + PurUntPrice + "---" + SldUntPrice + " = " + ProfitLose);

                                        MySqlCommand c_m_d = con.CreateCommand();
                                        c_m_d.CommandText = "Insert into report (MedCde , Type , Name , Total_Sold_Quantity , Total_Purchased_Cost , Total_Sold_Cost , Sold_per_Unit_Price , Purchased_Per_Unit_Price , Discount , Profit) values('" + MedCde + "' , '" + Type + "' , '" + MName + "' , '" + NewQuatity + "' , '" + purcost + "' , '" + soldcost + "' , '" + SldUntPrice + "' , '" + PurUntPrice + "' , '" + Discount + "%" + "' , '" + ProfitLose + "')";

                                        try
                                        {
                                            c_m_d.ExecuteNonQuery();

                                            try
                                            {
                                                MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                                DataTable dtssss = new DataTable();
                                                sda.Fill(dtssss);
                                                dataGridView1.DataSource = dtssss;
                                                dataGridView1.AllowUserToAddRows = false;

                                                MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                                DataTable dtsss = new DataTable();
                                                sdss.Fill(dtsss);
                                                dataGridView2.DataSource = dtsss;
                                                dataGridView2.AllowUserToAddRows = false;
                                            }

                                            catch (Exception)
                                            {
                                                MessageBox.Show("Current Week Data does not Exists!");
                                            }
                                        }

                                        catch (MySqlException)
                                        {
                                            MessageBox.Show("Data not inserted Successfully!");
                                        }
                                    }
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show(MName + " Medicine doest not Found!");
                                }
                            }

                            try
                            {
                                MySqlDataAdapter sds = new MySqlDataAdapter("select sum(Profit) from report", con);
                                DataTable dtss = new DataTable();
                                sds.Fill(dtss);

                                string profit = dtss.Rows[0][0].ToString();

                                MySqlDataAdapter sdss = new MySqlDataAdapter("select sum(Price) from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                DataTable dtsss = new DataTable();
                                sdss.Fill(dtsss);

                                string expense = dtsss.Rows[0][0].ToString();

                                Double Profit = Double.Parse(profit);

                                Double Expense;

                                try
                                {
                                    Expense = Double.Parse(expense);
                                }

                                catch (Exception)
                                {
                                    Expense = 0;
                                    expense = "0";
                                }

                                Double NetProfit = Profit - Expense;

                                long P = Convert.ToInt64(Profit);
                                long E = Convert.ToInt64(Expense);
                                long N = Convert.ToInt64(NetProfit);

                                SalesProfitTxtBox.Text = P.ToString();
                                ExpensesTxtBox.Text = E.ToString();

                                if (NetProfit < 0)
                                {
                                    NProfitTxtBox.BackColor = Color.Red;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                else
                                {
                                    NProfitTxtBox.BackColor = Color.Green;
                                    NProfitTxtBox.ForeColor = Color.White;

                                    NProfitTxtBox.Text = N.ToString();
                                }

                                DownloadReport_Button.Enabled = true;
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Current Week Data does not Exists!");

                                try
                                {
                                    MySqlDataAdapter sda = new MySqlDataAdapter(@"Select * from report", con);
                                    DataTable dtssss = new DataTable();
                                    sda.Fill(dtssss);
                                    dataGridView1.DataSource = dtssss;
                                    dataGridView1.AllowUserToAddRows = false;

                                    MySqlDataAdapter sdss = new MySqlDataAdapter("select * from expense where Date between '" + dt.ToString("yyyy/MM/dd") + "'  and  '" + thisDay.ToString("yyyy/MM/dd") + "'", con);
                                    DataTable dtsss = new DataTable();
                                    sdss.Fill(dtsss);
                                    dataGridView2.DataSource = dtsss;
                                    dataGridView2.AllowUserToAddRows = false;

                                    NProfitTxtBox.BackColor = Color.White;

                                    SalesProfitTxtBox.Text = null;
                                    ExpensesTxtBox.Text = null;
                                    NProfitTxtBox.Text = null;
                                }

                                catch (Exception)
                                {
                                    MessageBox.Show("Current Week Data does not Exists!");
                                }
                            }

                            MySqlCommand cmd = new MySqlCommand(@"Delete from report", con);

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }

                            catch (Exception)
                            {
                                MessageBox.Show("Query Error!");
                            }
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Data not found!");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Please Select Option!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }

        private void GoBack_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminPage ad = new AdminPage(Name);
            ad.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Option = comboBox1.Text;

            if (Option != "")
            {
                if (Option == "Last n days")
                {
                    DaysTxtBox.Text = "Enter Days";
                    DaysTxtBox.Enabled = true;
                    StartDate.Enabled = false;
                    EndDate.Enabled = false;
                }

                if (Option == "Select Date Range")
                {
                    DaysTxtBox.Text = "Enter Days";
                    DaysTxtBox.Enabled = false;
                    StartDate.Enabled = true;
                    EndDate.Enabled = true;
                }

                if (Option == "Today" || Option == "Yesterday" || Option == "Last Week" || Option == "Last Month" || Option == "Current Month" || Option == "Current Year" || Option == "Current Week")
                {
                    DaysTxtBox.Text = "Enter Days";
                    DaysTxtBox.Enabled = false;
                    StartDate.Enabled = false;
                    EndDate.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please Select Option!");
            }
        }

        private void DownloadReport_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;database=medical_store;username=root;convert zero datetime=true;pwd=");

            try
            {
                con.Open();
                try
                {
                    saveFileDialog1.InitialDirectory = "C:";
                    saveFileDialog1.Title = "Save as Excel File";
                    saveFileDialog1.FileName = "";
                    saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx|Excel Files(2013)|*.xlsx";

                    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    {
                        Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);

                        ExcelApp.Columns.ColumnWidth = 25;

                        try
                        {
                            MySqlDataAdapter sds = new MySqlDataAdapter("select MedStrName from accounts where Name = '" + Name + "'", con);
                            DataTable dtss = new DataTable();
                            sds.Fill(dtss);

                            string MedStrName = dtss.Rows[0][0].ToString();
                            ExcelApp.Cells[1, 1] = MedStrName;
                        }

                        catch (Exception)
                        {
                            MessageBox.Show("Medical Store Name does not exist!");
                        }

                        Excel.Range formatRange = ExcelApp.get_Range("a1", "d1");
                        formatRange.Font.Bold = true;
                        formatRange.Font.Size = 25;
                        formatRange.Font.Name = "Calibri (Body)";

                        DateTime thisDay = DateTime.Now;
                        ExcelApp.Cells[3, 1] = "Report Generated on " + thisDay.ToString();

                        Excel.Range formatRange1 = ExcelApp.get_Range("a3", "d3");
                        formatRange1.Font.Bold = true;
                        formatRange1.Font.Size = 12;
                        formatRange1.Font.Name = "Calibri (Body)";

                        Excel.Range formatRange2 = ExcelApp.get_Range("a5", "j5");
                        formatRange2.Font.Bold = true;

                        for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[5, i] = dataGridView1.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 6, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        int ExpenseHCol = 6 + dataGridView1.Rows.Count + 2;
                        string expenseHCol = ExpenseHCol.ToString();

                        Excel.Range formatRange1_2 = ExcelApp.get_Range("a" + expenseHCol);
                        formatRange1_2.Font.Bold = true;
                        formatRange1_2.Font.Size = 12;
                        formatRange1_2.Font.Name = "Calibri (Body)";

                        ExcelApp.Cells[ExpenseHCol, 1] = "Expenses";

                        int ExpenseColNo = ExpenseHCol + 2;
                        string expenseColNo = ExpenseColNo.ToString();

                        Excel.Range formatRange2_1 = ExcelApp.get_Range("a" + expenseColNo , "d" + expenseColNo);
                        formatRange2_1.Font.Bold = true;

                        for (int i = 1; i < dataGridView2.Columns.Count + 1; i++)
                        {
                            ExcelApp.Cells[ExpenseColNo, i] = dataGridView2.Columns[i - 1].HeaderText;
                        }

                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView2.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + ExpenseColNo + 1 , j + 1] = dataGridView2.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        int column1 = 6 + dataGridView1.Rows.Count + dataGridView1.Rows.Count + 7;
                        string Column1 = column1.ToString();

                        int column2 = column1 + 1;
                        string Column2 = column2.ToString();

                        int column3 = column2 + 1;
                        string Column3 = column3.ToString();

                        Excel.Range formatRange3 = ExcelApp.get_Range("a" + Column1, "d" + Column1);
                        formatRange3.Font.Bold = true;
                        formatRange3.Font.Size = 15;
                        formatRange3.Font.Name = "Calibri (Body)";

                        Excel.Range formatRange3_1 = ExcelApp.get_Range("b" + Column1);
                        formatRange3_1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        ExcelApp.Cells[column1 , 1] = "Total Sales Profit";
                        ExcelApp.Cells[column1 , 2] = SalesProfitTxtBox.Text;

                        Excel.Range formatRange4 = ExcelApp.get_Range("a" + Column2, "d" + Column2);
                        formatRange4.Font.Bold = true;
                        formatRange4.Font.Size = 15;
                        formatRange4.Font.Name = "Calibri (Body)";

                        Excel.Range formatRange4_1 = ExcelApp.get_Range("b" + Column2);
                        formatRange4_1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);

                        ExcelApp.Cells[column2, 1] = "Total Expenses";
                        ExcelApp.Cells[column2, 2] = ExpensesTxtBox.Text;

                        Excel.Range formatRange5 = ExcelApp.get_Range("a" + Column3, "d" + Column3);
                        formatRange5.Font.Bold = true;
                        formatRange5.Font.Size = 15;
                        formatRange5.Font.Name = "Calibri (Body)";

                        ExcelApp.Cells[column3, 1] = "Net Profit";
                        ExcelApp.Cells[column3, 2] = NProfitTxtBox.Text;

                        long NetProfit = Int64.Parse(NProfitTxtBox.Text);

                        if (NetProfit < 0)
                        {
                            Excel.Range formatRange5_1 = ExcelApp.get_Range("b" + Column3);
                            formatRange5_1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                            formatRange5_1.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        }
                        else
                        {
                            Excel.Range formatRange5_1 = ExcelApp.get_Range("b" + Column3);
                            formatRange5_1.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);
                            formatRange5_1.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        }

                        ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();

                        MessageBox.Show("Report Created Successsfully!");
                    }
                }

                catch (Exception)
                {
                    MessageBox.Show("Some Error Occurrs Report does not Created!");
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Problem!");
            }
        }
    }
}
