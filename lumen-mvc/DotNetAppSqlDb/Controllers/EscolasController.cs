using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using Newtonsoft.Json;

namespace DotNetAppSqlDb.Controllers
{
    public class EscolasController : Controller
    {
        //private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Escolas
        //public ActionResult Index()
        //{
        //    return View(db.Escola.ToList());
        //}

        public ActionResult MainPage(Escola escola)
        {

            if (escola != null)
            {
                Session["EscolaLogada"] = escola;
                return View("MainPage");
            }
            else {

                TempData["Mensagem"] = "Sua Sessão Expirou, Por Favor Efetue o Login Novamente";
                return View("LoginEscola");
            }
            
        }

        public ActionResult Passeios() {

            Escola escolaModel = (Escola) Session["EscolaLogada"];
            PasseioEscolaBusiness passeEscoBusiness = new PasseioEscolaBusiness();
            
            if(passeEscoBusiness.VerificaEscolaPossuiPasseio(escolaModel) != true)
            {
                IList<Passeio> listaPasseio = new PasseioDAO().ListaPasseios().Where(p => p.IdEscola == null).ToList();

                return View(listaPasseio);
            }
            else
            {
                TempData["Mensagem"] = "Você já possui um passeio pendente para ir!!";
                return RedirectToAction("MeusPasseios","Escolas", escolaModel);
            }
            

        }

        [HttpGet]
        public ActionResult Graficos(int id)
        {
            var alunos = new AlunoDAO().ListaAlunos().Where(a => a.IdEscola == id).ToList();

            var masculino = Math.Round(((double)alunos.Where(a => a.Genero == "Masculino").Count()/alunos.Count()) *100, 2);
            var feminino = Math.Round(((double)alunos.Where(a => a.Genero == "Feminino").Count()/ alunos.Count() )*100, 2);
            var indefinido = Math.Round(((double)alunos.Where(a => a.Genero == "Indefinido").Count()/ alunos.Count())*100, 2);

            var generoChart = new List<ChartData> { new ChartData { y = masculino, label = "Masculino" },
                new ChartData { y= feminino, label="Feminino"}, new ChartData{ y=indefinido, label= "Indefinido"} };

            var testes = new TesteDAO().ListaTestes();
            var testesfiltrados = testes.Where(t => alunos.Where(a => a.IdAluno == t.IdAluno).Count() > 0).ToList();


            //var nresponderam = Math.Round((double)(new TesteDAO().ListaTestes().Where(t => alunos.Where(a => a.IdAluno == t.IdAluno) is null).Count() / alunos.Count()) *100, 2);
            var responderam = Math.Round(((double)testesfiltrados.Count() / alunos.Count()) *100, 2);
            var nresponderam = 100 - responderam;

            var testeChart = new List<ChartData> { new ChartData { y = nresponderam, label = "Não responderam" }, new ChartData { y = responderam, label = "Respoderam" } };

            var categorias = new MyDatabaseContext().Categoria.ToList();
            var resultados = new MyDatabaseContext().Resultado.ToList().Where(r => testesfiltrados.Where(t => t.IdResultado == r.IdResposta).Count() > 0);
            var barChart = new List<ChartData>();
            var bar1 = new ChartData();
            var bar2 = new ChartData();
            var bar3 = new ChartData();
            var bar4 = new ChartData();
            var bar5 = new ChartData();
            var bar6 = new ChartData();
            foreach (var r in resultados) {
                var i = 1;
                foreach (var c in categorias) {
                    
                    switch (i)
                    {
                        case 1:
                            bar1.y = bar1.y + r.Categoria1;
                            bar1.label = c.NomeCategoria;
                            break;
                        case 2:
                            bar2.y = bar2.y + r.Categoria2;
                            bar2.label = c.NomeCategoria;
                            break;
                        case 3:
                            bar3.y = bar3.y + r.Categoria3;
                            bar3.label = c.NomeCategoria;
                            break;
                        case 4:
                            bar4.y = bar4.y + r.Categoria4;
                            bar4.label = c.NomeCategoria;
                            break;
                        case 5:
                            bar5.y = bar5.y + r.Categoria5;
                            bar5.label = c.NomeCategoria;
                            break;
                        case 6:
                            bar6.y = bar6.y + r.Categoria6;
                            bar6.label = c.NomeCategoria;
                            break;
                        default:
                            break;
                    }
                    i++;
                    
                }
            }
            barChart.Add(bar1);
            barChart.Add(bar2);
            barChart.Add(bar3);
            barChart.Add(bar4);
            barChart.Add(bar5);
            barChart.Add(bar6);
            //IList<Passeio> listaPasseio = new List<Passeio>();
            //listaPasseio = new PasseioDAO().ListaPasseios();

            //IList<Escola> lista2 = new List<Escola>();

            //Escola escola1 = new Escola();
            //escola1.label = "Não sabem qual profissão se encaixam";
            //escola1.y = 80;
            //lista2.Add(escola1);

            //Escola escola2 = new Escola();
            //escola2.label = "Sabem qual profissão se encaixam";
            //escola2.y = 20;
            //lista2.Add(escola2);

            //foreach (var item in listaPasseio)
            //{
            //    item.label = item.Nome;
            //    item.y = item.QuantAlunos;
            //}

            ViewBag.Genero = JsonConvert.SerializeObject(generoChart);
            ViewBag.Teste = JsonConvert.SerializeObject(testeChart);
            ViewBag.Bar = JsonConvert.SerializeObject(barChart);
            //ViewBag.DataPoints = JsonConvert.SerializeObject(listaPasseio);
            return View();
        }
        
