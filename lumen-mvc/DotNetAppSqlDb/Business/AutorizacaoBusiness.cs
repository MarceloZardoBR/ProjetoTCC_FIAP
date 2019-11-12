using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.Models;
using DotNetAppSqlDb.DAO;

namespace DotNetAppSqlDb.Business
{
    public class AutorizacaoBusiness
    {

        public Autorizacao VerificaAutorizacao(int idAluno)
        {
            Autorizacao autorizacaoModel = new Autorizacao();
            autorizacaoModel = new AutorizacaoDAO().BuscarPorAlunoId(idAluno);

            return autorizacaoModel;
        }

    }
}