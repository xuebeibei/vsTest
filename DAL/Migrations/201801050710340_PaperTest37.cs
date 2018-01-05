namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.StoreRoomMedicineNums", "SellPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StoreRoomMedicineNums", "SellPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Medicines", "SellPrice");
        }
    }
}
