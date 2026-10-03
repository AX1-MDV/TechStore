using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Models;
using TechStore.Services.Interfaces;

namespace TechStore.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly TechStoreContext _context;

        public CategoriaService(TechStoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> ObtenerTodasAsync()
        {
            return await _context.Categorias
                .AsNoTracking()
                .OrderBy(c => c.Nombre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObtenerConProductosAsync()
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .AsNoTracking()
                .OrderBy(c => c.Nombre)
                .ToListAsync();
        }

        public async Task<Categoria?> ObtenerPorIdAsync(int id)
        {
            return await _context.Categorias
                .Include(c => c.Productos)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ID == id);
        }
    }
}
