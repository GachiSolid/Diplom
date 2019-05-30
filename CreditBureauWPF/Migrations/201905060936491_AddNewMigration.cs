namespace CreditBureauWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditBanks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Bank = c.String(),
                        Sum = c.Int(nullable: false),
                        Percent = c.Int(nullable: false),
                        Begin = c.DateTime(),
                        Mounth = c.Int(nullable: false),
                        Status = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Passport = c.String(),
                        Familiya = c.String(),
                        Name = c.String(),
                        Otchestvo = c.String(),
                        Gender = c.String(),
                        UpdateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Name = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.Login);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditBanks", "PersonId", "dbo.People");
            DropIndex("dbo.CreditBanks", new[] { "PersonId" });
            DropTable("dbo.Users");
            DropTable("dbo.People");
            DropTable("dbo.CreditBanks");
        }
    }
}
