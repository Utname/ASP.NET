using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
namespace Data
{
    
    public  class mapAccount
    {
        SuperMartketsEntities db = new SuperMartketsEntities();
        public Account Search(string username,string password)
        {
            var user = db.Accounts.Where(q=>q.Username == username  & q.Password == password).ToList();
            if(user.Count() > 0) return user[0];
            else return null;
        }
    }
}
