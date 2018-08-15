namespace DBSystemTP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        DepartamentoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 100),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paises", t => t.PaisId, cascadeDelete: true)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Paises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TiposDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Direccion = c.String(nullable: false, maxLength: 100),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        NumeroIdentificacion = c.String(nullable: false, maxLength: 10, unicode: false),
                        Ciudade_Id = c.Int(),
                        TiposDocumento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ciudades", t => t.Ciudade_Id)
                .ForeignKey("dbo.TiposDocumento", t => t.TiposDocumento_Id)
                .Index(t => t.Ciudade_Id)
                .Index(t => t.TiposDocumento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "TiposDocumento_Id", "dbo.TiposDocumento");
            DropForeignKey("dbo.Usuarios", "Ciudade_Id", "dbo.Ciudades");
            DropForeignKey("dbo.Ciudades", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Departamentos", "PaisId", "dbo.Paises");
            DropIndex("dbo.Usuarios", new[] { "TiposDocumento_Id" });
            DropIndex("dbo.Usuarios", new[] { "Ciudade_Id" });
            DropIndex("dbo.Departamentos", new[] { "PaisId" });
            DropIndex("dbo.Ciudades", new[] { "DepartamentoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.TiposDocumento");
            DropTable("dbo.Paises");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Ciudades");
        }
    }
}
