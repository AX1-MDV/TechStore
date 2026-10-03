using TechStore.Models;

namespace TechStore.Services.Interfaces
{
    public interface ICategoriaService
    {
        /// <summary>Obtiene todas las categorías ordenadas por nombre (útil para los dropdowns).</summary>
        Task<IEnumerable<Categoria>> ObtenerTodasAsync();

        /// <summary>Obtiene todas las categorías con sus productos.</summary>
        Task<IEnumerable<Categoria>> ObtenerConProductosAsync();

        Task<Categoria?> ObtenerPorIdAsync(int id);
    }
}
