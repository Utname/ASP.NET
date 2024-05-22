using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARB_ASPNET.App_Start;
using Data;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [RoleUser]
        public ActionResult Index()
        {
            return View(new mapAccount().getListAll());
        }

        public ActionResult LoiPhanQuyen()
        {
            return View();
        }
    }
}