namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StationModelChangedTypeOfStationStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "_CurrentStationStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Stations", "busy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stations", "busy", c => c.Boolean(nullable: false));
            DropColumn("dbo.Stations", "_CurrentStationStatus");
        }
    }
}
