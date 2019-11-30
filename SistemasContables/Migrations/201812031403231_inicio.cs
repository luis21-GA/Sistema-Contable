namespace SistemasContables.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsientoDiario",
                c => new
                    {
                        idAsiento = c.Int(nullable: false, identity: true),
                        CodigoCuenta = c.Int(nullable: false),
                        CodigoCuenta1 = c.Int(nullable: false),
                        Debe1 = c.Double(nullable: false),
                        Haber1 = c.Double(nullable: false),
                        Debe2 = c.Double(nullable: false),
                        Haber2 = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                        DEscripcion = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.idAsiento)
                .ForeignKey("dbo.Cuentas", t => t.CodigoCuenta)
                .ForeignKey("dbo.Cuentas", t => t.CodigoCuenta1)
                .Index(t => t.CodigoCuenta)
                .Index(t => t.CodigoCuenta1);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        CodigoCuenta = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        Descripcion = c.String(maxLength: 250, unicode: false),
                        idCategoria = c.Int(nullable: false),
                        Cargos = c.Double(),
                        Abonos = c.Double(),
                    })
                .PrimaryKey(t => t.CodigoCuenta)
                .ForeignKey("dbo.Category", t => t.idCategoria)
                .Index(t => t.idCategoria);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 100, unicode: false),
                        descripcion = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.idCategoria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cuentas", "idCategoria", "dbo.Category");
            DropForeignKey("dbo.AsientoDiario", "CodigoCuenta1", "dbo.Cuentas");
            DropForeignKey("dbo.AsientoDiario", "CodigoCuenta", "dbo.Cuentas");
            DropIndex("dbo.Cuentas", new[] { "idCategoria" });
            DropIndex("dbo.AsientoDiario", new[] { "CodigoCuenta1" });
            DropIndex("dbo.AsientoDiario", new[] { "CodigoCuenta" });
            DropTable("dbo.Category");
            DropTable("dbo.Cuentas");
            DropTable("dbo.AsientoDiario");
        }
    }
}
