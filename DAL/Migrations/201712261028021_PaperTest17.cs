namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assays", "RegistrationID", c => c.Int(nullable: false));
            AddColumn("dbo.Inspects", "RegistrationID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspects", "RegistrationID");
            DropColumn("dbo.Assays", "RegistrationID");
        }
    }
}
