namespace ChatUygulamasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        Durum = c.String(),
                        CikisTarih = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicis");
        }
    }
}
