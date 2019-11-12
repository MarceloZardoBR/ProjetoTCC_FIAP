using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Filter;
using DotNetAppSqlDb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace DotNetAppSqlDb.Controllers
{
    public class EmpresasController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.Empresa.ToList());
        }

        //Abrir Perfil da Empresa, bem mockadao mesmo
        public ActionResult MainPage(Empresa empresa)
        {

            if (empresa != null)
            {
                Session["EmpresaLogada"] = empresa;
                return View("MainPage");
            }
            else
            {
                TempData["Mensagem"] = "Sua Sessão Expirou, Por Favor Efetue o Login Novamente";
                return View("LoginEmpresa");

            }
            
            
        }


        public ActionResult LoginEmpresa(Empresa empresaModel)
        {

            MyDatabaseContext db = new MyDatabaseContext();

            if (empresaModel != null)
            {

                var vEmpresa = db.Empresa.Where(p => p.Email.Equals(empresaModel.Email)).FirstOrDefault();

                if (vEmpresa != null)
                {
                    if (CriptografiaSenha.Compara(empresaModel.Senha, vEmpresa.Senha))
                    {

                        Session["EmpresaLogada"] = vEmpresa;
                        return View("MainPage");

                    }
                    else
                    {

                        TempData["Mensagem"] = "Usuario ou senha errada!";
                        return View("LoginEmpresa", vEmpresa);

                    }
                }
                else
                {
                    TempData["Mensagem"] = "Não há nenhuma conta registrada nesse email";
                    return View("LoginEmpresa", empresaModel);

                }
            }

            return View();

        }

        [HttpGet]
        public ActionResult Passeios(Empresa empresaModel)
        {

            IList<Passeio> listaPasseio = new List<Passeio>();
            listaPasseio = new PasseioBusiness().PasseiosDaEmpresa(empresaModel);

            if (listaPasseio != null)
            {
                ViewData["EmpresaModel"] = empresaModel;
                return View(listaPasseio);
            }
            else
            {
                ViewData["EmpresaModel"] = empresaModel;
                return View(listaPasseio);
            }

        }

        [HttpGet]
        public ActionResult PasseiosConfirmar(int id, Empresa empresa)
        {
            EmpresaDAO empaDao = new EmpresaDAO();
            empresa = empaDao.ConsultarPorId(id);
            IList<Passeio> passeios = db.Passeio
                .Where(p => p.IdEmpresa == empresa.IdEmpresa && p.IdEscola != 0 && p.Confirmado == true && p.PasseioRealizado == false)
                .ToList();
            return View(passeios);
        }

        
        //para ficar mias facil colocar um modal perguntando se quer confirmar mesmo o passeio e ao clicar nele chamar um fecth do js
        public ActionResult PasseioConfirmar(int id)
        {
            PasseioDAO passeioDAO = new PasseioDAO();

            Passeio passeio = passeioDAO.BuscarPorId(id);
            passeio.PasseioRealizado = true;

            passeioDAO.Editar(passeio);
            Empresa empresa = (Empresa) Session["EmpresaLogada"];
            IList<Passeio> passeios = passeioDAO.ListaPasseios().Where(p => p.IdEmpresa == passeio.IdEmpresa && p.IdEscola != 0).ToList();
            return View("PasseiosRealizados", empresa);
        }

        [HttpGet]
        public ActionResult PasseiosRealizados(Empresa empresa)
        {
            IList<Passeio> listaPasseiosRealizado = new PasseioDAO()
                .ListaPasseios()
                .Where(p => p.IdEmpresa == empresa.IdEmpresa && p.PasseioRealizado == true)
                .ToList();


            return View(listaPasseiosRealizado);
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            Empresa empresa = db.Empresa.Find(id);

            if (empresa != null)
            {
                Session["EmpresaLogada"] = empresa;
                return View("MainPage");
            }
            else
            {
                TempData["Mensagem"] = "Sua Sessão Expirou, Por Favor Efetue o Login Novamente";
                return View("LoginEmpresa");
            }

            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);*/
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
           
            return View(new Empresa());
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create([Bind(Include = "IdEmpresa,NomeEmpresa,Telefone,Email,Datas,Senha,IdCategoria")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        [HttpGet]
        public ActionResult CadastrarPasseio()
        {
            ViewBag.ListaCategoria = new CategoriaPasseioDAO().ListaCategoria();
            return View(new Passeio());
        }

        [HttpPost]
        public ActionResult CadastrarPasseio(Passeio passeio, int id)
        {
            if (ModelState.IsValid)
            {
                EmpresaDAO empDao = new EmpresaDAO();
                var empresa = empDao.ConsultarPorId(id);           
                passeio.IdEmpresa = empresa.IdEmpresa;
                passeio.Valor = passeio.QuantAlunos * 20;
                passeio.Confirmado = false;
                passeio.PasseioRealizado = false;
                PasseioDAO dao = new PasseioDAO();
                dao.Inserir(passeio);
                ViewBag.ListaCategoria = new CategoriaPasseioDAO().ListaCategoria();
                return View();
            }

            ViewBag.ListaCategoria = new CategoriaPasseioDAO().ListaCategoria();
            return View();

        }


        // GET: Empresas/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                EmpresaDAO dao = new EmpresaDAO();
                Empresa empresa = dao.ConsultarPorId(id);
                return View(empresa);
            }
            
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit(Empresa empresa)
        {
            EmpresaDAO dao = new EmpresaDAO();
            empresa.Senha = CriptografiaSenha.Codifica(empresa.Senha);
            dao.Editar(empresa);
            TempData["Mensagem"] = "Dados Atualizados Com Sucesso!!";
            return View("Edit");
        }

        [HttpPost]
        public ActionResult EditarPasseio(Passeio passeio)
        {
            PasseioDAO dao = new PasseioDAO();
            dao.Editar(passeio);
            TempData["Mensagem"] = "Dados Atualizados Com Sucesso!!";
            var passeios = dao.ListaPasseios().Where(p=>p.IdEmpresa == passeio.IdEmpresa).ToList();
            return View("Passeios",passeios);
        }

        [HttpGet]
        public ActionResult EditarPasseio(int id)
        {
            PasseioDAO dao = new PasseioDAO();
            Passeio passeio = dao.BuscarPorId(id);
            dao.Editar(passeio);
            return View("EditarPasseio", passeio);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
            db.SaveChanges();
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

        [HttpGet, ActionName("AddData")]
        public ActionResult AddData()
        {
            return PartialView("DataRow", new Models.DataDisponivel());
        }

        [HttpGet]
        public ActionResult Logoff()
        {
            Session["EmpresaLogada"] = null;
            return View("LoginEmpresa");
        }

        [HttpGet]
        public ActionResult Graficos(int id)
        {
            //var alunos =  new AlunoDAO().ListaAlunos().Where(a => a.IdEscola == id).ToList();
            var passeios = new PasseioDAO().ListaPasseios().Where(p => p.IdEmpresa == id).ToList();
            var passeiosAlunos = new PasseioAlunoDAO().ListarTodosPasseios().Where(pa => passeios.Where(p=> p.IdPasseio == pa.IdPasseio).Count() > 0).ToList();
            var autorizacoes = new AutorizacaoDAO().ListaTodasAutorizacao().Where(au => passeiosAlunos.Where(pa => pa.IdAutorizacao == au.IdAutorizacao).Count() > 0).ToList();
            var alunos = new AlunoDAO().ListaAlunos().Where(a => autorizacoes.Where(au => au.IdAluno == a.IdAluno).Count() > 0).ToList();

            var masculino = Math.Round(((double)alunos.Where(a => a.Genero == "Masculino").Count() / alunos.Count()) * 100, 2);
            var feminino = Math.Round(((double)alunos.Where(a => a.Genero == "Feminino").Count() / alunos.Count()) * 100, 2);
            var indefinido = Math.Round(((double)alunos.Where(a => a.Genero == "Indefinido").Count() / alunos.Count()) * 100, 2);

            var generoChart = new List<ChartData> { new ChartData { y = masculino, label = "Masculino" },
                new ChartData { y= feminino, label="Feminino"}, new ChartData{ y=indefinido, label= "Indefinido"} };
            var testes = new TesteDAO().ListaTestes();
            var testesfiltrados = testes.Where(t => alunos.Where(a => a.IdAluno == t.IdAluno).Count() > 0).ToList();


            ////var nresponderam = Math.Round((double)(new TesteDAO().ListaTestes().Where(t => alunos.Where(a => a.IdAluno == t.IdAluno) is null).Count() / alunos.Count()) *100, 2);
            //var responderam = Math.Round(((double)testesfiltrados.Count() / alunos.Count()) * 100, 2);
            //var nresponderam = 100 - responderam;

            //var testeChart = new List<ChartData> { new ChartData { y = nresponderam, label = "Não responderam" }, new ChartData { y = responderam, label = "Respoderam" } };

            var categorias = new MyDatabaseContext().Categoria.ToList();
            var resultados = new MyDatabaseContext().Resultado.ToList().Where(r => testesfiltrados.Where(t => t.IdResultado == r.IdResposta).Count() > 0);
            var barChart = new List<ChartData>();
            var bar1 = new ChartData();
            var bar2 = new ChartData();
            var bar3 = new ChartData();
            var bar4 = new ChartData();
            var bar5 = new ChartData();
            var bar6 = new ChartData();
            foreach (var r in resultados)
            {
                var i = 1;
                foreach (var c in categorias)
                {

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

            ViewBag.GeneroEmpresa = JsonConvert.SerializeObject(generoChart);
            ViewBag.BarEmpresa = JsonConvert.SerializeObject(barChart);
            //ViewBag.DataPoints = JsonConvert.SerializeObject(listaPasseio);
            return View();
        }
    }
}
