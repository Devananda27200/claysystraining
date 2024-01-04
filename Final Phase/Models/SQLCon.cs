using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_ShoppingPortal.Models
{
    public class SQLCon
    {
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection("Data Source=DEVANANDA\\SQLEXPRESS;Initial Catalog=ShoppingPortal;Integrated Security=True");
            connection.Open();
            return connection;
        }
    }
}