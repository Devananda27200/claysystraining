using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_ShoppingPortal.Models;
using E_ShoppingPortal.DAL;
using System.Data.SqlClient;
using System.Data;

namespace E_ShoppingPortal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (SqlConnection con = SQLCon.getConnection())
                {
                    con.Open();

                    /* categories */
                    using (SqlCommand q = con.CreateCommand())
                    {
                        q.CommandType = CommandType.Text;
                        q.CommandText = "SELECT * FROM [Category]";
                        using (SqlDataReader result = q.ExecuteReader())
                        {
                            List<Category> categories = new List<Category>();
                            while (result.Read())
                            {
                                categories.Add(new Category
                                {
                                    id = Int32.Parse(result["id"].ToString()),
                                    name = result["name"].ToString()
                                });
                            }
                            ViewBag.categories = categories;
                        }
                    }

                    /* latest items */
                    using (SqlCommand q = con.CreateCommand())
                    {
                        q.CommandType = CommandType.Text;
                        q.CommandText = "SELECT TOP 6 [Category].name AS category_name,[Item].* FROM [Item] LEFT JOIN [Category] ON [Item].category_id=[Category].id WHERE [Item].status=0 ORDER BY [Item].id DESC";
                        using (SqlDataReader result = q.ExecuteReader())
                        {
                            List<Item> items = new List<Item>();
                            while (result.Read())
                            {
                                Double.TryParse(result["price"].ToString(), out double price);
                                items.Add(new Item
                                {
                                    id = Int32.Parse(result["id"].ToString()),
                                    userId = Int32.Parse(result["user_id"].ToString()),
                                    price = Double.Parse(result["price"].ToString()),
                                    itemName = result["itemName"].ToString(),
                                    imageFile = result["imagefile"].ToString(),
                                    description = result["description"].ToString()
                                });
                            }
                            ViewBag.items = items;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Handle the exception here, you may want to log it or display a user-friendly error message.
                ViewBag.ErrorMessage = e.ToString()  +"An error occurred while processing your request.";
                // Optionally, you can log the exception for further analysis
                // Log.Error("An error occurred: " + ex.Message);
            }

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }

}
