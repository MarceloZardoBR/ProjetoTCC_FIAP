namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Passeios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "qtd_alunos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.passeios", "qtd_alunos");
        }
    }
}
