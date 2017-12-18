namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RecipeDetails", "RecipeID");
            AddForeignKey("dbo.RecipeDetails", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeDetails", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeDetails", new[] { "RecipeID" });
        }
    }
}
