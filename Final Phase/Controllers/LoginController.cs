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
    public class LoginController : Controller
    {
        public static int userid;
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        // POST : Login
        public ActionResult Index(string username, string password)
        {
            SqlConnection con = SQLCon.getConnection();
            SqlCommand q = con.CreateCommand();
            q.CommandType = CommandType.Text;
            q.CommandText = "SELECT TOP 1 * FROM [Register] WHERE Username='" + username + "' AND password='" + password + "'";
            SqlDataReader result = q.ExecuteReader();

            if (result.HasRows)
            {
                result.Read();  
                User user = new User
                {
                    firstName = result["firstname"].ToString(),
                    lastName = result["lastname"].ToString(),
                    email = result["email"].ToString(),
                    username = result["username"].ToString(),
                    password = result["password"].ToString(),
                    address = result["address"].ToString(),
                    bankDetails = result["bankdetails"].ToString(),
                    id = Int32.Parse(result["id"].ToString())
                   
                };
                Session["loggedUser"] = user;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.loginFailed = true; 
            bool disableSignupLink = false; // Set this value based on your condition

            ViewBag.DisableSignupLink = disableSignupLink;

            return View();
        }

        public ActionResult Signout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}