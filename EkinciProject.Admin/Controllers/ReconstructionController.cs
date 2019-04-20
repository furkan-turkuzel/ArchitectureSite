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
    public class ReconstructionController : Controller
    {
        ReconstructionService _reconstructionService = new ReconstructionService();
        public ActionResult ReconstructionCreate()
        {
            ReconstructionCreateViewModel model = new ReconstructionCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult ReconstructionCreate(ReconstructionCreateViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Reconstruction newReconstruction = new Reconstruction();
                newReconstruction.Title = model.Title;
                newReconstruction.Writing = model.Writing;
                newReconstruction.ImageUrl = "~/Content/images/" + fileName;
                newReconstruction.Status = true;

                try
                {
                    _reconstructionService.Add(newReconstruction);

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

        public ActionResult ReconstructionEditDeletePage()
        {
            List<Reconstruction> ReconstructionList = _reconstructionService.GetAll();

            ReconstructionEditViewModel model = new ReconstructionEditViewModel();
            model.ReconstructionList = ReconstructionList.OrderByDescending(x=>x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult ReconstructionEdit(int Id)
        {
            Reconstruction Reconstruction = _reconstructionService.Get(x => x.Id == Id);

            ReconstructionEditViewModel model = new ReconstructionEditViewModel()
            {
                Id = Id,
                Title = Reconstruction.Title,
                Writing = Reconstruction.Writing,
                ImageUrl = Reconstruction.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ReconstructionEdit(ReconstructionEditViewModel model)
        {
            if (model.Title != "" && model.Writing != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Reconstruction Reconstruction = _reconstructionService.Get(x => x.Id == model.Id);

                Reconstruction.Title = model.Title;
                Reconstruction.Writing = model.Writing;
                Reconstruction.ImageUrl = "~/Content/images/" + fileName;
                Reconstruction.Status = true;

                try
                {
                    _reconstructionService.Update(Reconstruction);
                    return RedirectToAction("ReconstructionEditDeletePage");
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

        public ActionResult ReconstructionDelete(int Id)
        {
            Reconstruction Reconstruction = _reconstructionService.Get(x => x.Id == Id);
            Reconstruction.Status = false;
            _reconstructionService.Update(Reconstruction);

            return RedirectToAction("ReconstructionEditDeletePage");
        }
    }
}