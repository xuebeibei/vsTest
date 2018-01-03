namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest34 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.MedicineInStores", "OperateUserID");
            AddForeignKey("dbo.MedicineInStores", "OperateUserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedicineInStores", "OperateUserID", "dbo.Users");
            DropIndex("dbo.MedicineInStores", new[] { "OperateUserID" });
        }
    }
}
