using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class MostAskedEditViewModel
    {
        public List<MostAsked> MostAskedList { get; set; }
        public int Id { get; set; }

        [Display(Name = "Soru")]
        public string Question { get; set; }

        [Display(Name = "Cevap")]
        public string Answer { get; set; }
    }
}