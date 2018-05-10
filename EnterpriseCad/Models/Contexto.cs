using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnterpriseCad.Models;

namespace EnterpriseCad.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<EnterpriseCad.Models.Contato> Contato { get; set; }

        public DbSet<EnterpriseCad.Models.ContatoViewModel> ContatoViewModel { get; set; }
    }
}
