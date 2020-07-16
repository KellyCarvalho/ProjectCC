using System;
using projetos.Models;
namespace projetos.Models
{
    public class OS
    {
        public int ID { get; set; }
       public Cliente cliente { get; set; }
        public Servico servico { get; set; }
        public string Observacoes { get; set; }

    }
}