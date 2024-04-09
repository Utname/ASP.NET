using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
    public class mapAddress
    {
        SuperMartketsEntities db = new SuperMartketsEntities();
        public List<Address> getAllAddress()
        {
            return db.Addresses.ToList();
        }

    }
}
