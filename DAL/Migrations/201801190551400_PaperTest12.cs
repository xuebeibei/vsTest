namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest12 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assays", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.Responsibilities", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Inpatients", "InHospitalTime", c => c.DateTime());
            AlterColumn("dbo.Patients", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Registrations", "RegisterTime", c => c.DateTime());
            AlterColumn("dbo.MedicalRecords", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.SignalSources", "VistTime", c => c.DateTime());
            AlterColumn("dbo.Inspects", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.MaterialBills", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.MedicineInStores", "OperateTime", c => c.DateTime());
            AlterColumn("dbo.StoreRoomMedicineNums", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.MedicineInStoreDetails", "ExpirationDate", c => c.DateTime());
            AlterColumn("dbo.Recipes", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.MedicineOutStores", "OperateTime", c => c.DateTime());
            AlterColumn("dbo.RecipeChargeBills", "ChargeTime", c => c.DateTime());
            AlterColumn("dbo.OtherServices", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.Therapies", "WriteTime", c => c.DateTime());
            AlterColumn("dbo.MedicineCheckStores", "OperateTime", c => c.DateTime());
            AlterColumn("dbo.Triages", "DateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Triages", "DateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineCheckStores", "OperateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Therapies", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OtherServices", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RecipeChargeBills", "ChargeTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineOutStores", "OperateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Recipes", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineInStoreDetails", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.StoreRoomMedicineNums", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicineInStores", "OperateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MaterialBills", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Inspects", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SignalSources", "VistTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MedicalRecords", "WriteTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Registrations", "RegisterTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Patients", "BirthDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Inpatients", "InHospitalTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Responsibilities", "StartTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Assays", "WriteTime", c => c.DateTime(nullable: false));
        }
    }
}
