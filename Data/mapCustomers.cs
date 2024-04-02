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
        public List<Customer> getAllCustomer()
        {
            return db.Customers.ToList();
        }

        public List<Customer> getPageListCustomer(int page,int size)
        {
            return db.Customers.ToList().Skip((page-1)*size).Take(size).ToList();
        }

        public Customer getDetailCustomer(int id)
        {
            return db.Customers.Find(id);
        }
    }
}
