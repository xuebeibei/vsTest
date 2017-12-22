namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeDetails", "MedicineID", c => c.Int(nullable: false));
            CreateIndex("dbo.RecipeDetails", "MedicineID");
            AddForeignKey("dbo.RecipeDetails", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
            DropColumn("dbo.RecipeDetails", "DrugID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeDetails", "DrugID", c => c.Int(nullable: false));
            DropForeignKey("dbo.RecipeDetails", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.RecipeDetails", new[] { "MedicineID" });
            DropColumn("dbo.RecipeDetails", "MedicineID");
        }
    }
}
