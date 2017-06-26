namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataCorreta : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "DataEntrada", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "DataSaida", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "DataSaida", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Tickets", "DataEntrada", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
