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

            DateTime currentDate = DateTime.Today;
            DateTime eighteenAge = currentDate.AddYears(-18);

            if (selectedDate > eighteenAge)
            {
                MessageBox.Show("You must be at least 18 years old.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Reset the DateTimePicker value to the minimum allowed date
                dateTimePicker1.Value = eighteenAge;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(confirmpass.Text)|| string.IsNullOrWhiteSpace(empid.Text))
            {
                MessageBox.Show("Field Empty!!!");
            }
            else
            {
                try
                {
                    sql = "update register set firstName='" + fname.Text + "',lastName='" + lname.Text + "',dateOfBirth='" + selectedDate.ToString("yyyy-MM-dd") + "',depId=" + dpID.Text + ",phone=" + phoneno.Text + ",email='" + emailid.Text + "',password='" + confirmpass.Text + "' where eId=" + empid.Text + "";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    sql = "update login set password='" + confirmpass.Text + "' where username='" + textBox9.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Details have been updated!!", "Message");
                    confirmpass.Text = " ";
                    empid.Text = " ";
                    fname.Text = " ";
                    lname.Text = " ";
                    dpID.Text = " ";
                    phoneno.Text = " ";
                    emailid.Text = " ";
                    pass.Text = " ";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        public admin()
        {
            InitializeComponent();
            dateTimePicker1.MaxDate = DateTime.Today.AddYears(-18);
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
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
            if (string.IsNullOrWhiteSpace(empid.Text))
            {
                MessageBox.Show("Enter the ID!!");
            }
            else
            {
                try
                {
                    sql = "select firstName,lastName,depId,phone,email,password,username from register where eId='" + empid.Text + "'";
                    cmd = new SqlCommand(sql, con);
                    rdr = cmd.ExecuteReader();
                    rdr.Read();
                    firstname = rdr[0].ToString();
                    fname.Text = firstname;
                    lastname = rdr[1].ToString();
                    lname.Text = lastname;
                    depid = rdr[2].ToString();
                    dpID.Text = depid;
                    phone = rdr[3].ToString();
                    phoneno.Text = phone;
                    email = rdr[4].ToString();
                    emailid.Text = email;
                    password = rdr[5].ToString();
                    pass.Text = password;
                    username = rdr[6].ToString();
                    textBox9.Text = username;


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
