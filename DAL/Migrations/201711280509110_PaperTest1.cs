namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        Department_ID = c.Int(),
                        Job_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.Department_ID)
                .ForeignKey("dbo.Jobs", t => t.Job_ID)
                .Index(t => t.Department_ID)
                .Index(t => t.Job_ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Default = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Employee_ID", c => c.Int());
            CreateIndex("dbo.Users", "Employee_ID");
            AddForeignKey("dbo.Users", "Employee_ID", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Employees", "Department_ID", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "Employee_ID" });
            DropIndex("dbo.Employees", new[] { "Job_ID" });
            DropIndex("dbo.Employees", new[] { "Department_ID" });
            DropColumn("dbo.Users", "Employee_ID");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
        }
    }
}
