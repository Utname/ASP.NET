using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARB_ASPNET.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult getAllCustomer()
        {
            mapCustomers map = new mapCustomers();
            var ds = map.getPageListCustomer(1,10);
            return View(ds);
        }
    }
}