namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "tpt.AssayDoctorAdvice",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ReCheckName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("tpt.DoctorAdviceBase", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.AssayDoctorAdviceDetail",
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
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "AssayDoctorAdviceID", "tpt.AssayDoctorAdvice");
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "AssayID", "dbo.AssayItems");
            DropForeignKey("dbo.AssayDoctorAdviceDetail", "ID", "tpt.DoctorAdviceDetailBase");
            DropForeignKey("tpt.AssayDoctorAdvice", "ID", "tpt.DoctorAdviceBase");
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "AssayDoctorAdviceID" });
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "AssayID" });
            DropIndex("dbo.AssayDoctorAdviceDetail", new[] { "ID" });
            DropIndex("tpt.AssayDoctorAdvice", new[] { "ID" });
            DropTable("dbo.AssayDoctorAdviceDetail");
            DropTable("tpt.AssayDoctorAdvice");
        }
    }
}
