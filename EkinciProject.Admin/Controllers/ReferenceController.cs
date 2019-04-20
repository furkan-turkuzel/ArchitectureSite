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
    public class ReferenceController : Controller
    {
        ReferenceService _referenceService = new ReferenceService();
        public ActionResult ReferenceCreate()
        {
            ReferenceCreateViewModel model = new ReferenceCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult ReferenceCreate(ReferenceCreateViewModel model)
        {
            if (model.ReferanceType != "" && model.ReferanceName != "" && model.ReferancePhone != "" && model.ReferanceAddress != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                var a = model.ReferancePhone.Length;

                Reference newReference = new Reference();
                newReference.ReferanceType = model.ReferanceType;
                newReference.ReferanceName = model.ReferanceName;
                newReference.ReferancePhone = model.ReferancePhone;
                newReference.ReferanceAddress = model.ReferanceAddress;
                newReference.Description = model.Description;
                newReference.ReferanceLogo = "~/Content/images/" + fileName;
                newReference.Status = true;

                try
                {
                    _referenceService.Add(newReference);

                    ViewBag.Message = "Oluşturma işlemi başarılı.";
                    ViewBag.MessageType = "success";
                }
                catch (Exception ex)
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

        public ActionResult ReferenceEditDeletePage()
        {
            List<Reference> ReferenceList = _referenceService.GetAll();

            ReferenceEditViewModel model = new ReferenceEditViewModel();
            model.ReferenceList = ReferenceList.OrderByDescending(x => x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult ReferenceEdit(int Id)
        {
            Reference Reference = _referenceService.Get(x => x.Id == Id);

            ReferenceEditViewModel model = new ReferenceEditViewModel()
            {
                Id = Id,
                ReferanceType = Reference.ReferanceType,
                ReferanceName = Reference.ReferanceName,
                ReferancePhone = Reference.ReferancePhone,
                ReferanceAddress = Reference.ReferanceAddress,
                Description = Reference.Description,
                ReferanceLogo = Reference.ReferanceLogo
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult ReferenceEdit(ReferenceEditViewModel model)
        {
            if (model.ReferanceType != "" && model.ReferanceName != "" && model.ReferancePhone != "" && model.ReferanceAddress != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Reference Reference = _referenceService.Get(x => x.Id == model.Id);

                Reference.ReferanceType = model.ReferanceType;
                Reference.ReferanceName = model.ReferanceName;
                Reference.ReferancePhone = model.ReferancePhone;
                Reference.ReferanceAddress = model.ReferanceAddress;
                Reference.Description = model.Description;
                Reference.ReferanceLogo = "~/Content/images/" + fileName;
                Reference.Status = true;

                try
                {
                    _referenceService.Update(Reference);
                    return RedirectToAction("ReferenceEditDeletePage");
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

        public ActionResult ReferenceDelete(int Id)
        {
            Reference Reference = _referenceService.Get(x => x.Id == Id);
            Reference.Status = false;
            _referenceService.Update(Reference);

            return RedirectToAction("ReferenceEditDeletePage");
        }
    }
}