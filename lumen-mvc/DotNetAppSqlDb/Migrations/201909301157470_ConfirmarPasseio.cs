namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfirmarPasseio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "confirmado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.passeios", "confirmado");
        }
    }
}
