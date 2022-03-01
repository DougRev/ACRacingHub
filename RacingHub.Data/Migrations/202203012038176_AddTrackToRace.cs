namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrackToRace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Race", "Track", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Race", "Track");
        }
    }
}
