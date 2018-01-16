namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastLogin", c => c.DateTime(nullable: false));
        }
    }
}
