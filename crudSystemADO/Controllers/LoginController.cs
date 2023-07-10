using crudSystemADO.Models;
using crudSystemADO.Utility;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NuGet.Protocol;
using System.Data;
using GoogleAuthentication.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace crudSystemADO.Controllers
{
    public class Login: Controller
    {
        private readonly string connectionString;

        public Login()
        {
            connectionString = ConnectionString.CName;
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPage(LoginPage lg)
        {
            MySqlConnection con = new MySqlConnection(connectionString);

            //string mysqlquery = "SELECT UserName,Password FROM userreg WHERE UserName = @UserName AND UserName = @Password";
            con.Open();
            MySqlCommand cmd = new MySqlCommand("ViewLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("p_email", lg.Email);
            cmd.Parameters.AddWithValue("p_password", lg.Password);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                TempData["Email"] = lg.Email.ToString();
                return RedirectToAction("Index", "employee", null);

            }
            else
            {
                ViewData["Message"] = "Login Failed";
            }
            con.Close();
            return View();
        }



        [HttpGet]
        public IActionResult GoogleLogin()
        {
            // Clear the existing external cookie to force Google authentication
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var properties = new AuthenticationProperties
            { 
                
                RedirectUri = Url.Action("Index","Employee")
            };
            properties.SetParameter("prompt", "select_account"); // Add this line to force account selection
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }


       

        
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("LoginPage");
        }


        

    }
}

