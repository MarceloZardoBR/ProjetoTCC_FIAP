namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinallyModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.alunos", "Passeio_IdPasseio", c => c.Int());
            AddColumn("dbo.enderecos", "Empresa_IdEmpresa", c => c.Int());
            AddColumn("dbo.frases", "FrasesModel_IdPergunta", c => c.Int());
            AddColumn("dbo.passeios", "label", c => c.String());
            AddColumn("dbo.passeios", "y", c => c.Int(nullable: false));
            AddColumn("dbo.passeios", "Passeio_IdPasseio", c => c.Int());
            AddColumn("dbo.teste", "ResultadoModel_IdResposta", c => c.Int());
            CreateIndex("dbo.alunos", "Passeio_IdPasseio");
            CreateIndex("dbo.autorizacoes", "id_aluno");
            CreateIndex("dbo.area_curso", "idCategoria");
            CreateIndex("dbo.enderecos", "Empresa_IdEmpresa");
            CreateIndex("dbo.frases", "idCategoria");
            CreateIndex("dbo.frases", "FrasesModel_IdPergunta");
            CreateIndex("dbo.pagamento", "id_escola");
            CreateIndex("dbo.passeios", "id_data_disponivel");
            CreateIndex("dbo.passeios", "Passeio_IdPasseio");
            CreateIndex("dbo.passeiosEscolas", "id_escola");
            CreateIndex("dbo.passeiosEscolas", "id_passeio");
            CreateIndex("dbo.resultado", "id_aluno");
            CreateIndex("dbo.teste", "idCurso");
            CreateIndex("dbo.teste", "id_aluno");
            CreateIndex("dbo.teste", "ResultadoModel_IdResposta");
            CreateIndex("dbo.usuario", "id_escola");
            CreateIndex("dbo.usuario", "id_empresa");
            AddForeignKey("dbo.autorizacoes", "id_aluno", "dbo.alunos", "id_aluno", cascadeDelete: true);
            AddForeignKey("dbo.area_curso", "idCategoria", "dbo.categorias", "idCategoria", cascadeDelete: true);
            AddForeignKey("dbo.enderecos", "Empresa_IdEmpresa", "dbo.empresas", "id_empresa");
            AddForeignKey("dbo.frases", "idCategoria", "dbo.categorias", "idCategoria", cascadeDelete: true);
            AddForeignKey("dbo.frases", "FrasesModel_IdPergunta", "dbo.frases", "idFrase");
            AddForeignKey("dbo.pagamento", "id_escola", "dbo.escolas", "id_escola", cascadeDelete: true);
            AddForeignKey("dbo.alunos", "Passeio_IdPasseio", "dbo.passeios", "id_passeio");
            AddForeignKey("dbo.passeios", "id_data_disponivel", "dbo.datas_disponiveis", "id_data_disponivel", cascadeDelete: true);
            AddForeignKey("dbo.passeios", "Passeio_IdPasseio", "dbo.passeios", "id_passeio");
            AddForeignKey("dbo.passeiosEscolas", "id_escola", "dbo.escolas", "id_escola", cascadeDelete: true);
            AddForeignKey("dbo.passeiosEscolas", "id_passeio", "dbo.passeios", "id_passeio", cascadeDelete: true);
            AddForeignKey("dbo.resultado", "id_aluno", "dbo.alunos", "id_aluno", cascadeDelete: true);
            AddForeignKey("dbo.teste", "id_aluno", "dbo.alunos", "id_aluno", cascadeDelete: true);
            AddForeignKey("dbo.teste", "idCurso", "dbo.area_curso", "idCurso", cascadeDelete: true);
            AddForeignKey("dbo.teste", "ResultadoModel_IdResposta", "dbo.resultado", "idResultado");
            AddForeignKey("dbo.usuario", "id_empresa", "dbo.empresas", "id_empresa", cascadeDelete: true);
            AddForeignKey("dbo.usuario", "id_escola", "dbo.escolas", "id_escola", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.usuario", "id_escola", "dbo.escolas");
            DropForeignKey("dbo.usuario", "id_empresa", "dbo.empresas");
            DropForeignKey("dbo.teste", "ResultadoModel_IdResposta", "dbo.resultado");
            DropForeignKey("dbo.teste", "idCurso", "dbo.area_curso");
            DropForeignKey("dbo.teste", "id_aluno", "dbo.alunos");
            DropForeignKey("dbo.resultado", "id_aluno", "dbo.alunos");
            DropForeignKey("dbo.passeiosEscolas", "id_passeio", "dbo.passeios");
            DropForeignKey("dbo.passeiosEscolas", "id_escola", "dbo.escolas");
            DropForeignKey("dbo.passeios", "Passeio_IdPasseio", "dbo.passeios");
            DropForeignKey("dbo.passeios", "id_data_disponivel", "dbo.datas_disponiveis");
            DropForeignKey("dbo.alunos", "Passeio_IdPasseio", "dbo.passeios");
            DropForeignKey("dbo.pagamento", "id_escola", "dbo.escolas");
            DropForeignKey("dbo.frases", "FrasesModel_IdPergunta", "dbo.frases");
            DropForeignKey("dbo.frases", "idCategoria", "dbo.categorias");
            DropForeignKey("dbo.enderecos", "Empresa_IdEmpresa", "dbo.empresas");
            DropForeignKey("dbo.area_curso", "idCategoria", "dbo.categorias");
            DropForeignKey("dbo.autorizacoes", "id_aluno", "dbo.alunos");
            DropIndex("dbo.usuario", new[] { "id_empresa" });
            DropIndex("dbo.usuario", new[] { "id_escola" });
            DropIndex("dbo.teste", new[] { "ResultadoModel_IdResposta" });
            DropIndex("dbo.teste", new[] { "id_aluno" });
            DropIndex("dbo.teste", new[] { "idCurso" });
            DropIndex("dbo.resultado", new[] { "id_aluno" });
            DropIndex("dbo.passeiosEscolas", new[] { "id_passeio" });
            DropIndex("dbo.passeiosEscolas", new[] { "id_escola" });
            DropIndex("dbo.passeios", new[] { "Passeio_IdPasseio" });
            DropIndex("dbo.passeios", new[] { "id_data_disponivel" });
            DropIndex("dbo.pagamento", new[] { "id_escola" });
            DropIndex("dbo.frases", new[] { "FrasesModel_IdPergunta" });
            DropIndex("dbo.frases", new[] { "idCategoria" });
            DropIndex("dbo.enderecos", new[] { "Empresa_IdEmpresa" });
            DropIndex("dbo.area_curso", new[] { "idCategoria" });
            DropIndex("dbo.autorizacoes", new[] { "id_aluno" });
            DropIndex("dbo.alunos", new[] { "Passeio_IdPasseio" });
            DropColumn("dbo.teste", "ResultadoModel_IdResposta");
            DropColumn("dbo.passeios", "Passeio_IdPasseio");
            DropColumn("dbo.passeios", "y");
            DropColumn("dbo.passeios", "label");
            DropColumn("dbo.frases", "FrasesModel_IdPergunta");
            DropColumn("dbo.enderecos", "Empresa_IdEmpresa");
            DropColumn("dbo.alunos", "Passeio_IdPasseio");
        }
    }
}
