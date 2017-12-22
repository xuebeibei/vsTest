namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest9 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Recipes", "WriteUserID");
            AddForeignKey("dbo.Recipes", "WriteUserID", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.Recipes", "AuditorUserID");
            DropColumn("dbo.Recipes", "AuditorTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "AuditorTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "AuditorUserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Recipes", "WriteUserID", "dbo.Users");
            DropIndex("dbo.Recipes", new[] { "WriteUserID" });
        }
    }
}
