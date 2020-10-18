using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAspNet.Library.Mail;
using ProjectAspNet.Models;

namespace ProjectAspNet.Controllers
{
    public class ContatoController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Contato = new Contato();
            return View();
        }

        public IActionResult ReceberContato([FromForm]Contato contato)
        {
            if (ModelState.IsValid)
            {
                //string conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3} ", contato.Name, contato.Email, contato.Assunto, contato.Msg);
                //return new ContentResult() { Content = conteudo };

                ViewBag.Contato = new Contato();
                EnviarEmail.EnviarMsgContato(contato);
                ViewBag.msg = "Mensagem enviada com sucesso!";
                return View("index");
                
            } else
            {
                ViewBag.Contato = contato;
                return View("index");
            }


        }

        /* Obter dados manualmente
         * 
         * 
        public IActionResult ReceberContato()
        {
            Contato contato = new Contato();

            // POST - Request.Form
            // Get - Request.Query/ QueryString
           
            contato.Name = Request.Form["name"];
            contato.Email = Request.Form["email"];
            contato.Assunto = Request.Form["assunto"];
            contato.Msg = Request.Form["msg"];

            string conteudo = string.Format("Nome: {0}, E-mail: {1}, Assunto: {2}, Mensagem: {3} ", contato.Name, contato.Email, contato.Assunto, contato.Msg);
                
           
            return new ContentResult() { Content = conteudo};
        }
        */
    }
}