        [HttpGet]
        public ActionResult ConfirmaPasseio(int idPasseio, int idEscola)
        {
            TempData["Mensagem"] = "";
            ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(idPasseio);
            Session["EscolaLogada"] = new EscolaDAO().ConsultarPorID(idEscola);
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmaPasseio(PasseioEscola passeioEscola)
        {
            PasseioEscolaBusiness passeioEscolaB = new PasseioEscolaBusiness();
            Escola escola = new Escola();
            Passeio passeio = new Passeio();
            PasseioDAO passeioDAO = new PasseioDAO();
            escola = new EscolaDAO().ConsultarPorID(passeioEscola.idEscola);
            passeio = passeioDAO.BuscarPorId(passeioEscola.IdPasseio);

            if (passeioEscolaB.ConfirmarPasseio(passeioEscola) == true)
            {
                if(passeio.Confirmado != true)
                {
                    passeio.IdEscola = escola.IdEscola;
                    passeio.Confirmado = true;

                    passeioDAO.Editar(passeio);

                    return RedirectToAction("Pagamento", "Escolas", new { passeio.IdPasseio, escola.IdEscola });
                }
                else
                {
                    return RedirectToAction("Pagamento", "Escolas", new { passeio.IdPasseio, escola.IdEscola });
                }
                
               
            }
            else
            {
                ViewData["EscolaModel"] = passeioEscola.Escola;
                ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(passeioEscola.IdPasseio);
                return View("ConfirmaPasseio");
            }

        }

        [HttpGet]
        public ActionResult Pagamento(int idPasseio, int idEscola)
        {
            Escola escola = new EscolaDAO().ConsultarPorID(idEscola);
            ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(idPasseio);
            Session["EscolaLogada"] = new EscolaDAO().ConsultarPorID(idEscola);
            return View(new Pagamento());
        }

        [HttpPost]
        public ActionResult Pagamento(Pagamento pagamentoModel)
        {
            PagamentoDAO pagamentoDAO = new PagamentoDAO();
            pagamentoDAO.Inserir(pagamentoModel);

            Escola escolaModel = new EscolaDAO().ConsultarPorID(pagamentoModel.IdEscola);
            
            return View("MainPage",escolaModel);
        }

        [HttpGet]
        public ActionResult ConfirmaPagamento(int idPasseio, int idEscola)
        {
            ViewData["PasseioModel"] = new PasseioDAO().BuscarPorId(idPasseio);
            Session["EscolaLogada"] = new EscolaDAO().ConsultarPorID(idEscola);
            return View();
        }

        [HttpGet]
        public ActionResult MeusPasseios(Escola escola)
        {

            IList<Passeio> listaPasseio = new List<Passeio>();
            listaPasseio = new PasseioEscolaBusiness().PasseiosDaEscola(escola);

            if (listaPasseio != null)
            {
                ViewData["EscolaModel"] = escola;
                return View(listaPasseio);
            }
            else
            {
                ViewData["EscolaModel"] = escola;
                return View(listaPasseio);
            }

        }

        [HttpGet]
        public ActionResult MeusPasseiosRealizado(Escola escola)
        {

            IList<Passeio> listaPasseio = new List<Passeio>();
            listaPasseio = new PasseioEscolaBusiness().PasseiosConcluidoDaEscola(escola);

            if (listaPasseio != null)
            {
                ViewData["EscolaModel"] = escola;
                return View(listaPasseio);
            }
            else
            {
                TempData["Mensagem"] = "Você ainda não realizou nenhum passeio!!";
                ViewData["EscolaModel"] = escola;
                return View(listaPasseio);
            }
        }
        // GET: Escolas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = new EscolaDAO().ConsultarPorID(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        public ActionResult LoginEscola(Escola escolaModel)
        {

            MyDatabaseContext db = new MyDatabaseContext();

            if (escolaModel != null)
            {
                var vEscola = db.Escola.Where(p => p.Email.Equals(escolaModel.Email)).FirstOrDefault();
                if (vEscola != null)
                {
                    if (CriptografiaSenha.Compara(escolaModel.Senha, vEscola.Senha))
                    {
                        Session["EscolaLogada"] = vEscola;
                        return View("MainPage");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Usuario ou senha errada!";
                        return View("LoginEscola", vEscola);
                    }
                }
                else
                {
                    TempData["Mensagem"] = "Não há nenhuma conta registrada nesse email";
                    return View("LoginEscola", escolaModel);

                }
            }

            return View();
        }

        // GET: Escolas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEscola,Email,Telefone")] Escola escola)
        {
            if (ModelState.IsValid)
            {
                new EscolaDAO().Inserir(escola);
                return RedirectToAction("Index");
            }

            return View(escola);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                EscolaDAO dao = new EscolaDAO();
                Escola escola = dao.ConsultarPorID(id);
                return View(escola);
            }
            
        }


