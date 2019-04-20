using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class TeamEditViewModel
    {
        public List<Team> TeamList { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase FileUrl { get; set; }

        [Display(Name = "Ünvan")]
        public string Title { get; set; }

        [Display(Name = "Tam İsim")]
        public string FullName { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
        public bool Status { get; set; }
    }
}