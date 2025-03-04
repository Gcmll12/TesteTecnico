using GestorProcessosApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorProcessos.Data
{
    public class ApiProcessoDbContext : DbContext
    {
        public ApiProcessoDbContext(DbContextOptions<ApiProcessoDbContext> options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do índice único para NumeroProcesso
            modelBuilder.Entity<Processos>()
                .HasIndex(p => p.NumeroProcesso)
                .IsUnique();

           
        }


        public DbSet<Processos> Processos { get; set; }
      
    }
}

