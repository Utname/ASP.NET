using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class mapDonHang
    {
        SuperMartketsEntities db =new SuperMartketsEntities();
        public string message = "";

        public List<spGetAllDonHangNew_Result> loadPageByStore(int? idCustomer,DateTime? date, int? Price)
        {
            return db.spGetAllDonHangNew(idCustomer,date, Price).ToList();
        }
    }
}
