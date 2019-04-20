using EkinciProject.Bll.Concrete;
using EkinciProject.Entity.Entities;
using EkinciProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EkinciProject.Web.Controllers
{
    public class ContactController : Controller
    {
        ContactService _contactService = new ContactService();
        VisitorService _visitorService = new VisitorService();
        public ActionResult Index()
        {
            Contact contact = _contactService.Get();
            VisitorService _visitorService = new VisitorService();

            ContactViewModel model = new ContactViewModel()
            {
                Address = contact.Address,
                Phone = contact.Phone,
                Mail = contact.Mail,
                MapUrl = contact.MapUrl
            };
            return View(model);
        }

        public ActionResult Message()
        {
            VisitorViewModel model = new VisitorViewModel();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Message(VisitorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Visitor visitor = new Visitor();

                visitor.FullName = model.FullName;
                visitor.Email = model.Email;
                visitor.Subject = model.Subject;
                visitor.Message = model.Message;
                visitor.SendTime = DateTime.Now;
                visitor.Readed = false;

                try
                {
                    _visitorService.Add(visitor);

                    ViewBag.Message = "Mesajınız başarıyla gönderildi.";
                    ViewBag.MessageType = "success";
                }
                catch (Exception)
                {
                    ViewBag.Message = "Mesajınız gönderilemedi. Bir hata oluştu.";
                    ViewBag.MessageType = "danger";
                }
            }
            else
            {
                ViewBag.Message = "Mesajınızı gönderebilmeniz için bütün alanları doldurmalısınız.";
                ViewBag.MessageType = "warning";
            }

            return PartialView();
        }
    }
}