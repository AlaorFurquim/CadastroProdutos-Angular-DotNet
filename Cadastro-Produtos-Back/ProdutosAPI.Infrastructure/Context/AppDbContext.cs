using Microsoft.EntityFrameworkCore;
using ProdutosAPI.Domain.Entities;

namespace ProdutosAPI.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
