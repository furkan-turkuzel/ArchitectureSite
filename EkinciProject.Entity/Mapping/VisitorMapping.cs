using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class VisitorMapping : EntityTypeConfiguration<Visitor>
    {
        public VisitorMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption
                  (System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.FullName)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Email)
                .HasMaxLength(50)
                .IsOptional();

            Property(x => x.Subject)
                .HasMaxLength(100)
                .IsOptional();

            Property(x => x.Message)
                .IsOptional();

            Property(x => x.SendTime)
                .IsRequired();

            Property(x => x.Readed)
                .IsRequired();
        }
    }
}
