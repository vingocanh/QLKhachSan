using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLPhongTro.Common;
using QLPhongTro.DAL;
using QLPhongTro.Models;

namespace QLPhongTro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(NhanVienModel nhanVien)
        {
            if (ModelState.IsValid)
            {
                var resul = new NhanVienDAL().Login(nhanVien.TaiKhoan, MaHoa.MD5Hash(nhanVien.MatKhau));
                if (resul != null)
                {

                    var userSession = new AddSession();
                    userSession.UserName = resul.TaiKhoan;
                    userSession.UserID = resul.Id;
                    userSession.Name = resul.Ten;

                    Session.Add("USER_SESSION", userSession);
                    Session.Add("name", userSession.Name);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Login failed");
                }
            }


            return View("Login");
        }
    }
}