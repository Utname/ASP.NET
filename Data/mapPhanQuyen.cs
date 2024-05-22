using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class mapPhanQuyen
    {
        SuperMartketsEntities db = new SuperMartketsEntities();
        public string message = "";

        public bool KiemTra(int idTaiKhoan,string MaChucNang)
        {
            var check = db.PhanQuyens.Where(q => q.idTaiKhoan == idTaiKhoan).Where(q => q.MaChucNang == MaChucNang).Count() > 0;
            return check;
        }

        public bool LuuPhanQuyen(int idTaiKhoan,string chucNang)
        {
            var role = db.PhanQuyens.Where(q => q.idTaiKhoan == idTaiKhoan).Where(q => q.MaChucNang == chucNang).SingleOrDefault();
            if(role != null)
            {
                db.PhanQuyens.Remove(role);
                db.SaveChanges();
                return true;
            }
            else
            {
               var role2 = new PhanQuyen();
                role2.idTaiKhoan = idTaiKhoan;
                role2.MaChucNang = chucNang;
                db.PhanQuyens.Add(role2);   
                db.SaveChanges();
                return true;
                    
            }

        }

        public List<ChucNang> DanhSachChucNang()
        {
            return db.ChucNangs.ToList();
        }
    }
}
