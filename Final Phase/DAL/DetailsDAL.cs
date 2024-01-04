using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace E_ShoppingPortal.DAL
{

    public class DetailsDAL
    {
        SqlCommand command;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public static SqlConnection Connect()
        {
            string connection = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            else con.Open();

            return con;
        }
        public bool DMLOpperation(string query)
        {
            command = new SqlCommand(query, DetailsDAL.Connect());
            int x = command.ExecuteNonQuery();
            if (x == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable SelactAll(string query)
        {
            dataAdapter = new SqlDataAdapter(query, DetailsDAL.Connect());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            return dt;
        }
    }
}