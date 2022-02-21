namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeams : DbMigration
    {
        public override void Up()
        {
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
            DropTable("dbo.Team");
        }
    }
}
