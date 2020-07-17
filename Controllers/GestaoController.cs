using System;
using projetos.Models;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using System.Linq;

namespace projetos.Controllers{
    public class GestaoController:Controller

    {
        private readonly ApplicationDbContext database;

        public GestaoController(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cliente()
        {
         
            var clientes = database.clientes.ToList();
          
            return View(clientes);
        }
      
        public IActionResult NovoCliente()
        {
            return View();
        }
        public IActionResult Servico()
        {
            var servico = database.servicos.ToList();
            return View(servico);
        }

        public IActionResult NovoServico()
        {
            return View();
        }

        public IActionResult OS()
        {
            var os = database.os.ToList();
            return View(os);
        }

        public IActionResult NovaOS()
        {
            ViewBag.clientes= database.clientes.ToList();
            ViewBag.servicos = database.servicos.ToList();
            return View();
        }



    }
}
