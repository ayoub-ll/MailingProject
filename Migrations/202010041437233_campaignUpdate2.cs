namespace MailingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campaignUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailsFile", "Campaign_campaignId", c => c.Int());
            CreateIndex("dbo.EmailsFile", "Campaign_campaignId");
            AddForeignKey("dbo.EmailsFile", "Campaign_campaignId", "dbo.Campaign", "campaignId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailsFile", "Campaign_campaignId", "dbo.Campaign");
            DropIndex("dbo.EmailsFile", new[] { "Campaign_campaignId" });
            DropColumn("dbo.EmailsFile", "Campaign_campaignId");
        }
    }
}
