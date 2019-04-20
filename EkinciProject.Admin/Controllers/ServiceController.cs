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
    public class ServiceController : Controller
    {
        ServiceService _serviceService = new ServiceService();

        public ActionResult ServiceCreate()
        {
            ServiceCreateViewModel model = new ServiceCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult ServiceCreate(ServiceCreateViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Service newService = new Service();
                newService.Title = model.Title;
                newService.Writing = model.Writing;
                newService.ImageUrl = "~/Content/images/" + fileName;
                newService.Status = true;

                try
                {
                    _serviceService.Add(newService);

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

        public ActionResult ServiceEditDeletePage()
        {
            List<Service> ServiceList = _serviceService.GetAll();

            ServiceEditViewModel model = new ServiceEditViewModel();
            model.ServiceList = ServiceList.OrderByDescending(x => x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult ServiceEdit(int Id)
        {
            Service Service = _serviceService.Get(x => x.Id == Id);

            ServiceEditViewModel model = new ServiceEditViewModel()
            {
                Id = Id,
                Title = Service.Title,
                Writing = Service.Writing,
                ImageUrl = Service.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ServiceEdit(ServiceEditViewModel model)
        {
            if (model.Title != "" && model.Writing != "")
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Service Service = _serviceService.Get(x => x.Id == model.Id);

                Service.Title = model.Title;
                Service.Writing = model.Writing;
                Service.ImageUrl = "~/Content/images/" + fileName;
                Service.Status = true;

                try
                {
                    _serviceService.Update(Service);
                    return RedirectToAction("ServiceEditDeletePage");
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

        public ActionResult ServiceDelete(int Id)
        {
            Service Service = _serviceService.Get(x => x.Id == Id);
            Service.Status = false;
            _serviceService.Update(Service);

            return RedirectToAction("ServiceEditDeletePage");
        }
    }
}