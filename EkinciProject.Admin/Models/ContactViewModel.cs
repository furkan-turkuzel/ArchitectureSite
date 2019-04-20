using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EkinciProject.Admin.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string MapUrl { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
        public string Linkedin { get; set; }
        public string Instagram { get; set; }
    }
}