using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class AreaBusiness
    {

        public Area InserirArea(Area area)
        {

            AreaDAO dao = new AreaDAO();

            dao.Inserir(area);

            return area;

        }

    }
}