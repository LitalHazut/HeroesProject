namespace HeroProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second_mig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hero", "Ability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hero", "Ability");
        }
    }
}
