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
    public class MostAskedController : Controller
    {
        MostAskedService _mostAskedService = new MostAskedService();
        public ActionResult MostAskedCreate()
        {
            MostAskedCreateViewModel model = new MostAskedCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult MostAskedCreate(MostAskedCreateViewModel model)
        {
            if (model.Answer != "" && model.Question != "")
            {

                MostAsked newMostAsked = new MostAsked();
                newMostAsked.Question = model.Question;
                newMostAsked.Answer = model.Answer;
                newMostAsked.Status = true;

                try
                {
                    _mostAskedService.Add(newMostAsked);

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

        public ActionResult MostAskedEditDeletePage()
        {
            List<MostAsked> MostAskedList = _mostAskedService.GetAll();

            MostAskedEditViewModel model = new MostAskedEditViewModel();
            model.MostAskedList = MostAskedList.OrderByDescending(x => x.Status).ThenByDescending(x=>x.Id).ToList();

            return View(model);
        }

        public ActionResult MostAskedEdit(int Id)
        {
            MostAsked MostAsked = _mostAskedService.Get(x => x.Id == Id);

            MostAskedEditViewModel model = new MostAskedEditViewModel()
            {
                Id = Id,
                Question = MostAsked.Question,
                Answer = MostAsked.Answer,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult MostAskedEdit(MostAskedEditViewModel model)
        {
            if (model.Question != "" && model.Answer != "")
            {

                MostAsked MostAsked = _mostAskedService.Get(x => x.Id == model.Id);

                MostAsked.Question = model.Question;
                MostAsked.Answer = model.Answer;
                MostAsked.Status = true;

                try
                {
                    _mostAskedService.Update(MostAsked);
                    return RedirectToAction("MostAskedEditDeletePage");
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

        public ActionResult MostAskedDelete(int Id)
        {
            MostAsked MostAsked = _mostAskedService.Get(x => x.Id == Id);
            MostAsked.Status = false;
            _mostAskedService.Update(MostAsked);

            return RedirectToAction("MostAskedEditDeletePage");
        }
    }
}