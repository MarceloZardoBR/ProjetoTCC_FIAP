using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class EscolaDAO
    {

        public Escola ConsultarPorID(int id)
        {

            return new MyDatabaseContext().Escola.Find(id);

        }

        public void Inserir(Escola escola)
        {

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Escola.Add(escola);
                DBContext.SaveChanges();
            }

        }

        public void Editar(Escola escola)
        {

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Entry(escola).State = System.Data.Entity.EntityState.Modified;
                DBContext.SaveChanges();
            }

        }

        public void Excluir(int Id)
        {
            var Produto = new Escola { IdEscola = Id };

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Escola.Attach(Produto);
                DBContext.Escola.Remove(Produto);
                DBContext.SaveChanges();
            }
        }

        public Escola ConsultarPorID(int? id)
        {
            return new MyDatabaseContext().Escola.Find(id);
        }
    }
}