using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinciProject.Web.Models
{
    public class ServiceViewModel
    {
        public List<Service> ServiceList { get; set; }
        public string Title { get; set; }
        public string Writing { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}