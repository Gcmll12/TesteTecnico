using ApiProcessos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ApiProcessos.Data
{
    public class ApiProcessosDbContext: IdentityDbContext
    {
        public ApiProcessosDbContext(DbContextOptions<ApiProcessosDbContext> options) : base(options)
        { 
            
        
        }
        public DbSet<Processo> Processo { get; set; }
        public DbSet<Movimentacoes> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
