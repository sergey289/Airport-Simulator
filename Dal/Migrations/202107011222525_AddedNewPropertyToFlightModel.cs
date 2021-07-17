namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewPropertyToFlightModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Flights", "flightNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Flights", "flightNumber", c => c.Int(nullable: false));
        }
    }
}
