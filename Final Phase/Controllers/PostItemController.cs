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
    public class PostItemController : Controller
    {
        // GET: PostItem
        public ActionResult Index()
        {
            if (Session["loggedUser"] == null) return RedirectToAction("Index", "Login");
            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();
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
            ViewBag.categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, int category, double price, string description, HttpPostedFileBase file)
        {

            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();
            q.CommandType = CommandType.Text;

            string imagefile = "";
            if (file.ContentLength > 0)
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";
                var path = Path.Combine(Server.MapPath("~/Content/Uploads"), fileName);
                file.SaveAs(path);
                imagefile = fileName;
            }

            User loggeduser = (User)Session["loggedUser"];
            q.CommandText = "INSERT INTO [Item](category_id,user_id,itemName,description,price,imagefile,status) VALUES('" + category + "','" + loggeduser.id + "','" + name.Replace("'", "''") + "','" + description.Replace("'", "''") + "','" + price + "','" + imagefile + "','0');";

            int a = q.ExecuteNonQuery();

            if (a > 0)
            {
                q.CommandText = "SELECT @@IDENTITY AS new_id";
                int new_id = Int32.Parse(q.ExecuteScalar().ToString());
                return RedirectToAction("Index", "MyItems", new { new_id = new_id });
            }

            return RedirectToAction("Error", "PostItem");
        }


        public ActionResult Error()
        {
            return View();
        }

    }
}