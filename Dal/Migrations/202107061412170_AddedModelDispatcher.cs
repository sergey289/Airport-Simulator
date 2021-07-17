namespace Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelDispatcher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dispatchers",
                c => new
                    {
                        dispatcherID = c.Int(nullable: false, identity: true),
                        AirportStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dispatcherID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Dispatchers");
        }
    }
}
