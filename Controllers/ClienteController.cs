using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;

namespace SystemCC.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ApplicationDbContext database;

        public ClienteController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpPost]
        public IActionResult Salvar(Cliente cliente)
        {
         cliente.Nome = cliente.Nome;
            cliente.CPF = cliente.CPF;
            cliente.Bairro = cliente.Bairro;
            cliente.Cidade = cliente.Cidade;
            cliente.Telefone = cliente.Telefone;
            cliente.Observacoes = cliente.Observacoes;
            database.Add(cliente);
      
            database.SaveChanges();
            return RedirectToAction("Cliente","Gestao");
 
             
        }

        public IActionResult Index(Cliente cliente)
        {

            return View();


        }
    }
}