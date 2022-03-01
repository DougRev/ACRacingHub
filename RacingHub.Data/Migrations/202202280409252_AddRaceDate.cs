namespace RacingHub.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRaceDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Race", "RaceDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ApplicationUser", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplicationUser", "LockoutEndDateUtc", c => c.DateTime());
            DropColumn("dbo.Race", "RaceDate");
        }
    }
}
