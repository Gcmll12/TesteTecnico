using GestorProcessosApi.Shared.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore; 


namespace ApiMovimentacoesProcessos.Data
    
{
    public class ApiMovimentacoesDbContext : DbContext 
    {
    public ApiMovimentacoesDbContext(DbContextOptions<ApiMovimentacoesDbContext> options) : base(options)
    {

    }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento entre Movimentacoes e Processos
            modelBuilder.Entity<Movimentacoes>()
                .HasOne(m => m.Processo)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(m => m.NumeroProcesso)
                .HasPrincipalKey(p => p.NumeroProcesso);
        }*/
        public DbSet<Movimentacoes> Movimentacoes { get; set; }

       

    }
}
