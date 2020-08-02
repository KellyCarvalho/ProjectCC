using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projetos.Data;
using projetos.Models;

namespace SystemCC.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ApplicationDbContext database;

        public ClienteController(ApplicationDbContext database)
        {
            this.database = database;
        }
        [HttpPost]
        public IActionResult Salvar(Cliente cliente)
        {
         cliente.Nome = cliente.Nome;
            cliente.CPF = cliente.CPF;
            cliente.Bairro = cliente.Bairro;
            cliente.Cidade = cliente.Cidade;
            cliente.Telefone = cliente.Telefone;
            cliente.Observacoes = cliente.Observacoes;
            database.Add(cliente);
      
            database.SaveChanges();
            return RedirectToAction("Cliente","Gestao");
 
             
        }

        public IActionResult Index(Cliente cliente)
        {

            return View();


        }

        [HttpPost]
        public IActionResult Clientes(int id){
        

        return Json(id);
        }

        public IActionResult Deletar(int id)
        {
          if(id > 0){

   var removercliente =database.clientes.SingleOrDefault(os=>os.ID==id);
                   database.clientes.Remove(removercliente);
                   database.SaveChanges();
               
            }
              
            return RedirectToAction("Cliente", "Gestao");


       
        }


        [HttpPost]
        public IActionResult Atualizar(Cliente cliente)
        {

            cliente.ID = cliente.ID;
            cliente.Nome = cliente.Nome;
            cliente.CPF = cliente.CPF;
            cliente.Telefone = cliente.Telefone;
            cliente.Bairro = cliente.Bairro;
            cliente.Cidade = cliente.Cidade;
            cliente.Observacoes = cliente.Observacoes;


       


            database.SaveChanges();
            return RedirectToAction("OS", "Gestao");


        }

    }
}