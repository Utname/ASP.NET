using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARB_ASPNET.App_Start;
using Data;
using Data.Entity;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class PhanQuyenController : Controller
    {
        // GET: Admin/PhanQuyen
      //  [RoleUser(MaChucNang = "PhanQuyen")]
        public ActionResult DanhSachTaiKhoan()
        {
            return View(new mapAccount().getListAll());
        }

        public ActionResult PhanQuyenChucNang(int idTaiKhoan)
        {
            return View(new mapAccount().Search(idTaiKhoan));
        }

        public ActionResult LuuPhanQuyen(int idTaiKhoan,string chucNang)
        {
            return View(new mapPhanQuyen().LuuPhanQuyen(idTaiKhoan, chucNang));
        }
    }
}