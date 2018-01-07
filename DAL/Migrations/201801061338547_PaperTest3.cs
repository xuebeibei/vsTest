namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineOutStores", "ReCheckStatusEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineOutStores", "ReCheckStatusEnum");
        }
    }
}
