namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudandoIdEscolaPasseio : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.passeios", "id_escola", "dbo.escolas");
            DropIndex("dbo.passeios", new[] { "id_escola" });
            AlterColumn("dbo.passeios", "id_escola", c => c.Int());
            CreateIndex("dbo.passeios", "id_escola");
            AddForeignKey("dbo.passeios", "id_escola", "dbo.escolas", "id_escola");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.passeios", "id_escola", "dbo.escolas");
            DropIndex("dbo.passeios", new[] { "id_escola" });
            AlterColumn("dbo.passeios", "id_escola", c => c.Int(nullable: false));
            CreateIndex("dbo.passeios", "id_escola");
            AddForeignKey("dbo.passeios", "id_escola", "dbo.escolas", "id_escola", cascadeDelete: true);
        }
    }
}
