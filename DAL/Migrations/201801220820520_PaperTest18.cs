namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.DoctorAdviceBase",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NO = c.String(),
                        SumOfMoney = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WriteTime = c.DateTime(),
                        WriteDoctorUserID = c.Int(nullable: false),
                        PatientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "tpt.DoctorAdviceDetailBase",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AllNum = c.Int(nullable: false),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "tpt.MedicineDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        RecipeContentEnum = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "tpt.MedicineDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        MedicineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.MedicineDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.MedicineDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("tpt.MedicineDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.MedicineDoctorAdvice", new[] { "ID" });
            DropTable("tpt.MedicineDoctorAdviceDetail");
            DropTable("tpt.MedicineDoctorAdvice");
            DropTable("tpt.DoctorAdviceDetailBase");
            DropTable("tpt.DoctorAdviceBase");
        }
    }
}
