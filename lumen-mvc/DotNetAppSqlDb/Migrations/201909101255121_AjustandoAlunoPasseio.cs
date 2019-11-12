namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjustandoAlunoPasseio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "Selecionado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.passeios", "Selecionado");
        }
    }
}
