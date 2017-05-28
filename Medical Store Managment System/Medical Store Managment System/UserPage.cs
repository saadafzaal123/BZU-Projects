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
    public partial class UserPage : Form
    {
        string name;

        public UserPage(string User)
        {
            InitializeComponent();
            USER.Text = "User : " + User;
            name = User;
        }

        private void LogOut_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form lf = new Login_Form();
            lf.Show();
        }

        private void Reset_Password_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword rp = new ResetPassword(name);
            rp.Show();
        }

        private void Sales_button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sales s = new Sales(name);
            s.Show();
        }
    }
}
