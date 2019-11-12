namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoCategoriaEmpresa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoriaEmpresa",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
            AddColumn("dbo.empresas", "idCategoria", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.empresas", "idCategoria");
            DropTable("dbo.categoriaEmpresa");
        }
    }
}
