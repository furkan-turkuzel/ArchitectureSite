using EkinciProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Entities
{
    public class News : IEntity
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Writing { get; set; }
        public int AdminId { get; set; }
        public DateTime NewsDate { get; set; }
        public bool Status { get; set; }

        public virtual Admin Admin { get; set; }
    }
}
