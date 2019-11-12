namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefatorandoTudo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.empresas", "Senha", c => c.String());
            AddColumn("dbo.empresas", "Endereco_IdEndereco", c => c.Int());
            AddColumn("dbo.passeios", "data", c => c.String());
            AddColumn("dbo.passeios", "qtdAlunos", c => c.String());
            CreateIndex("dbo.empresas", "Endereco_IdEndereco");
            AddForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos", "id_end");
            DropColumn("dbo.empresas", "idCurso");
            DropColumn("dbo.empresas", "idEnderecoo");
            DropColumn("dbo.passeios", "qtd_alunos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.passeios", "qtd_alunos", c => c.Int(nullable: false));
            AddColumn("dbo.empresas", "idEnderecoo", c => c.Int(nullable: false));
            AddColumn("dbo.empresas", "idCurso", c => c.Int(nullable: false));
            DropForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos");
            DropIndex("dbo.empresas", new[] { "Endereco_IdEndereco" });
            DropColumn("dbo.passeios", "qtdAlunos");
            DropColumn("dbo.passeios", "data");
            DropColumn("dbo.empresas", "Endereco_IdEndereco");
            DropColumn("dbo.empresas", "Senha");
        }
    }
}
