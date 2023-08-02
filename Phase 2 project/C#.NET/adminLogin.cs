using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phase_2_Project
{
    public partial class adminLogin : Form
    {
        public adminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin l = new admin();
            l.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            delete d= new delete();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            login login = new login();
            login.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            allUserDetails obj = new allUserDetails();
            obj.Show();
        }
    }
}
