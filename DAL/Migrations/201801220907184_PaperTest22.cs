namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("tpt.DoctorAdviceBase", "ChargeStatusEnum", c => c.Int(nullable: false));
            AddColumn("tpt.DoctorAdviceBase", "RegistrationID", c => c.Int(nullable: false));
            AddColumn("tpt.DoctorAdviceBase", "InpatientID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("tpt.DoctorAdviceBase", "InpatientID");
            DropColumn("tpt.DoctorAdviceBase", "RegistrationID");
            DropColumn("tpt.DoctorAdviceBase", "ChargeStatusEnum");
        }
    }
}
