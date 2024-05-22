using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
namespace Data
{

    public class mapAccount
    {
        SuperMartketsEntities db = new SuperMartketsEntities();

        //Search Account    
        public Account Search(string username, string password)
        {
            var user = db.Accounts.Where(q => q.Username == username & q.Password == password).ToList();
            if (user.Count() > 0) return user[0];
            else return null;
        }
        public Account Search(int id)
        {
            var user = db.Accounts.Find(id);
            return user;
        }

        //Get all list account
        public List<Account> getListAll()
        {
            return db.Accounts.ToList();
        }

        /// <summary>
        /// Insert Account user cách 1
        /// </summary> 
        #region
        public void Insert(string avatar, string username, string phone, string password)
        {
            // Khởi tạo đối tượng và gán giá trị cho đổi tượng
            Account user = new Account();
            user.Avatar = avatar;
            user.Username = username;
            user.Password = password;
            user.Phone = phone;
            //Save account
            db.Accounts.Add(user);
            db.SaveChanges();
        }
        #endregion

        /// <summary>
        /// Insert Account user cách 2
        /// </summary> 
        #region
        public bool Insert(Account user)
        {
            try
            {
                //Save account
                db.Accounts.Add(user);
                db.SaveChanges();
                return true;
            }
            catch{ return false; }
        }
        #endregion

    }
}
