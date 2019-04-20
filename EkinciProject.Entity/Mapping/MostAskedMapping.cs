using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class MostAskedMapping : EntityTypeConfiguration<MostAsked>
    {
        public MostAskedMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Question)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Answer)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();
        }
    }
}
