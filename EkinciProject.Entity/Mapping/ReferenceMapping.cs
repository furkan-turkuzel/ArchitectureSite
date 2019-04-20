using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class ReferenceMapping : EntityTypeConfiguration<Reference>
    {
        public ReferenceMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.ReferanceLogo)
                .IsRequired();

            Property(x => x.ReferanceName)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.ReferancePhone)
                .IsRequired();

            Property(x => x.ReferanceType)
                .IsOptional();

            Property(x => x.ReferanceAddress)
                .HasMaxLength(200)
                .IsRequired();

            Property(x => x.Description)
                .IsOptional();

            Property(x => x.Status)
                .IsOptional();
        }
    }
}
