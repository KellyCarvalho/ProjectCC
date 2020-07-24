using System;
using projetos.Models;
namespace projetos.Models
{
    public class OS
    {
        public int ID { get; set; }
       public Cliente Cliente { get; set; }
        public Servico Servico { get; set; }
        public int idServico { get; set; }
        public int idcliente { get; set; }
        public string Observacoes { get; set; }

    }
}