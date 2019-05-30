namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add1Migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CreditBanks", "Mounth", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CreditBanks", "Mounth", c => c.Int(nullable: false));
        }
    }
}
