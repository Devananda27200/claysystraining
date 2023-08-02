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
            if (string.IsNullOrWhiteSpace(deId.Text)||string.IsNullOrEmpty(dDeptid.Text)|| string.IsNullOrEmpty(dDob.Text) || string.IsNullOrEmpty(dEmail.Text) || string.IsNullOrEmpty(dPass.Text) || string.IsNullOrEmpty(dPhone.Text) || string.IsNullOrEmpty(dfname.Text) || string.IsNullOrEmpty(dlname.Text))
            {
                MessageBox.Show("Fields Empty!!!");
            }
            else
            {
                try
                {
                    sql = "delete from register where eId=" + deId.Text + "";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    sql = "delete from login where username='" + textBox9.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Details have been deleted!!", "Message");
                    deId.Text = " ";
                    dfname.Text = " ";
                    dlname.Text = " ";
                    dDeptid.Text = " ";
                    dDob.Text = " ";
                    dEmail.Text = " ";
                    dPass.Text = " ";
                    dPhone.Text = " ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message");
                }
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
            if (string.IsNullOrWhiteSpace(deId.Text))
            {
                MessageBox.Show("Field Empty!!!");
            }
            else
            {
                try
                {
                    sql = "select firstName,lastName,dateOfBirth,depId,phone,email,password,username from register where eId='" + deId.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    firstname = rdr[0].ToString();
                    dfname.Text = firstname;
                    lastname = rdr[1].ToString();
                    dlname.Text = lastname;
                    depid = rdr[3].ToString();
                    dDeptid.Text = depid;
                    phone = rdr[4].ToString();
                    dPhone.Text = phone;
                    email = rdr[5].ToString();
                    dEmail.Text = email;
                    password = rdr[6].ToString();
                    dPass.Text = password;
                    username = rdr[7].ToString();
                    textBox9.Text = username;
                    dob = rdr[2].ToString();
                    dDob.Text = dob;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                rdr.Close();
            }
        }
    }
}
