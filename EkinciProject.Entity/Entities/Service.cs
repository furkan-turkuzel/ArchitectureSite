using EkinciProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Entities
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Writing { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
