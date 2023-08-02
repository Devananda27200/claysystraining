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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Phase_2_Project
{
    public partial class userUpdate : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        string sql, password, username;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select password,username from register where eId='" + uEid.Text + "'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                username = rdr[0].ToString();
                uUname.Text = username;
                password = rdr[1].ToString();
                uPass.Text = password;

                uEid.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rdr.Close();
        }

        private void userUpdate_Load(object sender, EventArgs e)
        {
            con.Open();
            uEid.Focus();
        }

        public userUpdate()
        {
            InitializeComponent();
        }

        private void uEid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            user u = new user();
            u.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uEid.Text) || string.IsNullOrWhiteSpace(uPass.Text))
            {
                MessageBox.Show("Fields Empty!!!");
            }
            else
            {
                try
                {
                    sql = "update register set password='" + uPass.Text + "' where eId=" + uEid.Text + "";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    sql = "update login set password='" + uPass.Text + "' where username='" + uUname.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Details have been updated!!", "Message");
                    uEid.Text = " ";
                    uUname.Text = " ";
                    uPass.Text = " ";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
