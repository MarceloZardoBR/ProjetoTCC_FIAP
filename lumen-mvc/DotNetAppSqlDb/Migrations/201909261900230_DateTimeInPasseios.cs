namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeInPasseios : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.passeios", "data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.passeios", "data", c => c.String());
        }
    }
}
