
using prueba4.Controllers;
using prueba4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prueba4.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {
        private Dk_user oUsuario;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                oUsuario = (Dk_user)HttpContext.Current.Session["User"];
                if (oUsuario == null)
                {

                    if (filterContext.Controller is AccountController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Account/SignIn");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("~/Account/SignIn");
            }

        }
    }

}