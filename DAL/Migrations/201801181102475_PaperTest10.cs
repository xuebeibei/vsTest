namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inpatients", "InHospitalStatusEnum", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inpatients", "InHospitalStatusEnum");
        }
    }
}
