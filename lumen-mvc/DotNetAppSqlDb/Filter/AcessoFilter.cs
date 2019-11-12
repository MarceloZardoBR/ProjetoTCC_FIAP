using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetAppSqlDb.Filter
{
    public class AcessoFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["AlunoLogado"] == null)
            {

                filterContext.Controller.TempData.Add("MensagemData", "Sessão Expirada! Efetue o login novamente.");

                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Aluno");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);

            }

            base.OnActionExecuting(filterContext);

        }

    }
}