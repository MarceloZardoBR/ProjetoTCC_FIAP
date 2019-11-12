namespace DotNetAppSqlDb.Migrations
{
    using DotNetAppSqlDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Business;

    internal sealed class Configuration : DbMigrationsConfiguration<DotNetAppSqlDb.DAO.MyDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DotNetAppSqlDb.DAO.MyDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}