        [HttpPost]
        public ActionResult Edit(Escola escola)
        {
            EscolaDAO dao = new EscolaDAO();
            dao.Editar(escola);

            TempData["Mensagem"] = "Dados Atualizados Com Sucesso!!";
            return View("Edit");
        }

        // GET: Escolas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escola escola = new EscolaDAO().ConsultarPorID(id);
            if (escola == null)
            {
                return HttpNotFound();
            }
            return View(escola);
        }

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EscolaDAO escolaDAO = new EscolaDAO();
            Escola escola = escolaDAO.ConsultarPorID(id);

            escolaDAO.Excluir(escola.IdEscola);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public ActionResult CadastrarPasseio()
        {

            return View(new Passeio());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarPasseio([Bind(Include = "IdPasseio")] Passeio passeio)
        {

            if (ModelState.IsValid)
            {
                new PasseioDAO().Inserir(passeio);
                return View();
            }

            return View(passeio);

        }

        [HttpGet, ActionName("AddData")]
        public ActionResult AddData()
        {
            return PartialView("DataRow", new Models.DataDisponivel());
        }

        [HttpGet]
        public ActionResult EscolherPlano()
        {
            Escola e = (Escola)Session["EscolaLogada"];
            if (!(e is null) || e.IdEscola != 0)
            {
                var planos = new PlanoDAO().getAll();
                ViewBag.ListaPlanos = planos;
                return View((Escola)Session["EscolaLogada"]);
            }
            else
            {
                return View("Index");
            }
            
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            Session["EscolaLogada"] = null;
            return View("LoginEscola");
        }

    }
}
