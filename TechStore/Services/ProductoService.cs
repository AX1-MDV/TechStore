using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Services.Interfaces;

namespace TechStore.Services
{
    public class ProductoService : IProductoService
    {
        private readonly TechStoreContext _context;

        public ProductoService(TechStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<Producto?> ObtenerPorIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task AgregarAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EditarAsync(Producto producto)
        {
            var existente = await _context.Productos.FindAsync(producto.ID);
            if (existente == null) return false;

            existente.Nombre = producto.Nombre;
            existente.Descripcion = producto.Descripcion;
            existente.ImagenUrl = producto.ImagenUrl;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.Estado = producto.Estado;
            existente.CategoriaId = producto.CategoriaId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
