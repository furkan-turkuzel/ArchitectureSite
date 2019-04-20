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
    public class MostAskedController : Controller
    {
        MostAskedService _mostAskedService = new MostAskedService();
        public ActionResult Index()
        {
            List<MostAsked> mostAskedList = _mostAskedService.GetAll(x => x.Status == true);

            MostAskedViewModel model = new MostAskedViewModel()
            {
                MostAskedList = mostAskedList
            };
            return View(model);
        }


    }
}