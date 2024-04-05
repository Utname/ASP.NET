using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entity;
namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name,string password) {

            mapAccount map = new mapAccount();
            var user = map.Search(name, password);
            if(user != null)
            {
                return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                //return RedirectToAction("/Admin/Dashboard/Index);
            }
            ViewBag.error = "Invalid account name or password";
            return View();

        }
    }
}