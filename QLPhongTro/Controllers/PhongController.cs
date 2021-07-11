using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPhongTro.DAL;
using QLPhongTro.Models;
using QLPhongTro.DAL;

namespace QLPhongTro.Controllers
{
    public class PhongController : BaseController
    {
        // GET: Phong
        public ActionResult Phong()
        {
            var tam = new PhongDAL();
            var list = tam.FindAllPhong();

            //ViewBag.loaiPhong = list;

            return View(list);
        }

        // GET: Phong/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Phong/Create
        public ActionResult Create()
        {
            var dta = new LoaiPhongDAL();
            var tem = dta.FindAllLoaiPhong();

            ViewData["loaiPhong"] = new SelectList(tem, "Id", "Id");
            String[] tenLoaiP = { "Còn", "Hết Phòng" };
            ViewData["tenLoaiPhong"] = new SelectList(tenLoaiP);
            return View();
        }

        // POST: Phong/Create
        [HttpPost]
        public ActionResult Create(PhongModel phong)
        {
            try
            {
                var dta = new PhongDAL();

                var tam = dta.CreatePhong(phong);

               

                if (tam != null)
                {
                    return RedirectToAction("Phong", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Insert Thất bại");
                }

                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Phong/Edit/5
        public ActionResult Edit(int id)
        {
            var tam = new PhongDAL().FindPhongById(id);
            var dta = new LoaiPhongDAL();
            var tem = dta.FindAllLoaiPhong();
            ViewData["loaiPhong"] = new SelectList(tem, "Id", "Id",tam.LoaiPhong.Id);
            String[] tenLoaiP = { "Còn", "Hết Phòng" };
            ViewData["tenLoaiPhong"] = new SelectList(tenLoaiP, tam.TrangThai);

            return View(tam);
        }

        // POST: Phong/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PhongModel phong)
        {
            try
            {
                var dta = new PhongDAL();


                var tam = dta.UpdatePhong(phong, id);


                if (tam != null)
                {
                    return RedirectToAction("Phong", "Phong");
                }
                else
                {
                    ModelState.AddModelError("", "Update Thất bại");
                }
                //if (ModelState.IsValid)
                //{
                  
                //}
                return View("Edit");
            }
            catch
            {
                return View();
            }
        }

        // GET: Phong/Delete/5
        public ActionResult Delete(int id)
        {
            new PhongDAL().DeletePhong(id);
            return RedirectToAction("Phong");
        }

        // POST: Phong/Delete/5
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
