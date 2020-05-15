namespace ChatUygulamasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kullanicis", "connectionId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kullanicis", "connectionId");
        }
    }
}
