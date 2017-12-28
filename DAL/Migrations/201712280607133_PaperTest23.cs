namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inpatients", "InPatientUserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Inpatients", "InPatientUserID");
            AddForeignKey("dbo.Inpatients", "InPatientUserID", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inpatients", "InPatientUserID", "dbo.Users");
            DropIndex("dbo.Inpatients", new[] { "InPatientUserID" });
            DropColumn("dbo.Inpatients", "InPatientUserID");
        }
    }
}
