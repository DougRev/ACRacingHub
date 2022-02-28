namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaceIdToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "RaceId", c => c.Int());
            CreateIndex("dbo.Post", "RaceId");
            AddForeignKey("dbo.Post", "RaceId", "dbo.Race", "RaceId");
            DropColumn("dbo.Race", "RaceDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Race", "RaceDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Post", "RaceId", "dbo.Race");
            DropIndex("dbo.Post", new[] { "RaceId" });
            DropColumn("dbo.Post", "RaceId");
        }
    }
}
