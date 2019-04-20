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
    public class IndexController : Controller
    {
        ContactService _contactService = new ContactService();
        AboutService _aboutService = new AboutService();
        MostAskedService _mostAskedService = new MostAskedService();
        ServiceService _serviceService = new ServiceService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            List<Service> serviceList = _serviceService.GetAll(x => x.Status == true);

            ServiceViewModel model = new ServiceViewModel()
            {
                ServiceList = serviceList
            };

            return PartialView(model);
        }

        public ActionResult ContactHeader()
        {
            Contact contact = _contactService.Get();

            ContactViewModel model = new ContactViewModel()
            {
                Phone = contact.Phone,
                Mail = contact.Mail,
                Address = contact.Address,
                Facebook = contact.Address,
                Twitter = contact.Twitter,
                Instagram = contact.Instagram,
                Youtube = contact.Youtube,
                Linkedin = contact.Linkedin
            };
            return PartialView(model);
        }

        public ActionResult ContactFooter()
        {
            Contact contact = _contactService.Get();

            ContactViewModel model = new ContactViewModel()
            {
                Phone = contact.Phone,
                Mail = contact.Mail,
                Address = contact.Address,
                Facebook = contact.Address,
                Twitter = contact.Twitter,
                Instagram = contact.Instagram,
                Youtube = contact.Youtube,
                Linkedin = contact.Linkedin
            };
            return PartialView(model);
        }

        public ActionResult FooterAbout()
        {
            Contact contact = _contactService.Get();
            About about = _aboutService.Get(x=>x.Status == true); 

            AboutContactViewModel model = new AboutContactViewModel()
            {
                About = about.Writing.Length > 250 ? about.Writing.Substring(0,250) : about.Writing,
                Facebook = contact.Address,
                Twitter = contact.Twitter,
                Instagram = contact.Instagram,
                Youtube = contact.Youtube,
                Linkedin = contact.Linkedin
            };

            return PartialView(model);
        }

        public ActionResult FooterMostAsked()
        {
            List<MostAsked> mostAskedList = _mostAskedService.GetAll(x=>x.Status == true);

            MostAskedFooterViewModel model = new MostAskedFooterViewModel()
            {
                MostAskedList = mostAskedList.OrderByDescending(x=>x.Id).Take(5).ToList()
            };

            return PartialView(model);
        }
    }
}