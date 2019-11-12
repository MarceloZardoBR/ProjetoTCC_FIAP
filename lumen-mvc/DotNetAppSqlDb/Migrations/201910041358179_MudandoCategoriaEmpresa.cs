namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudandoCategoriaEmpresa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "idCategoria", c => c.Int(nullable: false));
            DropColumn("dbo.empresas", "idCategoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.empresas", "idCategoria", c => c.Int(nullable: false));
            DropColumn("dbo.passeios", "idCategoria");
        }
    }
}
