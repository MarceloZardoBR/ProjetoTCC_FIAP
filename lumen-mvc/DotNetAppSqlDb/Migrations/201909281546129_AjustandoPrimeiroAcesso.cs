namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoPrimeiroAcesso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.alunos", "primeiroAcesso", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.alunos", "primeiroAcesso");
        }
    }
}
