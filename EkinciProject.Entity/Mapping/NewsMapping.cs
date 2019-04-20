using EkinciProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Entity.Mapping
{
    public class NewsMapping : EntityTypeConfiguration<News>
    {
        public NewsMapping()
        {
            HasKey(x => x.Id);

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            HasRequired(x => x.Admin)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.AdminId)
                .WillCascadeOnDelete(true);

            Property(x => x.Title)
                .HasMaxLength(150)
                .IsRequired();

            Property(x => x.Writing)
                .IsRequired();

            Property(x => x.ImageUrl)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();

            Property(x => x.NewsDate)
                .IsRequired();

            Property(x => x.Status)
                .IsRequired();
        }
    }
}
