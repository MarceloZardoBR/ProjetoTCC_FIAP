namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizandoPasseios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "id_empresa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.passeios", "id_empresa");
        }
    }
}
