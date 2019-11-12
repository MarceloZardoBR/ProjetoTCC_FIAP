using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class EnderecoBusiness
    {

        public Endereco InserirEndereco(Endereco endereco)
        {

            EnderecoDAO dao = new EnderecoDAO();

            dao.Inserir(endereco);

            return endereco;

        }



    }
}