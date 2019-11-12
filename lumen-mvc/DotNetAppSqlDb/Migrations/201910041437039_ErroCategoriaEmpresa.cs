namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErroCategoriaEmpresa : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.categoriaEmpresa", newName: "categoriaPasseio");
            CreateIndex("dbo.passeios", "idCategoria");
            AddForeignKey("dbo.passeios", "idCategoria", "dbo.categoriaPasseio", "idCategoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.passeios", "idCategoria", "dbo.categoriaPasseio");
            DropIndex("dbo.passeios", new[] { "idCategoria" });
            RenameTable(name: "dbo.categoriaPasseio", newName: "categoriaEmpresa");
        }
    }
}
