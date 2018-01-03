namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MedicineInStoreDetails", "MedicineBatchID", "dbo.MedicineBatches");
            DropForeignKey("dbo.StoreRoomMedicineNums", "MedicineBatchID", "dbo.MedicineBatches");
            DropIndex("dbo.MedicineInStoreDetails", new[] { "MedicineBatchID" });
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "MedicineBatchID" });
            AddColumn("dbo.StoreRoomMedicineNums", "MedicineID", c => c.Int(nullable: false));
            AddColumn("dbo.StoreRoomMedicineNums", "Batch", c => c.String());
            AddColumn("dbo.StoreRoomMedicineNums", "ExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.StoreRoomMedicineNums", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.StoreRoomMedicineNums", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StoreRoomMedicineNums", "MedicineBatchID");
            DropTable("dbo.MedicineBatches");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedicineBatches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicineID = c.Int(nullable: false),
                        Batch = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.StoreRoomMedicineNums", "MedicineBatchID", c => c.Int(nullable: false));
            DropColumn("dbo.StoreRoomMedicineNums", "SellPrice");
            DropColumn("dbo.StoreRoomMedicineNums", "StorePrice");
            DropColumn("dbo.StoreRoomMedicineNums", "ExpirationDate");
            DropColumn("dbo.StoreRoomMedicineNums", "Batch");
            DropColumn("dbo.StoreRoomMedicineNums", "MedicineID");
            CreateIndex("dbo.StoreRoomMedicineNums", "MedicineBatchID");
            CreateIndex("dbo.MedicineInStoreDetails", "MedicineBatchID");
            AddForeignKey("dbo.StoreRoomMedicineNums", "MedicineBatchID", "dbo.MedicineBatches", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MedicineInStoreDetails", "MedicineBatchID", "dbo.MedicineBatches", "ID", cascadeDelete: true);
        }
    }
}
