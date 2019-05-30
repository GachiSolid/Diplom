namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "LastOnline", c => c.DateTime());
            DropColumn("dbo.Users", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
            DropColumn("dbo.Users", "LastOnline");
            DropColumn("dbo.Users", "IsAdmin");
        }
    }
}
