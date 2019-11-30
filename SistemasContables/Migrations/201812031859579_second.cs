namespace SistemasContables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AsientoDiario", "Fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AsientoDiario", "Fecha", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
