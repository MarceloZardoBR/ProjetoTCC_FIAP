namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pagamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pagamento",
                c => new
                    {
                        id_pagamento = c.Int(nullable: false, identity: true),
                        titular = c.String(),
                        numero_cartao = c.String(),
                        validade = c.String(),
                        codigo = c.String(),
                        id_escola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_pagamento);
            
            AddColumn("dbo.passeiosEscolas", "id_pagamento", c => c.Int(nullable: false));
            DropColumn("dbo.passeiosEscolas", "id_escola");
        }
        
        public override void Down()
        {
            AddColumn("dbo.passeiosEscolas", "id_escola", c => c.Int(nullable: false));
            DropColumn("dbo.passeiosEscolas", "id_pagamento");
            DropTable("dbo.pagamento");
        }
    }
}
