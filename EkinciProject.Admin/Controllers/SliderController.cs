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
    public class SliderController : Controller
    {
        SlidersService _sliderService = new SlidersService();

        public ActionResult SlidersCreate()
        {
            SlidersCreateViewModel model = new SlidersCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult SlidersCreate(SlidersCreateViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Sliders newSliders = new Sliders();
                newSliders.Title = model.Title;
                newSliders.Writing = model.Writing;
                newSliders.ImageUrl = "~/Content/images/" + fileName;
                newSliders.Status = true;

                try
                {
                    _sliderService.Add(newSliders);

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

        public ActionResult SlidersEditDeletePage()
        {
            List<Sliders> SlidersList = _sliderService.GetAll();

            SlidersEditViewModel model = new SlidersEditViewModel();
            model.SlidersList = SlidersList.OrderByDescending(x => x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult SlidersEdit(int Id)
        {
            Sliders Sliders = _sliderService.Get(x => x.Id == Id);

            SlidersEditViewModel model = new SlidersEditViewModel()
            {
                Id = Id,
                Title = Sliders.Title,
                Writing = Sliders.Writing,
                ImageUrl = Sliders.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SlidersEdit(SlidersEditViewModel model)
        {
            if (model.Title != "" && model.Writing != "")
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Sliders Sliders = _sliderService.Get(x => x.Id == model.Id);

                Sliders.Title = model.Title;
                Sliders.Writing = model.Writing;
                Sliders.ImageUrl = "~/Content/images/" + fileName;
                Sliders.Status = true;

                try
                {
                    _sliderService.Update(Sliders);
                    return RedirectToAction("SlidersEditDeletePage");
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

        public ActionResult SlidersDelete(int Id)
        {
            Sliders Sliders = _sliderService.Get(x => x.Id == Id);
            Sliders.Status = false;
            _sliderService.Update(Sliders);

            return RedirectToAction("SlidersEditDeletePage");
        }
    }
}