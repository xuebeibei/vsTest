namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest27 : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.StoreRoomMedicineNums",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomID = c.Int(nullable: false),
                        MedicineBatchID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MedicineBatches", t => t.MedicineBatchID, cascadeDelete: true)
                .ForeignKey("dbo.StoreRooms", t => t.StoreRoomID, cascadeDelete: true)
                .Index(t => t.StoreRoomID)
                .Index(t => t.MedicineBatchID);
            
            CreateTable(
                "dbo.StoreRooms",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Contents = c.String(),
                        Tel = c.String(),
                        StoreRoomEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineCheckStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomMedicineNumID = c.Int(nullable: false),
                        NumBeforeCheck = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineCheckStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        CheckStoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineInStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedicineBatchID = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineInStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        InStoreEnum = c.Int(nullable: false),
                        FromSupplierID = c.Int(nullable: false),
                        ToStoreID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineOutStoreDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StoreRoomMedicineNumID = c.Int(nullable: false),
                        NumBeforeOut = c.Int(nullable: false),
                        Num = c.Int(nullable: false),
                        StorePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MedicineOutStores",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OperateTime = c.DateTime(nullable: false),
                        OutStoreEnum = c.Int(nullable: false),
                        FromStoreID = c.Int(nullable: false),
                        ToStoreID = c.Int(nullable: false),
                        ToOtherHospitalID = c.Int(nullable: false),
                        ToSupplierID = c.Int(nullable: false),
                        Remarks = c.String(),
                        OperateUserID = c.Int(nullable: false),
                        ReCheckUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreRoomMedicineNums", "StoreRoomID", "dbo.StoreRooms");
            DropForeignKey("dbo.StoreRoomMedicineNums", "MedicineBatchID", "dbo.MedicineBatches");
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "MedicineBatchID" });
            DropIndex("dbo.StoreRoomMedicineNums", new[] { "StoreRoomID" });
            DropTable("dbo.MedicineOutStores");
            DropTable("dbo.MedicineOutStoreDetails");
            DropTable("dbo.MedicineInStores");
            DropTable("dbo.MedicineInStoreDetails");
            DropTable("dbo.MedicineCheckStores");
            DropTable("dbo.MedicineCheckStoreDetails");
            DropTable("dbo.StoreRooms");
            DropTable("dbo.StoreRoomMedicineNums");
            DropTable("dbo.MedicineBatches");
        }
    }
}
