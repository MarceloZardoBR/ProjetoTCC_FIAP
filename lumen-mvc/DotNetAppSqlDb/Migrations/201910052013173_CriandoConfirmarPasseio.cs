namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoConfirmarPasseio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeios", "passeioRealizado", c => c.Boolean(nullable: false));
            CreateIndex("dbo.passeios", "id_escola");
            AddForeignKey("dbo.passeios", "id_escola", "dbo.escolas", "id_escola", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.passeios", "id_escola", "dbo.escolas");
            DropIndex("dbo.passeios", new[] { "id_escola" });
            DropColumn("dbo.passeios", "passeioRealizado");
        }
    }
}
