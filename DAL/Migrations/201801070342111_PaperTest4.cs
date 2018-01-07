namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineOutStoreDetails", "StoreRoomMedicineNumID");
            AddForeignKey("dbo.MedicineOutStoreDetails", "StoreRoomMedicineNumID", "dbo.StoreRoomMedicineNums", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineOutStoreDetails", "StoreRoomMedicineNumID", "dbo.StoreRoomMedicineNums");
            DropIndex("dbo.MedicineOutStoreDetails", new[] { "StoreRoomMedicineNumID" });
        }
    }
}
