using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class PagamentoBusiness
    {

        public Pagamento VerificarPagamento(int idEscola)
        {
            Pagamento pagamentoModel = new Pagamento();
            pagamentoModel = new PagamentoDAO().BuscarEscolaPorId(idEscola);

            return pagamentoModel;
        }

    }
}