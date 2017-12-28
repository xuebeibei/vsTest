namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest24 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Responsibilities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InpatientID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.EmployeeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Responsibilities", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Responsibilities", new[] { "EmployeeID" });
            DropTable("dbo.Responsibilities");
        }
    }
}
