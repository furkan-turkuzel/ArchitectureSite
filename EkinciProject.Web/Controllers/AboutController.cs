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
    public class AboutController : Controller
    {
        AboutService _aboutService = new AboutService();
        public ActionResult Index()
        {
            List<About> aboutList = _aboutService.GetAll(x => x.Status == true);

            AboutViewModel model = new AboutViewModel()
            {
                AboutList = aboutList
            };

            return View(model);
        }
    }
}