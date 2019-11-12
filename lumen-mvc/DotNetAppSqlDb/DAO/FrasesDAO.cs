using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.DAO
{
    public class FrasesDAO
    {
        public IList<FrasesModel> ListarTodas()
        {
            return new MyDatabaseContext().Frases.ToList<FrasesModel>();
        }

    }
}