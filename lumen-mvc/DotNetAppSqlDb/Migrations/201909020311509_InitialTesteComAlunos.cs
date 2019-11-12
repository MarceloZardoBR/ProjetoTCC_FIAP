namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTesteComAlunos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.alunos", "Turma", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.alunos", "Turma");
        }
    }
}
