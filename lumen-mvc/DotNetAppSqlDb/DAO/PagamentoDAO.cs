using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.DAO
{
    public class PagamentoDAO
    {

        public void Inserir(Pagamento pagamento)
        {
            using (MyDatabaseContext db = new MyDatabaseContext())
            {
                db.Pagamento.Add(pagamento);
                db.SaveChanges();
            }
        }

        public Pagamento BuscarPorId(int id)
        {
            return new MyDatabaseContext().Pagamento.Find(id);
        }

        public IList<Pagamento> ListarTodosPagamentos()
        {
            return new MyDatabaseContext().Pagamento.ToList<Pagamento>();
        }

        public Pagamento BuscarEscolaPorId(int idEscola)
        {
            MyDatabaseContext db = new MyDatabaseContext();
            return db.Pagamento.Where(model => model.IdEscola == idEscola).FirstOrDefault();
        }




    }
}