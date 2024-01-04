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
    public class RemoveItemController : Controller
    {
        // GET: RemoveItem
        [HttpPost]
        public ActionResult Index(int itemId)
        {
            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();
            q.CommandType = CommandType.Text;
            User user = (User)Session["loggedUser"];
            q.CommandText = "DELETE FROM [Item] WHERE id=@itemId";
            q.Parameters.AddWithValue("@itemId", itemId);
            con.Open();
            int rowsAffected = q.ExecuteNonQuery();
            con.Close();

            if (rowsAffected > 0)
            {
                // Item removed successfully
                return RedirectToAction("Index", "Products");
            }
            else
            {
                // Item removal failed
                TempData["ErrorMessage"] = "Failed to remove item.";
                return  RedirectToAction("Index","Item");
            }
            
        }
    }
}