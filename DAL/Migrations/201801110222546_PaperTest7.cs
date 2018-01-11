namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SignalSources", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.InspectItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MaterialItems", "StockPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.StoreRoomMedicineNums", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineInStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineInStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineOutStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineOutStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.OtherServiceItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.TherapyItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.AssayItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineCheckStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
            AlterColumn("dbo.MedicineCheckStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineCheckStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MedicineCheckStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.AssayItems", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.TherapyItems", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.OtherServiceItems", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.MedicineOutStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MedicineOutStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MedicineInStoreDetails", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MedicineInStoreDetails", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.StoreRoomMedicineNums", "StorePrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.MaterialItems", "StockPrice", c => c.Double(nullable: false));
            AlterColumn("dbo.InspectItems", "Price", c => c.Double(nullable: false));
            AlterColumn("dbo.SignalSources", "Price", c => c.Double(nullable: false));
        }
    }
}
