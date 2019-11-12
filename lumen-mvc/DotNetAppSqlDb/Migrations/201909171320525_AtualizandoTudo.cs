namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizandoTudo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.escolas", "Endereco_IdEndereco", "dbo.enderecos");
            DropIndex("dbo.escolas", new[] { "Endereco_IdEndereco" });
            AddColumn("dbo.escolas", "id_end", c => c.Int(nullable: false));
            DropColumn("dbo.escolas", "Endereco_IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.escolas", "Endereco_IdEndereco", c => c.Int());
            DropColumn("dbo.escolas", "id_end");
            CreateIndex("dbo.escolas", "Endereco_IdEndereco");
            AddForeignKey("dbo.escolas", "Endereco_IdEndereco", "dbo.enderecos", "id_end");
        }
    }
}
