using System;
using projetos.Models;
using Microsoft.AspNetCore.Mvc;

namespace projetos.Models{
    public class Cliente{
     public int ID { get; set; }
        public int CPF { get; set; }
        public string Nome { get; set; }
        public string Telefone{get;set;}
        public string Cidade{get;set;}
        public string Bairro{get;set;}
        public string Observacoes{get;set;}
    }
}