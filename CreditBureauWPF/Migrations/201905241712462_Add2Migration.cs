namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add2Migration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "UpdateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "UpdateTime", c => c.DateTime());
        }
    }
}
