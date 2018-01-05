namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreRoomMedicineNums", "SupplierID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreRoomMedicineNums", "SupplierID");
        }
    }
}
