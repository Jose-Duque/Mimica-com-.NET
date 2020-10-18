using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectAspNet.Library.Filters
{
    public class LoginAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // 1º Verificar se tem Session
            if(context.HttpContext.Session.GetString("Login") == null)
            {
                if(context.Controller != null)
                {
                    Controller controlador = context.Controller as Controller;
                    controlador.TempData["mensagenError"] = "Faça o login para ter permissão";
                }

                // Redirecionar
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
        }
    }
}
