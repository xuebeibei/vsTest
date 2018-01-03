namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaperTest30 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbr1 = c.String(),
                        Abbr2 = c.String(),
                        Abbr3 = c.String(),
                        Address = c.String(),
                        Contents = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.StoreRooms", "Abbr1", c => c.String());
            AddColumn("dbo.StoreRooms", "Abbr2", c => c.String());
            AddColumn("dbo.StoreRooms", "Abbr3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreRooms", "Abbr3");
            DropColumn("dbo.StoreRooms", "Abbr2");
            DropColumn("dbo.StoreRooms", "Abbr1");
            DropTable("dbo.Suppliers");
        }
    }
}
