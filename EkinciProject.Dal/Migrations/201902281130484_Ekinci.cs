namespace EkinciProject.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ekinci : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        Title = c.String(nullable: false, maxLength: 150),
                        Writing = c.String(nullable: false),
                        AdminId = c.Int(nullable: false),
                        NewsDate = c.DateTime(nullable: false),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.AdminId, cascadeDelete: true)
                .Index(t => t.AdminId);
            
            CreateTable(
                "dbo.References",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReferanceType = c.String(),
                        ReferanceName = c.String(nullable: false, maxLength: 150),
                        ReferancePhone = c.String(nullable: false, maxLength: 11),
                        ReferanceAddress = c.String(nullable: false, maxLength: 200),
                        ReferanceLogo = c.String(nullable: false),
                        Description = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Writing = c.String(nullable: false),
                        ImageUrl = c.String(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Youtube = c.String(),
                        Linkedin = c.String(),
                        Instagram = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 50),
                        Subject = c.String(maxLength: 100),
                        Message = c.String(),
                        SendTime = c.DateTime(nullable: false),
                        Readed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Admins", "ImageUrl", c => c.String());
            AddColumn("dbo.Admins", "Facebook", c => c.String());
            AddColumn("dbo.Admins", "Twitter", c => c.String());
            AddColumn("dbo.Admins", "Youtube", c => c.String());
            AddColumn("dbo.Admins", "Linkedin", c => c.String());
            AddColumn("dbo.Admins", "Instagram", c => c.String());
            AddColumn("dbo.Contacts", "Facebook", c => c.String());
            AddColumn("dbo.Contacts", "Twitter", c => c.String());
            AddColumn("dbo.Contacts", "Youtube", c => c.String());
            AddColumn("dbo.Contacts", "Linkedin", c => c.String());
            AddColumn("dbo.Contacts", "Instagram", c => c.String());
            AlterColumn("dbo.Abouts", "Writing", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Admins", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "AdminId", "dbo.Admins");
            DropIndex("dbo.News", new[] { "AdminId" });
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "LastName", c => c.String());
            AlterColumn("dbo.Admins", "FirstName", c => c.String());
            AlterColumn("dbo.Abouts", "Writing", c => c.String());
            DropColumn("dbo.Contacts", "Instagram");
            DropColumn("dbo.Contacts", "Linkedin");
            DropColumn("dbo.Contacts", "Youtube");
            DropColumn("dbo.Contacts", "Twitter");
            DropColumn("dbo.Contacts", "Facebook");
            DropColumn("dbo.Admins", "Instagram");
            DropColumn("dbo.Admins", "Linkedin");
            DropColumn("dbo.Admins", "Youtube");
            DropColumn("dbo.Admins", "Twitter");
            DropColumn("dbo.Admins", "Facebook");
            DropColumn("dbo.Admins", "ImageUrl");
            DropTable("dbo.Visitors");
            DropTable("dbo.Teams");
            DropTable("dbo.Services");
            DropTable("dbo.References");
            DropTable("dbo.News");
        }
    }
}
