using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;
using DotNetAppSqlDb.DAO;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.Filter;

namespace DotNetAppSqlDb.Controllers
{
    [AcessoFilter]
    public class VocacionalController : Controller
    {

        MyDatabaseContext db = new MyDatabaseContext();
        Aluno alunoModel = new Aluno();

        //testar removendo essa session
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["AlunoLogado"] != null)
            {
                alunoModel = Session["AlunoLogado"] as Aluno;

                TestesModel testeModel = db.Testes.Where(m => m.IdAluno == alunoModel.IdAluno).FirstOrDefault();

                if (testeModel != null)
                {
                    ResultadoDAO resultadoDAO = new ResultadoDAO();
                    ResultadoModel resultado = resultadoDAO.ConsultarResultado(testeModel.IdResultado);
                    //TempData["ResultadoModel"] = resultado;
                    int id = resultado.IdResposta;

                    return RedirectToAction("ExibirCurso", "Resultado", new { id = resultado.IdResposta});
                    //return View("ExibirCurso","Resultado", resultado.IdResposta);

                }
                else
                {
                    FrasesModel perguntas = new FrasesModel();
                    FrasesDAO dao = new FrasesDAO();
                    perguntas.ListaFrases = dao.ListarTodas();
                    //Caso não de, usar session
                    Session["AlunoLogado"] = alunoModel;
                    return View(perguntas);
                    

                }
            }
            else
            {
                TempData["Mensagem"] = "Sessão Expirada, efetue o login novamente!";
                return RedirectToAction("Index","Aluno");
            }
        }

        [AcessoFilter]
        [HttpPost]
        public ActionResult Enviar(FrasesModel model)
        {
            
            TesteBusiness testeBusiness = new TesteBusiness();
            var modelTeste = testeBusiness.EscolhasDoTeste(model);

            TempData["ResultadoModel"] = modelTeste;
            TempData["AlunoModel"] = Session["AlunoLogado"];
            //Session["ResultadoModel"] = modelTeste;

            return RedirectToAction("Index","Resultado");
        }
    }
}