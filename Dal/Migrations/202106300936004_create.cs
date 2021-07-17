namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        airPlaneID = c.Int(nullable: false, identity: true),
                        planeCompany = c.String(),
                    })
                .PrimaryKey(t => t.airPlaneID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        flightID = c.Int(nullable: false, identity: true),
                        flightNumber = c.Int(nullable: false),
                        airPlaneID = c.Int(),
                        CurentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.flightID)
                .ForeignKey("dbo.Airplanes", t => t.airPlaneID)
                .Index(t => t.airPlaneID);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        stationID = c.Int(nullable: false, identity: true),
                        stationNnumber = c.Int(nullable: false),
                        airplaneID = c.Int(),
                        busy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.stationID)
                .ForeignKey("dbo.Airplanes", t => t.airplaneID)
                .Index(t => t.airplaneID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stations", "airplaneID", "dbo.Airplanes");
            DropForeignKey("dbo.Flights", "airPlaneID", "dbo.Airplanes");
            DropIndex("dbo.Stations", new[] { "airplaneID" });
            DropIndex("dbo.Flights", new[] { "airPlaneID" });
            DropTable("dbo.Stations");
            DropTable("dbo.Flights");
            DropTable("dbo.Airplanes");
        }
    }
}
