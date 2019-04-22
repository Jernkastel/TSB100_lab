using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TSB100_lab.Models;

namespace TSB100_lab.Controllers
{
    public class HomeController : Controller
    {
        UserInfoDBEntities db = new UserInfoDBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserCredentials login)
        {
            if (login.Username == null || login.Password == null)
            {
                ModelState.AddModelError("", "Du måste ange användarnamn och lösenord");
                return View();
            }

            bool validUser = false;
            /* LOGIN TEST WITH FORMSAUTHENTICATION 
            validUser = System.Web.Security.FormsAuthentication.Authenticate(login.Username, login.Password);
            */
            validUser = ValidateUser(login.Username, login.Password);

            if (validUser)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(login.Username, false);
            }
            ModelState.AddModelError("", "Inloggningen misslyckades, vänligen försök igen");
            return View();

        }

        [Authorize]
        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private bool ValidateUser(string username, string password)
        {
            var user = from row in db.UserCredentials
                       where row.Username.ToUpper() == username.ToUpper()
                       && row.Password == password
                       select row;

            if (user.Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}