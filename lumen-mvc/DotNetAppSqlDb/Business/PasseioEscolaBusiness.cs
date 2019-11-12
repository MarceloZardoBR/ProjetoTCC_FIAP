using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetAppSqlDb.Business
{
    public class PasseioEscolaBusiness
    {

        public Boolean ConfirmarPasseio(PasseioEscola passeioEscola)
        {
            PasseioEscolaDAO passeioEscolaDAO = new PasseioEscolaDAO();
            if (passeioEscola != null)
            {
                passeioEscolaDAO.Inserir(passeioEscola);
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean VerificaEscolaPossuiPasseio(Escola _escola)
        {
            IList<Passeio> listaPass = new PasseioDAO().ListaPasseios();

            foreach (var item in listaPass)
            {

                if(item.IdEscola == _escola.IdEscola && item.PasseioRealizado == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public IList<Passeio> PasseiosDaEscola(Escola escola)
        {
            Pagamento pagamento = new PagamentoDAO().BuscarEscolaPorId(escola.IdEscola);
            PasseioEscolaDAO dao = new PasseioEscolaDAO();
            IList<Passeio> listaPasseios = new List<Passeio>();

            if (pagamento != null)
            {
                IList<PasseioEscola> listaPasseiosEscola = new List<PasseioEscola>();
                listaPasseiosEscola = dao.ListarTodosPasseios().Where(p => p.idEscola == pagamento.IdEscola).ToList();

                foreach (var item in listaPasseiosEscola)
                {
                    listaPasseios.Add(new PasseioDAO().BuscarPorId(item.IdPasseio));
                }

                return listaPasseios.Where(p => p.PasseioRealizado != true).ToList();
            }
            else
            {
                return listaPasseios.Where(p => p.PasseioRealizado != true).ToList();
            }

        }


        public IList<Passeio> PasseiosConcluidoDaEscola(Escola escola)
        {
            Pagamento pagamento = new PagamentoDAO().BuscarEscolaPorId(escola.IdEscola);
            PasseioEscolaDAO dao = new PasseioEscolaDAO();
            IList<Passeio> listaPasseios = new List<Passeio>();

                IList<PasseioEscola> listaPasseiosEscola = new List<PasseioEscola>();
                listaPasseiosEscola = dao.ListarTodosPasseios().Where(p => p.idEscola == pagamento.IdEscola).ToList();

                foreach (var item in listaPasseiosEscola)
                {
                    listaPasseios.Add(new PasseioDAO().BuscarPorId(item.IdPasseio));
                }

                return listaPasseios.Where(p => p.PasseioRealizado == true).ToList();
        }
    }
}