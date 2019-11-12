namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterandoModels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.passeios_x_alunos", newName: "passeiosAluno");
            RenameColumn(table: "dbo.passeiosAluno", name: "id_passeio_aluno", newName: "id_passeioAluno");
            DropColumn("dbo.passeios", "Selecionado");
            DropColumn("dbo.passeiosAluno", "id_aluno");
        }
        
        public override void Down()
        {
            AddColumn("dbo.passeiosAluno", "id_aluno", c => c.Int(nullable: false));
            AddColumn("dbo.passeios", "Selecionado", c => c.Boolean(nullable: false));
            RenameColumn(table: "dbo.passeiosAluno", name: "id_passeioAluno", newName: "id_passeio_aluno");
            RenameTable(name: "dbo.passeiosAluno", newName: "passeios_x_alunos");
        }
    }
}
