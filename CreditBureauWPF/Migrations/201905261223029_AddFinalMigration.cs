namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinalMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Date");
        }
    }
}
