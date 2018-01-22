namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest16 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RecipeChargeBills", "RecipeID");
            AddForeignKey("dbo.RecipeChargeBills", "RecipeID", "dbo.Recipes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeChargeBills", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.RecipeChargeBills", new[] { "RecipeID" });
        }
    }
}
