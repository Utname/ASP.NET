using Data;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        mapTinTuc map = new mapTinTuc();
        // GET: Admin/TinTuc
        public ActionResult getAllList()
        {
            return View(map.loadPageByStore(null,null,1,20));
        }

        //Trả về view thêm mới
        public ActionResult Insert()
        {
            return View(new TinTuc() { ThoiGianViet = DateTime.Now, TrangThai = 1 });
        }
        //Nhận và thêm dữ liệu
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(TinTuc model, HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                List<string> exts = new List<string>() { ".jpeg", ".png", ".gif" };
                string ten = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                string ext = Path.GetExtension(fileUpload.FileName);
                if (fileUpload.ContentLength > 0 & exts.Count(m => m == ext.ToLower()) > 0)
                {
                    //Lưu
                    //--Thêm thư mục con teho năm-tháng-ngày
                    string folderThoiGian = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    //1.Xác định thư mục lưu
                    string folder = "/File/" + folderThoiGian + "/";
                    if (System.IO.File.Exists(Server.MapPath(folder)) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(folder));
                    }
                    //Tính kilobyte
                    var kb = fileUpload.ContentLength / 1024;
                    var mb = (float)kb / 1024;
                    //2.Xác định tên file
                    string tenFile = fileUpload.FileName;
                    //3.Xác định đường dẫn tuyệt đối của file
                    string ddTuyetDoi = Server.MapPath(folder + tenFile);
                    //4.Kiểm tra tồn tại => Có tồn tại file cũ thì xóa
                    //if(System.IO.File.Exists(ddTuyetDoi) == true)
                    //{
                    //    System.IO.File.Delete(ddTuyetDoi);
                    //}
                    //5.Trùng tên file
                    int i = 0;
                    string duongDanLuuFile = folder + tenFile;
                    while (System.IO.File.Exists(ddTuyetDoi) == true)
                    {
                        i++;

                        tenFile = ten + "_" + i + ext;
                        ddTuyetDoi = Server.MapPath(folder + tenFile);
                    }
                    fileUpload.SaveAs(ddTuyetDoi);
                    model.HinhAnh = duongDanLuuFile;
                }
            }
            if (map.Insert(model) == 1)
            {
                return View("getAllList");
            }
            else
            {
                ModelState.AddModelError("", "Dữ liệu chưa đúng, vui lòng kiểm tra lại");
                return View(model);
            }
        }
        
        //Thông tin chi tiết trang chỉnh sửa
        public ActionResult Edit(int id)
        {
            return View(map.Details(id));
        }

        //Lưa và cập nhật thông tin tin tưc
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(TinTuc model,HttpPostedFileBase fileUpload)
        {
            if (fileUpload != null)
            {
                List<string> exts = new List<string>() { ".jpeg", ".png", ".gif" };
                string ten = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                string ext = Path.GetExtension(fileUpload.FileName);
                if (fileUpload.ContentLength > 0 & exts.Count(m => m == ext.ToLower()) > 0)
                {
                    //Lưu
                    //--Thêm thư mục con teho năm-tháng-ngày
                    string folderThoiGian = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    //1.Xác định thư mục lưu
                    string folder = "/File/" + folderThoiGian + "/";
                    if (System.IO.File.Exists(Server.MapPath(folder)) == false)
                    {
                        System.IO.Directory.CreateDirectory(Server.MapPath(folder));
                    }
                    //Tính kilobyte
                    var kb = fileUpload.ContentLength / 1024;
                    var mb = (float)kb / 1024;
                    //2.Xác định tên file
                    string tenFile = fileUpload.FileName;
                    //3.Xác định đường dẫn tuyệt đối của file
                    string ddTuyetDoi = Server.MapPath(folder + tenFile);
                    //4.Kiểm tra tồn tại => Có tồn tại file cũ thì xóa
                    //if(System.IO.File.Exists(ddTuyetDoi) == true)
                    //{
                    //    System.IO.File.Delete(ddTuyetDoi);
                    //}
                    //5.Trùng tên file
                    int i = 0;
                    string duongDanLuuFile = folder + tenFile;
                    while (System.IO.File.Exists(ddTuyetDoi) == true)
                    {
                        i++;

                        tenFile = ten + "_" + i + ext;
                        ddTuyetDoi = Server.MapPath(folder + tenFile);
                    }
                    fileUpload.SaveAs(ddTuyetDoi);
                    model.HinhAnh = duongDanLuuFile;
                }
            }
            if (map.Update(model) == 1)
            {
                return View("getAllList");
            }
            else
            {
                ModelState.AddModelError("", "Dữ liệu chưa đúng,vui lòng kiểm tra lại");
                return View(model);
            }
        }
       
        public ActionResult Delete(int id)
        {
            if(map.Delete(id) != 0) return View("getAllList");
            else
            {
                ModelState.AddModelError("", "Không tìm thấy tin tức,Vui lòng thử lại");
                return View("getAllList");
            }
        }
    }
}