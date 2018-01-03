namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MedicineInStores", "ReCheckStatusEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MedicineInStores", "ReCheckStatusEnum");
        }
    }
}
