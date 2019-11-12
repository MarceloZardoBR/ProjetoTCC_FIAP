using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Business;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.Controllers
{

    public class HomeController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Empresa.ToList());
        }

        public ActionResult CadastroEmpresa()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CadastroEmpresa(Empresa empresa, Endereco endereco,Area area)
        {

            if (ModelState.IsValid)
            {
                EnderecoBusiness business = new EnderecoBusiness();
                AreaBusiness areaBusiness = new AreaBusiness();
                empresa.Senha = CriptografiaSenha.Codifica(empresa.Senha);
                endereco = business.InserirEndereco(endereco);
                area = areaBusiness.InserirArea(area);
                empresa.IdEndereco = endereco.IdEndereco;
                empresa.IdArea = area.IdArea;
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return View();
            }

            return View(new Empresa());

        }


        public ActionResult CadastroEscola()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CadastroEscola(Escola escola, Endereco endereco)
        {


            if (ModelState.IsValid)
            {
                EnderecoBusiness business = new EnderecoBusiness();
                escola.Senha = CriptografiaSenha.Codifica(escola.Senha);
                endereco = business.InserirEndereco(endereco);
                escola.IdEndereco = endereco.IdEndereco;
                db.Escola.Add(escola);
                db.SaveChanges();

                return View();

            }

            return View();
        }

        public ActionResult CadastroEscolha()
        {

            return View();

        }

        public ActionResult LoginEscolha()
        {

            return View();

        }

        public ActionResult Contato() {

            return View();
        }
        public ActionResult ContatoSucesso() {

            return View();
        }


    }
}