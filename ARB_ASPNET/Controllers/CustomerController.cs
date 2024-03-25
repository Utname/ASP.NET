using ARB_ASPNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARB_ASPNET.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index(string fullname)  
        {
            var data = ARB_ASPNET.Models.ListCustomer.customers.Where(q => q.Fullname.ToLower().Contains(fullname.ToLower().Trim())).ToList();
            return View(data);
        }
    }
}