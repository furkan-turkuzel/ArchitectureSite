using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class ServiceEditViewModel
    {
        public List<Service> ServiceList { get; set; }
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        public string Writing { get; set; }
        public string ImageUrl { get; set; }
        public HttpPostedFileBase FileUrl { get; set; }
        public bool Status { get; set; }
    }
}