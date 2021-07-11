using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPhongTro.DAL;
using QLPhongTro.Models;

namespace QLPhongTro.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            var tam = new PhongDAL();
            var list = tam.FindAllPhongStatus();


            return View(list);
        }

        public ActionResult Book(int id)
        {
            var tam = new PhongDAL().FindPhongById(id);
            var temp = new KhachHangDAL().FindAllKhachHang();
            var tem = new NhanVienDAL().FindAllNhanVien();

            ViewBag.phong = tam.Id;
            ViewData["nhanVien"] = new SelectList(tem,"Id", "Ten");
            ViewData["khacHang"] = new SelectList(temp, "Id", "Ten");
            ViewBag.ngayDat = DateTime.Now;
            return View();
        }

        [HttpPost]
        public ActionResult Book(DatPhongModel datPhong)
        {
            try
            {
               // return RedirectToAction("Home", "Index");
                // TODO: Add insert logic here
                
                var dta = new DatPhongDAL();

                var tam = dta.DatPhong(datPhong);

                if (tam != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Insert Thất bại");
                }
                
                return View("Book");
            }
            catch
            {
                return View();
            }
        }
    }
}