using System;
using System.Collections.Generic;
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
        public IActionResult Deletar(int id)
        {
            if (id > 0)
            {
                var verificarservico = database.os.Where(os => os.idServico == id);

                if (verificarservico!=null)
                {
                    return View("Error","Gestao");

                }
                else{

                    var removerservico = database.servicos.SingleOrDefault(ser => ser.ID == id);
                    database.servicos.Remove(removerservico);
                    database.SaveChanges();

                }
            

            }

            return RedirectToAction("Servico", "Gestao");


        }
    }
}