namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "AssayID", "dbo.AssayItems");
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "AssayDoctorAdviceID", "tpt.AssayDoctorAdvice");
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "ID" });
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "AssayID" });
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "AssayDoctorAdviceID" });
            DropTable("dbo.AssayDoctorAdviceDetail");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssayDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        AssayID = c.Int(nullable: false),
                        AssayDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AssayDoctorAdviceDetail", "AssayDoctorAdviceID");
            CreateIndex("dbo.AssayDoctorAdviceDetail", "AssayID");
            CreateIndex("dbo.AssayDoctorAdviceDetail", "ID");
            AddForeignKey("dbo.AssayDoctorAdviceDetail", "AssayDoctorAdviceID", "tpt.AssayDoctorAdvice", "ID");
            AddForeignKey("dbo.AssayDoctorAdviceDetail", "AssayID", "dbo.AssayItems", "ID", cascadeDelete: true);
            AddForeignKey("dbo.AssayDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase", "ID");
        }
    }
}
