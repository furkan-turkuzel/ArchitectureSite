using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class ReferenceEditViewModel
    {
        public List<Reference> ReferenceList { get; set; }
        public int Id { get; set; }

        [Display(Name = "Referans Tipi")]
        public string ReferanceType { get; set; }

        [Display(Name = "Referans Adı")]
        public string ReferanceName { get; set; }

        [Display(Name = "Referans Telefonu")]
        public string ReferancePhone { get; set; }

        [Display(Name = "Referans Adresi")]
        public string ReferanceAddress { get; set; }

        [Display(Name = "Referans Logosu")]
        public string ReferanceLogo { get; set; }
        public HttpPostedFileBase FileUrl { get; set; }

        [Display(Name = "Referans Açıklama")]
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}