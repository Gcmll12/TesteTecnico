using GestorProcessos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestorProcessos.Data
{
    public class ApiProcessoDbContext : DbContext
    {
        public ApiProcessoDbContext(DbContextOptions<ApiProcessoDbContext> options) : base (options)
        {
            
        }
        public DbSet<Processos> Processos { get; set; }
    }
}
