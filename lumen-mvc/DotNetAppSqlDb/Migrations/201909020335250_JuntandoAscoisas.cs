namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JuntandoAscoisas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos");
            DropIndex("dbo.empresas", new[] { "Endereco_IdEndereco" });
            AddColumn("dbo.empresas", "idCurso", c => c.Int(nullable: false));
            AddColumn("dbo.empresas", "idEnderecoo", c => c.Int(nullable: false));
            AlterColumn("dbo.alunos", "Turma", c => c.String());
            DropColumn("dbo.empresas", "Endereco_IdEndereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.empresas", "Endereco_IdEndereco", c => c.Int());
            AlterColumn("dbo.alunos", "Turma", c => c.String(nullable: false));
            DropColumn("dbo.empresas", "idEnderecoo");
            DropColumn("dbo.empresas", "idCurso");
            CreateIndex("dbo.empresas", "Endereco_IdEndereco");
            AddForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos", "id_end");
        }
    }
}
