namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "DepartmentEnum", c => c.Int(nullable: false));
            DropColumn("dbo.Departments", "IsDoctorDepartment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "IsDoctorDepartment", c => c.Boolean(nullable: false));
            DropColumn("dbo.Departments", "DepartmentEnum");
        }
    }
}
