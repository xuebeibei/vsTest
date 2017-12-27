namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "RecipeContentEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "RecipeContentEnum");
        }
    }
}
