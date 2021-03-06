﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class ReconstructionCreateViewModel
    {
        public string ImageUrl { get; set; }
        public HttpPostedFileBase FileUrl { get; set; }

        [Display(Name = "Başlık")]
        public string Title { get; set; }

        [Display(Name = "Başlık")]
        public string Writing { get; set; }
        public bool Status { get; set; }
    }
}