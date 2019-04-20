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
    public class NewsController : Controller
    {
        NewsService _newsService = new NewsService();
        public ActionResult Index()
        {
            List<News> newsList = _newsService.GetAll(x => x.Status == true);

            NewsViewModel model = new NewsViewModel()
            {
                NewsList = newsList
            };

            return View(model);
        }
    }
}