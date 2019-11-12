using DotNetAppSqlDb.DAO;
using DotNetAppSqlDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Business;
namespace DotNetAppSqlDb.Controllers
{
    public class AdminController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        [HttpGet]
        public ActionResult Index()
        {

            HttpCookie cookie = Request.Cookies["UsuarioLumen"];

            if (cookie != null)
            {
                string Email = cookie["Email"].ToString();
                string Senha = cookie["Senha"].ToString();

                var vUsuario = db.Usuario.Include("Escola").Include("Empresa").Where(p => p.Email.Equals(Email)).FirstOrDefault();

                if (vUsuario != null)
                {
                    if (vUsuario.Senha == Senha)
                    {

                        Session["UsuarioLogado"] = vUsuario;
                        var tipo = vUsuario.Escola is null ? "empresa" : "escola";
                        Session["UsuarioLogadoTipo"] = tipo;
                        cookie.Expires = DateTime.Now.AddDays(360);
                        Response.AppendCookie(cookie);
                        if (tipo == "escola")
                        {
                            return View("AdminEscola");
                        }
                        else
                        {
                            if (tipo == "empresa")
                            {
                                return View("AdminEmpresa");
                            }
                            else
                            {
                                return View("Login");

                            }
                        }

                    }
                    else
                    {
                        return View("Login");
                    }

                }
                else
                {
                    return View("Login");
                }


            }
            else {
                return View("Login");
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        public ActionResult Login(Usuario UsuarioLogin)
        {

            if (UsuarioLogin != null)
            {

                var vUsuario = db.Usuario.Include("Escola").Include("Empresa").Where(p => p.Email.Equals(UsuarioLogin.Email)).FirstOrDefault();

                if (UsuarioLogin != null)
                {
                    if (CriptografiaSenha.Compara(UsuarioLogin.Senha, vUsuario.Senha))
                    {
                        // Adicionando o usuário na Sessão
                        Session["UsuarioLogado"] = vUsuario;
                        var tipo = vUsuario.Escola is null ? "empresa" : "escola";
                        Session["UsuarioLogadoTipo"] = tipo;

                        HttpCookie cookie = new HttpCookie("UsuarioLumen");

                        cookie.Values.Add("Email", UsuarioLogin.Email);
                        cookie.Values.Add("Senha", vUsuario.Senha);
                        cookie.Expires = DateTime.Now.AddDays(360);
                        Response.SetCookie(cookie);
                        if (tipo == "escola") {
                            return View("AdminEscola");
                        }
                        if (tipo == "empresa")
                        {
                            return View("AdminEmpresa");
                        }

                        return View();
                    }
                    else {
                        return View("Login", UsuarioLogin);
                    }

                }
                else
                {
                    TempData["Mensagem"] = "Usuário ou Senha inválida.";
                    return View("Login", UsuarioLogin);
                }
            }

            // Falha no Login
            else
            {
                TempData["Mensagem"] = "Usuário ou Senha inválida.";
                return View("Login", UsuarioLogin);
            }
            //UsuarioLogin.Escola = new Escola();
            //UsuarioLogin.Escola.Nome = "Escola da bia";
            //Session["UsuarioLogado"] = UsuarioLogin;

            //HttpCookie cookie = new HttpCookie("UsuarioLumen");
            //cookie.Values.Add("Email", "oi");
            //cookie.Values.Add("Senha", "aaaa");

            //Session["UsuarioLogadoTipo"] =  "escola";
            //cookie.Expires = DateTime.Now.AddDays(360);
            //Response.SetCookie(cookie);
            //return View("Index");


            //    UsuarioLogin = dao.Login(UsuarioLogin.EmailUsuario, UsuarioLogin.SenhaUsuario);

            //    if (UsuarioLogin != null)
            //    {
            //        // Adicionando o usuário na Sessão
            //        Session["UsuarioLogado"] = UsuarioLogin;

            //        HttpCookie cookie = new HttpCookie("UsuarioProjetoWeb");
            //        cookie.Values.Add("Email", UsuarioLogin.EmailUsuario);
            //        cookie.Values.Add("Senha", UsuarioLogin.SenhaUsuario);
            //        cookie.Expires = DateTime.Now.AddDays(360);
            //        Response.SetCookie(cookie);

            //        return View();

            //    }
            //    else
            //    {
            //        TempData["Mensagem"] = "Usuário ou Senha inválida.";
            //        return View("Index", UsuarioLogin);
            //    }
            //}

            //// Falha no Login
            //else
            //{
            //    TempData["Mensagem"] = "Usuário ou Senha inválida.";
            //    return View("Index", UsuarioLogin);
            //}

        }


        [HttpGet]
        public ActionResult LogOff()
        {
            Session.Clear();

            HttpCookie cookie = Request.Cookies["UsuarioLumen"];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.AppendCookie(cookie);

            return RedirectToAction("Index", "Home");
        }
    }



}