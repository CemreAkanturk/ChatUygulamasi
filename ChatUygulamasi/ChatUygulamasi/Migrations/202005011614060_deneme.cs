namespace ChatUygulamasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Mesajs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciId = c.Int(nullable: false),
                        MesajMetin = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Kullanicis", t => t.KullaniciId, cascadeDelete: true)
                .Index(t => t.KullaniciId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mesajs", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.Mesajs", new[] { "KullaniciId" });
            DropTable("dbo.Mesajs");
            DropTable("dbo.Kullanicis");
        }
    }
}
