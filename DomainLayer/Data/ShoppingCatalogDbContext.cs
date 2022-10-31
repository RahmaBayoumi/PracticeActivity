using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCatalog.API.DbContexts
{
    public class ShoppingCatalogDbContext : DbContext
    {
        public ShoppingCatalogDbContext(DbContextOptions<ShoppingCatalogDbContext> options)
         : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
