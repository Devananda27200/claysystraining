using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Phase_2_Project
{
    public partial class user : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        string sql, firstname, lastname, depid, phone, email, password, username, dob;

        private void updatePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            userUpdate obj = new userUpdate();
            obj.Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure? You want to exit now?", "Exit", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();

            }
            else
            {
                MessageBox.Show("Continue?");
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure? You want logout now?", "Logout", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                login obj = new login();
                obj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Continue?");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select firstName,lastName,dateOfBirth,depId,phone,email,password,username from register where eId='" + textBox1.Text + "'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                firstname = rdr[0].ToString();
                textBox2.Text = firstname;
                lastname = rdr[1].ToString();
                dob = rdr[2].ToString();
                textBox10.Text = dob;
                textBox3.Text = lastname;
                depid = rdr[3].ToString();
                textBox4.Text = depid;
                phone = rdr[4].ToString();
                textBox5.Text = phone;
                email = rdr[5].ToString();
                textBox6.Text = email;
                password = rdr[6].ToString();
                textBox7.Text = password;
                //username = rdr[7].ToString();
                //textBox9.Text = username;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rdr.Close();
        }

        private void user_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        public user()
        {
            InitializeComponent();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            
        }
    }
}
