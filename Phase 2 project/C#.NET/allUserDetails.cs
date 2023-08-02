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

namespace Phase_2_Project
{
    public partial class allUserDetails : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=projectDb;Integrated Security=True");
        SqlDataReader rdr;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        string sql;
        public allUserDetails()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminLogin obj = new adminLogin();
            obj.Show();
        }

        private void allUserDetails_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDbDataSet.register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.projectDbDataSet.register);
            con.Open();
            sql = "select * from register";
            da=new SqlDataAdapter(sql,con);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
