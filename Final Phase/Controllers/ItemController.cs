using E_ShoppingPortal.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ShoppingPortal.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index(int item_id)
        {
            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();
            q.CommandType = CommandType.Text;
            q.CommandText = "SELECT TOP 1 [Register].id AS seller_id, [Register].firstname,[Register].lastname, [Register].email,[Register].address,[Register].bankdetails,[Category].name AS category_name,[Item].* FROM [Item] LEFT JOIN [Category] ON [Item].category_id=[Category].id LEFT JOIN [Register] ON [Item].user_id=[Register].id WHERE [Item].id='" + item_id + "'";
            SqlDataReader result = q.ExecuteReader();
            result.Read();

            Item item = new Item
            {
                id = Convert.ToInt32(result["id"].ToString()),
                category = new Category
                {
                    id = Convert.ToInt32(result["category_id"].ToString()),
                    name = result["category_name"].ToString()

                },
                userId = Convert.ToInt32(result["user_id"].ToString()),
                //isSold = Int32.Parse(result["sold"].ToString()) == 1,
                price = Double.Parse(result["price"].ToString()),
                itemName = result["name"].ToString(),
                imageFile = result["imagefile"].ToString(),
                description = result["description"].ToString(),
                user = new User
                {
                    id = Convert.ToInt32(result["seller_id"].ToString()),
                    email = result["email"].ToString(),
                    firstName = result["firstname"].ToString(),
                    lastName = result["lastname"].ToString(),
                    address = result["address"].ToString(),
                    bankDetails = result["bankdetails"].ToString()
                }
            };
            ViewData["Items"] = item;
            result.Close();

            /* get if item is sold */
            if (item.isSold)
            {
                q.CommandText = "SELECT TOP 1 [Register].*,[Order].id AS oid,[Order].ordered_time AS ordered_time FROM [Order] LEFT JOIN [Register] ON [Order].user_id=[Register].id WHERE [Order].item_id='" + item.id + "'";
                result = q.ExecuteReader();
                if (result.HasRows)
                {
                    result.Read();
                    Order order = new Order
                    {
                        id = Convert.ToInt32(result["oid"].ToString()),
                        orderedTime = DateTime.Parse(result["ordered_time"].ToString()),
                        item = item,
                        user = new User
                        {
                            id = Convert.ToInt32(result["id"].ToString()),
                            email = result["email"].ToString(),
                            firstName = result["firstname"].ToString(),
                            lastName = result["lastname"].ToString(),
                            address = result["address"].ToString(),
                            bankDetails = result["bankdetails"].ToString()
                        }


                    };

                    ViewBag.order = order;

                }

            }


            return View();
        }
    }
}