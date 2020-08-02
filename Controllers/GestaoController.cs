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

        public IActionResult EditarCliente(int id)
        {
            var cli = database.clientes.First(c => c.ID == id);
            Cliente cliente = new Cliente();
            cliente.ID = cli.ID;
            cliente.Nome = cli.Nome;
            cliente.Telefone = cli.Telefone;
            cliente.Bairro = cli.Bairro;
            cliente.Cidade = cli.Cidade;
            cliente.CPF = cli.CPF;
            cliente.Observacoes = cli.Observacoes;
                return View(cliente);
        }

        public IActionResult GerarOS()
        {

            ViewBag.servicos = database.servicos.ToList();



            return View();


        }
        /*
        public IActionResult GetId(int id)
        {
            ViewBag.clientes = database.clientes.Where(c=>c.ID==id);
            ViewBag.servicos = database.servicos.ToList();

            OS os = new OS();
            os.Cliente = database.clientes.First(cli => cli.ID == id);
            os.idcliente = os.idcliente;
            os.idServico = os.idServico;
            os.Observacoes = os.Observacoes;

            return Content(os);
        }
        */





    }
}
