using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class MostAskedCreateViewModel
    {
        [Display(Name = "Soru")]
        public string Question { get; set; }

        [Display(Name = "Cevap")]
        public string Answer { get; set; }
    }
}