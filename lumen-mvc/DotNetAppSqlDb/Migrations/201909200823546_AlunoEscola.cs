namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlunoEscola : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.alunos", name: "Escola_IdEscola", newName: "id_escola");
            RenameIndex(table: "dbo.alunos", name: "IX_Escola_IdEscola", newName: "IX_id_escola");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.alunos", name: "IX_id_escola", newName: "IX_Escola_IdEscola");
            RenameColumn(table: "dbo.alunos", name: "id_escola", newName: "Escola_IdEscola");
        }
    }
}
