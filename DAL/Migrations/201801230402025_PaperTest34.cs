namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.AssayDoctorAdviceDetail",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        AssayID = c.Int(nullable: false),
                        AssayDoctorAdviceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceDetailBase", t => t.ID)
                .ForeignKey("dbo.AssayItems", t => t.AssayID, cascadeDelete: true)
                .ForeignKey("tpt.AssayDoctorAdvice", t => t.AssayDoctorAdviceID)
                .Index(t => t.ID)
                .Index(t => t.AssayID)
                .Index(t => t.AssayDoctorAdviceID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("tpt.AssayDoctorAdviceDetail", "AssayDoctorAdviceID", "tpt.AssayDoctorAdvice");
            DropForeignKey("tpt.AssayDoctorAdviceDetail", "AssayID", "dbo.AssayItems");
            DropForeignKey("tpt.AssayDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropIndex("tpt.AssayDoctorAdviceDetail", new[] { "AssayDoctorAdviceID" });
            DropIndex("tpt.AssayDoctorAdviceDetail", new[] { "AssayID" });
            DropIndex("tpt.AssayDoctorAdviceDetail", new[] { "ID" });
            DropTable("tpt.AssayDoctorAdviceDetail");
        }
    }
}
