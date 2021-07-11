using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPhongTro.DAL;
using QLPhongTro.Models;

namespace QLPhongTro.Controllers
{
    public class KhachHangController : BaseController
    {
        // GET: KhachHang
        public ActionResult KhachHang()
        {
            var tam = new KhachHangDAL();
            var list = tam.FindAllKhachHang();
            return View(list);
        }

        // GET: KhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        [HttpPost]
        public ActionResult Create(KhachHangModel khachHang)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var dta = new KhachHangDAL();
        
                    var tam = dta.CreateKhachHang(khachHang);

                    if (tam != null)
                    {
                        return RedirectToAction("KhachHang", "KhachHang");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Insert Thất bại");
                    }
                }
                return View("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            var tam = new KhachHangDAL().FindKhachHangById(id);
            return View(tam);
        }

        // POST: KhachHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KhachHangModel khachHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dta = new KhachHangDAL();
                  

                    var tam = dta.UpdateKhachHang(khachHang, id);


                    if (tam != null)
                    {
                        return RedirectToAction("KhachHang", "KhachHang");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Update Thất bại");
                    }
                }
                return View("Edit");

               
            }
            catch
            {
                return View();
            }
        }

        // GET: KhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            new KhachHangDAL().DeleteKhachHang(id);
            return RedirectToAction("KhachHang"); 
        }

        // POST: KhachHang/Delete/5
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
