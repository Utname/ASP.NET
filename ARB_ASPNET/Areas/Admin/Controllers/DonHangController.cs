using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        public ActionResult getAllListNew()
        {
            var map = new mapDonHang();
            return View(map.loadPageByStore(3,null,-1));
        }

       
    }
}