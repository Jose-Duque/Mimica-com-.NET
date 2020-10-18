using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectAspNet.Database;
using ProjectAspNet.Library.Filters;
using ProjectAspNet.Models;
using X.PagedList;

namespace ProjectAspNet.Controllers
{
    [Login]
    public class PalavraController : Controller
    {
        List<Nivel> niveis = new List<Nivel>(); // Esse aqui é um construtor
        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;

          
            niveis.Add(new Nivel() { Id = 1, Name = "Fácil" });
            niveis.Add(new Nivel() { Id = 2, Name = "Médio" });
            niveis.Add(new Nivel() { Id = 3, Name = "Difícil" });
        }

        // Listar todas as palavras do banco de dados
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var palavras = _db.Palavras.ToList();
            var resultPage = palavras.ToPagedList(pageNumber, 5);

            return View(resultPage);
        }

        // CRUD - Cadastrar, Consultar, Atualizar, Deletar
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Nivel = niveis;
            return View(new Palavra());
        }

        [HttpPost]
        public IActionResult Create([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;

            if (ModelState.IsValid)
            {
                _db.Palavras.Add(palavra); // Adiciona a palavra
                _db.SaveChanges(); // Salva a palavra

                TempData["Mensagem"] = "A palavra '" + palavra.Name + "' foi cadastrada com sucesso!";

                return RedirectToAction("Index");
            }
            return View(palavra);
        }

        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.Nivel = niveis;

            Palavra palavra = _db.Palavras.Find(Id);
            return View("Create", palavra);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;

            if (ModelState.IsValid)
            {
                _db.Palavras.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Name + "' foi atualizada com sucesso!";


                return RedirectToAction("Index");
            }
            return View("Create", palavra);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Palavra palavra = _db.Palavras.Find(Id);
            _db.Palavras.Remove(palavra);
            _db.SaveChanges();

            TempData["Mensagem"] = "A palavra '" + palavra.Name + "' foi excluida com sucesso!";


            return RedirectToAction("Index");
        }

    }
}
