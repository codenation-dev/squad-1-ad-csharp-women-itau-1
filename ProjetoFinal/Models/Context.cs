using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinal.Models
{
    public class Context : DbContext
    {
       public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<Nivel> Niveis { get; set; }
        public DbSet<Erro> Erros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=tcp:centraldeerros-squad1dbserver.database.windows.net,1433;Initial Catalog=ProjetoFinalBD;Persist Security Info=False;User ID=administradorah;Password=senhabd123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
