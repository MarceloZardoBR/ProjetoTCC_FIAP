namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasseiosDoAluno : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.passeiosAluno", newName: "passeiosAlunos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.passeiosAlunos", newName: "passeiosAluno");
        }
    }
}
