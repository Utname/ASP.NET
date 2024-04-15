using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entity;

namespace Data
{
    public class mapTinTuc
    {
        SuperMartketsEntities db = new SuperMartketsEntities();
        public string message = "";

        public List<spGetAllTinTuc_Result> loadPageByStore(string TieuDe,DateTime? ThoiGianViet,int page, int size)
        {
            return db.spGetAllTinTuc(TieuDe, ThoiGianViet, page, size).ToList();
        }

        //Thêm tin tức
        public int Insert(TinTuc model)
        {
            try
            {
                db.TinTucs.Add(model);
                db.SaveChanges();
                return 1;
            }
            catch{ return 0; }
        }

        //Cập nhật tin tức
        public int Update(TinTuc model)
        {
            var tin_tuc = db.TinTucs.Find(model.ID);
            if (tin_tuc == null) return 0;
            tin_tuc.TieuDe = model.TieuDe;
            tin_tuc.ThoiGianViet = model.ThoiGianViet;
            tin_tuc.TomTat = model.TomTat;
            tin_tuc.NoiDung = model.NoiDung;
            tin_tuc.TrangThai = model.TrangThai;
            tin_tuc.TacGia = model.TacGia;
            tin_tuc.HinhAnh = model.HinhAnh;
            db.SaveChanges();
            return 1;
        }

        //Lấy chi tiết tin tức
        public TinTuc Details(int id)
        {
            return db.TinTucs.Find(id);
        }

        //Xóa 1 tin tức
        public int Delete(int id)
        {
            try {
                var tin_tuc = db.TinTucs.Find(id);
                db.TinTucs.Remove(tin_tuc);
                db.SaveChanges();
                return 1;
            
            } catch {return 0;}
        }
    }
}
