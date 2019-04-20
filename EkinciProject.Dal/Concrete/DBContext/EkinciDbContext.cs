using EkinciProject.Entity.Entities;
using EkinciProject.Entity.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkinciProject.Dal.Concrete.DBContext
{
    public class EkinciDbContext : DbContext
    {
        public EkinciDbContext() : base("Server=.;Database=EkinciDB;Integrated Security=true")
        {
            Database.SetInitializer(new DataBaseDataCreater());
        }

        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<MostAsked> MostAsked { get; set; }
        public DbSet<Reconstruction> Reconstruction { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Visitor> Visitor { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SlidersMapping());
            modelBuilder.Configurations.Add(new AboutMapping());
            modelBuilder.Configurations.Add(new ContactMapping());
            modelBuilder.Configurations.Add(new ReconstructionMapping());
            modelBuilder.Configurations.Add(new MostAskedMapping());
            modelBuilder.Configurations.Add(new AdminMapping());
            modelBuilder.Configurations.Add(new NewsMapping());
            modelBuilder.Configurations.Add(new ReferenceMapping());
            modelBuilder.Configurations.Add(new ServiceMapping());
            modelBuilder.Configurations.Add(new TeamMapping());
            modelBuilder.Configurations.Add(new VisitorMapping());
        }

    }

    public class DataBaseDataCreater : CreateDatabaseIfNotExists<EkinciDbContext>
    {
        protected override void Seed(EkinciDbContext context)
        {
        }
    }
}
