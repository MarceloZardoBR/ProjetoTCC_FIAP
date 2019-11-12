using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetAppSqlDb.DAO;

namespace DotNetAppSqlDb.Business
{
    public class PasseioAlunoBusiness
    {

        public Boolean ConfirmarPasseio(PasseioAluno passeioAluno)
        {
            PasseioAlunoDAO passeioAlunoDAO = new PasseioAlunoDAO();
            if(passeioAluno != null)
            {
                passeioAlunoDAO.Inserir(passeioAluno);
                return true;
            }
            else
            {
                return false;
            }

        }

        public IList<Passeio> PasseiosDoAluno(Aluno aluno)
        {
            Autorizacao autorizacao = new AutorizacaoDAO().BuscarPorAlunoId(aluno.IdAluno);
            PasseioAlunoDAO dao = new PasseioAlunoDAO();
            IList<Passeio> listaPasseios = new List<Passeio>();

            if (autorizacao != null) { 
                IList<PasseioAluno> listaPasseiosAluno = new List<PasseioAluno>();
                listaPasseiosAluno = dao.ListarTodosPasseios().Where(p => p.IdAutorizacao == autorizacao.IdAutorizacao).ToList();

                foreach (var item in listaPasseiosAluno)
                {
                    listaPasseios.Add(new PasseioDAO().BuscarPorId(item.IdPasseio));
                }

                return listaPasseios;
            }
            else
            {
            return listaPasseios;
            }
        }

        public IList<Passeio> ListaPasseioCategoria(IList<CursoModel> cursos)
        {

            IList<Passeio> listaPasseio = new List<Passeio>();
            PasseioDAO passeioDAO = new PasseioDAO();

            if(cursos.First().IdCategoria == 1)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 1).ToList();
            }
            else if (cursos.First().IdCategoria == 2)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 2).ToList();
            }
            else if (cursos.First().IdCategoria == 3)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 6).ToList();
            }
            else if (cursos.First().IdCategoria == 4)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 5).ToList();
            }
            else if (cursos.First().IdCategoria == 5)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 3).ToList();
            }
            else if (cursos.First().IdCategoria == 6)
            {
                listaPasseio = passeioDAO.ListaPasseios().Where(p => p.IdCategoria == 4).ToList();
            }

            return listaPasseio;
        }
        

    }
}