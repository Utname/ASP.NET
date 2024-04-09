using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
namespace Data
{
    public class mapCustomers
    {
        SuperMartketsEntities db = new SuperMartketsEntities();
        public string message = "";

        public List<Customer> getAllCustomer()
        {
            return db.Customers.ToList();
        }

        public List<Customer> getPageListCustomer(int page, int size)
        {
            return db.Customers.ToList().Skip((page - 1) * size).Take(size).ToList();
        }

        public List<spGetAllProduct_Result> loadPageByStore(int? namSinh,int page, int size)
        {
            return db.spGetAllProduct(namSinh, page, size).ToList();
        }

        public Customer getDetailCustomer(int id)
        {
            return db.Customers.Find(id);
        }
        
        /// <summary>
        /// Add Customer new
        /// </summary>
        public int Insert(Customer model)
        {
            try
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return model.Id;
            }
            catch { return 0;}
           
        }

        //Get details customer
        public Customer Details(int id)
        {
            return db.Customers.Find(id);
        }


        public bool Update(Customer model)
        {
            var customer = db.Customers.Find(model.Id);
            if (customer == null)
            {
                message = "Not find to customer";
                return false;
            }
            customer.Name = model.Name;
            customer.Birthday = model.Birthday;
            customer.idAddress = model.idAddress;
            customer.Phone = model.Phone;
            customer.Year = model.Year;
            customer.Money = model.Money;
            customer.Active = model.Active;
            customer.Avatar = model.Avatar;
            db.SaveChanges();
            return true;
        }
    }
}
