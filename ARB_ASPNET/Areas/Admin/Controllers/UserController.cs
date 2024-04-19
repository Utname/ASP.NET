using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARB_ASPNET.App_Start;
using Data;
using Data.Entity;
namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        mapAccount map = new mapAccount();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            var user = map.Search(name, password);
            if (user != null)
            {
                SessionConfig.SetUser(user);
                var us = SessionConfig.GetUser();
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                //return RedirectToAction("/Admin/Dashboard/Index);
            }
            ViewBag.error = "Invalid account name or password";
            return View();
        }

        public ActionResult Logout()
        {
            SessionConfig.SetUser(null);
            return RedirectToAction("Login", "User", new { area = "Admin" });

        }

        /// <summary>
        /// Return view Account
        /// </summary>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register Account
        /// </summary>
        [HttpPost]
        public ActionResult Register(Account model)
        {
            if (map.Insert(model) == true) return RedirectToAction("Login");
            else return View(model);
        }
    }
}