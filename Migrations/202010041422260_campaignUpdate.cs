namespace MailingProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campaignUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        emailId = c.Int(nullable: false, identity: true),
                        email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.emailId);
            
            CreateTable(
                "dbo.EmailsFile",
                c => new
                    {
                        emailsFileId = c.Int(nullable: false, identity: true),
                        path = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.emailsFileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailsFile");
            DropTable("dbo.Email");
        }
    }
}
