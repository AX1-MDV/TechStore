using TechStore.Models;

namespace TechStore.Services.Interfaces
{
    public interface IProductoService
    {
        /// <summary>Obtiene todos los productos, incluyendo su categoría.</summary>
        Task<IEnumerable<Producto>> ObtenerTodosAsync();

        /// <summary>Obtiene un producto por su ID, incluyendo su categoría. Devuelve null si no existe.</summary>
        Task<Producto?> ObtenerPorIdAsync(int id);

        Task AgregarAsync(Producto producto);

        /// <summary>Actualiza un producto existente. Devuelve false si no existe.</summary>
        Task<bool> EditarAsync(Producto producto);

        /// <summary>Elimina un producto por su ID. Devuelve false si no existe.</summary>
        Task<bool> EliminarAsync(int id);
    }
}
