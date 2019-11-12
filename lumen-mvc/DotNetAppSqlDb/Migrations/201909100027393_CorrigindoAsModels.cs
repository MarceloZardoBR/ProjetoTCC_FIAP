namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoAsModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.autorizacoes", "Aluno_IdAluno", "dbo.alunos");
            DropForeignKey("dbo.empresas", "AreaDeAtuacao_IdArea", "dbo.areas");
            DropForeignKey("dbo.datas_disponiveis", "Empresa_IdEmpresa", "dbo.empresas");
            DropForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos");
            DropForeignKey("dbo.PlanoEscolas", "Plano_IdPlano", "dbo.planos");
            DropForeignKey("dbo.PlanoEscolas", "Escola_IdEscola", "dbo.escolas");
            DropForeignKey("dbo.passeios_x_alunos", "Aluno_IdAluno", "dbo.alunos");
            DropForeignKey("dbo.passeios_x_alunos", "Autorizacao_IdAutorizacao", "dbo.autorizacoes");
            DropForeignKey("dbo.passeios_x_alunos", "Passeio_IdPasseio", "dbo.passeios");
            DropForeignKey("dbo.usuario", "Empresa_IdEmpresa", "dbo.empresas");
            DropForeignKey("dbo.usuario", "Escola_IdEscola", "dbo.escolas");
            DropIndex("dbo.autorizacoes", new[] { "Aluno_IdAluno" });
            DropIndex("dbo.datas_disponiveis", new[] { "Empresa_IdEmpresa" });
            DropIndex("dbo.empresas", new[] { "AreaDeAtuacao_IdArea" });
            DropIndex("dbo.empresas", new[] { "Endereco_IdEndereco" });
            DropIndex("dbo.passeios_x_alunos", new[] { "Aluno_IdAluno" });
            DropIndex("dbo.passeios_x_alunos", new[] { "Autorizacao_IdAutorizacao" });
            DropIndex("dbo.passeios_x_alunos", new[] { "Passeio_IdPasseio" });
            DropIndex("dbo.usuario", new[] { "Empresa_IdEmpresa" });
            DropIndex("dbo.usuario", new[] { "Escola_IdEscola" });
            DropIndex("dbo.PlanoEscolas", new[] { "Plano_IdPlano" });
            DropIndex("dbo.PlanoEscolas", new[] { "Escola_IdEscola" });
            AddColumn("dbo.autorizacoes", "id_aluno", c => c.Int(nullable: false));
            AddColumn("dbo.datas_disponiveis", "id_empresa", c => c.Int(nullable: false));
            AddColumn("dbo.empresas", "id_area", c => c.Int(nullable: false));
            AddColumn("dbo.empresas", "id_end", c => c.Int(nullable: false));
            AddColumn("dbo.planos", "Escola_IdEscola", c => c.Int());
            AddColumn("dbo.passeios_x_alunos", "id_aluno", c => c.Int(nullable: false));
            AddColumn("dbo.passeios_x_alunos", "id_autorizacao", c => c.Int(nullable: false));
            AddColumn("dbo.passeios_x_alunos", "id_passeio", c => c.Int(nullable: false));
            AddColumn("dbo.usuario", "id_escola", c => c.Int(nullable: false));
            AddColumn("dbo.usuario", "id_empresa", c => c.Int(nullable: false));
            CreateIndex("dbo.planos", "Escola_IdEscola");
            AddForeignKey("dbo.planos", "Escola_IdEscola", "dbo.escolas", "id_escola");
            DropColumn("dbo.autorizacoes", "Aluno_IdAluno");
            DropColumn("dbo.datas_disponiveis", "Empresa_IdEmpresa");
            DropColumn("dbo.empresas", "AreaDeAtuacao_IdArea");
            DropColumn("dbo.empresas", "Endereco_IdEndereco");
            DropColumn("dbo.passeios_x_alunos", "Aluno_IdAluno");
            DropColumn("dbo.passeios_x_alunos", "Autorizacao_IdAutorizacao");
            DropColumn("dbo.passeios_x_alunos", "Passeio_IdPasseio");
            DropColumn("dbo.usuario", "Empresa_IdEmpresa");
            DropColumn("dbo.usuario", "Escola_IdEscola");
            DropTable("dbo.PlanoEscolas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PlanoEscolas",
                c => new
                    {
                        Plano_IdPlano = c.Int(nullable: false),
                        Escola_IdEscola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Plano_IdPlano, t.Escola_IdEscola });
            
            AddColumn("dbo.usuario", "Escola_IdEscola", c => c.Int());
            AddColumn("dbo.usuario", "Empresa_IdEmpresa", c => c.Int());
            AddColumn("dbo.passeios_x_alunos", "Passeio_IdPasseio", c => c.Int());
            AddColumn("dbo.passeios_x_alunos", "Autorizacao_IdAutorizacao", c => c.Int());
            AddColumn("dbo.passeios_x_alunos", "Aluno_IdAluno", c => c.Int());
            AddColumn("dbo.empresas", "Endereco_IdEndereco", c => c.Int());
            AddColumn("dbo.empresas", "AreaDeAtuacao_IdArea", c => c.Int());
            AddColumn("dbo.datas_disponiveis", "Empresa_IdEmpresa", c => c.Int());
            AddColumn("dbo.autorizacoes", "Aluno_IdAluno", c => c.Int());
            DropForeignKey("dbo.planos", "Escola_IdEscola", "dbo.escolas");
            DropIndex("dbo.planos", new[] { "Escola_IdEscola" });
            DropColumn("dbo.usuario", "id_empresa");
            DropColumn("dbo.usuario", "id_escola");
            DropColumn("dbo.passeios_x_alunos", "id_passeio");
            DropColumn("dbo.passeios_x_alunos", "id_autorizacao");
            DropColumn("dbo.passeios_x_alunos", "id_aluno");
            DropColumn("dbo.planos", "Escola_IdEscola");
            DropColumn("dbo.empresas", "id_end");
            DropColumn("dbo.empresas", "id_area");
            DropColumn("dbo.datas_disponiveis", "id_empresa");
            DropColumn("dbo.autorizacoes", "id_aluno");
            CreateIndex("dbo.PlanoEscolas", "Escola_IdEscola");
            CreateIndex("dbo.PlanoEscolas", "Plano_IdPlano");
            CreateIndex("dbo.usuario", "Escola_IdEscola");
            CreateIndex("dbo.usuario", "Empresa_IdEmpresa");
            CreateIndex("dbo.passeios_x_alunos", "Passeio_IdPasseio");
            CreateIndex("dbo.passeios_x_alunos", "Autorizacao_IdAutorizacao");
            CreateIndex("dbo.passeios_x_alunos", "Aluno_IdAluno");
            CreateIndex("dbo.empresas", "Endereco_IdEndereco");
            CreateIndex("dbo.empresas", "AreaDeAtuacao_IdArea");
            CreateIndex("dbo.datas_disponiveis", "Empresa_IdEmpresa");
            CreateIndex("dbo.autorizacoes", "Aluno_IdAluno");
            AddForeignKey("dbo.usuario", "Escola_IdEscola", "dbo.escolas", "id_escola");
            AddForeignKey("dbo.usuario", "Empresa_IdEmpresa", "dbo.empresas", "id_empresa");
            AddForeignKey("dbo.passeios_x_alunos", "Passeio_IdPasseio", "dbo.passeios", "id_passeio");
            AddForeignKey("dbo.passeios_x_alunos", "Autorizacao_IdAutorizacao", "dbo.autorizacoes", "id_autorizacao");
            AddForeignKey("dbo.passeios_x_alunos", "Aluno_IdAluno", "dbo.alunos", "id_aluno");
            AddForeignKey("dbo.PlanoEscolas", "Escola_IdEscola", "dbo.escolas", "id_escola", cascadeDelete: true);
            AddForeignKey("dbo.PlanoEscolas", "Plano_IdPlano", "dbo.planos", "id_plano", cascadeDelete: true);
            AddForeignKey("dbo.empresas", "Endereco_IdEndereco", "dbo.enderecos", "id_end");
            AddForeignKey("dbo.datas_disponiveis", "Empresa_IdEmpresa", "dbo.empresas", "id_empresa");
            AddForeignKey("dbo.empresas", "AreaDeAtuacao_IdArea", "dbo.areas", "id_area");
            AddForeignKey("dbo.autorizacoes", "Aluno_IdAluno", "dbo.alunos", "id_aluno");
        }
    }
}
