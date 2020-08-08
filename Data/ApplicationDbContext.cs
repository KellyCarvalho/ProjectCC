using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetos.Models;
using SystemCC.Models;

namespace projetos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Servico> servicos { get; set; }
        public DbSet<OS> os { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SystemCC.Models.Error> Error { get; set; }
    }
}
