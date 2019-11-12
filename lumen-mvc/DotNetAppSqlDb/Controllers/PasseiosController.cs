using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;

namespace DotNetAppSqlDb.Controllers
{
    public class PasseiosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        public ActionResult Passeios()
        {

            return View(db.Passeio.ToList());

        }

        public ActionResult CadastrarPasseio()
        {

            return View(new Passeio());
        }

        [HttpPost]
        public ActionResult CadastrarPasseio(Passeio passeio)
        {

            if (ModelState.IsValid)
            {
                PasseioDAO dao = new PasseioDAO();
                dao.Inserir(passeio);
                return View();
            }

            return View();

        }
    }
}
