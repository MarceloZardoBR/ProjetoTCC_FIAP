using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class AreaDAO
    {
        public void Inserir(Area area)
        {

            using(MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Area.Add(area);
                db.SaveChanges();
            }

        }

    }
}