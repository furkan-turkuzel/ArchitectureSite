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
    public class PanelController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        //public FileContentResult FileView(HttpPostedFileBase image,string a,AboutViewModel model)
        //{
        //    var file = image;

        //    MemoryStream target = new MemoryStream();
        //    image.InputStream.CopyTo(target);
        //    byte[] data = target.ToArray();

        //    return new FileContentResult(data, file.ContentType);
        //}
    }
}