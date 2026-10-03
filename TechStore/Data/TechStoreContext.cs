using Microsoft.EntityFrameworkCore;
using TechStore.Models;

namespace TechStore.Data
{
    public class TechStoreContext : DbContext
    {
        public TechStoreContext(DbContextOptions<TechStoreContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación uno a muchos: una categoría tiene varios productos
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { ID = 1, Nombre = "Celulares", Descripcion = "Smartphones de última generación." },
                new Categoria { ID = 2, Nombre = "Tarjetas de video", Descripcion = "GPUs para gaming y trabajo profesional." },
                new Categoria { ID = 3, Nombre = "Consolas", Descripcion = "Consolas de videojuegos de sobremesa y portátiles." },
                new Categoria { ID = 4, Nombre = "Audio", Descripcion = "Auriculares, parlantes y accesorios de sonido." },
                new Categoria { ID = 5, Nombre = "Notebooks", Descripcion = "Laptops para estudio, trabajo y gaming." },
                new Categoria { ID = 6, Nombre = "Tablets", Descripcion = "Tablets para productividad y entretenimiento." }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { ID = 1, Nombre = "IPhone 16", Descripcion = "Diseño revolucionario en aluminio de grado aeroespacial, impulsado por el nuevo chip A18 para un rendimiento ultrarrápido y máxima eficiencia.", ImagenUrl = "/images/iphone_16.jpg", CategoriaId = 1, Precio = 1250m, Estado = "Disponible", Stock = 10 },
                new Producto { ID = 2, Nombre = "Asus Prime RTX 5080", Descripcion = "Lleva tu experiencia visual al extremo. Diseñada bajo la avanzada arquitectura NVIDIA Blackwell y respaldada por 16 GB de memoria ultra rápida GDDR7.", ImagenUrl = "/images/asus_prime_rtx_5080.jpg", CategoriaId = 2, Precio = 1500m, Estado = "Disponible", Stock = 16 },
                new Producto { ID = 3, Nombre = "Steam Deck OLED", Descripcion = "Consola portátil de videojuegos con pantalla OLED de colores vibrantes, negros puros y una batería de mayor duración.", ImagenUrl = "/images/steam_deck.jpg", CategoriaId = 3, Precio = 980.65m, Estado = "Disponible", Stock = 4 },
                new Producto { ID = 4, Nombre = "Sony WH-1000XM6", Descripcion = "Auriculares inalámbricos de gama alta con la cancelación de ruido activa líder de la industria y un perfil de sonido de alta definición.", ImagenUrl = "/images/sony_wh1000xm6.jpg", CategoriaId = 4, Precio = 340m, Estado = "Disponible", Stock = 8 },
                new Producto { ID = 5, Nombre = "MacBook Pro 16\"", Descripcion = "La laptop más potente de Apple, con el chip M3 Pro y una pantalla Retina de 16 pulgadas.", ImagenUrl = "/images/macbookpro.jpg", CategoriaId = 5, Precio = 2499m, Estado = "Disponible", Stock = 6 },
                new Producto { ID = 6, Nombre = "iPad Air", Descripcion = "La tablet más rápida de Apple, con el chip M1 y una pantalla Liquid Retina de 10.9 pulgadas.", ImagenUrl = "/images/airpadair.jpg", CategoriaId = 6, Precio = 599m, Estado = "Disponible", Stock = 12 }
            );
        }
    }
}
