namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SickRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SickRoomEnum = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SickRooms", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.SickRooms", new[] { "DepartmentID" });
            DropTable("dbo.SickRooms");
        }
    }
}
