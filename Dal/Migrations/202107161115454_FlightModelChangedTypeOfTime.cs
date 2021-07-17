namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightModelChangedTypeOfTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "time", c => c.DateTime());
        }
    }
}
