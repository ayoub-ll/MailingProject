namespace MailingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        campaignId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.campaignId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Campaign");
        }
    }
}
