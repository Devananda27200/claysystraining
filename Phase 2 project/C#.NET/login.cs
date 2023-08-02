using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Phase_2_Project
{
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlDataReader rdr;
        string type;
        public static string user;
        public login()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            register obj= new register();
            obj.Show();
        }

        private void blogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(lPassword.Text) && string.IsNullOrWhiteSpace(lUsername.Text))
            {
                MessageBox.Show("Enter username and password!");
            }
            else
            {
                try
                {
                    
                    SqlCommand cmd = new SqlCommand("select userType from login where username=@username and password=@password", con);
                    cmd.Parameters.AddWithValue("@username", lPassword.Text);
                    cmd.Parameters.AddWithValue("@password", lUsername.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        type = rdr[0].ToString();
                        if (type == "Admin")
                        {
                            this.Hide();
                            adminLogin obj = new adminLogin();
                            user = lPassword.Text.ToUpper();
                            obj.ShowDialog();
                        }
                        else
                        {
                            this.Hide();
                            user obj = new user();
                            user = lPassword.Text.ToUpper();
                            obj.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!!");
                        lPassword.Clear();
                        lUsername.Clear();

                    }
                    rdr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            con.Open(); 
        }
    }
}
