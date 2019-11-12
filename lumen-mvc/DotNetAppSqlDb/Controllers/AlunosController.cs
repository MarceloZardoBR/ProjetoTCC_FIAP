using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CsvHelper;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using DotNetAppSqlDb.Business;

namespace DotNetAppSqlDb.Controllers
{
    public class AlunosController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Alunoes
        public ActionResult Index()
        {
             var escolaLog = (Escola)Session["EscolaLogada"];
             ViewData["SenhaPadrao"] = Base64Business.Base64Encode(escolaLog.IdEscola.ToString());
             return View(db.Escola.Include("Alunos").SingleOrDefault(e => e.IdEscola == escolaLog.IdEscola).Alunos);
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            var escolaLog = (Escola)Session["EscolaLogada"];

            List<Aluno> alunos = new List<Aluno>();
            using (var reader = new StreamReader(postedFile.InputStream))
            using (var csvReader = new CsvReader(reader))
            {
                //Use While(csvReader.Read()); if you want to read all the rows in the records)
                List<Aluno> alunosCSV = new List<Aluno>();

                alunosCSV = csvReader.GetRecords<Aluno>().ToList();

                var alunosCsvTrimmed = alunosCSV.Where(t => t.NomeCompleto != null && t.NomeCompleto != "").ToList();
                var escola = db.Escola.Include("Alunos")?.SingleOrDefault(e => e.IdEscola == escolaLog.IdEscola);
                var alunosNovos = alunosCsvTrimmed.Where(a => !escola.Alunos.Any(db => db.NomeCompleto != a.NomeCompleto)).ToList();
                var alunosSenhas = new List<Aluno>();
                foreach (var a in alunosNovos)
                {
                    a.IdEscola = escola.IdEscola;
                    var senha = Business.Base64Business.Base64Encode(escola.IdEscola.ToString());
                    a.Senha = Business.CriptografiaSenha.Codifica(senha);
                    a.PrimeiroAcesso = true;
                    alunosSenhas.Add(a);
                }
                escola.Alunos.AddRange(alunosSenhas);
                db.Entry(escola).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                //var escolaId = id;

                // colocar dentro de aluno/ turma/ escola
                //salvar
            }
            return View(db.Escola.Include("Alunos").SingleOrDefault(e => e.IdEscola == escolaLog.IdEscola).Alunos);
        }



        // GET: Alunoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAluno,NomeCompleto,Email,Telefone,Genero")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Aluno.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Alunoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAluno,NomeCompleto,Email,Telefone,Genero")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Alunoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Aluno.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Aluno.Find(id);
            db.Aluno.Remove(aluno);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
