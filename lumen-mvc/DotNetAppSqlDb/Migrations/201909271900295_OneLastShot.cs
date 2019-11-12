namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneLastShot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.passeiosEscolas", "id_escola", c => c.Int(nullable: false));
            DropColumn("dbo.passeiosEscolas", "id_pagamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.passeiosEscolas", "id_pagamento", c => c.Int(nullable: false));
            DropColumn("dbo.passeiosEscolas", "id_escola");
        }
    }
}
