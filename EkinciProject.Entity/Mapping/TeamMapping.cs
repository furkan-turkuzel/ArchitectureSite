using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class TeamMapping : EntityTypeConfiguration<Team>
    {
        public TeamMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Title)
                .IsRequired();

            Property(x => x.FullName)
                .IsRequired();

            Property(x => x.ImageUrl)
                .IsRequired();

            Property(x => x.Facebook)
                .IsOptional();

            Property(x => x.Twitter)
                .IsOptional();

            Property(x => x.Youtube)
                .IsOptional();

            Property(x => x.Linkedin)
                .IsOptional();

            Property(x => x.Instagram)
                .IsOptional();

            Property(x => x.Status)
                .IsRequired();
        }
    }
}
