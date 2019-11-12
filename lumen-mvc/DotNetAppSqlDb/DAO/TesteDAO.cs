using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.DAO
{
    public class TesteDAO
    {

        public IList<TestesModel> ListaTestes()
        {
            return new MyDatabaseContext().Testes.ToList<TestesModel>();
        }

        public void Inserir(TestesModel teste) {

            using(MyDatabaseContext Dbx = new MyDatabaseContext())
            {
                Dbx.Testes.Add(teste);
                Dbx.SaveChanges();
            }
        }

        public TestesModel BuscarPorId(int id)
        {
            return new MyDatabaseContext().Testes.Find(id);
        }

    }
}