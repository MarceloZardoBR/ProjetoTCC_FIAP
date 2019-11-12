using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;
using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Filter;

namespace DotNetAppSqlDb.Controllers
{
    //[AcessoFilter]
    public class ResultadoController : Controller
    {

        TesteBusiness testeBusiness = new TesteBusiness();

        [HttpGet]
        public ActionResult Index()
        {
            ResultadoModel resultadoModel = new ResultadoModel();
            TestesModel testeModel = new TestesModel();
            TesteDAO testeDao = new TesteDAO();

            //if (Session["ResultadoModel"] != null)
            //{
            //    String resultado = Session["ResultadoModel"] as String;
            //}

            if (TempData.ContainsKey("ResultadoModel") && TempData.ContainsKey("AlunoModel"))
            {
                //String com as respostasUsuario

                Aluno alunoModel = TempData["AlunoModel"] as Aluno;
                String resultado = TempData["ResultadoModel"] as String;
                //Retornando um resultado model
                resultadoModel = testeBusiness.ResultadoTeste(resultado,alunoModel);

                testeModel.IdResultado = resultadoModel.IdResposta;
                testeModel.IdAluno = alunoModel.IdAluno;
                testeDao.Inserir(testeModel);
            }

            return View(resultadoModel);
        }

        [HttpGet]
        public ActionResult ExibirCurso(int id)
        {
          
            ResultadoDAO resultadoDao = new ResultadoDAO();
            RespostasBusiness repBusiness = new RespostasBusiness();
            ResultadoModel resultadoModel = new ResultadoModel();
            IList<CursoModel> cursos = new List<CursoModel>();

            //chart
            resultadoModel = resultadoDao.ConsultarResultado(id);
            //Enviando Model dos Cursos

            
            ViewData["ResultadoModel"] = resultadoModel;
            cursos = repBusiness.ResultadoCursos(resultadoModel);

            ViewData["ListaPasseios"] = new PasseioAlunoBusiness().ListaPasseioCategoria(cursos);

            return View(cursos);   
        }

        
        public ActionResult VerificaAutorizacao(int idPasseio, int idAluno)
        {
            Autorizacao autorizacao = new Autorizacao();

            autorizacao = new AutorizacaoBusiness().VerificaAutorizacao(idAluno);

            if (autorizacao != null)
            {
                return RedirectToAction("ConfirmarPasseio","Resultado", new { autorizacao.IdAutorizacao, idPasseio });
            }
            else
            {
                TempData["Mensagem"] = "É necessário enviar uma autorização para os passeios!!";
                TempData["IdAluno"] = idAluno;
                return RedirectToAction("AutorizacaoPasseio", "Aluno", new Autorizacao());
            }
            
        }

        [HttpGet]
        public ActionResult ConfirmarPasseio(int idAutorizacao, int idPasseio)
        {
            ViewData["AutorizacaoModel"] = new AutorizacaoDAO().BuscarPorId(idAutorizacao);
            ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(idPasseio);
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmarPasseio(PasseioAluno passeioAluno)
        {
            PasseioAlunoBusiness passeioAlunoB = new PasseioAlunoBusiness();
            Autorizacao autorizacaoModel = new AutorizacaoDAO().BuscarPorId(passeioAluno.IdAutorizacao);
            
            if (passeioAlunoB.ConfirmarPasseio(passeioAluno) == true)
            {
                TempData["Mensagem"] = "Passeio Confirmado com Sucesso";
                Aluno aluno = new Aluno();
                aluno = new AlunoDAO().BuscarAlunoId(autorizacaoModel.IdAluno);
                return RedirectToAction("IndexAluno", "Aluno", aluno);
            }
            else
            {
                TempData["Mensagem"] = "Houve um erro ao confirmar o Passeio!!";
                ViewData["AutorizacaoModel"] = passeioAluno.Autorizacao;
                ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(passeioAluno.IdPasseio);
                return View("ConfirmarPasseio");
            }

        }


        [HttpGet]
        public ActionResult SelecionarPasseio(int id, ResultadoModel resultadoModel)
        {

            PasseioAlunoDAO passeioAlunoDAO = new PasseioAlunoDAO();
            PasseioAluno passeio = new PasseioAluno
            {
                IdPasseio = id,
                //IdAluno = resultadoModel.IdAluno,
                
            };

            passeioAlunoDAO.Inserir(passeio);

            return RedirectToAction("Index","Aluno");
        }
    }
}