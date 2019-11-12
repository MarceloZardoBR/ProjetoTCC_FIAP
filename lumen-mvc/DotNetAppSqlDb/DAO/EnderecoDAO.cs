using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class EnderecoDAO
    {
        public void Inserir(Endereco endereco)
        {

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {

                DBContext.Endereco.Add(endereco);
                DBContext.SaveChanges();
            }

        }

        public Endereco BuscarEnderecoPorId(int id)
        {
            return new MyDatabaseContext().Endereco.Find(id);
        }

        

    }
}