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
            ViewBag.title = "Welcome to my channel";
            ViewBag.amount = 2000;
            //Dữ liệu được public nhưng chỉ đuọc gọi và dùng 1 lần , xài được giữ các view
            TempData["subTitle"] = "Say hi when you see me!!!";
            return View();
        }
        public ActionResult AboutUs()
        {
            Data data = new Data();
            data.name = "Trang gioi thieu";
            data.description = "Trang gioi thieu cua toi";

            Data data2 = new Data();
            data2.name = "Trang gioi thieu2";
            data2.description = "Trang gioi thieu cua toi2";

            List<Data> list = new List<Data>();
            list.Add(data);
            list.Add(data2);
            return View(list);
        }

        //View
        public ActionResult Form()
        {
            Customer customer = new Customer();
            customer.BirthDay = DateTime.Now;
            customer.Gender = "Nam";
            return View(customer);
        }
        //Submit
        [HttpPost]
        public ActionResult Form(Customer model)
        {
           
            return View(model);
        }
        
        // Hàm nhận form
        public ActionResult FormNhanObject(Data model)
        {
            return View(model);  
        }
    }
}