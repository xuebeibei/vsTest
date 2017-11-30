namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Registrations", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registrations", "EmployeeID", c => c.Int(nullable: false));
        }
    }
}
