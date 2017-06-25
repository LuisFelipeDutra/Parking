namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false, maxLength: 7),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        SegundaVia = c.Boolean(nullable: false),
                        MotivoLiberacaoGeral = c.String(),
                        MotivoSegundaVia = c.String(),
                        Valor = c.Double(nullable: false),
                        Liberado = c.Boolean(nullable: false),
                        VagaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Vagas", t => t.VagaID, cascadeDelete: true)
                .Index(t => t.VagaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "VagaID", "dbo.Vagas");
            DropIndex("dbo.Tickets", new[] { "VagaID" });
            DropTable("dbo.Tickets");
        }
    }
}
