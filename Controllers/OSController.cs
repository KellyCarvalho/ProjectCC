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
        [HttpPost]
        public IActionResult Salvar(OS oS)
        {
            string clienteid = database.clientes.First(c =>c.ID==oS.idcliente).ToString();
            string servicoid= database.servicos.First(s=>s.ID==oS.idServico).ToString();

            int sid;
           
            int.TryParse(clienteid, out sid);
        /*    oS.cliente.ID=clienteid;*/
         
            /*Conversões*/
          
          /*
                oS.idcliente= Convert.ToInt32(database.clientes.First(c =>c.ID==oS.idcliente));
                oS.idServico= Convert.ToInt32(database.servicos.First(s=>s.ID==oS.idServico));*/

        /*  oS.servico.ID=Convert.ToInt32(database.servicos.First(ser=>ser.ID==oS.servico.ID));*/
             /*   oS.servico.Nome=database.servicos.First(ser=>ser.Nome==oS.servico.Nome);     

                oS.servico.Preco=Convert.ToSingle(database.servicos.First(ser=>ser.Preco==oS.servico.Preco));


                oS.cliente.ID=Convert.ToInt32(database.clientes.First(cli=>cli.ID==oS.cliente.ID));
                 oS.cliente.CPF= Convert.ToInt32(database.clientes.First(cli=>cli.CPF==oS.cliente.CPF));
                oS.cliente.Nome=database.clientes.First(cli=>cli.Nome==oS.cliente.Nome).ToString();
                oS.cliente.Telefone=database.clientes.First(cli=> cli.Telefone==oS.cliente.Telefone).ToString();
                oS.cliente.Bairro=database.clientes.First(cli=>cli.Bairro==oS.cliente.Bairro).ToString();
                oS.cliente.Cidade=database.clientes.First(cli=>cli.Cidade==oS.cliente.Cidade).ToString();*/
               
                oS.Observacoes = oS.Observacoes;
                database.Add(oS);
                database.SaveChanges();
                return RedirectToAction("OS", "Gestao");




           

        }
/*
        [HttpPost]
        public IActionResult Atualizar(OS oS){

             var os = database.os.First(os => os.ID == oS.ID);
                oS.cliente = database.clientes.First(cliente => cliente.ID == oS.cliente.ID);
                oS.servico = database.servicos.First(servico => servico.ID == oS.servico.ID);
                oS.idcliente = oS.cliente.ID;
                oS.idServico = oS.servico.ID;
                oS.Observacoes = oS.Observacoes;
                database.Add(oS);

            
                database.SaveChanges();
                return RedirectToAction("OS", "Gestao");
        
        
        }*/
    }
}