using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Entity;
using System.IO;

namespace ARB_ASPNET.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Admin/Customers
        public ActionResult getAllList()
        {
            var map = new mapCustomers();
            return View(map.loadPageByStore(null,1,20));
        }
        public ActionResult Insert()
        {
            return View(new Customer() { Birthday = DateTime.Now, Money = 0});
        }

        [HttpPost]
        public ActionResult Insert(Customer model)
        {
            var map = new mapCustomers();
            var id = map.Insert(model);
            if (id > 0) return RedirectToAction("getAllList");
            else
            {
                ModelState.AddModelError("", "Add data error,please check data again!");
                return View(model);
            }
        }


        public ActionResult Edit(int id)
        {
            var map = new mapCustomers();
            return View(map.Details(id));
        }
        [HttpPost]

        public ActionResult Edit(Customer model, HttpPostedFileBase fileUpload)
        {
            //1.Kiểm tra tồn tại: người dùng có đưa file lên không (null,length)
            if(fileUpload != null)
            {
                List<string> exts = new List<string>() { ".jpeg", ".png", ".gif" };
                string ten = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                string  ext = Path.GetExtension(fileUpload.FileName);
                if (fileUpload.ContentLength > 0 & exts.Count(m => m == ext.ToLower()) > 0)
                {
                    //Lưu
                    //--Thêm thư mục con teho năm-tháng-ngày
                    string folderThoiGian = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                    //1.Xác định thư mục lưu
                    string folder = "/File/" + folderThoiGian + "/";
                    if(System.IO.File.Exists(Server.MapPath(folder)) == false)
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
                    model.Avatar = duongDanLuuFile;

                }
            }

            var map = new mapCustomers();
            if (map.Update(model) == true) return RedirectToAction("getAllList");
            else return View(model);
            return View(new mapCustomers().Details(model.Id));
        }
    }
}