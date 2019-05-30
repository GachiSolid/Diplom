namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditBanks", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditBanks", "Status", c => c.String());
        }
    }
}
