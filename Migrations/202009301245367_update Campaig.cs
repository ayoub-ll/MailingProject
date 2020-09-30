namespace MailingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCampaig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaign", "name", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaign", "name");
        }
    }
}
