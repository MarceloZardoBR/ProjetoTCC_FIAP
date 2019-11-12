using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class EmpresaDAO
    {
        public Empresa ConsultarPorId(int Id)
        {
            return new MyDatabaseContext().Empresa.Find(Id);
        }

        public void Inserir(Empresa empresa)
        {
            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Empresa.Add(empresa);
                DBContext.SaveChanges();
            }

        }

        public void Editar(Empresa empresa)
        {

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Entry(empresa).State = System.Data.Entity.EntityState.Modified;
                DBContext.SaveChanges();
            }

        }

        public void Excluir(int Id)
        {
            var Produto = new Empresa { IdEmpresa = Id };

            using (MyDatabaseContext DBContext = new MyDatabaseContext())
            {
                DBContext.Empresa.Attach(Produto);
                DBContext.Empresa.Remove(Produto);
                DBContext.SaveChanges();
            }
        }
    }
}