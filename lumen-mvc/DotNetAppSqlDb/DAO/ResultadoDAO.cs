using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.Models;
using DotNetAppSqlDb.Business;

namespace DotNetAppSqlDb.DAO
{
    public class ResultadoDAO
    {

        public void Inserir(ResultadoModel resultadoModel)
        {
            
            using (MyDatabaseContext dbx = new MyDatabaseContext())
            {
                dbx.Resultado.Add(resultadoModel);
                dbx.SaveChanges();
            }
        }

        public ResultadoModel ConsultarResultado(int id)
        {
            return new MyDatabaseContext().Resultado.Find(id);
        }

    }
}