using EkinciProject.Admin.Models;
using EkinciProject.Bll.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EkinciProject.Admin.Controllers
{
    public class SecurityController : Controller
    {
        AdminService _adminService = new AdminService();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = _adminService.Get(x => x.UserName == model.UserName && x.Password == model.Password);

                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(admin.UserName, false);
                    return RedirectToAction("Index","Panel");
                }
                else
                {
                    ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                }
            }
            else
            {
                ViewBag.Message = "Lütfen bütün alanları doldurunuz";
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Setting()
        {
            return View();
        }
    }
}