using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class AutorizacaoDAO
    {

        public void Inserir(Autorizacao autorizacao)
        {
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Autorizacao.Add(autorizacao);
                db.SaveChanges();
            }
        }

        public Autorizacao BuscarPorId(int id)
        {
            return new MyDatabaseContext().Autorizacao.Find(id);
        }

        public IList<Autorizacao> ListaTodasAutorizacao()
        {
            return new MyDatabaseContext().Autorizacao.ToList<Autorizacao>();
        }

        public Autorizacao BuscarPorAlunoId(int idAluno)
        {
            MyDatabaseContext db = new MyDatabaseContext();
            return db.Autorizacao.Where(model => model.IdAluno == idAluno).FirstOrDefault();
        }

        public void EditarAutorizacao(Autorizacao autorizacao)
        {
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Entry(autorizacao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}