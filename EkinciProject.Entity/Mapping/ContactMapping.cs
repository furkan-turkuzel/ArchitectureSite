using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class ContactMapping : EntityTypeConfiguration<Contact>
    {
        public ContactMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(x => x.Address)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Phone)
                .HasMaxLength(11)
                .IsRequired();

            Property(x => x.Mail)
                .IsRequired();

            Property(x => x.MapUrl)
                .IsOptional();

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

        }
    }
}
