namespace HeroProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hero",
                c => new
                    {
                        HeroId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 25),
                        Ability = c.String(nullable: false, maxLength: 10),
                        StartDate = c.DateTime(nullable: false),
                        SuitColors = c.String(nullable: false, maxLength: 10),
                        StartingPower = c.Decimal(precision: 18, scale: 2),
                        CurrentPower = c.Decimal(precision: 18, scale: 2),
                        TrainerId = c.Int(),
                    })
                .PrimaryKey(t => t.HeroId)
                .ForeignKey("dbo.Trainer", t => t.TrainerId)
                .Index(t => t.TrainerId);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 25),
                        Email = c.String(nullable: false, maxLength: 25),
                        SecretPassword = c.String(nullable: false, maxLength: 8),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hero", "TrainerId", "dbo.Trainer");
            DropIndex("dbo.Hero", new[] { "TrainerId" });
            DropTable("dbo.Trainer");
            DropTable("dbo.Hero");
        }
    }
}
