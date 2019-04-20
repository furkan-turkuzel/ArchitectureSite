using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class AboutMapping : EntityTypeConfiguration<About>
    {
        public AboutMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Writing)
                .IsRequired();

            Property(x => x.ImageUrl)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();
        }
    }
}
