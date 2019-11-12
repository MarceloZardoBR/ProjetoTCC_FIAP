using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.DAO;

namespace DotNetAppSqlDb.DAO
{
    public class AlunoDAO
    {

        public void Inserir(Aluno aluno)
        {
            using(MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
            }
        }

        public Aluno BuscarAlunoId(int id)
        {
            return new MyDatabaseContext().Aluno.Find(id);
        }

        public void EditarAluno(Aluno aluno)
        {
            using(MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Entry(aluno).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IList<Aluno> ListaAlunos()
        {
            return new MyDatabaseContext().Aluno.ToList();
        }
        
    }
}