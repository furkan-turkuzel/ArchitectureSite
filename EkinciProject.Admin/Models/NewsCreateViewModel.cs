using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class NewsCreateViewModel
    {
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