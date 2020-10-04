namespace MailingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campaignUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Email", "Campaign_campaignId", c => c.Int());
            CreateIndex("dbo.Email", "Campaign_campaignId");
            AddForeignKey("dbo.Email", "Campaign_campaignId", "dbo.Campaign", "campaignId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Email", "Campaign_campaignId", "dbo.Campaign");
            DropIndex("dbo.Email", new[] { "Campaign_campaignId" });
            DropColumn("dbo.Email", "Campaign_campaignId");
        }
    }
}
