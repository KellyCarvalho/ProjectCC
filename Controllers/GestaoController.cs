using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetos.Models;

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
         
            var os = database.os.Include(cli=>cli.Cliente).Include(Ser=>Ser.Servico).ToList();
            return View(os);
        }

        public IActionResult NovaOS()
        {

            ViewBag.clientes = database.clientes.ToList();
            ViewBag.servicos =database.servicos.ToList();
        
            return View();
        }
      /*  public IActionResult EditarOs(int id){
        
            ViewBag.clientes = database.clientes.ToList();
            ViewBag.servicos =database.servicos.ToList();
            var oss =database.os.First(os=>os.ID==id);
            OS os = new OS();
            os.idcliente=oss.idcliente;
            os.idServico=oss.idServico;
            os.servico=oss.servico;
            os.cliente=oss.cliente;
            os.Observacoes=oss.Observacoes;
            return View(os);
                

        }*/


    }
}
