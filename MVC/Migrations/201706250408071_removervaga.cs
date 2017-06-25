namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removervaga : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Vagas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        VagasID = c.Int(nullable: false, identity: true),
                        Ocupada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VagasID);
            
        }
    }
}
