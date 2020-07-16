using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;

namespace SystemCC.Controllers
{
    public class ServicoController : Controller
    {
     

        private readonly ApplicationDbContext database;

        public ServicoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(Servico servico)
        {
            servico.Nome = servico.Nome;
            string preco="";
            preco = servico.Preco.ToString();

            servico.Preco = float.Parse(preco);
            database.Add(servico);

            database.SaveChanges();
            return RedirectToAction("Servico", "Gestao");


        }
        public IActionResult Index(Servico servico)
        {

            return View();


        }
    }
}