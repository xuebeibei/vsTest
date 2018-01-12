namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest12 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RecipeChargeDetails", "StoreRoomMedicineNumID");
            AddForeignKey("dbo.RecipeChargeDetails", "StoreRoomMedicineNumID", "dbo.StoreRoomMedicineNums", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeChargeDetails", "StoreRoomMedicineNumID", "dbo.StoreRoomMedicineNums");
            DropIndex("dbo.RecipeChargeDetails", new[] { "StoreRoomMedicineNumID" });
        }
    }
}
