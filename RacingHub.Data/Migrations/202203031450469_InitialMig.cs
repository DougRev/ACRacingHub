namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                {
                    PostId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    PostName = c.String(nullable: false),
                    PostBody = c.String(nullable: false),
                    CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedUtc = c.DateTimeOffset(precision: 7),
                    RaceId = c.Int(),
                })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Race", t => t.RaceId)
                .Index(t => t.RaceId);

            CreateTable(
                "dbo.Race",
                c => new
                {
                    RaceId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    RaceName = c.String(nullable: false),
                    RaceDescription = c.String(),
                    Track = c.String(nullable: false),
                    RaceDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    DriverLimit = c.Int(nullable: false),
                    CarType = c.Int(nullable: false),
                    CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedUtc = c.DateTimeOffset(precision: 7),
                })
                .PrimaryKey(t => t.RaceId);



            CreateTable(
                "dbo.Team",
                c => new
                {
                    TeamId = c.Int(nullable: false, identity: true),
                    OwnerId = c.Guid(nullable: false),
                    TeamName = c.String(nullable: false),
                    TeamDescription = c.String(),
                    CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                    ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                })
                .PrimaryKey(t => t.TeamId);


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Post", "RaceId", "dbo.Race");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Post", new[] { "RaceId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Team");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Race");
            DropTable("dbo.Post");
        }
    }
}
