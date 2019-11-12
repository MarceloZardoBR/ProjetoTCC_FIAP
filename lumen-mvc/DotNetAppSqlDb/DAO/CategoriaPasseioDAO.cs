using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class CategoriaPasseioDAO
    {

        public IList<CategoriaPasseio> ListaCategoria()
        {
            return new MyDatabaseContext().CategoriaPasseio.ToList<CategoriaPasseio>();
        }

    }
}