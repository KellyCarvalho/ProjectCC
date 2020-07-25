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

      public IActionResult EditarOs(int id){
             ViewBag.clientes = database.clientes.ToList();
            ViewBag.servicos =database.servicos.ToList();


          var oS=database.os.First(oSs=>oSs.ID==id);           
            OS oss = new OS();

            oss.Cliente=oS.Cliente;
            oss.Servico=oS.Servico;
            oss.Observacoes=oS.Observacoes;
           
            return View(oS);
                

        }

       


    }
}
