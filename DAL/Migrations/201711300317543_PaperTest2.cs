namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SignalSources", "Department_ID", "dbo.Departments");
            DropIndex("dbo.SignalSources", new[] { "Department_ID" });
            AddColumn("dbo.SignalSources", "DepartmentID", c => c.Int(nullable: false));
            DropColumn("dbo.SignalSources", "Department_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SignalSources", "Department_ID", c => c.Int());
            DropColumn("dbo.SignalSources", "DepartmentID");
            CreateIndex("dbo.SignalSources", "Department_ID");
            AddForeignKey("dbo.SignalSources", "Department_ID", "dbo.Departments", "ID");
        }
    }
}
