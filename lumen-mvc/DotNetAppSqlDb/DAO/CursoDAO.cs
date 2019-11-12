using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class CursoDAO
    {

        public IList<CursoModel> ListaCursos() {

            return new MyDatabaseContext().Cursos.ToList<CursoModel>();

        }

        public CursoModel BuscarPorID(int id)
        {
            return new MyDatabaseContext().Cursos.Find(id);
        }
    }
}