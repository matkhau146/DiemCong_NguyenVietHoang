using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_NguyenVietHoang.Models;

namespace DiemCong_NguyenVietHoang.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_sinhvien = from tt in data.SinhViens select tt;
            return View(all_sinhvien);
        }

        // Detail
        public ActionResult Detail(int id)
        {
            var D_Sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_Sinhvien);
        }
        
        //Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var ten = collection["HoTen"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Dont empty!";
            }
            else
            {
                sv.HoTen = ten;
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
    }
}