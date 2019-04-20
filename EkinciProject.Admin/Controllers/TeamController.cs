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
    public class TeamController : Controller
    {
        TeamService _teamService = new TeamService();
        public ActionResult TeamCreate()
        {
            TeamCreateViewModel model = new TeamCreateViewModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult TeamCreate(TeamCreateViewModel model)
        {
            if (model.Title != "" && model.FullName != "" && model.FileUrl != null)
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Team newTeam = new Team();
                newTeam.Title = model.Title;
                newTeam.FullName = model.FullName;
                newTeam.ImageUrl = "~/Content/images/" + fileName;
                newTeam.Facebook = model.Facebook;
                newTeam.Twitter = model.Twitter;
                newTeam.Instagram = model.Instagram;
                newTeam.Youtube = model.Youtube;
                newTeam.Linkedin = model.Linkedin;
                newTeam.Status = true;

                try
                {
                    _teamService.Add(newTeam);

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

        public ActionResult TeamEditDeletePage()
        {
            List<Team> TeamList = _teamService.GetAll();

            TeamEditViewModel model = new TeamEditViewModel();
            model.TeamList = TeamList.OrderByDescending(x => x.Status).ThenByDescending(x => x.Id).ToList();

            return View(model);
        }

        public ActionResult TeamEdit(int Id)
        {
            Team Team = _teamService.Get(x => x.Id == Id);

            TeamEditViewModel model = new TeamEditViewModel()
            {
                Id = Id,
                Title = Team.Title,
                FullName = Team.FullName,
                Facebook = Team.Facebook,
                Twitter = Team.Twitter,
                Instagram = Team.Instagram,
                Youtube = Team.Youtube,
                Linkedin = Team.Linkedin,
                ImageUrl = Team.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult TeamEdit(TeamEditViewModel model)
        {
            if (model.Title != "" && model.FullName != "")
            {
                var fileName = Path.GetFileName(model.FileUrl.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/image"), fileName);
                model.FileUrl.SaveAs(path);

                string phisicalPath = HttpContext.Request.PhysicalApplicationPath;
                string webPath = phisicalPath.Replace("Admin", "Web") + "Content\\images\\" + fileName;
                model.FileUrl.SaveAs(webPath);

                Team Team = _teamService.Get(x => x.Id == model.Id);

                Team.Title = model.Title;
                Team.FullName = model.FullName;
                Team.Facebook = model.Facebook;
                Team.Twitter = model.Twitter;
                Team.Instagram = model.Instagram;
                Team.Youtube = model.Youtube;
                Team.Linkedin = model.Linkedin;
                Team.ImageUrl = "~/Content/images/" + fileName;
                Team.Status = true;

                try
                {
                    _teamService.Update(Team);
                    return RedirectToAction("TeamEditDeletePage");
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

        public ActionResult TeamDelete(int Id)
        {
            Team Team = _teamService.Get(x => x.Id == Id);
            Team.Status = false;
            _teamService.Update(Team);

            return RedirectToAction("TeamEditDeletePage");
        }
    }
}