namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JuntandoMatheusMarcelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.passeiosEscolas",
                c => new
                    {
                        id_passeioEscola = c.Int(nullable: false, identity: true),
                        id_escola = c.Int(nullable: false),
                        id_passeio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_passeioEscola);
            
            AddColumn("dbo.passeios", "valor", c => c.Double(nullable: false));
            AlterColumn("dbo.passeios", "qtdAlunos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.passeios", "qtdAlunos", c => c.String());
            DropColumn("dbo.passeios", "valor");
            DropTable("dbo.passeiosEscolas");
        }
    }
}
