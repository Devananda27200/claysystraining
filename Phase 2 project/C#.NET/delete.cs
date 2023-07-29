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

namespace Phase_2_Project
{
    public partial class delete : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        string sql, firstname, lastname, depid, phone, email, password, username,dob;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            adminLogin al=new adminLogin();
            al.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "delete from register where eId=" + textBox1.Text + "";
                cmd = new SqlCommand(sql,con);
                cmd.ExecuteNonQuery();
                sql = "delete from login where username='" + textBox9.Text + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Details have been deleted!!", "Message");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message");
            }
        }

        private void delete_Load(object sender, EventArgs e)
        {
            con.Open(); 
        }

        public delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select firstName,lastName,dateOfBirth,depId,phone,email,password,username from register where eId='" + textBox1.Text + "'";
                cmd = new SqlCommand(sql,con);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                firstname = rdr[0].ToString();
                textBox2.Text = firstname;
                lastname = rdr[1].ToString();
                textBox3.Text = lastname;
                depid = rdr[3].ToString();
                textBox4.Text = depid;
                phone = rdr[4].ToString();
                textBox5.Text = phone;
                email = rdr[5].ToString();
                textBox6.Text = email;
                password = rdr[6].ToString();
                textBox7.Text = password;
                username = rdr[7].ToString();
                textBox9.Text = username;
                dob = rdr[2].ToString();
                textBox10.Text = dob;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rdr.Close();
        }
    }
}
