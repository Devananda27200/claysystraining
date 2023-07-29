using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Phase_2_Project
{
    public partial class register : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlCommand cmd;
        //SqlDataAdapter da;
        string sql;
        public register()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login l = new login();
            l.Show();
        }

        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            label10.Text = selectedDate.ToString("yyyy-MM-dd");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cities.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "Kerala")
            {
                cities.Items.Add("kozhikode");
                cities.Items.Add("Trivandrum");
                cities.Items.Add("Kochi");
                cities.Items.Add("Thrissur");
            }
            else if (comboBox1.SelectedItem.ToString() == "Tamilnadu")
            {
                cities.Items.Add("chennai");
                cities.Items.Add("Coimbatore");
                cities.Items.Add("Madurai");
                cities.Items.Add("salem");
            }
            else if (comboBox1.SelectedItem.ToString() == "Goa")
            {
                cities.Items.Add("Panaji");
                cities.Items.Add("Margao");
                cities.Items.Add("vasco da gama");

            }
            //    cities.Items.Add(String.Format("{0}",
            //    comboBox1.SelectedItem, i.ToString()));

            //cities.SelectedIndex = 0;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string email = textBox6.Text.Trim();

            // Defining the regular expression pattern for email validation.
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Checking if the email matches the pattern.
            if (Regex.IsMatch(email, emailPattern))
            {
                // Valid email address.
                label15.Text = " ";
            }
            else
            {
                // Invalid email address.
                label15.Text = "Inalid email address";
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == textBox9.Text)
            {
                //same password
                label16.Text = " ";
            }
            else
            {
                // Invalid
                label16.Text = "Mismatched Passwords!";
            }

        }

        private void register_Load(object sender, EventArgs e)
        {
            con.Open();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox9.Text == "")
            {
                MessageBox.Show("Enter the details!!");
            }
            else
            {
                try
                {
                    //inserting data into register table
                    sql = "insert into dbo.register values('" + textBox1.Text + "','" + textBox2.Text + "','" + label10.Text + "'," + textBox3.Text + ",'" + comboBox1.SelectedItem.ToString() + "','" + cities.SelectedItem.ToString() + "'," + textBox4.Text + ",'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox9.Text + "','User')";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    //inserting data into login table
                    sql = "insert into Login values('" + textBox7.Text + "','" + textBox9.Text + "','User')";
                    cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successfull!!");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    comboBox1.SelectedIndex = 0;
                    cities.Items.Clear();
                    cities.SelectedIndex = 0;
                    dateTimePicker1.Value = DateTime.Now; 
                    label10.Visible=false;
                    label15.Visible = false;
                    label16.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }
    }   
}
