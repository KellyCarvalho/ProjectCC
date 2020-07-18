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
    {
        private readonly ApplicationDbContext database;

        public OSController(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Salvar(OS oS)
        {
            if (oS == null)
            {
                oS.cliente = database.clientes.First(cliente => cliente.ID == oS.cliente.ID);
                oS.servico = database.servicos.First(servico => servico.ID == oS.servico.ID);
                oS.idcliente = oS.cliente.ID;
                oS.idServico = oS.servico.ID;
                oS.Observacoes = oS.Observacoes;
                database.Add(oS);
                database.SaveChanges();
                return RedirectToAction("OS", "Gestao");

            }
            else
            {

                ViewBag.clientes = database.clientes.ToList();
                ViewBag.servicos = database.servicos.ToList();
                return View("../Gestao/NovaOS");
            }

           

        }
    }
}