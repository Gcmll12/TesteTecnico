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
    public DbSet<Movimentacoes> Movimentacoes { get; set; }

}
}
