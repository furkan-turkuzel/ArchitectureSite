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
    public class NewsController : Controller
    {
        NewsService _newsService = new NewsService();
        AdminService _adminService = new AdminService();
        public ActionResult NewsCreate()
        {
            NewsCreateViewModel model = new NewsCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult NewsCreate(NewsCreateViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                EkinciProject.Entity.Entities.Admin admin = _adminService.Get(x => x.UserName == HttpContext.User.Identity.Name);

                News newNews = new News();
                newNews.Title = model.Title;
                newNews.Writing = model.Writing;
                newNews.ImageUrl = "~/Content/images/" + fileName;
                newNews.NewsDate = DateTime.Now;
                newNews.AdminId = admin.Id;
                newNews.Admin = admin;
                newNews.Status = true;

                try
                {
                    _newsService.Add(newNews);

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

        public ActionResult NewsEditDeletePage()
        {
            List<News> NewsList = _newsService.GetAll();

            NewsEditViewModel model = new NewsEditViewModel();
            model.NewsList = NewsList.OrderByDescending(x => x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult NewsEdit(int Id)
        {
            News News = _newsService.Get(x => x.Id == Id);

            NewsEditViewModel model = new NewsEditViewModel()
            {
                Id = Id,
                Title = News.Title,
                Writing = News.Writing,
                ImageUrl = News.ImageUrl,
                NewsDate = News.NewsDate,
                AdminId = News.AdminId
                
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult NewsEdit(NewsEditViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                EkinciProject.Entity.Entities.Admin admin = _adminService.Get(x => x.UserName == HttpContext.User.Identity.Name);

                News News = _newsService.Get(x => x.Id == model.Id);

                News.Title = model.Title;
                News.Writing = model.Writing;
                News.ImageUrl = "~/Content/images/" + fileName;
                News.Status = true;

                try
                {
                    _newsService.Update(News);
                    return RedirectToAction("NewsEditDeletePage");
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

        public ActionResult NewsDelete(int Id)
        {
            News News = _newsService.Get(x => x.Id == Id);
            News.Status = false;
            _newsService.Update(News);

            return RedirectToAction("NewsEditDeletePage");
        }
    }
}