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
using System.Xml.Linq;

namespace Phase_2_Project
{
    public partial class admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader rdr;
        string sql,firstname,lastname,depid,phone,email,password,username;
        DateTime selectedDate;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "update register set firstName='" + textBox2.Text + "',lastName='" + textBox3.Text + "',dateOfBirth='" + selectedDate.ToString("yyyy-MM-dd") + "',depId=" + textBox4.Text + ",phone="+textBox5.Text+",email='"+textBox6.Text+"',password='"+textBox8.Text+"' where eId=" + textBox1.Text + "";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                sql = "update login set password='" + textBox8.Text + "' where username='" + textBox9.Text + "'";
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your Details have been updated!!", "Message");
                textBox8.Text = " ";
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public admin()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            adminLogin l=new adminLogin();
            l.Show();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select firstName,lastName,depId,phone,email,password,username from register where eId='" + textBox1.Text + "'";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                firstname = rdr[0].ToString();
                textBox2.Text = firstname;
                lastname = rdr[1].ToString();
                textBox3.Text = lastname;
                depid = rdr[2].ToString();
                textBox4.Text = depid;
                phone = rdr[3].ToString();
                textBox5.Text = phone;
                email = rdr[4].ToString();
                textBox6.Text = email;
                password = rdr[5].ToString();
                textBox7.Text = password;
                username = rdr[6].ToString();
                textBox9.Text= username;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rdr.Close();
        }
    }
}
