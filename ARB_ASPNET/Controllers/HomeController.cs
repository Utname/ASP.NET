using ARB_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARB_ASPNET.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        // Chuyển dữ liệu từ action/controller sang view
        // - viewbag: túi dữ liệu
        public ActionResult Index()
        {
            return View();
        }
        
    }
}