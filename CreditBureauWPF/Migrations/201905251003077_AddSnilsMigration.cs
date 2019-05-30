namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSnilsMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Snils", c => c.String());
            DropColumn("dbo.People", "Passport");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Passport", c => c.String());
            DropColumn("dbo.People", "Snils");
        }
    }
}
