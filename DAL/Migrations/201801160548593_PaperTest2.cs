namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SickBeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 4),
                        Unit = c.String(),
                        SickRoomID = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SickRooms", t => t.SickRoomID, cascadeDelete: true)
                .Index(t => t.SickRoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SickBeds", "SickRoomID", "dbo.SickRooms");
            DropIndex("dbo.SickBeds", new[] { "SickRoomID" });
            DropTable("dbo.SickBeds");
        }
    }
}
