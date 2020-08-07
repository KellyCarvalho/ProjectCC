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
        public IActionResult Index( OS os)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(OS oS)
        {  
       
            
       

            
            oS.Cliente=database.clientes.First(clientes=>clientes.ID==oS.idcliente);
            oS.Servico=database.servicos.First(servicos=>servicos.ID==oS.idServico);

                oS.Observacoes = oS.Observacoes;
                database.Add(oS);
                database.SaveChanges();
                return RedirectToAction("OS", "Gestao");




           

        }

        [HttpPost]
        public IActionResult Atualizar(OS oS){
            
   


            var os =database.os.First(oSs=>oSs.ID==oS.ID);

            os.Cliente=database.clientes.First(cli=> cli.ID==oS.idcliente);
            os.Servico=database.servicos.First(ser=>ser.ID==oS.idServico);
            os.idcliente=oS.idcliente;
            os.idServico=oS.idServico;
            os.Observacoes=oS.Observacoes;
   

            
                database.SaveChanges();
                return RedirectToAction("OS", "Gestao");
        
        
        }
        [HttpPost]
        public IActionResult GerarOrdemServico(OS oS)
        {


            oS.Cliente = database.clientes.First(clientes => clientes.ID == oS.idcliente);
            oS.Servico = database.servicos.First(servicos => servicos.ID == oS.idServico);

            oS.Observacoes = oS.Observacoes;
 
            database.SaveChanges();
            return RedirectToAction("OS", "Gestao");

        }

        public IActionResult Deletar(int id)
        {
          if(id > 0){

   var removeros =database.os.SingleOrDefault(os=>os.ID==id);
                   database.os.Remove(removeros);
                   database.SaveChanges();
               
            }
              
            return RedirectToAction("OS", "Gestao");


        }

      
            

      

        }
    }