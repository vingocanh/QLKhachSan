using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPhongTro.DAL;
using QLPhongTro.Models;

namespace QLPhongTro.Controllers
{
    public class DatPhongController : BaseController
    {
        // GET: DatPhong
        public ActionResult DatPhong()
        {
            var tam = new DatPhongDAL();
            var list = tam.FindAllHoaDonDatPhong();
            return View(list);
        }

        // GET: DatPhong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DatPhong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DatPhong/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DatPhong/Edit/5
        public ActionResult traPhong(int id)
        {
            var tam = new DatPhongDAL().FindHoaDonDatPhongById(id);
            ViewBag.idP = tam.Phong.Id;
            ViewBag.idD = tam.Id;
            ViewBag.idHA = tam.NhanVien.Id;
            ViewBag.tenPhong = tam.Phong.TenPhong;
            ViewBag.ngayDat = tam.NgayDat;
            ViewBag.ngayTra = DateTime.Now;
            long soTien = 0;
            double soNgay = ((DateTime.Now - tam.NgayDat).Value.TotalDays);
            if (soNgay <= 1)
            {
                soTien += tam.Phong.LoaiPhong.GiaTien;
            }
            else
            {
                soTien += tam.Phong.LoaiPhong.GiaTien * (int)Math.Round(soNgay, 1);
            }
           
           
            ViewBag.tien = soTien;
            return View();
        }

        // POST: DatPhong/Edit/5
        [HttpPost]
        public ActionResult traPhong(TraPhongModel traPhong)
        {
            try
            {
                var dta = new TraPhongDAL();

                var tam = dta.TraPhong(traPhong);

                if (tam != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Trả Phòng Thất bại");
                }

                return View("traPhong");

               
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: DatPhong/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DatPhong/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
