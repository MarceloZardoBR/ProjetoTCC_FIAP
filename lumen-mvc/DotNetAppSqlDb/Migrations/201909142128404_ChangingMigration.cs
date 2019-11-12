namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.passeiosAluno", "id_autorizacao", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.passeiosAluno", "id_autorizacao", c => c.Int());
        }
    }
}
