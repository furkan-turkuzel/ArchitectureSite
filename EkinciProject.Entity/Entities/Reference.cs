using EkinciProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Entities
{
    public class Reference : IEntity
    {
        public int Id { get; set; }
        public string ReferanceType { get; set; }
        public string ReferanceName { get; set; }
        public string ReferancePhone { get; set; }
        public string ReferanceAddress { get; set; }
        public string ReferanceLogo { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
