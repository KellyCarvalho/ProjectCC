using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;
using Microsoft.EntityFrameworkCore;
using projetos.Models;
using Microsoft.AspNetCore.Mvc;

using projetos.Data;
using System.Linq;

namespace SystemCC.Controllers
{
    public class GerarOrdemServico : Controller
    {
        private readonly ApplicationDbContext database;

        public GerarOrdemServico(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }



        public ActionResult GerarOS(int id)
        {
            OS os = new OS();
            ViewBag.cliente = database.clientes.Where(cli => cli.ID == id);
            ViewBag.servicos = database.servicos.ToList();

            os.Cliente = database.clientes.First(cli => cli.ID == id);
            os.Servico = database.servicos.ToList();
            os.Observacoes = os.Observacoes;
     
        return View("OS", "Gestao");


        }


    }
}