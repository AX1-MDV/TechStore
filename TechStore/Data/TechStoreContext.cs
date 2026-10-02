using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
