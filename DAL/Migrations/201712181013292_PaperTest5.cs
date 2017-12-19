namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Abbr", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Abbr");
        }
    }
}
