namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotonId = c.Int(nullable: false),
                        LightData = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Motions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotonId = c.Int(nullable: false),
                        MotionData = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Temperatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotonId = c.Int(nullable: false),
                        TempData = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Photons_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photons", t => t.Photons_Id)
                .Index(t => t.Photons_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Photons_Id", "dbo.Photons");
            DropIndex("dbo.Users", new[] { "Photons_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Temperatures");
            DropTable("dbo.Photons");
            DropTable("dbo.Motions");
            DropTable("dbo.Lights");
        }
    }
}
