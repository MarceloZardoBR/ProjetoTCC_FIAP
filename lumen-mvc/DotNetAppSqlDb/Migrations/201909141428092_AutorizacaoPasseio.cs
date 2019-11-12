namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutorizacaoPasseio : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.passeios_x_alunos", "id_autorizacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.passeios_x_alunos", "id_autorizacao", c => c.Int());
        }
    }
}
