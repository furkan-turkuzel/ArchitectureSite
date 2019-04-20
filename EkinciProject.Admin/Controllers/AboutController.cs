using EkinciProject.Admin.Models;
using EkinciProject.Bll.Concrete;
using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EkinciProject.Admin.Controllers
{
    [Authorize]
    public class AboutController : Controller
    {
        AboutService _aboutService = new AboutService();
        public ActionResult AboutCreate()
        {
            AboutCreateViewModel model = new AboutCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult AboutCreate(AboutCreateViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);
                
                About newAbout = new About();
                newAbout.Title = model.Title;
                newAbout.Writing = model.Writing;
                newAbout.ImageUrl = "~/Content/images/" + fileName;
                newAbout.Status = true;

                try
                {
                    _aboutService.Add(newAbout);

                    ViewBag.Message = "Oluşturma işlemi başarılı.";
                    ViewBag.MessageType = "success";
                }
                catch (Exception)
                {
                    ViewBag.Message = "Oluşturma işlemi sırasında hata oluştu.";
                    ViewBag.MessageType = "danger";
                }

            }
            else
            {
                ViewBag.Message = "Lütfen bütün alanları doldurunuz!";
                ViewBag.MessageType = "warning";
            }

            return View();
        }

        public ActionResult AboutEditDeletePage()
        {
            List<About> aboutList = _aboutService.GetAll();

            AboutEditViewModel model = new AboutEditViewModel();
            model.AboutList = aboutList.OrderByDescending(x=>x.Status).ThenByDescending(x=>x.Id).ToList();

            return View(model);
        }

        public ActionResult AboutEdit(int Id)
        {
            About about = _aboutService.Get(x => x.Id == Id);

            AboutEditViewModel model = new AboutEditViewModel()
            {
                Id = Id,
                Title = about.Title,
                Writing = about.Writing,
                ImageUrl = about.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AboutEdit(AboutEditViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                About about = _aboutService.Get(x => x.Id == model.Id);

                about.Title = model.Title;
                about.Writing = model.Writing;
                about.ImageUrl = "~/Content/images/" + fileName;
                about.Status = true;

                try
                {
                    _aboutService.Update(about);
                    return RedirectToAction("AboutEditDeletePage");
                }
                catch (Exception)
                {
                    ViewBag.Message = "Düzenleme işlemi sırasında hata oluştu.";
                    ViewBag.MessageType = "danger";

                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Lütfen bütün alanları doldurunuz!";
                ViewBag.MessageType = "warning";

                return View();
            }
        }

        public ActionResult AboutDelete(int Id)
        {
            About about = _aboutService.Get(x => x.Id == Id);
            about.Status = false;
            _aboutService.Update(about);

            return RedirectToAction("AboutEditDeletePage");
        }
    }
}