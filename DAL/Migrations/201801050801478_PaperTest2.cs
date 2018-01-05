namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StoreRoomMedicineNums", "MedicineID");
            AddForeignKey("dbo.StoreRoomMedicineNums", "MedicineID", "dbo.Medicines", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRoomMedicineNums", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "MedicineID" });
        }
    }
}
