using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class NewsEditViewModel
    {
        public List<News> NewsList { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase FileUrl { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        public string Writing { get; set; }
        public int AdminId { get; set; }
        public DateTime NewsDate { get; set; }
        public bool Status { get; set; }
    }
}