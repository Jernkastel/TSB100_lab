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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserCredentials login)
        {
            bool validUser = false;
            validUser = System.Web.Security.FormsAuthentication.Authenticate(login.Username, login.Password);

            if (validUser)
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(login.Username, false);
            }
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
    }
}