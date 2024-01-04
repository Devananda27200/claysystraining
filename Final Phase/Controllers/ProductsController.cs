
using E_ShoppingPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace E_ShoppingPortal.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(int? category_id, string keyword, int? startPrice, int? endPrice, int? page)
        {
            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();

            if (page == null)
                page = 0;

            ViewBag.page = page;
            /* categories */
            q.CommandType = CommandType.Text;
            q.CommandText = "SELECT * FROM [Category]";
            SqlDataReader result = q.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (result.Read())
            {
                categories.Add(new Category
                {
                    id = Int32.Parse(result["id"].ToString()),
                    name = result["name"].ToString()
                });
            }
            ViewData["Categories"] = categories;
            result.Close();
            /* latest items */

            string filter = "";

            if (category_id != null && category_id > 0)
            {
                ViewBag.category_id = category_id;
                filter += " AND [Item].category_id=" + category_id;
            }

            if (keyword != null)
            {
                ViewBag.keyword = keyword;
                filter += " AND [Item].name LIKE '%" + keyword + "%'";
            }

            if (startPrice != null && endPrice != null)
            {
                ViewBag.startPrice = startPrice;
                ViewBag.endPrice = endPrice;
                filter += " AND [Item].price>=" + startPrice + " AND [Item].price<=" + endPrice + "";
            }



            SqlCommand qTotal = con.CreateCommand();
            qTotal.CommandType = CommandType.Text;
            qTotal.CommandText = "SELECT COUNT([Item].id) AS total FROM [Item] LEFT JOIN [Category] ON [Item].category_id=[Category].id WHERE [Item].status=0 " + filter + "";

            SqlDataReader resultTotal = qTotal.ExecuteReader();
            resultTotal.Read();

            int totalResults = Int32.Parse(resultTotal["total"].ToString());
            int totalPages = (int)Math.Ceiling((double)totalResults / 10);
            ViewBag.totalResult = totalResults;
            ViewBag.totalPages = totalPages;

            resultTotal.Close();


            q.CommandType = CommandType.Text;
            q.CommandText = "SELECT [Category].name AS category_name,[Item].* FROM [Item] LEFT JOIN [Category] ON [Item].category_id=[Category].id WHERE [Item].status=0 " + filter + " ORDER BY [Item].id DESC OFFSET " + page * 10 + " ROWS FETCH NEXT 10 ROWS ONLY";
            result = q.ExecuteReader();

            int currentItems = 0;
            List<Item> items = new List<Item>();
            while (result.Read())
            {
                items.Add(new Item
                {
                    id = Convert.ToInt32(result["id"].ToString()),
                    category = new Category
                    {
                        id = Int32.Parse(result["category_id"].ToString()),
                        name = result["category_name"].ToString()

                    },
                    userId = Convert.ToInt32(result["user_id"].ToString()),
                    price = Convert.ToDouble(result["price"].ToString()),
                    itemName = result["name"].ToString(),
                    imageFile = result["imagefile"].ToString(),
                    description = result["description"].ToString()

                });
                currentItems++;
            }
            ViewBag.items = items;
            ViewBag.currentItems = currentItems;
            ViewData["Categories"] = categories;
            ViewData["Items"] = items;

            return View();
        }
    }
}
