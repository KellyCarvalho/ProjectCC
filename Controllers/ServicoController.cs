using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;

namespace SystemCC.Controllers
{
    public class ServicoController : Controller
    {
     

        private readonly ApplicationDbContext database;

        public ServicoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Salvar(Servico servico)
        {
            servico.Nome = servico.Nome;
            string preco="";
            preco = servico.Preco.ToString();

            servico.Preco = float.Parse(preco);
            database.Add(servico);

            database.SaveChanges();
            return RedirectToAction("Servico", "Gestao");


        }

        [HttpPost]
        public IActionResult Atualizar(Servico servico)
        {




            var serv = database.servicos.First(ser => ser.ID == servico.ID);
            serv.Nome = servico.Nome;
            string preco = "";
            preco = servico.Preco.ToString();

            serv.Preco = float.Parse(preco);
        
        


            database.SaveChanges();
            return RedirectToAction("Servico", "Gestao");


        }

        public IActionResult ErrorMensage()
        {
            return View();
        }
        public IActionResult Deletar(int id)
        {

            try
            {
                var verificarservico = database.os.Where(os => os.idServico == id);
                var removerservico = database.servicos.SingleOrDefault(ser => ser.ID == id);

                
                if (id > 0)
                {
                 


                  
                        database.servicos.Remove(removerservico);
                        database.SaveChanges();
                        return RedirectToAction("Servico", "Gestao");




                    }



            }
            catch (Exception e)
            {
                return RedirectToAction("ErrorMensage", "Gestao");

            }
            return RedirectToAction("Servico", "Gestao");

        }
                }
}