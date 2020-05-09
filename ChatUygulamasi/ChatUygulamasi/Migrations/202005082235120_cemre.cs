namespace ChatUygulamasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cemre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mesajs", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.Mesajs", new[] { "KullaniciId" });
            AddColumn("dbo.Mesajs", "GonderenAdi", c => c.String());
            AddColumn("dbo.Mesajs", "AliciAdi", c => c.String());
            DropColumn("dbo.Mesajs", "KullaniciId");
            DropTable("dbo.Kullanicis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Durumu = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Mesajs", "KullaniciId", c => c.Int(nullable: false));
            DropColumn("dbo.Mesajs", "AliciAdi");
            DropColumn("dbo.Mesajs", "GonderenAdi");
            CreateIndex("dbo.Mesajs", "KullaniciId");
            AddForeignKey("dbo.Mesajs", "KullaniciId", "dbo.Kullanicis", "Id", cascadeDelete: true);
        }
    }
}
