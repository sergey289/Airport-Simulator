namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlightModelAddedToDestGetSet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Flights", "destination", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Flights", "destination");
        }
    }
}
