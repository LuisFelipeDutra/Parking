namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disponiveis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vagas", "Disponiveis", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vagas", "Disponiveis");
        }
    }
}
