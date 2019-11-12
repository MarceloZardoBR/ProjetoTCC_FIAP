using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Filter;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DotNetAppSqlDb.Controllers
{
    [LogFilter]
    public class AlunoController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Aluno alunoModel)
        {
            MyDatabaseContext Db = new MyDatabaseContext();

            if (alunoModel != null)
            {
                var vUsuario = Db.Aluno.Where(p => p.Email.Equals(alunoModel.Email)).FirstOrDefault();

                if (vUsuario != null)
                {
                    if (CriptografiaSenha.Compara(alunoModel.Senha, vUsuario.Senha))
                    {
                        if (vUsuario.PrimeiroAcesso == true && vUsuario.IdEscola != 0)
                        {
                            TempData["Mensagem"] = "Antes de prosseguir, é necessário efetuar a alteração da senha padrão que lhe foi dada.";
                            Session["AlunoLogado"] = vUsuario;
                            return RedirectToAction("AlterarSenha", "Aluno", vUsuario);
                        }
                        else
                        {
                            Session["AlunoLogado"] = vUsuario;
                            return View("AreaAluno");
                        }

                    }
                    else
                    {
                        TempData["Mensagem"] = "Usuario ou Senha Incorretos!!";
                        return View("Index", vUsuario);
                    }
                }
            }
            else
            {
                TempData["Mensagem"] = "Não há nenhuma conta registrada nesse email!!";
                return View("Index");
            }

            TempData["Mensagem"] = "Não há nenhuma conta registrada nesse email!!";
            return View("Index");
        }

        public ActionResult IndexAluno(Aluno aluno)
        {
            if (aluno != null)
            {
                Session["AlunoLogado"] = aluno;
                return View("AreaAluno");
            }
            else
            {
                TempData["Mensagem"] = "Sua Sessão Expirou, Por Favor Efetue o Login Novamente";
                return View("Index");
            }
        }

        [HttpGet]
        public ActionResult Registra()
        {
            return View(new Aluno());
        }

        [HttpPost]
        public ActionResult Registrar(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoDAO alunoDAO = new AlunoDAO();
                aluno.Senha = CriptografiaSenha.Codifica(aluno.Senha);
                aluno.PrimeiroAcesso = true;
                alunoDAO.Inserir(aluno);

                return View("CadastroSucesso");

            }
            else
            {
                return View("Index");
            }

        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                AlunoDAO dao = new AlunoDAO();
                Aluno alunoModel = dao.BuscarAlunoId(id);

                return View(alunoModel);
            }

        }

        [HttpPost]
        public ActionResult Editar(Aluno _aluno)
        {

            AlunoDAO alunoDAO = new AlunoDAO();
            alunoDAO.EditarAluno(_aluno);

            TempData["Mensagem"] = "Dados Atualizados Com Sucesso!!";
            return View("Editar");
        }

        [HttpGet]
        public ActionResult AutorizacaoPasseio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarAutorizacao(Autorizacao autorizacaoModel)
        {
            AutorizacaoDAO autorizacaoDAO = new AutorizacaoDAO();
            autorizacaoDAO.Inserir(autorizacaoModel);

            Aluno alunoModel = new AlunoDAO().BuscarAlunoId(autorizacaoModel.IdAluno);

            TempData["Mensagem"] = "Autorização Cadastrada Com Sucesso, agora você pode escolher um passeio";

            return RedirectToAction("IndexAluno", "Aluno", alunoModel);
        }

        [HttpGet]
        public ActionResult PasseiosAluno(Aluno aluno)
        {
            IList<Passeio> listaPasseio = new List<Passeio>();
            listaPasseio = new PasseioAlunoBusiness().PasseiosDoAluno(aluno);

            if (listaPasseio != null)
            {
                ViewData["AlunoModel"] = aluno;
                return View(listaPasseio);
            }
            else
            {
                ViewData["AlunoModel"] = aluno;
                TempData["Mensagem"] = "Você não possui nenhum passeio para ir";
                return View(listaPasseio);
            }

        }

        [HttpGet]
        public ActionResult AutorizacaoAluno(int idAluno)
        {
            Autorizacao autorizacao = new Autorizacao();
            autorizacao = new AutorizacaoDAO().BuscarPorAlunoId(idAluno);
            Aluno aluno = new AlunoDAO().BuscarAlunoId(idAluno);

            if (autorizacao == null)
            {
                TempData["Mensagem"] = "Envie uma autorização preenchida para participar dos passeios";
                ViewData["AlunoModel"] = aluno;
                return View("CadastrarAutorizacao", new Autorizacao());
            }
            else
            {
                return View(autorizacao);
            }
        }

        //editar autorizacao
        [HttpGet]
        public ActionResult EditarAutorizacao(int idAutorizacao)
        {
            return View(new AutorizacaoDAO().BuscarPorId(idAutorizacao));
        }

        [HttpPost]
        public ActionResult EditarAutorizacao(Autorizacao autorizacao)
        {
            new AutorizacaoDAO().EditarAutorizacao(autorizacao);

            return View("AutorizacaoAluno", autorizacao);
        }

        public ActionResult EscolaAdicionada(Aluno aluno)
        {
            if (!(aluno.IdEscola is null))
            {
                var escola = new EscolaDAO().ConsultarPorID(aluno.IdEscola);
                return View(escola);
            }
            else
            {
                return View("AdicionarEscola");
            }

        }

        [HttpPost]
        public ActionResult AdicionarEscola([Bind(Include = "codigo")] string codigo, Aluno _aluno)
        {
            try
            {
                Aluno a = (Aluno)Session["AlunoLogado"];

                if (!(a is null))
                {
                    if (!(a.IdEscola is null))
                    {
                        var escola = new EscolaDAO().ConsultarPorID(a.IdEscola);
                        return View("EscolaAdicionada", escola);
                    }
                    else
                    {
                        Aluno aluno = new AlunoDAO().BuscarAlunoId(_aluno.IdAluno);
                        aluno.IdEscola = Int32.Parse(Business.Base64Business.Base64Decode(codigo));
                        new AlunoDAO().EditarAluno(aluno);
                        Session["AlunoLogado"] = aluno;
                        return View("EscolaAdicionada");
                    }
                }
                else
                {
                    return View("Index");
                }


            }
            catch
            {
                TempData["Mensagem"] = "Codigo Inválido.";
                return View();
            }

        }

        [HttpGet]
        public ActionResult AdicionarEscola(Aluno a)
        {
            if (a.IdAluno == 0)
                a = (Aluno)Session["AlunoLogado"];

            if (!(a is null))
            {
                if (!(a.IdEscola is null || a.IdEscola == 0))
                {
                    var escola = new EscolaDAO().ConsultarPorID(a.IdEscola);
                    return View("EscolaAdicionada", escola);
                }
                else
                {
                    return View(Session["AlunoLogado"]);
                }
            }
            else
            {
                return View("Index");

            }

        }

        [HttpGet]
        public ActionResult Logoff()
        {
            Session.Clear();
            return View("Index");
        }

        [HttpGet]
        public ActionResult AlterarSenha(Aluno aluno)
        {

            if (aluno == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                string senhaPassada = aluno.Senha;
                ViewData["SenhaPassada"] = senhaPassada;
                return View(aluno);
            }

        }

        [HttpPost]
        public ActionResult MudarSenha(Aluno aluno)
        {
            AlunoDAO dao = new AlunoDAO();
            var _alunoModel = aluno;

            if (_alunoModel.SenhaAtual == null || _alunoModel.Senha == null)
            {
                TempData["Mensagem"] = "Não pode haver campos vazios!!";
                _alunoModel = new AlunoDAO().BuscarAlunoId(aluno.IdAluno);
                return RedirectToAction("AlterarSenha", "Aluno", _alunoModel);
            }
            else
            {

                if (CriptografiaSenha.Compara(_alunoModel.SenhaAtual, _alunoModel.SenhaPassada))
                {
                    _alunoModel.Senha = CriptografiaSenha.Codifica(_alunoModel.Senha);
                    if (_alunoModel.PrimeiroAcesso == true && _alunoModel.IdEscola != 0)
                    {
                        _alunoModel.PrimeiroAcesso = false;
                    }
                    dao.EditarAluno(_alunoModel);
                    TempData["Mensagem"] = "Senha Alterada Com Sucesso!!";
                    return View("AlterarSenha", _alunoModel);
                }
                else
                {
                    TempData["Mensagem"] = "Senha Atual Incorreta";
                    _alunoModel = new AlunoDAO().BuscarAlunoId(aluno.IdAluno);
                    return RedirectToAction("AlterarSenha", "Aluno", _alunoModel);
                }

            }
        }
    }
}