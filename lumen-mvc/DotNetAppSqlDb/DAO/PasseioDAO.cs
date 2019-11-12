using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class PasseioDAO
    {

        MyDatabaseContext DBContext = new MyDatabaseContext();

        public void Inserir(Passeio passeio)
        {
            using (DBContext)
            {
                DBContext.Passeio.Add(passeio);
                DBContext.SaveChanges();
            }

        }

        public void Editar(Passeio passeio)
        {

            using (DBContext)
            {
                DBContext.Entry(passeio).State = System.Data.Entity.EntityState.Modified;
                DBContext.SaveChanges();
            }

        }

        public IList<Passeio> ListaPasseios()
        {
            return DBContext.Passeio.ToList();
        }

        public Passeio BuscarPorId(int id)
        {
            return DBContext.Passeio.Find(id);
        }

        public Passeio BuscarEmpresaPorId(int idEmpresa)
        {
            
            return DBContext.Passeio.Where(model => model.IdEmpresa == idEmpresa).FirstOrDefault();
        }

        //public void UpdatePasseio(Passeio passeio)
        //{
        //    using (MyDatabaseContext db = new MyDatabaseContext())
        //    {
        //        db.Entry(passeio).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //    }
        //}
    }
}