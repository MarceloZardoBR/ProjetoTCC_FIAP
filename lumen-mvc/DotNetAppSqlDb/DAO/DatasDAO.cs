using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.DAO;

namespace DotNetAppSqlDb.DAO
{
    public class DatasDAO
    {

    
        public List<DataDisponivel> GetDatasFromEmpresa(int id)
        {
            return new MyDatabaseContext().DataDisponivel.Where(d=> d.IdEmpresa == id).ToList();
        }

  

    }
}