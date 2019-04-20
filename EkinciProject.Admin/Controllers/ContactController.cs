using EkinciProject.Admin.Models;
using EkinciProject.Bll.Concrete;
using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EkinciProject.Admin.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        ContactService _contactService = new ContactService();
        public ActionResult Contact()
        {
            Contact contact = _contactService.Get();

            ContactViewModel model = new ContactViewModel()
            {
                Phone = contact.Phone,
                Mail = contact.Mail,
                Address = contact.Address,
                MapUrl = contact.MapUrl,
                Facebook = contact.Facebook,
                Twitter = contact.Twitter,
                Instagram = contact.Instagram,
                Youtube = contact.Youtube,
                Linkedin = contact.Linkedin
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            if (model.Phone != "" && model.Mail != "" && model.Address != "")
            {
                Contact contact = _contactService.Get();
                contact.Phone = model.Phone;
                contact.Mail = model.Mail;
                contact.Address = model.Address;
                contact.MapUrl = model.MapUrl;
                contact.Facebook = model.Facebook;
                contact.Twitter = model.Twitter;
                contact.Instagram = model.Instagram;
                contact.Youtube = model.Youtube;
                contact.Linkedin = model.Linkedin;

                try
                {
                    _contactService.Update(contact);

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
    }
}