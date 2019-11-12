using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class PlanoDAO
    {
        public List<Plano> getAll()
        {
            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                return DBContext.Plano.ToList();
            }
        }
    }
}