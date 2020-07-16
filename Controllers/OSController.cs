using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;


namespace SystemCC.Controllers
{
    public class OSController : Controller
    { private readonly ApplicationDbContext database;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salvar(OS oS)
        {
           
            oS.cliente = database.clientes.First(cliente => cliente.ID == oS.cliente.ID);
            oS.servico = database.servicos.First(servico => servico.ID == oS.servico.ID);
            oS.Observacoes = oS.Observacoes;
            database.Add(oS);
            database.SaveChanges();
            return RedirectToAction("Servico", "Gestao");

        }
    }
}