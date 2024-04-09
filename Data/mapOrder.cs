using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class mapOrder
    {
        SuperMartketsEntities db =new SuperMartketsEntities();
        public string message = "";
        /// <summary>
        /// Get All List Order
        /// </summary>
        public List<Order> getListAll()
        {
            return db.Orders.ToList();
        }

        /// <summary>
        /// Get List From Page
        /// </summary>
        public List<Order> getListPage(int page,int size)
        {
            try
            {
                return db.Orders.ToList().Skip((page - 1) * size).Take(size).ToList();
            }
            catch { return new List<Order>(); }
        }

        /// <summary>
        /// Inser Order
        /// </summary>
        public int Insert(Order model)
        {
            try
            {
                db.Orders.Add(model);
                db.SaveChanges();
                return model.Id;
            }
            catch  { return 0;}
        }

        /// <summary>
        /// Update Order
        /// </summary>
        public int Update(Order model)
        {
            try
            {
                var order = db.Orders.FirstOrDefault(q => q.Id == model.Id);
                order.FeeShip = model.FeeShip;
                order.TotalProductCost = model.TotalProductCost;
                order.Address = model.Address;
                order.idCustomer = model.idCustomer;
                order.Discount = model.Discount;
                order.InfoProduct = model.InfoProduct;
                model.OrderDate = order.OrderDate;
                model.Paid = order.Paid;
                model.Phone = order.Phone;
                db.SaveChanges();
                return model.Id;
            }
            catch { return 0;}
        }

        /// <summary>
        /// Update Order
        /// </summary>
        public bool Update2(Order model)
        {
            var order = db.Orders.Find(model.Id);
            if(order == null)
            {
                message = "Not find to order";
                return false;
            }
            order.FeeShip = model.FeeShip;
            order.TotalProductCost = model.TotalProductCost;
            order.Address = model.Address;
            order.idCustomer = model.idCustomer;
            order.Discount = model.Discount;
            order.InfoProduct = model.InfoProduct;
            model.OrderDate = order.OrderDate;
            model.Paid = order.Paid;
            model.Phone = order.Phone;
            db.SaveChanges();
            return true;
        }


        /// <summary>
        /// Delete Order
        /// </summary>

        public int Delete(int id) {
            try
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
                return id;
            }
            catch { return 0;}
        }

        //Details Order
        public Order Details(int id)
        {
            return db.Orders.Find(id);
        }

    }
}
