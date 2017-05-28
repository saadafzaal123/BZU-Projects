using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medical_Store_Managment_System
{
    public partial class AdminPage : Form
    {
        string name;

        public AdminPage(string User)
        {
            InitializeComponent();
            Admin.Text = "Admin : " + User;
            name = User;
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void Change_Password_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword rp = new ResetPassword(name);
            rp.Show();
        }

        private void Manage_User_Accounts_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageUserAccounts mua = new ManageUserAccounts(name);
            mua.Show();
        }

        private void Expense_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Expense ex = new Expense(name);
            ex.Show();
        }

        private void Product_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductPage pp = new ProductPage(name);
            pp.Show();
        }

        private void Sales_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales s = new Sales(name);
            s.Show();
        }

        private void Purchase_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Purchase p = new Purchase(name);
            p.Show();
        }

        private void Report_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report r = new Report(name);
            r.Show();
        }
    }
}
