using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class LogDAO
    {

        public void Inserir(Models.Log Log)
        {
            using (MyDatabaseContext ctx = new MyDatabaseContext())
            {
                ctx.Log.Add(Log);
                ctx.SaveChanges();
            }
        }
    }
}