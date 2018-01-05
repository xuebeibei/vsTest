namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StoreRoomMedicineNums", "SupplierID");
            AddForeignKey("dbo.StoreRoomMedicineNums", "SupplierID", "dbo.Suppliers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRoomMedicineNums", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "SupplierID" });
        }
    }
}
