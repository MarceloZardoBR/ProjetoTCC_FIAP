using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.DAO
{
    public class PasseioAlunoDAO
    {

        public void Inserir(PasseioAluno passeioAluno)
        {
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                db.PasseioAluno.Add(passeioAluno);
                db.SaveChanges();

            }

        }

        public IList<PasseioAluno> ListarTodosPasseios()
        {
            return new MyDatabaseContext().PasseioAluno.ToList<PasseioAluno>();
        }

    }
}