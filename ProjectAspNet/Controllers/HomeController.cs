using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProjectAspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAspNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // return new ContentResult() { Content = "Testando index" };
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([FromForm] User user)
        {
            if(ModelState.IsValid)
            {
                if(user.Email == "test@gmail.com" && user.Password == "1234")
                {
                    /* 
                     Add Session
                     HttpContext.Session.SetString("Login", "true");
                     HttpContext.Session.SetInt32("UserId", 7);

                     //Ler Session
                     string login = HttpContext.Session.GetString("Login");
                    */

                    HttpContext.Session.SetString("Login", "true");
                    return RedirectToAction("Index", "Palavra");
                } else
                {
                    ViewBag.msg = "Os dados informado está inválido!";

                   
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}

