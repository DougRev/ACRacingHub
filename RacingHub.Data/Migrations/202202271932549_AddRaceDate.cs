namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Race", "RaceDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Race", "RaceDate");
        }
    }
}
