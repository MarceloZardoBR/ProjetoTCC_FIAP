using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class PasseioEscolaDAO
    {
        public void Inserir(PasseioEscola passeioEscola)
        {
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                db.PasseioEscola.Add(passeioEscola);
                db.SaveChanges();

            }

        }

        public IList<PasseioEscola> ListarTodosPasseios()
        {
            return new MyDatabaseContext().PasseioEscola.ToList<PasseioEscola>();
        }

    }
}