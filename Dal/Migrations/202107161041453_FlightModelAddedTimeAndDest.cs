namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightModelAddedTimeAndDest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "time", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "time");
        }
    }
}
