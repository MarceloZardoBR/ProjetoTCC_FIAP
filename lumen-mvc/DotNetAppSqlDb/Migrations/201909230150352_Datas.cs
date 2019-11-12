namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datas : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.datas_disponiveis", "id_empresa");
            AddForeignKey("dbo.datas_disponiveis", "id_empresa", "dbo.empresas", "id_empresa", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.datas_disponiveis", "id_empresa", "dbo.empresas");
            DropIndex("dbo.datas_disponiveis", new[] { "id_empresa" });
        }
    }
}
