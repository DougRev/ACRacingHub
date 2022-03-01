namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RaceTypeToCarType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Race", "CarType", c => c.Int(nullable: false));
            DropColumn("dbo.Race", "RaceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Race", "RaceType", c => c.Int(nullable: false));
            DropColumn("dbo.Race", "CarType");
        }
    }
}
