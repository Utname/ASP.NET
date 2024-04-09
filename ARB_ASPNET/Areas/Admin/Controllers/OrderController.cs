using Data;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order

        //Get List Order
        public ActionResult getAllList()
        {
            var map = new mapOrder();
            var data = map.getListPage(1, 100).OrderByDescending(q => q.Id);
            return View(data);
        }

        //View Inser Order
        public ActionResult Insert()
        {
            return View(new Order() { OrderDate = DateTime.Now,TotalPay = 0,TotalProductCost = 0,Paid = 0,FeeShip = 0});
        }

        //Inser order
        [HttpPost]
        public ActionResult Insert(Order order)
        {
            var map = new mapOrder();
            if (map.Insert(order) > 0) return Redirect("getAllList");
            else
            {
                ModelState.AddModelError("", "Add data error,please check data again!");
                return View(order);
            }

        }

        //View Edit Order
        public ActionResult Edit(Order order)
        {
            return View(order);
        }

        //Update Order
        [HttpPost]
        public ActionResult Edit(Order order,string id)
        {
            var map = new mapOrder();
            if (map.Update(order) > 0) return RedirectToAction("getAllList");
            else
            {
                ModelState.AddModelError("", "Edit to field, Please check data again!");
                return View(order);
            }
            return View(order);
        }

        //View Update Order C2
        public ActionResult Update(int id)
        {
            var map = new mapOrder();
            var order = map.Details(id);
            return View(order);
        }

        //Update Order C2
        [HttpPost]
        public ActionResult Update(Order order)
        {
            var map = new mapOrder();
            if (map.Update2(order) == true) return RedirectToAction("getAllList");
            else
            {
                ModelState.AddModelError("", "Edit to field, Please check data again!");
                return View(order);
            }
        }
        //Delete Order
        public ActionResult Delete(int id)
        {
            var map = new mapOrder();
            map.Delete(id);
            return RedirectToAction("getAllList");
        }

     

    }
}