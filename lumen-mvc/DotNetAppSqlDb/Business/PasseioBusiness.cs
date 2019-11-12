using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class PasseioBusiness
    {
        public Passeio InserirPasseio(Passeio passeio)
        {

            PasseioDAO dao = new PasseioDAO();

            dao.Inserir(passeio);

            return passeio;
        }

        public IList<Passeio> ListarTodosPasseios()
        {
            return new MyDatabaseContext().Passeio.ToList<Passeio>();
        }

        public IList<Passeio> PasseiosDaEmpresa(Empresa empresaModel)
        {
            Passeio passeio = new PasseioDAO().BuscarEmpresaPorId(empresaModel.IdEmpresa);
            PasseioBusiness business = new PasseioBusiness();
            IList<Passeio> listaPasseios = new List<Passeio>();

            if (passeio != null)
            {
                IList<Passeio> listaPasseiosEmpresa = new List<Passeio>();
                listaPasseiosEmpresa = business.ListarTodosPasseios().Where(p => p.IdEmpresa == passeio.IdEmpresa).ToList();
                foreach (var item in listaPasseiosEmpresa)
                {

                    listaPasseios.Add(new PasseioDAO().BuscarPorId(item.IdEmpresa));

                }

                return listaPasseiosEmpresa.Where(p => p.PasseioRealizado != true).ToList();

            }
            else
            {
                return listaPasseios;

            }

        }

    }
}