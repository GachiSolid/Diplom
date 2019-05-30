namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditBanks", "Score", c => c.Int(nullable: false));
            AddColumn("dbo.CreditBanks", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CreditBanks", "Description");
            DropColumn("dbo.CreditBanks", "Score");
        }
    }
}
